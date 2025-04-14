using UnityEngine;

namespace AIEnemy.GridAgents
{
    public class GridAgentView: MonoBehaviour
    {
        protected IGridAgentData data;
        
        public virtual void Refresh(IGridAgentData data)
        {
            this.data = data;
            UpdatePosition(data);
        }

        protected virtual void UpdatePosition(IGridAgentData data)
        {
            transform.position = GridUtils.ToWorld(data.GridPosition);
        }
    }
}