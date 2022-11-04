using Common;

namespace SpaceInvaders.Game
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new WeaponCooldownSystem(contexts));
            Add(new WeaponSystem(contexts));
            Add(new ViewUpdateSystem(contexts));
            Add(new RigidbodyVelocitySystem(contexts));
            Add(new LevelSystem(contexts));
            Add(new ViewSystem(contexts));

            Add(new GameDestroyedEventSystem(contexts));
            Add(new LevelTickUpdateSystem(contexts));
            Add(new PlayerControlSystem(contexts));

            Add(new BorderStoppingSystem(contexts));
            Add(new DestroyEntitySystem(contexts));
            Add(new AbortGameSystem(contexts));
        }
    }
}