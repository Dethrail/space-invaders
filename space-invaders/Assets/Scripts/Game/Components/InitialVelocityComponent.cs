using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    [Game]
    public class InitialVelocityComponent : IComponent
    {
        public Vector3 Value;
    }
}
