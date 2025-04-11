using UnityEngine;

namespace AIEnemy
{
    public class GridBuilder
    {
        private readonly IObjectPool<GridTile> gridTilePool;
        private readonly int width;
        private readonly int height;
        
        private GridTile[,] gridTiles;

        public GridBuilder(IObjectPool<GridTile> gridTilePool, int width, int height)
        {
            this.gridTilePool = gridTilePool;
            this.width = width;
            this.height = height;
        }

        public void Build()
        {
            gridTiles = new GridTile[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var tile = gridTilePool.Get();
                    tile.transform.position = new Vector3(x, y, 0);

                    gridTiles[x, y] = tile;
                }
            }
        }

        public GridTile GetTileAt(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height) return null;
            return gridTiles[x, y];
        }

        public void Clear()
        {
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (gridTiles[x, y] == null)
                    {
                        continue;
                    }
                    
                    gridTilePool.Return(gridTiles[x, y]);
                    gridTiles[x, y] = null;
                }
            }
        }
    }
}