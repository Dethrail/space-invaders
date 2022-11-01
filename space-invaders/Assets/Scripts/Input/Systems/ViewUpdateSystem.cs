using Entitas;

namespace Common
{
    public class ViewUpdateSystem : IExecuteSystem
    {
        private GameContext _gameContext;

        public ViewUpdateSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Execute()
        {
            var views = _gameContext.GetGroup(GameMatcher.View).GetEntities();

            foreach (var gameEntity in views)
            {
                gameEntity.ReplacePosition(gameEntity.view.Value.position);
            }
        }
    }
}