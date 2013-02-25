using System.Linq;
using System.Xml.Linq;
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

        public void Prepare()
        {
            this.container = new Container(r =>
            {
                r.For<ISingleton>().Singleton().Use<Singleton>();
                r.For<ITransient>().Transient().Use<Transient>();
                r.For<ICombined>().Transient().Use<Combined>();
            });
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