using System;

namespace AIEnemy
{
    public class GameEvents : IGameEvents, IGameEventsInvoker
    {
        public event Action<int, int> GridTileSelected = delegate { };

        public void InvokeGridTileSelected(int x, int y)
        {
            GridTileSelected(x, y);
        }
    }
}