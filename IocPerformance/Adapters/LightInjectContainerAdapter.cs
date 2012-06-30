using LightInject;

namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : IContainerAdapter
    {
        private IServiceContainer container;

        public void Prepare()
        {
            this.container = new ServiceContainer();
            container.RegisterAsSingleton<ITransient>(() => new Transient());
            container.Register<ISingleton>(c => new Singleton());
            container.Register<ICombined>(c => new Combined(c.GetInstance<ITransient>(), c.GetInstance<ISingleton>()));
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