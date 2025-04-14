using UnityEngine;

namespace AIEnemy.GridAgents
{
    public interface IGridAgentData 
    {
        public Vector2Int GridPosition { get; set; }
        public int Health { get; set;}
        public int Damage { get; set;}
        public int MovementRange { get; set; }
        public int AttackRange { get; set; }
    }
}