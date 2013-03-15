using System.Linq;
using System.Xml.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class WindsorContainerAdapter : IContainerAdapter
    {
        private WindsorContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Castle.Windsor")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return true; } }

        public void Prepare()
        {
            this.container = new WindsorContainer();

            this.container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>());
            this.container.Register(Component.For<ITransient>().ImplementedBy<Transient>().LifeStyle.Transient);
            this.container.Register(Component.For<ICombined>().ImplementedBy<Combined>().LifeStyle.Transient);
            this.container.Register(Component.For<WindsorInterceptionLogger>());
            this.container.Register(Component.For<ICalculator>().ImplementedBy<Calculator>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public T ResolveProxy<T>() where T : class
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