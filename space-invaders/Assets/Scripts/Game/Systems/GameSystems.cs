using Common;

namespace SpaceInvaders.Game
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts, Services services)
        {
            Add(new LevelSystem(contexts, services));
            // Add(new ViewSystem(contexts, services));
            //
            // Add(new DragSystem(contexts));
            // Add(new GameRestartSystem(contexts));
            //
            // Add(new AnyWordMatchEventSystem(contexts));
            // Add(new BoosterStreakSystem(contexts));
            // Add(new TimeFreezeSystem(contexts));
            // Add(new MagnifyingSystem(contexts));
            // Add(new MagnetSystem(contexts));
            // Add(new LampSystem(contexts));
            //
            // Add(new AlignmentSymbolSystem(contexts));
            // Add(new DeckMatchSystem(contexts));
            // Add(new GameDestroyedEventSystem(contexts));
            Add(new LevelTickUpdateSystem(contexts));
            Add(new DestroyEntitySystem(contexts));
        }
    }
}