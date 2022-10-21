using Entitas;
using UnityEngine;
using Common;
using Config;

public class GameApplication : MonoBehaviour
{
    private Systems _systems;

    private Contexts _contexts;
    private Services _services;


    [SerializeField] private Config.AssetsSetupComponent _assetsSetupComponent;

    protected void Awake()
    {
        Application.targetFrameRate = 60;
        _contexts = Contexts.sharedInstance;
        _contexts.game.Reset();
        _contexts.config.SetAssetsSetup(_assetsSetupComponent);
        // _contexts.config.ReplaceAssetsSetup(_assetsSetupComponent);

        Configure(_contexts);

        _services = new Services
        {
            ViewService = new UnityViewService(_contexts),
            InputService = new UnityInputService(_contexts, Camera.main),
            TimeService = new UnityTimeService(_contexts),
            EnemyObjectService = new EnemyObjectService(_contexts),
            PlayerObjectService = new PlayerObjectService(_contexts),
        };

        _systems = new RootSystems(_contexts, _services);
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