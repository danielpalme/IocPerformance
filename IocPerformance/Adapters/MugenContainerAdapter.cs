using MugenInjection;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : IContainerAdapter
    {
        private MugenInjector container;

        public void Prepare()
        {
            this.container = new MugenInjector();

            this.container.Bind<IInterface1>().To<Implementation1>().InSingletonScope();
            this.container.Bind<IInterface2>().To<Implementation2>().InTransientScope();
            this.container.Bind<ICombined>().To<Combined>().InTransientScope();
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Get<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}