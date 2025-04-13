using System.Collections;
using AIEnemy.GridAgents;
using Code.Turns;
using Zenject;

namespace AIEnemy
{
    public class PlayerController : IInitializable, IGridAgentController
    {
        private readonly PlayerView view;
        private readonly IGameEvents events;
        private readonly ITurnOrderRegistar turnOrderRegistar;
        
        private bool hasGridTileSelected;
        
        public PlayerController(PlayerView view, IGameEvents events, ITurnOrderRegistar turnOrderRegistar)
        {
            this.view = view;
            this.events = events;
            this.turnOrderRegistar = turnOrderRegistar;
        }
        
        public void Initialize()
        {
            turnOrderRegistar.Register(this);
            view.Refresh(new PlayerData());
        }

        private void OnGridTileSelected(int x, int y)
        {
           view.Refresh(new PlayerData()
           {
               X = x,
               Y = y
           });
           
           hasGridTileSelected = true;
        }

        public IEnumerator TakeTurn()
        {
            hasGridTileSelected = false;
            events.GridTileSelected += OnGridTileSelected;
            while (!hasGridTileSelected)
            {
                yield return null;
            }
            
            events.GridTileSelected -= OnGridTileSelected;
        }
    }
}