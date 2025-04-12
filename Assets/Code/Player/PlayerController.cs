namespace AIEnemy.Player
{
    public class PlayerController
    {
        private readonly PlayerView view;
        
        public PlayerController(PlayerView view, IGameEvents events)
        {
            this.view = view;
            
            events.GridTileSelected += OnGridTileSelected;
        }

        private void OnGridTileSelected(GridTileData gridTileData)
        {
           view.Refresh(new PlayerData()
           {
               Damage = 10,
               Health = 100,
               X = gridTileData.X,
               Y = gridTileData.Y
           });
        }
        
    }
}