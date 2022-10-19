using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        ServiceLocator.Instance.StartGame(true);
    }

    private void OnDestroy()
    {
        var button = GetComponent<Button>();
        button.onClick.RemoveListener(RestartGame);
    }
}