using System;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        private void OnTriggerEnter(Collider triggeringObject)
        {
            var bullet = triggeringObject.GetComponent<Bullet>();
            if (bullet != null && !bullet.IsPlayerBullet)
            {
                Destroy(gameObject);
                Destroy(triggeringObject.gameObject);
                // add effect
                // GameOver
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = Instantiate(ServiceLocator.Instance.Config.Bullet, transform.position + Vector3.up,
                    Quaternion.Euler(-90, 0, 0));
                bullet.IsPlayerBullet = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // overlap left border
                transform.Translate(Vector2.left * 0.1f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                // overlap right border
                transform.Translate(Vector2.right * 0.1f);
            }
        }
    }
}