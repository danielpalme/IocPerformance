using System.Linq;
using System.Xml.Linq;
using fFastInjector;

namespace IocPerformance.Adapters
{
    public sealed class FFastInjectorContainerAdapter : IContainerAdapter
    {
        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "fFastInjector")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            var singleton = new Singleton();

            Injector.SetResolver<ISingleton>(() => singleton);
            Injector.SetResolver<ITransient, Transient>();
            Injector.SetResolver<ICombined, Combined>();
        }

        public T Resolve<T>() where T : class
        {
            return Injector.Resolve<T>();
        }

        public T ResolveProxy<T>() where T : class
        {
            return Injector.Resolve<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
        }
    }
}