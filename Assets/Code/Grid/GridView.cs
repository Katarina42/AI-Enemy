using System;

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
            gridTiles = new GridTile[data.Width, data.Height];

            for (var gridX = 0; gridX < data.Width; gridX++)
            {
                for (var gridY = 0; gridY < data.Height; gridY++)
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
                X = gridX,
                Y = gridY
            });

            gridTiles[gridX, gridY] = tile;
        }
    }
}