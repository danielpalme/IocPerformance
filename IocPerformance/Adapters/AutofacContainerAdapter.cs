using System;
using System.Linq;
using System.Xml.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class AutofacContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

        protected override string PackageName
        {
            get { return "Autofac"; }
        }

        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
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