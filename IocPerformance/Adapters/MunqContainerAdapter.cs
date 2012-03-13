using Munq;
using Munq.LifetimeManagers;

namespace IocPerformance.Adapters
{
    public sealed class MunqContainerAdapter : IContainerAdapter
    {
        private IocContainer container;

        public void Prepare()
        {
            // I made an optimization here, since Munq allows to do constructor injection. Not only is this
            // the preferable way of doing things, it is faster.
            this.container = new IocContainer();
            this.container.Register<IInterface1, Implementation1>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<IInterface2, Implementation2>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined, Combined>().WithLifetimeManager(new AlwaysNewLifetime());
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