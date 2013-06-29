using System;
using Hiro;
using Hiro.Containers;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class HiroContainerAdapter : ContainerAdapterBase
    {
        private IMicroContainer container;

		  public override string PackageName
        {
            get { return "Hiro"; }
        }

        public override void Prepare()
        {
            var map = new DependencyMap();

            map.AddSingletonService<ISingleton, Singleton>();
            map.AddService<ITransient, Transient>();
            map.AddService<ICombined, Combined>();

            this.container = map.CreateContainer();
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type, null);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}