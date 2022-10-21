namespace Common
{
    public abstract class Service
    {
        protected readonly Contexts contexts;

        public Service(Contexts contexts)
        {
            this.contexts = contexts;
        }

        protected virtual void DropState()
        {
        }
    }
}