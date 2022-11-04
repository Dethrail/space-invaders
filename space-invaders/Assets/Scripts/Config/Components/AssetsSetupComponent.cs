using System;
using Entitas.CodeGeneration.Attributes;
using SpaceInvaders.Game;
using Unity.Mathematics;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu]
    [Config]
    [Unique]
    public class AssetsSetupComponent : ScriptableObject
    {
        [field: SerializeField, Header("Game settings")]
        public GameObject EnemyShip { get; private set; }

        [field: SerializeField] public float TopBorderX { get; private set; } = 18.5f;
        [field: SerializeField] public float BottomBorderX { get; private set; } = -18.5f;
        [field: SerializeField] public float LeftBorderX { get; private set; } = -6.8f;
        [field: SerializeField] public float RightBorderX { get; private set; } = 6.8f;

        [field: SerializeField, Space(10), Header("Player settings")]
        public GameObject Player { get; private set; }

        [field: SerializeField] public float PlayerVelocityMultiplier { get; private set; } = 10f;

        [field: SerializeField, Space(10), Header("Player weapon settings")]
        public float ProjectileVelocity { get; private set; } = 20f;

        [field: SerializeField] public float ProjectileStartDistance { get; private set; } = 1.25f;
        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public WeaponType Weapon { get; private set; } = WeaponType.Laser;
        [field: SerializeField] public float Cooldown { get; private set; } = 3f;
        [field: SerializeField] public float Damage { get; private set; } = 3f;
    }
}