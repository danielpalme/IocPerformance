using TinyIoC;

namespace IocPerformance.Adapters
{
    public sealed class TinyIOCContainerAdapter : IContainerAdapter
    {
        private TinyIoCContainer container;

        public void Prepare()
        {
            this.container = new TinyIoC.TinyIoCContainer();

            this.container.Register<IInterface1, Implementation1>().AsSingleton();
            this.container.Register<IInterface2, Implementation2>().AsMultiInstance();
            this.container.Register<ICombined, Combined>().AsMultiInstance();
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