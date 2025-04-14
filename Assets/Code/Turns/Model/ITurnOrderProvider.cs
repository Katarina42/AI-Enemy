using System.Collections.Generic;

namespace AIEnemy
{
    public interface ITurnOrderProvider
    {
        public Queue<IGridAgentController> GetTurnOrder();
    }
}