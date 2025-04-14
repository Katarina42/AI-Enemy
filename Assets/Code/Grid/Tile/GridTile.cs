using System;
using UnityEngine;

namespace AIEnemy
{
    [RequireComponent(typeof(Collider2D))]
    public class GridTile : MonoBehaviour
    {
        public Action<GridTileData> TileSelected;
        
        [SerializeField] private SpriteRenderer defaultSprite;
        [SerializeField] private SpriteRenderer highlightSprite;

        private GridTileData data;

        public void Refresh(GridTileData data)
        {
            this.data = data;
            
            SetHighlight(false);
            SetPosition(data.GridPosition);
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
            if (data == null)
            {
                return;
            }
            
            TileSelected(data);
        }

        private void SetHighlight(bool active)
        {
           highlightSprite.enabled = active;
        }
        
        private void SetPosition(Vector2Int position)
        {
            transform.position = Utils.ToWorld(position);
        }
    }
}