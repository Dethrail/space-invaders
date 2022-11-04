using Entitas;
using System.Collections.Generic;

namespace SpaceInvaders.Game
{
    public class AbortGameSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public AbortGameSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameAbortSignal.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var allGameEntities = _contexts.game.GetEntities();
            foreach (var gameEntity in allGameEntities)
            {
                gameEntity.isDestroyed = true;
            }
        }
    }
}