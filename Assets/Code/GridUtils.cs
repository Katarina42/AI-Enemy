using UnityEngine;

namespace AIEnemy
{
    public static class GridUtils
    {
        public const int GRID_SIZE = 8;
        
        public static Vector3 ToWorld(Vector2Int gridPosition)
        {
            return new Vector3(gridPosition.x * GRID_SIZE, gridPosition.y * GRID_SIZE, 0);
        }
    }
}