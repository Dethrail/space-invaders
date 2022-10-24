using Entitas;
using UnityEngine;

namespace Common
{
    [Input]
    public sealed class KeyStartedHoldingComponent : IComponent
    {
        public KeyCode Value;
    }
}