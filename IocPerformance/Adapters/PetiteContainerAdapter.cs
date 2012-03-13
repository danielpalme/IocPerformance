using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Petite.Container();

            this.container.RegisterSingleton<IInterface1>(c => new Implementation1());
            this.container.Register<IInterface2>(c => new Implementation2());
            this.container.Register<ICombined>(c => new Combined(
                c.Resolve<IInterface1>(),
                c.Resolve<IInterface2>()));
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