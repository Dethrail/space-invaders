using Entitas;
using UnityEngine;
using Common;
using Config;

public class GameApplication : MonoBehaviour
{
    private Systems _systems;

    private Contexts _contexts;


    [SerializeField] private Config.AssetsSetupComponent _assetsSetupComponent;

    protected void Awake()
    {
        Application.targetFrameRate = 60;
        _contexts = Contexts.sharedInstance;
        _contexts.game.Reset();
        _contexts.config.SetAssetsSetup(_assetsSetupComponent);
        // _contexts.config.ReplaceAssetsSetup(_assetsSetupComponent);

        Configure(_contexts);

        _systems = new RootSystems(_contexts);
    }

    public void Start()
    {
        _systems.ActivateReactiveSystems();
        _systems.Initialize();
    }

    protected void Update()
    {
        if (_systems == null) return;

        _systems.Execute();
        _systems.Cleanup();
    }

    private void Configure(Contexts contexts)
    {
        contexts.config.ReplaceGenerateCount(10);
    }
}