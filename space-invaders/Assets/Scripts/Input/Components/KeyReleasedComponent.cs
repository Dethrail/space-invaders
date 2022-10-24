using Entitas;
using UnityEngine;

namespace Common
{
    [Input]
    public sealed class KeyReleasedComponent : IComponent
    {
        public KeyCode Value;
    }
}