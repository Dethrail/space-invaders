using Entitas;

namespace Common
{
    public interface IView
    {
        GameEntity GetGameEntity();
        void InitializeView(Contexts contexts, IEntity entity);
    }
}