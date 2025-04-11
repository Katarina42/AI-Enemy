using UnityEngine;

namespace AIEnemy
{
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private int gridSize;
        [SerializeField] private GridTile gridTilePrefab;
        
        public void Resolve()
        {
            var gridPool = new ObjectPool<GridTile>(gridTilePrefab, gridSize * gridSize);
            var gridBuilder = new GridBuilder(gridPool, gridSize, gridSize);
            gridBuilder.Build();
        }
    }
}