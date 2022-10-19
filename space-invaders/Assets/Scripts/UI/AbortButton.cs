using UnityEngine;
using UnityEngine.UI;

public class AbortButton : MonoBehaviour
{
    private void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(AbortGame);
    }

    private void AbortGame()
    {
        ServiceLocator.Instance.ReturnToMain(true);
    }

    private void OnDestroy()
    {
        var button = GetComponent<Button>();
        button.onClick.RemoveListener(AbortGame);
    }
}