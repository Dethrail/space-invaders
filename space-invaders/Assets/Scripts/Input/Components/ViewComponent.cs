using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Common
{
    [Game]
    public class ViewComponent : IComponent
    {
        [EntityIndex]
        public Transform Value;
    }
}
