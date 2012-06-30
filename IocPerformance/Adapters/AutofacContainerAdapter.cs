using Autofac;

namespace IocPerformance.Adapters
{
    public sealed class AutofacContainerAdapter : IContainerAdapter
    {
        private IContainer container;

        public void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.RegisterType<Transient>()
                    .As<ITransient>()
                    .SingleInstance();

            autofacContainerBuilder.RegisterType<Singleton>()
                    .As<ISingleton>();

            autofacContainerBuilder.RegisterType<Combined>()
                    .As<ICombined>();

            this.container = autofacContainerBuilder.Build();
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