using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    [Game]
    public class VelocityComponent : IComponent
    {
        public Vector3 Value;
    }
}