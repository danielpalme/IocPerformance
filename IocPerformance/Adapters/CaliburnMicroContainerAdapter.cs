using System;
using Caliburn.Micro;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class CaliburnMicroContainer : ContainerAdapterBase
    {
        private SimpleContainer container;

        protected override string PackageName
        {
            get { return "Caliburn.Micro.Container"; }
        }

        public override void Prepare()
        {
            this.container = new SimpleContainer();

            this.container.RegisterSingleton(typeof(ISingleton), null, typeof(Singleton));
            this.container.RegisterHandler(typeof(ITransient), null, (ioc) => new Transient());
            this.container.RegisterHandler(typeof(ICombined), null, (ioc) => new Combined(
                (ISingleton)ioc.GetInstance(typeof(ISingleton), null),
                (ITransient)ioc.GetInstance(typeof(ITransient), null)));
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