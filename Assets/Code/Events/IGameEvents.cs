using System;
using UnityEngine;

namespace AIEnemy
{
    public interface IGameEvents
    {
        public event Action<Vector2Int> GridTileSelected;
    }
}