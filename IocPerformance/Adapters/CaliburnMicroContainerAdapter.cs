using System.Linq;
using System.Xml.Linq;
using Caliburn.Micro;

namespace IocPerformance.Adapters
{
    public sealed class CaliburnMicroContainer : IContainerAdapter
    {
        private SimpleContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Caliburn.Micro.Container")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new SimpleContainer();

            this.container.RegisterSingleton(typeof(ISingleton), null, typeof(Singleton));
            this.container.RegisterHandler(typeof(ITransient), null, (ioc) => new Transient());
            this.container.RegisterHandler(typeof(ICombined), null, (ioc) => new Combined(
                (ISingleton)ioc.GetInstance(typeof(ISingleton), null),
                (ITransient)ioc.GetInstance(typeof(ITransient), null)));
        }

        public T Resolve<T>() where T : class
        {
            return (T)this.container.GetInstance(typeof(T), null);
        }

        public T ResolveProxy<T>() where T : class
        {
            return (T)this.container.GetInstance(typeof(T), null);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}