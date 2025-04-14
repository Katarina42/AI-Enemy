using System;
using UnityEngine;

namespace AIEnemy
{
    public class GridView
    {
        public Action<GridTileData> TileSelected = delegate { };
        private readonly IObjectPool<GridTile> gridTilePool;
        private GridTile[,] gridTiles;

        public GridView(IObjectPool<GridTile> gridTilePool)
        {
            this.gridTilePool = gridTilePool;
        }
        
        public void Refresh(GridData data)
        {
            SetupGrid(data);
        }

        private void SetupGrid(GridData data)
        {
            gridTiles = new GridTile[data.Size.x, data.Size.y];

            for (var gridX = 0; gridX < data.Size.x; gridX++)
            {
                for (var gridY = 0; gridY < data.Size.y; gridY++)
                {
                    SetupTile(gridX, gridY);
                }
            }
        }
        
        private void SetupTile(int gridX, int gridY)
        {
            var tile = gridTilePool.Get();

            tile.TileSelected += (gridTileData) => TileSelected(gridTileData);
            
            tile.Refresh( new GridTileData()
            {
                GridPosition = new Vector2Int(gridX, gridY)
            });

            gridTiles[gridX, gridY] = tile;
        }
    }
}