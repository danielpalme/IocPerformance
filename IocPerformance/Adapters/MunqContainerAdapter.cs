using System;
using IocPerformance.Classes.Standard;
using Munq;
using Munq.LifetimeManagers;

namespace IocPerformance.Adapters
{
    public sealed class MunqContainerAdapter : ContainerAdapterBase
    {
        private IocContainer container;

        protected override string PackageName
        {
            get { return "Munq.IocContainer"; }
        }

        public override void Prepare()
        {
            this.container = new IocContainer();
            this.container.Register<ISingleton, Singleton>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ITransient, Transient>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined, Combined>().WithLifetimeManager(new AlwaysNewLifetime());
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