using SimpleInjector;

namespace IocPerformance.Adapters
{
    public sealed class SimpleInjectorContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new SimpleInjector.Container();

            this.container.RegisterSingle<IInterface1, Implementation1>();
            this.container.Register<IInterface2, Implementation2>();
            this.container.Register<ICombined, Combined>();

            this.container.Verify();
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