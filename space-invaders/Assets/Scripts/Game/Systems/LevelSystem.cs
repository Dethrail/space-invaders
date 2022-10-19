using System.Collections.Generic;
using Common;
using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public sealed class LevelSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly EnemyObjectService _enemyObjectService;

        private readonly PlayerObjectService _playerObjectService;
        // private const int _seedPrimeNumber = int.MaxValue;

        public LevelSystem(Contexts contexts, Services services) : base(contexts.game)
        {
            _contexts = contexts;
            _enemyObjectService = services.EnemyObjectService;
            _playerObjectService = services.PlayerObjectService;
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
            CreatePlayer();
        }

        private void CreateAliens()
        {
        }

        private void CreateObstacles()
        {
        }

        private void CreatePlayer()
        {
        }
    }
}