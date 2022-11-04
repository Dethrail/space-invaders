using Common;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private UnityView ThisView;

    private void OnTriggerEnter(Collider other)
    {
        var otherView = other.GetComponent<UnityView>()?.GetGameEntity();
        if (otherView != null && otherView.isEnemy)
        {
            otherView.isDestroyed = true;
            ThisView.GetGameEntity().isDestroyed = true;
        }
    }
}