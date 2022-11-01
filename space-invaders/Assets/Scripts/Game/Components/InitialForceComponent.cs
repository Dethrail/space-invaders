using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    [Game]
    public class InitialForceComponent : IComponent
    {
        public Vector3 Value;
    }
}
