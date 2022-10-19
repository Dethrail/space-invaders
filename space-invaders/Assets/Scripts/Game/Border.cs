using System.Threading.Tasks;
using Game;
using UnityEngine;

public class Border : MonoBehaviour
{
    private Collider _border;

    private void Awake()
    {
        _border = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider triggeringObject)
    {
        if (triggeringObject.GetComponent<Enemy>() != null)
        {
            Enemy.IncrementState();
        }

        _border.enabled = false;
        EnableCollider();
    }

    private async void EnableCollider()
    {
        await Task.Delay(100);
        _border.enabled = true;
    }
}