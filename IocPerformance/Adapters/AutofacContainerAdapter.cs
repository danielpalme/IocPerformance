using System.Linq;
using System.Xml.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using IocPerformance.Interception;

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

        public bool SupportsInterception { get { return true; } }

        public void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

            autofacContainerBuilder.RegisterType<Singleton>()
                    .As<ISingleton>()
                    .SingleInstance();

            autofacContainerBuilder.RegisterType<Transient>()
                    .As<ITransient>();

            autofacContainerBuilder.RegisterType<Combined>()
                    .As<ICombined>();

            autofacContainerBuilder.RegisterType<Calculator>()
                    .As<ICalculator>()
                    .EnableInterfaceInterceptors();
            
            this.container = autofacContainerBuilder.Build();
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public T ResolveProxy<T>() where T : class
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