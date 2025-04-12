using System;

namespace AIEnemy
{
    public class GameEvents : IGameEvents, IGameEventsInvoker
    {
        public event Action<GridTileData> GridTileSelected = delegate { };

        public void InvokeGridTileSelected(GridTileData tileData)
        {
            GridTileSelected(tileData);
        }
    }
}