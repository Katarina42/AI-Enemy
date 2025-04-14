using System.Collections;
using UnityEngine;

namespace AIEnemy
{
    public class EnemyView : GridAgentView
    {
        [SerializeField] private float moveDuration = 0.5f;
        [SerializeField] private AnimationCurve moveCurve;
        
        public IEnumerator AnimateTurn(EnemyData data)
        {
            latestData = data;

            if (!data.ShouldMove)
            {
                yield break;
            }
            
            foreach (var nextTile in data.Path)
            {
                yield return MoveToTile(nextTile);
            }

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