using Zenject;

namespace AIEnemy
{
    public class GridController : IInitializable
    {
        private readonly IObjectPool<GridTile> gridTilePool;
        private readonly int width;
        private readonly int height;

        private GridTile[,] gridTiles;

        public GridController(IObjectPool<GridTile> gridTilePool, int width, int height)
        {
            this.gridTilePool = gridTilePool;
            this.width = width;
            this.height = height;
        }

        public void Initialize()
        {
            gridTiles = new GridTile[width, height];

            for (var gridX = 0; gridX < width; gridX++)
            {
                for (var gridY = 0; gridY < height; gridY++)
                {
                    var tile = gridTilePool.Get();
                    var tileData = new GridTileData()
                    {
                        ShouldHighlight = false,
                        Size = tile.transform.localScale.x,
                        X = gridX,
                        Y = gridY
                    };

                    tile.Initialize(tileData);

                    gridTiles[gridX, gridY] = tile;
                }
            }

        }
    }
}