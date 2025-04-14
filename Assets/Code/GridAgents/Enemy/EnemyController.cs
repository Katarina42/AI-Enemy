using System.Collections;
using AIEnemy.AI;
using AIEnemy.GridAgents;
using Code.GridAgents.Model;
using Code.Turns;
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
            RefreshView();
        }

        public IEnumerator TakeTurn()
        {
            ai.Act();
            RefreshView();
            yield break;
        }

        private void RefreshView()
        {
            var data = dataProvider.Get();
            view.Refresh(data);
        }
    }
}