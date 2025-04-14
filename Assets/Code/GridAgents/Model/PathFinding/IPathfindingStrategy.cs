using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy.AI
{
    public interface IPathfindingStrategy
    {
        List<Vector2Int> GetPathToPlayer(Vector2Int enemyPos, Vector2Int playerPos);
    }

    public class AStarPathfindingStrategy : IPathfindingStrategy
    {
        private readonly IPathfinder pathfinder;

        public AStarPathfindingStrategy(IPathfinder pathfinder)
        {
            this.pathfinder = pathfinder;
        }

        public List<Vector2Int> GetPathToPlayer(Vector2Int enemyPos, Vector2Int playerPos)
        {
            return pathfinder.FindPath(enemyPos, playerPos);
        }
    }
}