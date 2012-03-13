using Funq;

namespace IocPerformance.Adapters
{
    public sealed class FunqContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Funq.Container();
            this.container.Register<IInterface1>(ioc => new Implementation1())
                .ReusedWithin(Funq.ReuseScope.Container);

            this.container.Register<IInterface2>(ioc => new Implementation2())
                .ReusedWithin(Funq.ReuseScope.None);

            this.container.Register<ICombined>(ioc => new Combined(
                ioc.Resolve<IInterface1>(),
                ioc.Resolve<IInterface2>()))
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