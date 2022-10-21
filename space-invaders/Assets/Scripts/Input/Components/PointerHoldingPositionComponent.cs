using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Common
{
    [Input]
    [Unique]
    public sealed class PointerHoldingPositionComponent : IComponent
    {
        public Vector3 value;
    }
}