using Dynamo.Ioc;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : IContainerAdapter
    {
        private Container container;

        public void Prepare()
        {
            this.container = new Container();

            this.container.Register<IInterface1, Implementation1>().WithLifetime(Lifetime.Container());
            this.container.Register<IInterface2, Implementation2>();
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