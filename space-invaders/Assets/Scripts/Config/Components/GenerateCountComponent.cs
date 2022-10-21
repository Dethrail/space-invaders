using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Config
{
    [Config]
    [Unique]
    public sealed class GenerateCountComponent : IComponent
    {
        public int Value;
    }
}
