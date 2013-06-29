using System;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using SimpleInjector;
using SimpleInjector.Extensions.Interception;

namespace IocPerformance.Adapters
{
    public sealed class SimpleInjectorContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        protected override string PackageName
        {
            get { return "SimpleInjector"; }
        }

        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
        {
            this.container = new SimpleInjector.Container();

            this.container.RegisterSingle<ISingleton, Singleton>();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Register<ICalculator, Calculator>();

            container.InterceptWith<SimpleInjectorInterceptionLogger>(type => type == typeof(ICalculator));

            this.container.Verify();
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}