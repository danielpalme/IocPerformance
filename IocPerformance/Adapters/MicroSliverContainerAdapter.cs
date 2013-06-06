using System;
using System.Linq;
using System.Xml.Linq;
using MicroSliver;

namespace IocPerformance.Adapters
{
    public sealed class MicroSliverContainerAdapter : IContainerAdapter
    {
        private IoC container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "MicroSliver")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new IoC();
            this.container.Map<ISingleton, Singleton>().ToSingletonScope();
            this.container.Map<ITransient, Transient>();
            this.container.Map<ICombined, Combined>();
        }

        public object Resolve(Type type)
        {
            return this.container.GetByType(type);
        }

        public object ResolveProxy(Type type)
        {
            return this.container.GetByType(type);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}