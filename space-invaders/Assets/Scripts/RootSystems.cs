using Entitas;
using Common;
using SpaceInvaders.Game;
using UnityEngine;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new InputSystems(contexts, Camera.main));

        Add(new GameStateSystems(contexts));
        Add(new GameStateEventSystems(contexts));

        // somehow move this systems to end
        Add(new GameSystems(contexts));
        Add(new GameEventSystems(contexts));
    }

    public sealed override Systems Add(ISystem system)
    {
        return base.Add(system);
    }
}