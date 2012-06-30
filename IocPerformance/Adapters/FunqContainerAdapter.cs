using Funq;

namespace IocPerformance.Adapters
{
    public sealed class FunqContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Funq.Container();
            this.container.Register<ITransient>(ioc => new Transient())
                .ReusedWithin(Funq.ReuseScope.Container);

            this.container.Register<ISingleton>(ioc => new Singleton())
                .ReusedWithin(Funq.ReuseScope.None);

            this.container.Register<ICombined>(ioc => new Combined(
                ioc.Resolve<ITransient>(),
                ioc.Resolve<ISingleton>()))
                .ReusedWithin(Funq.ReuseScope.None);
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