using System;
using System.Linq;
using System.Xml.Linq;
using Catel.IoC;

namespace IocPerformance.Adapters
{
    public class CatelContainerAdapter : IContainerAdapter
    {
        private IServiceLocator container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Catel.Core")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            var serviceLocator = new ServiceLocator();

            serviceLocator.RegisterType<ISingleton, Singleton>(RegistrationType.Singleton);

            serviceLocator.RegisterType<ITransient, Transient>(RegistrationType.Transient);

            serviceLocator.RegisterType<ICombined, Combined>(RegistrationType.Transient);

            container = serviceLocator;
        }

		public object Resolve(Type type)
		{
			return this.container.ResolveType(type);
		}

		public object ResolveProxy(Type type)
		{
			return this.container.ResolveType(type);
		}

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            container = null;
        }
    }
}