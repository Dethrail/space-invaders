//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SpaceInvaders.Game.InitialForceComponent initialForce { get { return (SpaceInvaders.Game.InitialForceComponent)GetComponent(GameComponentsLookup.InitialForce); } }
    public bool hasInitialForce { get { return HasComponent(GameComponentsLookup.InitialForce); } }

    public void AddInitialForce(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.InitialForce;
        var component = (SpaceInvaders.Game.InitialForceComponent)CreateComponent(index, typeof(SpaceInvaders.Game.InitialForceComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInitialForce(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.InitialForce;
        var component = (SpaceInvaders.Game.InitialForceComponent)CreateComponent(index, typeof(SpaceInvaders.Game.InitialForceComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInitialForce() {
        RemoveComponent(GameComponentsLookup.InitialForce);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInitialForce;

    public static Entitas.IMatcher<GameEntity> InitialForce {
        get {
            if (_matcherInitialForce == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InitialForce);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInitialForce = matcher;
            }

            return _matcherInitialForce;
        }
    }
}
