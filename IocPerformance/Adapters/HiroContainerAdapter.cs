using Hiro;
using Hiro.Containers;

namespace IocPerformance.Adapters
{
    public sealed class HiroContainerAdapter : IContainerAdapter
    {
        private IMicroContainer container;

        public void Prepare()
        {
            var map = new DependencyMap();

            map.AddSingletonService<IInterface1, Implementation1>();
            map.AddService<IInterface2, Implementation2>();
            map.AddService<ICombined, Combined>();

            this.container = map.CreateContainer();
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