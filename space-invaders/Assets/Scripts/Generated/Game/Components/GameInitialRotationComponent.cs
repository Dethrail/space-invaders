//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Common.InitialRotationComponent initialRotation { get { return (Common.InitialRotationComponent)GetComponent(GameComponentsLookup.InitialRotation); } }
    public bool hasInitialRotation { get { return HasComponent(GameComponentsLookup.InitialRotation); } }

    public void AddInitialRotation(UnityEngine.Quaternion newValue) {
        var index = GameComponentsLookup.InitialRotation;
        var component = (Common.InitialRotationComponent)CreateComponent(index, typeof(Common.InitialRotationComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInitialRotation(UnityEngine.Quaternion newValue) {
        var index = GameComponentsLookup.InitialRotation;
        var component = (Common.InitialRotationComponent)CreateComponent(index, typeof(Common.InitialRotationComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInitialRotation() {
        RemoveComponent(GameComponentsLookup.InitialRotation);
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

    static Entitas.IMatcher<GameEntity> _matcherInitialRotation;

    public static Entitas.IMatcher<GameEntity> InitialRotation {
        get {
            if (_matcherInitialRotation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InitialRotation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInitialRotation = matcher;
            }

            return _matcherInitialRotation;
        }
    }
}
