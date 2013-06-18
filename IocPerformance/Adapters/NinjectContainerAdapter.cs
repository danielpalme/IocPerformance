using System;
using IocPerformance.Interception;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace IocPerformance.Adapters
{
    public sealed class NinjectContainerAdapter : ContainerAdapterBase
    {
        private StandardKernel container;

        protected override string PackageName
        {
            get { return "Ninject"; }
        }

        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
        {
            this.container = new StandardKernel();
            this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            this.container.Bind<ITransient>().To<Transient>().InTransientScope();
            this.container.Bind<ICombined>().To<Combined>().InTransientScope();
            this.container.Bind<ICalculator>().To<Calculator>().InTransientScope()
                .Intercept().With(new NinjectInterceptionLogger());
        }

        public override object Resolve(Type type)
        {
            return this.container.Get(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}