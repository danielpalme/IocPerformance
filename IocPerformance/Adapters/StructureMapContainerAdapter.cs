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
                r.For<ITransient>().Singleton().Use<Transient>();
                r.For<ISingleton>().Transient().Use<Singleton>();
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