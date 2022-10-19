using Game;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    public string StarterSceneName;
    public string GameSceneName;

    public Player Player;
    public Enemy Enemy;
    public Bullet Bullet;
}