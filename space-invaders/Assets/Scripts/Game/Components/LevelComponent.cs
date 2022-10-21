using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SpaceInvaders.Game
{
    [Game]
    [Unique]
    public class LevelComponent : IComponent
    {
        public string Value;
    }
}
