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

        public void Prepare()
        {
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }

        public T Resolve<T>() where T : class
        {
            return (T)container.GetObject(typeof(T).FullName);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}