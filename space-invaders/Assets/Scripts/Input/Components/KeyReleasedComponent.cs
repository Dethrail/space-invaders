using Entitas;

namespace Common
{
    [Input]
    public sealed class KeyReleasedComponent : IComponent
    {
        public char Value;
    }
}