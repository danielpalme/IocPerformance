using System;
using System.Linq;
using System.Xml.Linq;
using Hiro;
using Hiro.Containers;

namespace IocPerformance.Adapters
{
    public sealed class HiroContainerAdapter : IContainerAdapter
    {
        private IMicroContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Hiro")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            var map = new DependencyMap();

            map.AddSingletonService<ISingleton, Singleton>();
            map.AddService<ITransient, Transient>();
            map.AddService<ICombined, Combined>();

            this.container = map.CreateContainer();
        }

        public object Resolve(Type type)
        {
            return this.container.GetInstance(type, null);
        }

        public object ResolveProxy(Type type)
        {
            return this.container.GetInstance(type, null);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}