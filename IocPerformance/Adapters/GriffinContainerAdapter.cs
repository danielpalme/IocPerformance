using System.Linq;
using System.Xml.Linq;
using Griffin.Container;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class GriffinContainerAdapter : IContainerAdapter
    {
        private IParentContainer container;
        private IParentContainer containerWithLoggingInterception;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Griffin.Container")
                    .Attribute("version").Value;
            }
        }

        // The container is extremly slow, when creating proxies, so it's currently disabled
        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            var registrar = new ContainerRegistrar();
            registrar.RegisterType<ISingleton, Singleton>(Lifetime.Singleton);
            registrar.RegisterType<ITransient, Transient>(Lifetime.Transient);
            registrar.RegisterType<ICombined, Combined>(Lifetime.Transient);

            this.container = registrar.Build();

            registrar = new ContainerRegistrar();
            registrar.RegisterType<ICalculator, Calculator>(Lifetime.Transient);

            var containerWithLoggingInterception = registrar.Build();
            containerWithLoggingInterception.AddDecorator(new GriffinLoggingDecorator());
            this.containerWithLoggingInterception = containerWithLoggingInterception;
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public T ResolveProxy<T>() where T : class
        {
            return this.containerWithLoggingInterception.Resolve<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
            this.containerWithLoggingInterception = null;
        }
    }
}