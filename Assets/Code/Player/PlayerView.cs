using UnityEngine;

namespace AIEnemy.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerData data;
        public void Refresh(PlayerData data)
        {
            this.data = data;
            
        }

        private void UpdatePosition(PlayerData data)
        {
            transform.position = new Vector3(data.X, data.Y, 0);
        }
    }
}