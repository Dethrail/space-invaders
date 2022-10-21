using Common;

namespace Common
{
    public class GameStateSystems : Feature
    {
        public GameStateSystems(Contexts contexts)
        {
            Add(new InitStateSystem(contexts));
            Add(new GameStateRestartSystem(contexts));
        }
    }
}