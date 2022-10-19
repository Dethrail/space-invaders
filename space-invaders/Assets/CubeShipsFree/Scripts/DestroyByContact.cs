using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    public class DestroyByContact : MonoBehaviour
    {
        public GameObject explosion;
        public GameObject playerExplosion;
        public int scoreValue;
        private static GameController gameController;
        private bool isVisible = false;

        // Use this for initialization
        void Start()
        {
            if (!gameController)
                gameController = GameObject.FindObjectOfType<GameController>();
        }

        void OnBecameInvisible()
        {
            isVisible = false;
        }

        void OnBecameVisible()
        {
            isVisible = true;
        }

        void OnTriggerEnter(Collider other)
        {
            // Note: you can optimize these by using Tags
            // ignore bullet to bullet collision
            if (this.GetComponent<Bullet2>() && other.GetComponent<Bullet2>())
                return;

            // ignore collision with Enemy or Boundary
            if (other.name=="Boundary")
                return;
            if (other.GetComponent<Enemy2>() && this.GetComponent<EnemyBullet2>())
                return;
            if (other.GetComponent<EnemyBullet2>() && this.GetComponent<Enemy2>())
                return;

            if (explosion)
                Instantiate(explosion, transform.position, transform.rotation);

            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
