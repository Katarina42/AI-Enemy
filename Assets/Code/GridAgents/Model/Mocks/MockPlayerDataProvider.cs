using UnityEngine;

namespace AIEnemy
{
    public class MockPlayerDataProvider : IPlayerDataProvider
    {
        private readonly PlayerData data;

        public MockPlayerDataProvider()
        {
            data = new PlayerData()
            {
                GridPosition = new Vector2Int(2, 2),
                Health = 10,
                Damage = 10,
                AttackRange = 1,
                MovementRange = 2
            };
        }

        public IGridAgentData Get() => data;

    }
}