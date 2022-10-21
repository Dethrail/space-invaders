using UnityEngine;

namespace Common
{
    public sealed class PlayerObjectService : Service
    {
        private int _entityCounter;

        public PlayerObjectService(Contexts contexts) : base(contexts)
        {
            // TODO: ID from static generator
            _entityCounter = 1000;
        }

        protected override void DropState()
        {
            _entityCounter = 1000;
        }

        public void CreateDefaultSocket(char c, Vector3 position, bool fitted)
        {
            var entity = contexts.game.CreateEntity();
            // entity.AddSocket(c, fitted);
            // entity.AddId(_entityCounter);
            // entity.AddAsset(c.ToString());
            // entity.AddInitialPosition(position);
        
            _entityCounter++;
        }
    }
}
