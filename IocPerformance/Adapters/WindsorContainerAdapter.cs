using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class WindsorContainerAdapter : ContainerAdapterBase
    {
        private WindsorContainer container;

		  public override string PackageName
        {
            get { return "Castle.Windsor"; }
        }

        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
        {
            this.container = new WindsorContainer();

            this.container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>());
            this.container.Register(Component.For<ITransient>().ImplementedBy<Transient>().LifeStyle.Transient);
            this.container.Register(Component.For<ICombined>().ImplementedBy<Combined>().LifeStyle.Transient);
            this.container.Register(Component.For<WindsorInterceptionLogger>());
            this.container.Register(Component.For<ICalculator>().ImplementedBy<Calculator>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}