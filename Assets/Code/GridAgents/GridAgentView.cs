using UnityEngine;

namespace AIEnemy.GridAgents
{
    public class GridAgentView: MonoBehaviour
    {
        private IGridAgentData data;
        
        public void Refresh(IGridAgentData data)
        {
            this.data = data;
            UpdatePosition(data);
        }

        private void UpdatePosition(IGridAgentData data)
        {
            transform.position = new Vector3(data.X * 8, data.Y * 8, 0);
        }
    }
}