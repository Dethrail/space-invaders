using Entitas;
using UnityEngine;

namespace SpaceInvaders.Game
{
    [Game]
    public class MovingGraphComponent : IComponent
    {
        public AnimationCurve Value;
    }
}