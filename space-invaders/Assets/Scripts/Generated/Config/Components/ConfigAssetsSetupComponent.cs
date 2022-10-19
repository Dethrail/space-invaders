//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity assetsSetupEntity { get { return GetGroup(ConfigMatcher.AssetsSetup).GetSingleEntity(); } }
    public AssetsSetupComponent assetsSetup { get { return assetsSetupEntity.assetsSetup; } }
    public bool hasAssetsSetup { get { return assetsSetupEntity != null; } }

    public ConfigEntity SetAssetsSetup(Config.AssetsSetup newValue) {
        if (hasAssetsSetup) {
            throw new Entitas.EntitasException("Could not set AssetsSetup!\n" + this + " already has an entity with AssetsSetupComponent!",
                "You should check if the context already has a assetsSetupEntity before setting it or use context.ReplaceAssetsSetup().");
        }
        var entity = CreateEntity();
        entity.AddAssetsSetup(newValue);
        return entity;
    }

    public void ReplaceAssetsSetup(Config.AssetsSetup newValue) {
        var entity = assetsSetupEntity;
        if (entity == null) {
            entity = SetAssetsSetup(newValue);
        } else {
            entity.ReplaceAssetsSetup(newValue);
        }
    }

    public void RemoveAssetsSetup() {
        assetsSetupEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigEntity {

    public AssetsSetupComponent assetsSetup { get { return (AssetsSetupComponent)GetComponent(ConfigComponentsLookup.AssetsSetup); } }
    public bool hasAssetsSetup { get { return HasComponent(ConfigComponentsLookup.AssetsSetup); } }

    public void AddAssetsSetup(Config.AssetsSetup newValue) {
        var index = ConfigComponentsLookup.AssetsSetup;
        var component = (AssetsSetupComponent)CreateComponent(index, typeof(AssetsSetupComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAssetsSetup(Config.AssetsSetup newValue) {
        var index = ConfigComponentsLookup.AssetsSetup;
        var component = (AssetsSetupComponent)CreateComponent(index, typeof(AssetsSetupComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAssetsSetup() {
        RemoveComponent(ConfigComponentsLookup.AssetsSetup);
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
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherAssetsSetup;

    public static Entitas.IMatcher<ConfigEntity> AssetsSetup {
        get {
            if (_matcherAssetsSetup == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.AssetsSetup);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherAssetsSetup = matcher;
            }

            return _matcherAssetsSetup;
        }
    }
}
