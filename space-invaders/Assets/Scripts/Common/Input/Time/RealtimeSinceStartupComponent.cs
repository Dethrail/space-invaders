using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [Input]
    [Unique]
    public sealed class RealtimeSinceStartupComponent : IComponent
    {
        public float Value;
    }
}