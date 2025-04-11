using UnityEngine;
using System;

namespace AIEnemy
{
    [RequireComponent(typeof(Collider2D))]
    public class GridTile : MonoBehaviour
    {
        public event Action<GridTile> OnTileSelected = delegate { };

        [SerializeField] private SpriteRenderer sprite;

        private int x;
        private int y;

        public void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2Int GetGridPosition()
        {
            return new Vector2Int(x, y);
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
            OnTileSelected?.Invoke(this);
        }

        private void SetHighlight(bool active)
        {
            sprite.color = active ? Color.blue : Color.white;
        }
    }
}