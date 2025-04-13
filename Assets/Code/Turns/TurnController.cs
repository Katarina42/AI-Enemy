using System.Collections;
using System.Collections.Generic;
using AIEnemy.GridAgents;
using Code.Turns;
using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class TurnController : MonoBehaviour, IInitializable
    {
        [Inject]
        private readonly ITurnOrderProvider turnOrderProvider;
        private Queue<IGridAgentController> turnOrder;
        
        public void Initialize()
        {
            turnOrder = turnOrderProvider.GetTurnOrder();
            
            StartCoroutine(ProcessTurns());
        }

        private IEnumerator ProcessTurns()
        {
            while (true)
            {
                var agentTakingTurn = turnOrder.Dequeue();
                yield return agentTakingTurn.TakeTurn();
                turnOrder.Enqueue(agentTakingTurn);
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}