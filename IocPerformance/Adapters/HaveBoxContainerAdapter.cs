using System;
using HaveBox;

namespace IocPerformance.Adapters
{
    public sealed class HaveBoxContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        protected override string PackageName
        {
            get { return "HaveBox"; }
        }

        public override void Prepare()
        {
            this.container = new Container();

            this.container.Configure(config => config.For<ISingleton>().Use<Singleton>().AsSingleton());
            this.container.Configure(config => config.For<ITransient>().Use<Transient>());
            this.container.Configure(config => config.For<ICombined>().Use<Combined>());
        }

        public override object Resolve(Type type)
        {
            return container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}