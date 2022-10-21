using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Common
{
    public sealed class ViewSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        private readonly GameObject _playerPrefab;
        private readonly GameObject _enemyPrefab;

        private Transform _root;

        public ViewSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;

            var assetConfig = contexts.config.assetsSetup.value;

            _playerPrefab = assetConfig.Player;
            _enemyPrefab = assetConfig.EnemyShip;
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
                var view = LoadAsset(_contexts, entity);
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

        private void AddView(Contexts ctx, GameEntity ge, GameObject go)
        {
            ge.AddView(go.transform);
            var view = go.GetComponent<IView>();
            if (view != null)
            {
                view.InitializeView(ctx, ge);
            }
            else
            {
                Debug.Log("No view");
            }
        }

        public GameObject LoadAsset(Contexts ctx, GameEntity ge)
        {
            if (_root == null)
            {
                _root = new GameObject("view root").transform;
            }

            switch (ge.asset.Value)
            {
                case "enemy":
                {
                    if (!ge.hasInitialPosition || !ge.hasInitialRotation || !ge.hasAsset)
                    {
                        throw new Exception("Every instantiated GO through View Service should contain all init params");
                    }

                    var viewObject = UnityEngine.Object.Instantiate(_enemyPrefab, _root);
                    AddView(ctx, ge, viewObject);
                    return viewObject;
                }
                case "player":
                {
                    var viewObject = UnityEngine.Object.Instantiate(_playerPrefab, _root);
                    AddView(ctx, ge, viewObject);
                    return viewObject;
                }
                default:
                {
                    throw new Exception("Could not load asset");
                }
            }

            // if (ge.hasSocket) {
            //     //TODO: move to ecs
            //     var letterSlotMatched = Resources.Load<GameObject>(LETTER_SLOT_MATCHED);
            //     var letterSlotNotMatched = Resources.Load<GameObject>(LETTER_SLOT_NOT_MATCHED);
            //
            //     var socketView = viewObject.AddComponent<SocketView>();
            //     socketView.Symbol = viewObject.transform.Find(SYMBOL_GO_NAME).gameObject;
            //     socketView.LetterSlotMatched = UnityEngine.Object.Instantiate(letterSlotMatched, _root);
            //     socketView.LetterSlotNotMatched = UnityEngine.Object.Instantiate(letterSlotNotMatched, _root);
            //
            //     socketView.Init(viewObject.transform);
            //     //
            //
            //     if (ge.socket != null && ge.socket.isFitted) {
            //         socketView.OnMatched();
            //     }
            // }
            // throw new Exception("Could not load asset");
            // throw new NullReferenceException(string.Format(PatchToSymbolPrefab, ge.asset.Value));
        }
    }
}