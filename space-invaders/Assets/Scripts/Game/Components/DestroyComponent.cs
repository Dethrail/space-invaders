using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace scripts.game.destroy
{
    [Game]
    [Input]
    [Event(EventTarget.Self)]
    public sealed class DestroyedComponent : IComponent
    {
    }
}
