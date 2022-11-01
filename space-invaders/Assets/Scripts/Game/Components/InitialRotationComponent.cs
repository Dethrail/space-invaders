using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    [Game]
    public class InitialRotationComponent : IComponent
    {
        public Quaternion Value;
    }
}
