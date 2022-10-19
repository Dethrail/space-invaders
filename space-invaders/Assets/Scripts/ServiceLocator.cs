using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class ServiceLocator
{
    private const string Tag = "[ServiceLocator]:";

    private static ServiceLocator _locator = null;
    public static ServiceLocator Instance => _locator ??= new ServiceLocator();

    public GameLogic GameLogic { get; private set; }
    public GameConfig Config { get; private set; }

    private ServiceLocator()
    {
    }

    public void InjectGameConfig(GameConfig gc)
    {
        if (Config != null)
        {
            throw new Exception("Cant reassign gameConfig");
        }

        Config = gc;
    }

    public async void StartGame(bool isRestart = false)
    {
        if (GameLogic == null)
        {
            GameLogic = new GameLogic();
            Log("CreateGameLogic");
        }

        Log("Clean up field if needed");
        GameLogic.CleanUp();
        Log("StartLoadScene");
        var asyncLoad = SceneManager.LoadSceneAsync(Config.GameSceneName);

        while (!asyncLoad.isDone)
        {
            await Task.Yield();
        }

        Log("SceneLoaded");
        GameLogic.StartGame();
    }

    public void ReturnToMain(bool abortGame = false)
    {
        Log("Play button pressed");
        SceneManager.LoadScene(Config.StarterSceneName);
    }

    private void Log(string message)
    {
        Debug.Log($"{Tag} {message}");
    }
}