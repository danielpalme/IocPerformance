using System.Linq;
using System.Xml.Linq;
using LinFu.IoC;

namespace IocPerformance.Adapters
{
    public sealed class LinFuContainerAdapter : IContainerAdapter
    {
        private LinFu.IoC.ServiceContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "LinFu.Core")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new LinFu.IoC.ServiceContainer();
            this.container.Inject<ISingleton>().Using<Singleton>().AsSingleton();
            this.container.Inject<ITransient>().Using<Transient>().OncePerRequest();
            this.container.Inject<ICombined>().Using<Combined>().OncePerRequest();
            this.container.Inject<ICalculator>().Using<Calculator>().OncePerRequest();
        }

        public T Resolve<T>() where T : class
        {
            return this.container.GetService<T>();
        }

        public T ResolveProxy<T>() where T : class
        {
            return this.container.GetService<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}