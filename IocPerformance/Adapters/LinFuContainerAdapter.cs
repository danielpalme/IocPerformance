using System;
using LinFu.IoC;

namespace IocPerformance.Adapters
{
    public sealed class LinFuContainerAdapter : ContainerAdapterBase
    {
        private LinFu.IoC.ServiceContainer container;

        protected override string PackageName
        {
            get { return "LinFu.Core"; }
        }

        public override void Prepare()
        {
            this.container = new LinFu.IoC.ServiceContainer();
            this.container.Inject<ISingleton>().Using<Singleton>().AsSingleton();
            this.container.Inject<ITransient>().Using<Transient>().OncePerRequest();
            this.container.Inject<ICombined>().Using<Combined>().OncePerRequest();
            this.container.Inject<ICalculator>().Using<Calculator>().OncePerRequest();
        }

        public override object Resolve(Type type)
        {
            return this.container.GetService(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}