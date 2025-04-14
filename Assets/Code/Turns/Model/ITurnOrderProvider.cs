using System.Collections.Generic;
using AIEnemy.GridAgents;

namespace Code.Turns
{
    public interface ITurnOrderProvider
    {
        public Queue<IGridAgentController> GetTurnOrder();
    }
}