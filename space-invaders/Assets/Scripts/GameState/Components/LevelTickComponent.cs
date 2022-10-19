using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [Game][Unique]
    [Event(EventTarget.Any)]
    public class LevelTickComponent : IComponent
    {
        public long currentTick;
    }
}