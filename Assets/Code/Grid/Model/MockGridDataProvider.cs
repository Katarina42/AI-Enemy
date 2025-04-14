namespace AIEnemy
{
    public class MockGridDataProvider : IGridDataProvider
    {
        public GridData Get()
        {
            return new GridData()
            {
                Height = 20,
                Width = 16
            };
        }
    }
}