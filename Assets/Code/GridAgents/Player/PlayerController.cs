using System.Collections;
using AIEnemy.GridAgents;
using Code.GridAgents.Model;
using Code.Turns;
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
            RefreshView();
        }

        private void OnGridTileSelected(Vector2Int tilePosition)
        {
            var data = dataProvider.Get();
            data.GridPosition = tilePosition;
            
            RefreshView();
            hasGridTileSelected = true;
        }

        private void RefreshView()
        {
            var data = dataProvider.Get();
            view.Refresh(data);
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