using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IocPerformance.Adapters
{
    public sealed class UnityContainerAdapter : ContainerAdapterBase
    {
        private UnityContainer container;

        protected override string PackageName
        {
            get { return "Unity"; }
        }

        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
        {
            this.container = new UnityContainer();
            this.container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();

            this.container.RegisterType<ISingleton, Singleton>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ITransient, Transient>(new TransientLifetimeManager());
            this.container.RegisterType<ICombined, Combined>(new TransientLifetimeManager());
            this.container.RegisterType<ICalculator, Calculator>(new TransientLifetimeManager())
              .Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
              .SetInterceptorFor<ICalculator>(new InterfaceInterceptor());
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