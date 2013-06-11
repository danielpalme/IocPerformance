using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using HaveBox;

namespace IocPerformance.Adapters
{
    public sealed class HaveBoxContainerAdapter : IContainerAdapter
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
                    .First(e => e.Attribute("id").Value == "HaveBox")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new Container();

            this.container.Configure(config => config.For<ISingleton>().Use<Singleton>().AsSingleton());
            this.container.Configure(config => config.For<ITransient>().Use<Transient>());
            this.container.Configure(config => config.For<ICombined>().Use<Combined>());
        }

        public object Resolve(Type type)
        {
            return container.GetInstance(type);
        }

        public object ResolveProxy(Type type)
        {
            return container.GetInstance(type);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}