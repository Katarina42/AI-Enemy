using System;

namespace AIEnemy
{
    public interface IGameEvents
    {
        public event Action<GridTileData> GridTileSelected;
    }
}