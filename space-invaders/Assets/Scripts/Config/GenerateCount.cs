using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Config
{
    [Config]
    [Unique]
    public sealed class GenerateCount : IComponent
    {
        public int Value;
    }
}
