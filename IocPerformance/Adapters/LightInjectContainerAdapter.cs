using LightInject;

namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : IContainerAdapter
    {
        private IServiceContainer container;

        public void Prepare()
        {
            this.container = new ServiceContainer();
            container.RegisterAsSingleton<IInterface1>(() => new Implementation1());
            container.Register<IInterface2>(c => new Implementation2());
            container.Register<ICombined>(c => new Combined(c.GetInstance<IInterface1>(), c.GetInstance<IInterface2>()));
        }

        public T Resolve<T>() where T : class
        {
            return this.container.GetInstance<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}