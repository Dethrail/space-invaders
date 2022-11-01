using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Entitas;
using UnityEngine;

public sealed class PlayerControlSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _gameContext;

    private GameEntity _player;
    private readonly Config.AssetsSetupComponent _assetsSetupComponent;

    public PlayerControlSystem(Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _assetsSetupComponent = contexts.config.assetsSetup.value;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.KeyHoldingTime.Added(), InputMatcher.KeyReleased.Added());
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (_player != null)
        {
            foreach (var e in entities)
            {
                if (e.hasKeyStartedHolding)
                {
                    if (e.keyStartedHolding.Value == KeyCode.LeftArrow)
                    {
                        var velocity = Vector3.left * _assetsSetupComponent.PlayerVelocityMultiplier;
                        var worldVelocity = _player.view.Value.TransformVector(velocity);
                        if (_player.hasVelocity)
                        {
                            worldVelocity += _player.velocity.Value;
                        }

                        _player.ReplaceVelocity(worldVelocity);
                    }

                    if (e.keyStartedHolding.Value == KeyCode.RightArrow)
                    {
                        var velocity = Vector3.right * _assetsSetupComponent.PlayerVelocityMultiplier;
                        var worldVelocity = _player.view.Value.TransformVector(velocity);
                        if (_player.hasVelocity)
                        {
                            worldVelocity += _player.velocity.Value;
                        }

                        _player.ReplaceVelocity(worldVelocity);
                    }
                }

                if (e.hasKeyReleased)
                {
                    if (e.keyReleased.Value == KeyCode.LeftArrow)
                    {
                        var velocity = Vector3.zero;
                        var worldVelocity = _player.view.Value.TransformVector(velocity);
                        if (_player.hasVelocity)
                        {
                            worldVelocity -= _player.velocity.Value;
                        }

                        _player.ReplaceVelocity(worldVelocity);
                    }

                    if (e.keyReleased.Value == KeyCode.RightArrow)
                    {
                        var velocity = Vector3.zero;
                        var worldVelocity = _player.view.Value.TransformVector(velocity);
                        if (_player.hasVelocity)
                        {
                            worldVelocity -= _player.velocity.Value;
                        }

                        _player.ReplaceVelocity(worldVelocity);
                    }
                }
            }
        }
        else
        {
            _player = _gameContext.GetGroup(GameMatcher.Player).GetEntities().FirstOrDefault();
        }
    }
}