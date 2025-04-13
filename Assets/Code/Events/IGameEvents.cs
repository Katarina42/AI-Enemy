using System;

namespace AIEnemy
{
    public interface IGameEvents
    {
        public event Action<int, int> GridTileSelected;
    }
}