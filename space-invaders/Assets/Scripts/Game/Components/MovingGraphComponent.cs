using UnityEngine;

namespace SpaceInvaders.Game
{
    using Entitas;

    [Game]
    public class MovingGraphComponent : IComponent
    {
        public AnimationCurve Value;
    }
}