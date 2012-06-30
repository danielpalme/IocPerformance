using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Petite.Container();

            this.container.RegisterSingleton<ITransient>(c => new Transient());
            this.container.Register<ISingleton>(c => new Singleton());
            this.container.Register<ICombined>(c => new Combined(
                c.Resolve<ITransient>(),
                c.Resolve<ISingleton>()));
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