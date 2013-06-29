using System;
using System.Linq;
using System.Xml.Linq;
using Catel.IoC;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public class CatelContainerAdapter : ContainerAdapterBase
    {
        private IServiceLocator container;

        protected override string PackageName
        {
            get { return "Catel.Core"; }
        }

        public override void Prepare()
        {
            var serviceLocator = new ServiceLocator();

            serviceLocator.RegisterType<ISingleton, Singleton>(RegistrationType.Singleton);

            serviceLocator.RegisterType<ITransient, Transient>(RegistrationType.Transient);

            serviceLocator.RegisterType<ICombined, Combined>(RegistrationType.Transient);

            container = serviceLocator;
        }

        public override object Resolve(Type type)
        {
            return this.container.ResolveType(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            container = null;
        }
    }
}