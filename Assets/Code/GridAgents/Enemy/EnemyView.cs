using System.Collections;
using AIEnemy.GridAgents;
using UnityEngine;

namespace AIEnemy
{
    public class EnemyView : GridAgentView
    {
        [SerializeField] private float moveDuration = 0.5f;
        [SerializeField] private AnimationCurve moveCurve;
        
        protected override void UpdatePosition(IGridAgentData data)
        {
            var enemyData = data as EnemyData;
            if (enemyData.ShouldMove)
            {
                foreach (var nextTile in enemyData.Path)
                {
                    StartCoroutine(MoveToTile(nextTile));
                }
            }
            
            base.UpdatePosition(data);
        }

        private IEnumerator MoveToTile(Vector2Int gridPosition)
        {
            var targetPosition = GridUtils.ToWorld(gridPosition);
            var startPosition = transform.position;
            var timeElapsed = 0f;

            while (timeElapsed < moveDuration)
            {
                var t = timeElapsed / moveDuration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, moveCurve.Evaluate(t));
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        }

    }
}