using System.Diagnostics.CodeAnalysis;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu]
    [Config]
    [Unique]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AssetsSetup : ScriptableObject
    {
        public GameObject EnemyShip;
        public GameObject Player;
    }
}