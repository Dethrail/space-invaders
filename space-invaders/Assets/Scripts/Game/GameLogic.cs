using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public class GameLogic
    {
        private List<Enemy> _enemies = new List<Enemy>();

        public void StartGame()
        {
            // reset all 
            SpawnWaves();
        }

        private async void SpawnWaves()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var x = -6.9f + 2.3f * i;
                    var y = 9.2f - 2.0f * j;
                    var enemy = Object.Instantiate(ServiceLocator.Instance.Config.Enemy, new Vector3(x, y, 0f),
                        Quaternion.identity);
                    enemy.OnDestroyEvent += OnDestroyEnemy;
                    _enemies.Add(enemy);
                }
            }

            // await Task.Delay(3000); // 3 sec of delay before game
        }

        public void ShiftAllEnemiesDown()
        {
            foreach (var enemy in _enemies)
            {
                enemy.transform.Translate(Vector2.down * 2f); // need move all enemies
            }
        }

        public void CleanUp()
        {
            for (var i = _enemies.Count - 1; i > 0; i--)
            {
                if (_enemies[i] != null)
                {
                    Object.Destroy(_enemies[i].gameObject);
                    _enemies.RemoveAt(i);
                }
            }
        }

        private void OnDestroyEnemy(Enemy actor)
        {
            actor.OnDestroyEvent -= OnDestroyEnemy;
            _enemies.Remove(actor);
            Object.Destroy(actor.gameObject);
        }
    }
}