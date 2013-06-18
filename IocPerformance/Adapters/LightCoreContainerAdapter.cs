using System;
using LightCore;
using LightCore.Lifecycle;

namespace IocPerformance.Adapters
{
    public sealed class LightCoreContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

        protected override string PackageName
        {
            get { return "LightCore"; }
        }

        public override void Prepare()
        {
            var builder = new ContainerBuilder();

            builder.Register<ISingleton, Singleton>().ControlledBy<SingletonLifecycle>();
            builder.Register<ITransient, Transient>().ControlledBy<TransientLifecycle>();
            builder.Register<ICombined, Combined>().ControlledBy<TransientLifecycle>();

            this.container = builder.Build();
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