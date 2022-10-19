using System;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        private static EnemyMoveDirection _state;

        // TODO: move this from static
        public static void IncrementState()
        {
            _state = _state.Next();
            // invalidate?
        }

        private void OnTriggerEnter(Collider triggeringObject)
        {
            var bullet = triggeringObject.GetComponent<Bullet>();
            if (bullet != null && bullet.IsPlayerBullet)
            {
                Destroy(gameObject);
                Destroy(triggeringObject.gameObject);
                // add effect
            }
        }

        public event Action<Enemy> OnDestroyEvent;

        public void Update()
        {
            switch (_state)
            {
                case EnemyMoveDirection.Right:
                    transform.Translate(Vector2.right * Time.deltaTime);
                    break;
                case EnemyMoveDirection.Left:
                    transform.Translate(Vector2.left * Time.deltaTime);
                    break;
                case EnemyMoveDirection.DownFromRight:
                case EnemyMoveDirection.DownFromLeft:
                    ServiceLocator.Instance.GameLogic.ShiftAllEnemiesDown();
                    IncrementState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnDestroy()
        {
            OnDestroyEvent?.Invoke(this);
        }

        [ContextMenu("Destroy Test")]
        public void DestroyTest()
        {
            Destroy(gameObject);
        }
    }
}