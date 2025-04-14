using System.Collections.Generic;
using AIEnemy.GridAgents;
using Code.GridAgents.Model;
using UnityEngine;

namespace AIEnemy
{
    public class MockEnemyDataProvider : IEnemyDataProvider
    {
        public IGridAgentData Get()
        {
            return new EnemyData()
            {
                GridPosition = new Vector2Int(5,7),
                Health = 10,
                Damage = 10,
                AttackRange = 2,
                MovementRange = 1,
                Path = new List<Vector2Int>(),
            };
        }
    }
}