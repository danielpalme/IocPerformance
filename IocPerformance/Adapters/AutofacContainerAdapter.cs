using System.Linq;
using System.Xml.Linq;
using Autofac;

namespace IocPerformance.Adapters
{
    public sealed class AutofacContainerAdapter : IContainerAdapter
    {
        private IContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Autofac")
                    .Attribute("version").Value;
            }
        }

        public void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.RegisterType<Singleton>()
                    .As<ISingleton>()
                    .SingleInstance();

            autofacContainerBuilder.RegisterType<Transient>()
                    .As<ITransient>();

            autofacContainerBuilder.RegisterType<Combined>()
                    .As<ICombined>();

            this.container = autofacContainerBuilder.Build();
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}