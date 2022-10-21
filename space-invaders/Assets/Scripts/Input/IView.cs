using Entitas;

namespace Common
{
    public interface IView
    {
        void InitializeView(Contexts contexts, IEntity entity);
    }
}