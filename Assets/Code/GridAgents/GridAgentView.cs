using UnityEngine;

namespace AIEnemy
{
    public class GridAgentView: MonoBehaviour
    {
        protected IGridAgentData latestData;
        
        public virtual void Refresh(IGridAgentData data)
        {
            UpdatePosition(data);
            latestData = data;
        }

        protected virtual void UpdatePosition(IGridAgentData data)
        {
            transform.position = Utils.ToWorld(data.GridPosition);
        }
    }
}