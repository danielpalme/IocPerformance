using Dynamo.Ioc;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Container();

            this.container.Register<ISingleton, Singleton>().WithLifetime(Lifetime.Container());
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Compile();
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