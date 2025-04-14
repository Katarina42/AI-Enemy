
namespace AIEnemy.AI
{
    public class DefaultEnemyAI : IEnemyAI
    {
        private readonly IPathfinder pathfinder;
        private readonly IPlayerDataProvider playerDataProvider;
        private readonly IEnemyDataProvider enemyDataProvider;
        
        public DefaultEnemyAI(IPathfinder pathfinder, IPlayerDataProvider playerDataProvider, IEnemyDataProvider enemyDataProvider)
        {
            this.pathfinder = pathfinder;
            this.playerDataProvider = playerDataProvider;
            this.enemyDataProvider = enemyDataProvider;
        }
        
        public EnemyData Decide()
        {
            var enemyData = enemyDataProvider.Get();
            var playerData = playerDataProvider.Get();
            
            var path =pathfinder.FindPath(enemyData.GridPosition, playerData.GridPosition, enemyData.MovementRange);
            if (path == null || path.Count == 0)
            {
                return enemyData;
            }
            
            enemyData.Path = path;
            enemyData.GridPosition = enemyData.Path[^1];
            return enemyData;
        }
    }
}