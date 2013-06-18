using System;
using TinyIoC;

namespace IocPerformance.Adapters
{
    public sealed class TinyIOCContainerAdapter : ContainerAdapterBase
    {
        private TinyIoCContainer container;

        protected override string PackageName
        {
            get { return "TinyIoC"; }
        }

        public override void Prepare()
        {
            this.container = new TinyIoC.TinyIoCContainer();

            this.container.Register<ISingleton, Singleton>().AsSingleton();
            this.container.Register<ITransient, Transient>().AsMultiInstance();
            this.container.Register<ICombined, Combined>().AsMultiInstance();
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