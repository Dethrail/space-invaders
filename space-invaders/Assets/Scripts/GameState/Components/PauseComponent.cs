using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [Game]
    [Unique]
    [Event(EventTarget.Self)]
    public class PauseComponent : IComponent
    {
    }
}
