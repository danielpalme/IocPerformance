using StructureMap;

namespace IocPerformance.Adapters
{
    public sealed class StructureMapContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Container(r =>
            {
                r.For<ISingleton>().Singleton().Use<Singleton>();
                r.For<ITransient>().Transient().Use<Transient>();
                r.For<ICombined>().Transient().Use<Combined>();
            });
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