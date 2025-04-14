using AIEnemy.GridAgents;
using Code.GridAgents.Model;
using UnityEngine;

namespace AIEnemy
{
    public class MockPlayerDataProvider : IPlayerDataProvider
    {
        public IGridAgentData Get()
        {
            return new PlayerData()
            {
                GridPosition = new Vector2Int(2,2),
                Health = 10,
                Damage = 10,
                AttackRange = 1,
                MovementRange = 2
            };
        }
    }
}