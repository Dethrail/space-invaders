using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu]
    [Config]
    [Unique]
    public class AssetsSetupComponent : ScriptableObject
    {
        public GameObject EnemyShip;
        public GameObject Player;
        public float PlayerVelocityMultiplier;
    }
}