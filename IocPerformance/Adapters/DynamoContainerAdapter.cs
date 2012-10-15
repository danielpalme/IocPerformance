using Dynamo.Ioc;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : IContainerAdapter
    {
        private IocContainer container;

        public void Prepare()
        {
            this.container = new IocContainer(defaultCompileMode: CompileMode.Dynamic);

            this.container.Register<ISingleton, Singleton>().WithContainerLifetime();
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