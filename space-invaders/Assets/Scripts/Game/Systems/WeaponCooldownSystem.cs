using System.Linq;

namespace SpaceInvaders.Game
{
    using Entitas;

    public class WeaponCooldownSystem : IExecuteSystem
    {
        private Contexts _contexts;

        public WeaponCooldownSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            if (_contexts.game.isPause)
            {
                return;
            }

            var weapons = _contexts.game.GetGroup(GameMatcher.Weapon).GetEntities().Select(x=>x.weapon.Value);

            foreach (var gameEntity in weapons)
            {
                if (!gameEntity.hasCurrentCooldown)
                {
                    gameEntity.ReplaceCurrentCooldown(0);
                }

                gameEntity.ReplaceCurrentCooldown(gameEntity.currentCooldown.Value - _contexts.input.deltaTime.Value);
            }
        }
    }
}