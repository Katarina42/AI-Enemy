using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy
{
    public class EnemyData : IGridAgentData
    {
        public Vector2Int GridPosition { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int MovementRange { get; set; }
        public int AttackRange { get; set; }
        public List<Vector2Int> Path { get; set; }
        public bool ShouldMove => Path != null && Path.Count > 0;
    }
}