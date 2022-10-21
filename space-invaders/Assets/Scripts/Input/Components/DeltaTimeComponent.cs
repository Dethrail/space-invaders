using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [Input]
    [Unique]
    public sealed class DeltaTimeComponent : IComponent
    {
        public float Value;
    }
}