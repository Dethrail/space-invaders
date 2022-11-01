using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class BorderStoppingSystem : ReactiveSystem<GameEntity>
    {
        private float _leftBorderValue;
        private float _rightBorderValue;

        public BorderStoppingSystem(Contexts contexts) : base(contexts.game)
        {
            _leftBorderValue = contexts.config.assetsSetup.value.LeftBorderX;
            _rightBorderValue = contexts.config.assetsSetup.value.RightBorderX;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                if (e.isPlayer)
                {
                    var playerRigidbody = e.view.Value.GetComponent<Rigidbody>();
                    var velocity = playerRigidbody.velocity;
                    var movingLeft = velocity.x < 0;
                    var movingRight = velocity.x > 0;

                    if (_leftBorderValue > e.position.Value.x && movingLeft)
                    {
                        playerRigidbody.velocity = Vector3.zero;
                    }

                    if (_rightBorderValue < e.position.Value.x && movingRight)
                    {
                        playerRigidbody.velocity = Vector3.zero;
                    }
                }
            }
        }
    }
}