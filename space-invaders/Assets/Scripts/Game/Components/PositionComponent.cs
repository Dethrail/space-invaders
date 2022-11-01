using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}