using Entitas;

namespace SpaceInvaders.Game
{
    [Game]
    public sealed class RestartLevelComponent : IComponent
    {
        public LevelComponent Value;
        public bool IsRestart;
    }
}