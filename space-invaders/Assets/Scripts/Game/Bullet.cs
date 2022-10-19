using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool IsPlayerBullet = false;
    private void FixedUpdate()
    {
        transform.Translate(-transform.up * Time.deltaTime * 10f);
    }
}