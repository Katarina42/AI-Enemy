using Zenject;

namespace AIEnemy
{
    public class GridController : IInitializable
    {
        private readonly IGameEventsInvoker gameEventsInvoker;
        private readonly GridView view;
        
        private readonly int size;
        

        public GridController(IGameEventsInvoker gameEventsInvoker,
            GridView view,
            int size)
        {
            this.gameEventsInvoker = gameEventsInvoker;
            this.view = view;
            this.size = size;
        }

        public void Initialize()
        {
            view.TileSelected += OnTileSelected;
            view.Refresh(
                new GridData()
                {
                    Width = size,
                    Height = size
                });
        }
        
        private void OnTileSelected(GridTileData tile)
        {
            gameEventsInvoker.InvokeGridTileSelected(tile.X, tile.Y);
        }
    }
}