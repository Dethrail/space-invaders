using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SpaceInvaders.Game
{
    [Game]
    [Input]
    [Event(EventTarget.Self)]
    public sealed class DestroyedComponent : IComponent
    {
    }
}
