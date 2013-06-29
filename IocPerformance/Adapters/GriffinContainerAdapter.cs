using System;
using Griffin.Container;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class GriffinContainerAdapter : ContainerAdapterBase
    {
        private IParentContainer container;
        private IParentContainer containerWithLoggingInterception;

        protected override string PackageName
        {
            get { return "Griffin.Container"; }
        }

        // The container is extremly slow, when creating proxies, so it's currently disabled
        public override bool SupportsInterception { get { return false; } }

        public override void Prepare()
        {
            var registrar = new ContainerRegistrar();
            registrar.RegisterType<ISingleton, Singleton>(Lifetime.Singleton);
            registrar.RegisterType<ITransient, Transient>(Lifetime.Transient);
            registrar.RegisterType<ICombined, Combined>(Lifetime.Transient);

            this.container = registrar.Build();

            registrar = new ContainerRegistrar();
            registrar.RegisterType<ICalculator, Calculator>(Lifetime.Transient);

            var containerWithLoggingInterception = registrar.Build();
            containerWithLoggingInterception.AddDecorator(new GriffinLoggingDecorator());
            this.containerWithLoggingInterception = containerWithLoggingInterception;
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override object ResolveProxy(Type type)
        {
            return this.containerWithLoggingInterception.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
            this.containerWithLoggingInterception = null;
        }
    }
}