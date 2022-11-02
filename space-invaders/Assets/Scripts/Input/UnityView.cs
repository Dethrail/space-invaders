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
            _entity = (GameEntity) entity;
            _entity.AddGameDestroyedListener(this);
            
#if UNITY_EDITOR
            gameObject.Link(entity);
#endif
        }
#if UNITY_EDITOR
        public void Update()
        {
            // DrawPositioningGraph();
        }

        /// <summary>
        /// Giving method to check how interpolation looks and check how is moving of objects are smooth
        /// </summary>
        private void DrawPositioningGraph()
        {
            if (!_entity.hasMovingGraph)
            {
                _entity.ReplaceMovingGraph(new AnimationCurve());
            }

            var kf = new Keyframe(Time.time, transform.position.y, 0, 0, 0, 0);
            _entity.movingGraph.Value.AddKey(kf);
        }
#endif

        public void OnDestroyed(GameEntity entity)
        {
#if UNITY_EDITOR
            if (gameObject.GetEntityLink()?.entity != null)
            {
                gameObject.Unlink();
            }
#endif
            Destroy(gameObject);
        }
    }
}