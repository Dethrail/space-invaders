using Entitas;
using System.Collections.Generic;

namespace SpaceInvaders.Game
{
    public class WeaponSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly Config.AssetsSetupComponent _config;

        public WeaponSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _config = contexts.config.assetsSetupEntity.assetsSetup.value;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.FireSignal.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (_contexts.game.isPause)
            {
                return;
            }

            foreach (var e in entities)
            {
                if (e.hasWeapon)
                {
                    var weapon = e.weapon.Value;

                    if (weapon.currentCooldown.Value <= 0)
                    {
                        var projectileEntity = _contexts.game.CreateEntity();
                        projectileEntity.AddProjectile(e);

                        var shipUp = e.view.Value.up;

                        var front = shipUp * _config.ProjectileStartDistance + e.view.Value.position;
                        projectileEntity.ReplaceInitialVelocity(shipUp * _config.ProjectileVelocity);
                        projectileEntity.ReplaceInitialPosition(front);
                        projectileEntity.ReplaceInitialRotation(e.view.Value.rotation);
                        projectileEntity.ReplaceAsset("projectile"); // TODO: check it


                        weapon.ReplaceCurrentCooldown(weapon.cooldownSetting.Value);
                    }
                }

                e.isFireSignal = false;
            }
        }
    }
}