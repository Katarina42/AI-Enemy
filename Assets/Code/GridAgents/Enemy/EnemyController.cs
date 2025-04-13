using System.Collections;
using AIEnemy.AI;
using AIEnemy.GridAgents;
using Code.Turns;
using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class EnemyController : IInitializable, IGridAgentController
    {
        private readonly IEnemyAI ai;
        private readonly ITurnOrderRegistar turnOrderRegistar;
        private readonly EnemyView view;

        public EnemyController(IEnemyAI ai, ITurnOrderRegistar turnOrderRegistar, EnemyView view)
        {
            this.ai = ai;
            this.turnOrderRegistar = turnOrderRegistar;
            this.view = view;
        }

        public void Initialize()
        {
            turnOrderRegistar.Register(this);
            view.Refresh(new EnemyData());
            
        }

        public IEnumerator TakeTurn()
        {
            Debug.Log("Act");
            ai.Act();
            yield break;
        }
    }
}