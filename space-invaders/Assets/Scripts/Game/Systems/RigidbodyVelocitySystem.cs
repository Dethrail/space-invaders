using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RigidbodyVelocitySystem : ReactiveSystem<GameEntity>
{
    public RigidbodyVelocitySystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Velocity.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasView)
            {
                var rigidbody = e.view.Value.GetComponent<Rigidbody>();
                rigidbody.velocity = e.velocity.Value;
                e.RemoveVelocity();
            }
            else
            {
                Debug.LogError("[VelocitySystem] Velocity should have view object!");
            }
        }
    }
}