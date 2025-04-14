using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy
{
    public class MockEnemyDataProvider : IEnemyDataProvider
    {
        private readonly EnemyData data;

        public MockEnemyDataProvider()
        {
            data = new EnemyData()
            {
                GridPosition = new Vector2Int(5, 7),
                Health = 10,
                Damage = 10,
                AttackRange = 2,
                MovementRange = 1,
                Path = new List<Vector2Int>()
            };
        }

        public IGridAgentData Get() => data;

        EnemyData IEnemyDataProvider.Get() => data;
    }
}