using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Common
{
    public sealed class ViewSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly IViewService _viewService;

        public ViewSystem(Contexts contexts, Services services) : base(contexts.game)
        {
            _contexts = contexts;
            _viewService = services.ViewService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Asset.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAsset && !entity.isAssetLoaded;
        }
        
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = _viewService.LoadAsset(_contexts, entity);
                entity.RemoveAsset();

                // CopySpecialComponents(view.gameObject, symbolFeedbacks.container.gameObject);
                // symbolFeedbacks.container.gameObject.tag = "draggable";
                // symbolFeedbacks.name = entity.symbol.value.ToString();
                // view.transform.parent = symbolFeedbacks.container;
                // symbolFeedbacks.container.position = entity.initialPosition.value; // set initial position
                // symbolFeedbacks.container.rotation = entity.initialRotation.value;

                // entity.symbol.parentFeedbacks = symbolFeedbacks;
                // var rigidbody = symbolFeedbacks.GetComponentInChildren<Rigidbody>();
                // rigidbody.AddForce(entity.initialForce.value);

                // var symbolModel = view.transform.GetChild(0);
                // view.transform.parent = symbolFeedbacks.transform;
                // symbolFeedbacks.container.parent = view.transform;
                // symbolModel.parent = symbolFeedbacks.container.transform;
                view.transform.position = entity.initialPosition.Value;
                entity.RemoveInitialPosition();
                view.transform.rotation = entity.initialRotation.Value;
                entity.RemoveInitialRotation();
                
                entity.isAssetLoaded = true;
            }
        }
    }
}