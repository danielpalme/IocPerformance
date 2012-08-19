using TinyIoC;

namespace IocPerformance.Adapters
{
    public sealed class TinyIOCContainerAdapter : IContainerAdapter
    {
        private TinyIoCContainer container;

        public void Prepare()
        {
            this.container = new TinyIoC.TinyIoCContainer();

            this.container.Register<ISingleton, Singleton>().AsSingleton();
            this.container.Register<ITransient, Transient>().AsMultiInstance();
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