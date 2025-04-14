
namespace AIEnemy
{
    public interface IEnemyDataProvider : IGridAgentDataProvider
    {
        public new EnemyData Get();
    }
}