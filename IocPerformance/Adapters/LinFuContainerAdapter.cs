using LinFu.IoC;

namespace IocPerformance.Adapters
{
    public sealed class LinFuContainerAdapter : IContainerAdapter
    {
        private LinFu.IoC.ServiceContainer container;

        public void Prepare()
        {
            this.container = new LinFu.IoC.ServiceContainer();
            this.container.Inject<ISingleton>().Using<Singleton>().AsSingleton();
            this.container.Inject<ITransient>().Using<Transient>().OncePerRequest();
            this.container.Inject<ICombined>().Using<Combined>().OncePerRequest();
        }

        public T Resolve<T>() where T : class
        {
            return this.container.GetService<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}