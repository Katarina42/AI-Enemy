using UnityEngine;

namespace AIEnemy
{
    [RequireComponent(typeof(Collider2D))]
    public class GridTile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        
        private GridTileData data;

        public void Initialize(GridTileData data)
        {
            this.data = data;
            transform.position = new Vector3(data.X * data.Size, data.Y * data.Size, 0);
            SetHighlight(data.ShouldHighlight);
        }
        
        private void OnMouseEnter()
        {
            SetHighlight(true);
        }

        private void OnMouseExit()
        {
            SetHighlight(false);
        }

        private void OnMouseDown()
        {
            //GameEvents.GridTileSelected.Invoke(data);
        }

        private void SetHighlight(bool active)
        {
            sprite.color = active ? Color.blue : Color.white;
        }
    }
}