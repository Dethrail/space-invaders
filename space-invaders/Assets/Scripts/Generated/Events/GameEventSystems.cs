//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new GameDestroyedEventSystem(contexts)); // priority: 0
        Add(new AnyLevelTickEventSystem(contexts)); // priority: 0
        Add(new PauseEventSystem(contexts)); // priority: 0
        Add(new TickPauseEventSystem(contexts)); // priority: 0
    }
}