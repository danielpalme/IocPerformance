using System;

namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : ContainerAdapterBase
    {
        private IServiceContainer container;

        protected override string PackageName
        {
            get { return "LightInject"; }
        }

        public override void Prepare()
        {
            this.container = new ServiceContainer();
            container.Register<ISingleton>(c => new Singleton(), new PerContainerLifetime());
            container.Register<ITransient>(c => new Transient(), new PerRequestLifeTime());
            container.Register<ICombined>(c => new Combined(c.GetInstance<ISingleton>(), c.GetInstance<ITransient>()), new PerRequestLifeTime());
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