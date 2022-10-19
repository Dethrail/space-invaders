using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [GameState]
    [Unique]
    public sealed class LastSelectedComponent : IComponent
    {
        public int value;
    }
}
