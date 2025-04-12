using Zenject;

namespace AIEnemy
{
    public class PlayerController : IInitializable
    {
        private readonly PlayerView view;
        private readonly IGameEvents events;
        
        public PlayerController(PlayerView view, IGameEvents events)
        {
            this.view = view;
            this.events = events;
        }
        
        public void Initialize()
        {
            events.GridTileSelected += OnGridTileSelected;
            view.Refresh(new PlayerData()
            {
                Damage = 10,
                Health = 100
            });
        }

        private void OnGridTileSelected(GridTileData gridTileData)
        {
           view.Refresh(new PlayerData()
           {
               X = gridTileData.X,
               Y = gridTileData.Y
           });
        }
        
    }
}