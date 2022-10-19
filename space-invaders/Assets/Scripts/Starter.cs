using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] public GameConfig _gameSceneName;

    private void Awake()
    {
        if (ServiceLocator.Instance.Config == null)
        {
            ServiceLocator.Instance.InjectGameConfig(_gameSceneName);
        }
    }

    public void PlayGame()
    {
        ServiceLocator.Instance.StartGame();
    }
}