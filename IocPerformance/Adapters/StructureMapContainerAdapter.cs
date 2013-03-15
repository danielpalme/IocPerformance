using System.Linq;
using System.Xml.Linq;
using IocPerformance.Interception;
using StructureMap;

namespace IocPerformance.Adapters
{
    public sealed class StructureMapContainerAdapter : IContainerAdapter
    {
        private Container container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "structuremap")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return true; } }

        public void Prepare()
        {
            var pg = new Castle.DynamicProxy.ProxyGenerator();

            this.container = new Container(r =>
            {
                r.For<ISingleton>().Singleton().Use<Singleton>();
                r.For<ITransient>().Transient().Use<Transient>();
                r.For<ICombined>().Transient().Use<Combined>();
                r.For<ICalculator>().Transient().Use<Calculator>()
                    .EnrichWith(c => pg.CreateInterfaceProxyWithTarget<ICalculator>(c, new StructureMapInterceptionLogger()));
            });
        }

        public T Resolve<T>() where T : class
        {
            return this.container.GetInstance<T>();
        }

        public T ResolveProxy<T>() where T : class
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