using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public sealed class LevelSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;

        // private const int _seedPrimeNumber = int.MaxValue;

        public LevelSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RestartLevel.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.hasRestartLevel)
                {
                    ResetGameState();
                    RunLevel(entity.restartLevel.Value);
                    entity.isDestroyed = true;
                    Debug.Log($"Run level\nrestart is [{entity.restartLevel.IsRestart}]");
                }
            }
        }

        private void ResetGameState()
        {
            _contexts.game.ReplaceLevelTick(0);
            _contexts.game.ReplaceTickPause(0);
            _contexts.game.isPause = false;
            _contexts.gameState.isGameWin = false;
            _contexts.gameState.isGameOver = false;
        }

        public void Initialize()
        {
        }

        private void RunLevel(LevelComponent levelComponent)
        {
            _contexts.game.ReplaceCurrentLevel(levelComponent);

            CreateAliens();
            CreateObstacles();
            var playerWeapon = CreatePlayerWeapon();
            CreatePlayer(playerWeapon);
        }

        private void CreateAliens()
        {
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    var x = -6.9f + 2.3f * i;
                    var y = 9.2f - 2.0f * j;
                    var enemyEntity = _contexts.game.CreateEntity();
                    enemyEntity.ReplaceInitialPosition(new Vector3(x, y, 0));
                    enemyEntity.ReplaceInitialRotation(Quaternion.identity);
                    enemyEntity.ReplaceAsset("enemy"); // TODO: check it
                }
            }
        }

        private void CreateObstacles()
        {
        }

        private void CreatePlayer(GameEntity weapon)
        {
            var playerEntity = _contexts.game.CreateEntity();
            playerEntity.isPlayer = true;
            playerEntity.ReplaceInitialPosition(new Vector3(0, -14, 0f));
            playerEntity.ReplaceInitialRotation(Quaternion.Euler(0, 0, 0));
            playerEntity.ReplaceAsset("player"); // TODO: check it
            playerEntity.ReplaceWeapon(weapon);
        }

        private GameEntity CreatePlayerWeapon()
        {
            var config = _contexts.config.assetsSetup.value;
            var playerWeapon = _contexts.game.CreateEntity();
            playerWeapon.ReplaceCooldownSetting(config.Cooldown);
            return playerWeapon;
        }
    }
}