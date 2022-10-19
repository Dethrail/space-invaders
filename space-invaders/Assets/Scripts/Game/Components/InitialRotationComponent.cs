using Entitas;
using UnityEngine;

namespace Common
{
    [Game]
    public class InitialRotationComponent : IComponent
    {
        public Quaternion Value;
    }
}
