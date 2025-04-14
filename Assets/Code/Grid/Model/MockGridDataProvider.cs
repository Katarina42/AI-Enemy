using UnityEngine;

namespace AIEnemy
{
    public class MockGridDataProvider : IGridDataProvider
    {
        public GridData Get()
        {
            return new GridData()
            {
                Size = new Vector2Int(20, 18)
            };
        }
    }
}