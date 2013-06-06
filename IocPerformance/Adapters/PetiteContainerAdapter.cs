using System;
using System.Linq;
using System.Xml.Linq;
using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : IContainerAdapter
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
                    .First(e => e.Attribute("id").Value == "Petite.Container")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new Petite.Container();

            this.container.RegisterSingleton<ISingleton>(c => new Singleton());
            this.container.Register<ITransient>(c => new Transient());
            this.container.Register<ICombined>(c => new Combined(
                c.Resolve<ISingleton>(),
                c.Resolve<ITransient>()));
        }

        public object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public object ResolveProxy(Type type)
        {
            return this.container.Resolve(type);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}