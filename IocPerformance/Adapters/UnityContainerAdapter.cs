using Microsoft.Practices.Unity;

namespace IocPerformance.Adapters
{
    public sealed class UnityContainerAdapter : IContainerAdapter
    {
        private UnityContainer container;

        public void Prepare()
        {
            this.container = new UnityContainer();

            this.container.RegisterType<ISingleton, Singleton>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ITransient, Transient>(new TransientLifetimeManager());
            this.container.RegisterType<ICombined, Combined>(new TransientLifetimeManager());
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}