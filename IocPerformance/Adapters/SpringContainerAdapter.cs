using System;
using System.Linq;
using System.Xml.Linq;
using Spring.Context;

namespace IocPerformance.Adapters
{
    public sealed class SpringContainerAdapter : IContainerAdapter
    {
        private IApplicationContext container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Spring.Core")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return true; } }

        public void Prepare()
        {
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }

        public object Resolve(Type type)
        {
            return this.container.GetObject(type.FullName);
        }

        public object ResolveProxy(Type type)
        {
            return this.container.GetObject(type.FullName);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}