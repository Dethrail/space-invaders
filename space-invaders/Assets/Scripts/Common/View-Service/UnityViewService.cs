using System;
using UnityEngine;

namespace Common
{
    public sealed class UnityViewService : Service, IViewService
    {
        // private const string PatchToSymbolPrefab = "Prefabs/{0}";
        // var enemy = Resources.Load<GameObject>(string.Format(PatchToSymbolPrefab, ge.asset.Value));

        private readonly GameObject _playerPrefab;
        private readonly GameObject _enemyPrefab;

        private Transform _root;

        public UnityViewService(Contexts contexts) : base(contexts)
        {
            var assetConfig = contexts.config.assetsSetup.value;

            _playerPrefab = assetConfig.Player;
            _enemyPrefab = assetConfig.EnemyShip;
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

                    var viewObject = UnityEngine.Object.Instantiate(_enemyPrefab, ge.initialPosition.Value,
                        ge.initialRotation.Value, _root);
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