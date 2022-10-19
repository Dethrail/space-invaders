using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [GameState]
    [Unique]
    public sealed class MaxSelectedElementComponent : IComponent
    {
        public int value;
    }
}
