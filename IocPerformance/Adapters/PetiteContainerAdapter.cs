using System;
using IocPerformance.Classes.Standard;
using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "Petite.Container"; }
        }

        public override void Prepare()
        {
            this.container = new Petite.Container();

            this.container.RegisterSingleton<ISingleton>(c => new Singleton());
            this.container.Register<ITransient>(c => new Transient());
            this.container.Register<ICombined>(c => new Combined(
                c.Resolve<ISingleton>(),
                c.Resolve<ITransient>()));
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