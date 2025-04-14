using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy.AI
{
    public class AStarPathfinder : IPathfinder
    {
        private readonly IGridDataProvider gridDataProvider;

        public AStarPathfinder(IGridDataProvider gridDataProvider)
        {
            this.gridDataProvider = gridDataProvider;
        }

        public List<Vector2Int> FindPath(Vector2Int start, Vector2Int goal)
        {
            var openSet = new PriorityQueue<Vector2Int>();
            var cameFrom = new Dictionary<Vector2Int, Vector2Int>();
            var gScore = new Dictionary<Vector2Int, int> { [start] = 0 };

            openSet.Enqueue(start, Heuristic(start, goal));

            while (openSet.Count > 0)
            {
                var current = openSet.Dequeue();
                if (current == goal)
                    return ReconstructPath(cameFrom, current);
                //
                // foreach (var neighbor in grid.GetNeighbors(current))
                // {
                //     var tentativeG = gScore[current] + 1;
                //     if (gScore.ContainsKey(neighbor) && tentativeG >= gScore[neighbor]) continue;
                //     cameFrom[neighbor] = current;
                //     gScore[neighbor] = tentativeG;
                //     var fScore = tentativeG + Heuristic(neighbor, goal);
                //     openSet.Enqueue(neighbor, fScore);
                // }
            }

            return null;
        }

        private List<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current)
        {
            var path = new List<Vector2Int> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Insert(0, current);
            }
            return path;
        }

        private int Heuristic(Vector2Int a, Vector2Int b) => Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);

        private class PriorityQueue<T>
        {
            private readonly List<(T item, int priority)> elements = new();
            public int Count => elements.Count;

            public void Enqueue(T item, int priority)
            {
                elements.Add((item, priority));
                elements.Sort((a, b) => a.priority.CompareTo(b.priority));
            }

            public T Dequeue()
            {
                var item = elements[0].item;
                elements.RemoveAt(0);
                return item;
            }
        }
    }
}