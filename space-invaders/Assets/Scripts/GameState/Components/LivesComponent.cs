using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [GameState]
    [Unique]
    public class LivesComponent : IComponent
    {
        public int value;
    }
}