using System.Collections;
using AIEnemy.AI;
using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class EnemyController : IInitializable, IGridAgentController
    {
        private readonly IEnemyAI ai;
        private readonly ITurnOrderRegistar turnOrderRegistar;
        private readonly EnemyView view;
        private readonly IEnemyDataProvider dataProvider;

        public EnemyController(IEnemyAI ai,
            ITurnOrderRegistar turnOrderRegistar,
            EnemyView view,
            IEnemyDataProvider dataProvider)
        {
            this.ai = ai;
            this.turnOrderRegistar = turnOrderRegistar;
            this.view = view;
            this.dataProvider = dataProvider;
        }

        public void Initialize()
        {
            turnOrderRegistar.Register(this);
            var data = dataProvider.Get();
            view.Refresh(data);
            
        }

        public IEnumerator TakeTurn()
        {
            Debug.Log("Enemy is taking turn");
            var data = ai.Decide();
            yield return view.AnimateTurn(data);
        }
        
    }
}