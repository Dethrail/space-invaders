using System.Numerics;
using Entitas;

namespace SpaceInvaders.Game
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}