using System.Collections;
using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class PlayerController : IInitializable, IGridAgentController
    {
        private readonly PlayerView view;
        private readonly IGameEvents events;
        private readonly ITurnOrderRegistar turnOrderRegistar;
        private readonly IPlayerDataProvider dataProvider;

        private bool hasGridTileSelected;

        public PlayerController(PlayerView view, IGameEvents events, ITurnOrderRegistar turnOrderRegistar,
            IPlayerDataProvider dataProvider)
        {
            this.view = view;
            this.events = events;
            this.turnOrderRegistar = turnOrderRegistar;
            this.dataProvider = dataProvider;
        }

        public void Initialize()
        {
            turnOrderRegistar.Register(this);
            var data = dataProvider.Get();
            view.Refresh(data);
            
        }

        private void OnGridTileSelected(Vector2Int tilePosition)
        {
            if (!IsTileInRange(tilePosition))
            {
                return;
            }

            var data = dataProvider.Get();
            data.GridPosition = tilePosition;
            view.Refresh(data);
            
            hasGridTileSelected = true;
        }

        public IEnumerator TakeTurn()
        {
            Debug.Log("Player is taking turn");

            hasGridTileSelected = false;
            events.GridTileSelected += OnGridTileSelected;
            while (!hasGridTileSelected)
            {
                yield return null;
            }

            events.GridTileSelected -= OnGridTileSelected;
        }
        
        private bool IsTileInRange(Vector2Int tilePosition)
        {
            var data = dataProvider.Get();
            var distance = Mathf.Abs(tilePosition.x - data.GridPosition.x) + Mathf.Abs(tilePosition.y - data.GridPosition.y);
            return distance <= data.MovementRange;
        }
    }
}