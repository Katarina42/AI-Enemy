
using Code.GridAgents.Model;

namespace AIEnemy.AI
{
    public class NormalEnemyAI : IEnemyAI
    {
        private readonly IPathfinder pathfinder;
        private readonly IPlayerDataProvider playerDataProvider;
        private readonly IEnemyDataProvider enemyDataProvider;
        
        public NormalEnemyAI(IPathfinder pathfinder, IPlayerDataProvider playerDataProvider, IEnemyDataProvider enemyDataProvider)
        {
            this.pathfinder = pathfinder;
            this.playerDataProvider = playerDataProvider;
            this.enemyDataProvider = enemyDataProvider;
        }
        
        public void Act()
        {
            var enemyData = enemyDataProvider.Get() as EnemyData;
            var playerData = playerDataProvider.Get() as PlayerData;
            enemyData.Path = pathfinder.FindPath(enemyData.GridPosition, playerData.GridPosition, enemyData.MovementRange);
        }
    }
}