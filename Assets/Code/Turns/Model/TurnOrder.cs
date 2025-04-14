using System.Collections.Generic;

namespace AIEnemy
{
    public class TurnOrder : ITurnOrderProvider, ITurnOrderRegistar
    {
        private readonly Queue<IGridAgentController> turnOrder = new Queue<IGridAgentController>();
        
        public Queue<IGridAgentController> GetTurnOrder()
        {
            return turnOrder;
        }

        public void Register(IGridAgentController agent)
        {
            turnOrder.Enqueue(agent);
        }
    }
}