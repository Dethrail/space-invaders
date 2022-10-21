using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SpaceInvaders.Game
{
    [Game]
    [Unique]
    public class CurrentLevelComponent : IComponent
    {
        public LevelComponent Value;
    }
}
