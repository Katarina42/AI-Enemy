using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy.AI
{
    public interface IPathfinder
    {
        List<Vector2Int> FindPath(Vector2Int enemyPos, Vector2Int playerPos);
    }
}