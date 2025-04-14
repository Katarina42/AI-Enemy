using UnityEngine;

namespace AIEnemy
{
    public interface IGameEventsInvoker
    {
        public void InvokeGridTileSelected(Vector2Int tile);
    }
}