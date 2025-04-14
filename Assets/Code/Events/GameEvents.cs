using System;
using UnityEngine;

namespace AIEnemy
{
    public class GameEvents : IGameEvents, IGameEventsInvoker
    {
        public event Action<Vector2Int> GridTileSelected = delegate { };

        public void InvokeGridTileSelected(Vector2Int tile)
        {
            GridTileSelected(tile);
        }
    }
}