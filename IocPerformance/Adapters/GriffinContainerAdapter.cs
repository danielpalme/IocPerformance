using Griffin.Container;

namespace IocPerformance.Adapters
{
    public sealed class GriffinContainerAdapter : IContainerAdapter
    {
        private IParentContainer container;

        public void Prepare()
        {
            var registrar = new ContainerRegistrar();
            registrar.RegisterType<ITransient, Transient>(Lifetime.Singleton);
            registrar.RegisterType<ISingleton, Singleton>(Lifetime.Transient);
            registrar.RegisterType<ICombined, Combined>(Lifetime.Transient);

            this.container = registrar.Build();
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