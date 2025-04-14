using Zenject;

namespace AIEnemy
{
    public class GridController : IInitializable
    {
        private readonly IGameEventsInvoker gameEventsInvoker;
        private readonly GridView view;
        private readonly IGridDataProvider gridDataProvider;
        

        public GridController(IGameEventsInvoker gameEventsInvoker,
            GridView view,
            IGridDataProvider gridDataProvider)
        {
            this.gameEventsInvoker = gameEventsInvoker;
            this.view = view;
            this.gridDataProvider = gridDataProvider;
        }

        public void Initialize()
        {
            view.TileSelected += OnTileSelected;
            var data = gridDataProvider.Get();
            view.Refresh(data);
        }
        
        private void OnTileSelected(GridTileData tile)
        {
            gameEventsInvoker.InvokeGridTileSelected(tile.GridPosition);
        }
    }
}