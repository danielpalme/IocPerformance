using Spring.Context;

namespace IocPerformance.Adapters
{
    public sealed class SpringContainerAdapter : IContainerAdapter
    {
        private IApplicationContext container;

        public void Prepare()
        {
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }

        public T Resolve<T>() where T : class
        {
            return (T)container.GetObject(typeof(T).FullName);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}