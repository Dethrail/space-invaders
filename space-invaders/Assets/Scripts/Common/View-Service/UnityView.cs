// using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Common
{
    public class UnityView : MonoBehaviour, IView, IGameDestroyedListener
    {
        private GameEntity _entity;

        public void InitializeView(Contexts contexts, IEntity entity)
        {
            _entity = (GameEntity)entity;
            _entity.AddGameDestroyedListener(this);

            // if (_entity.hasSymbol) {
            //     var r = GetComponentInChildren<MeshRenderer>();
            //     var material = r.material;
            //     var oldColor = material.color;
            //     var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
            //
            //     r.material = Instantiate(material);
            //     r.material.DOColor(newColor, 1f);
            // }

#if UNITY_EDITOR
            gameObject.Link(entity);
#endif
        }

        public void OnDestroyed(GameEntity entity)
        {
#if UNITY_EDITOR
            if (gameObject.GetEntityLink()?.entity != null) {
                gameObject.Unlink();
            }
#endif
            Destroy(gameObject);
        }
    }
}
