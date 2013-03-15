using System.Linq;
using System.Xml.Linq;
using MugenInjection;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : IContainerAdapter
    {
        private MugenInjector container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "MugenInjection")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new MugenInjector();

            this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            this.container.Bind<ITransient>().To<Transient>().InTransientScope();
            this.container.Bind<ICombined>().To<Combined>().InTransientScope();
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Get<T>();
        }

        public T ResolveProxy<T>() where T : class
        {
            return this.container.Get<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}