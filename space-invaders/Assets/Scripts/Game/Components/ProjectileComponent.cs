using Entitas;

namespace SpaceInvaders.Game
{
    [Game]
    public class ProjectileComponent : IComponent
    {
        public GameEntity TriggeringEntity;
    }
}