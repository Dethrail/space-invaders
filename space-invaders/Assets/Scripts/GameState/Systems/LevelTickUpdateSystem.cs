using Entitas;

namespace Common
{
    public class LevelTickUpdateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly Contexts _contexts;

        public LevelTickUpdateSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _contexts.game.ReplaceLevelTick(0);
        }

        public void Execute()
        {
            if (!ValidLevelState() || _contexts.game.isPause)
            {
                return;
            }

            // if (_contexts.game.tickPause.value > 0)
            // {
            //     _contexts.game.ReplaceTickPause(_contexts.game.tickPause.value - 1);
            //     return;
            // }

            _contexts.game.ReplaceLevelTick(_contexts.game.levelTick.currentTick + 1);
        }

        private bool ValidLevelState()
        {
            return
                // _contexts.game.hasCurrentLevel &&
                !_contexts.gameState.isGameOver
                && !_contexts.gameState.isGameWin;
        }
    }
}