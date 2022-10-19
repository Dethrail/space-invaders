using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceLocator
{
    private const string Tag = "[ServiceLocator]:";

    private static ServiceLocator _locator = null;
    public static ServiceLocator Instance => _locator ??= new ServiceLocator();

    public GameConfig Config { get; private set; }

    private ServiceLocator()
    {
        // Prepare game state 
    }

    public void InjectGameConfig(GameConfig gc)
    {
        if (Config != null)
        {
            throw new Exception("Cant reassign gameConfig");
        }

        Config = gc;
    }

    public void StartGame(bool isRestart = false)
    {
        Log("Start");
        SceneManager.LoadScene(Config.GameSceneName); // TODO: make some async await with result of game?
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

    public void Start()
    {
    }
}