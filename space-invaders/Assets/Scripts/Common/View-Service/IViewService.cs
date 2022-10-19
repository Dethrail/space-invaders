using Entitas;
using UnityEngine;

namespace Common
{
    public interface IViewService
    {
        GameObject LoadAsset(Contexts ctx, GameEntity entity);
    }
}