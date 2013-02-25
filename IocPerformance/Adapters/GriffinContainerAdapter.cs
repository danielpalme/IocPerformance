using System.Linq;
using System.Xml.Linq;
using Griffin.Container;

namespace IocPerformance.Adapters
{
    public sealed class GriffinContainerAdapter : IContainerAdapter
    {
        private IParentContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Griffin.Container")
                    .Attribute("version").Value;
            }
        }

        public void Prepare()
        {
            var registrar = new ContainerRegistrar();
            registrar.RegisterType<ISingleton, Singleton>(Lifetime.Singleton);
            registrar.RegisterType<ITransient, Transient>(Lifetime.Transient);
            registrar.RegisterType<ICombined, Combined>(Lifetime.Transient);

            this.container = registrar.Build();
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