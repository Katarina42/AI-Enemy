using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy.AI
{
    public class BFSPathfinder : IPathfinder
    {
        private IGridDataProvider gridDataProvider;

        public BFSPathfinder(IGridDataProvider gridDataProvider)
        {
            this.gridDataProvider = gridDataProvider;
        }

        public List<Vector2Int> FindPath(Vector2Int start, Vector2Int goal, int movementRange)
        {
            var queue = new Queue<Vector2Int>();
            var cameFrom = new Dictionary<Vector2Int, Vector2Int>();
            var distance = new Dictionary<Vector2Int, int>();
            var gridSize = gridDataProvider.Get().Size;
            
            queue.Enqueue(start);
            cameFrom[start] = start;
            distance[start] = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                // Stop if we've reached the player
                if (current == goal)
                    break;

                foreach (var dir in Directions)
                {
                    var neighbor = current + dir;

                    if (!IsInsideGrid(neighbor, gridSize)) continue;
                    if (cameFrom.ContainsKey(neighbor)) continue;

                    int stepCount = distance[current] + 1;

                    if (stepCount > movementRange) continue;

                    queue.Enqueue(neighbor);
                    cameFrom[neighbor] = current;
                    distance[neighbor] = stepCount;
                }
            }

            // If player was unreachable, find closest position in range
            if (!cameFrom.ContainsKey(goal))
            {
                goal = FindClosestTo(goal, distance);
                if (goal == start)
                    return null; // Nowhere to go
            }

            return ReconstructPath(start, goal, cameFrom);
        }

        private Vector2Int FindClosestTo(Vector2Int target, Dictionary<Vector2Int, int> visited)
        {
            Vector2Int closest = Vector2Int.zero;
            float bestDist = float.MaxValue;

            foreach (var pos in visited.Keys)
            {
                float dist = Vector2Int.Distance(pos, target);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    closest = pos;
                }
            }

            return closest;
        }

        private List<Vector2Int> ReconstructPath(Vector2Int start, Vector2Int end, Dictionary<Vector2Int, Vector2Int> cameFrom)
        {
            var path = new List<Vector2Int>();
            var current = end;

            while (current != start)
            {
                path.Insert(0, current);
                current = cameFrom[current];
            }

            path.Insert(0, start);
            return path;
        }

        private bool IsInsideGrid(Vector2Int pos, Vector2Int gridSize)
        {
            return pos.x >= 0 && pos.y >= 0 && pos.x < gridSize.x && pos.y < gridSize.y;
        }

        private static readonly Vector2Int[] Directions =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };
    }
}
