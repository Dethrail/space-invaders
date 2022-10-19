using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [Game]
    [Unique]
    [Event(EventTarget.Self)]
    public class TickPauseComponent : IComponent
    {
        public float value;
    }
}
