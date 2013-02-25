using Funq;

namespace IocPerformance.Adapters
{
    public sealed class FunqContainerAdapter : IContainerAdapter
    {
        private Container container;

        public string Version
        {
            get { return typeof(Container).Assembly.GetName().Version.ToString(); }
        }

        public void Prepare()
        {
            this.container = new Funq.Container();
            this.container.Register<ISingleton>(ioc => new Singleton())
                .ReusedWithin(Funq.ReuseScope.Container);

            this.container.Register<ITransient>(ioc => new Transient())
                .ReusedWithin(Funq.ReuseScope.None);

            this.container.Register<ICombined>(ioc => new Combined(
                ioc.Resolve<ISingleton>(),
                ioc.Resolve<ITransient>()))
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