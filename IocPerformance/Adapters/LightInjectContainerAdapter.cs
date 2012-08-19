
namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : IContainerAdapter
    {
        private IServiceContainer container;

        public void Prepare()
        {
            this.container = new ServiceContainer();
            container.Register<ISingleton>(c => new Singleton(), LifeCycleType.Singleton);
            container.Register<ITransient>(c => new Transient(), LifeCycleType.Transient);
            container.Register<ICombined>(c => new Combined(c.GetInstance<ISingleton>(), c.GetInstance<ITransient>()), LifeCycleType.Transient);
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