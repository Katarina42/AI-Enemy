using System.Collections;

namespace AIEnemy.GridAgents
{
    public interface IGridAgentController
    {
        public IEnumerator TakeTurn();
    }
}