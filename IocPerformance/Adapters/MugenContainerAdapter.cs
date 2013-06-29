using System;
using IocPerformance.Classes.Standard;
using MugenInjection;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : ContainerAdapterBase
    {
        private MugenInjector container;

        protected override string PackageName
        {
            get { return "MugenInjection"; }
        }

        public override void Prepare()
        {
            this.container = new MugenInjector();

            this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            this.container.Bind<ITransient>().To<Transient>().InTransientScope();
            this.container.Bind<ICombined>().To<Combined>().InTransientScope();
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