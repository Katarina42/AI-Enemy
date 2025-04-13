using AIEnemy.GridAgents;

namespace AIEnemy
{
    public class EnemyData : IGridAgentData
    {
        public int X { get; set; } = 5;
        public int Y { get; set; } = 5;
        public int Health { get; set; }
        public int Damage { get; set; }
    }
}