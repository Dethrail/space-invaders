using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [Input]
    [Unique]
    public sealed class PointerHoldingTimeComponent : IComponent
    {
        public float Value;
    }
}