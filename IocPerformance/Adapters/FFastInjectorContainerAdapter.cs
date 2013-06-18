using System;
using System.Linq;
using System.Xml.Linq;
using fFastInjector;

namespace IocPerformance.Adapters
{
    public sealed class FFastInjectorContainerAdapter : ContainerAdapterBase
    {
        protected override string PackageName
        {
            get { return "fFastInjector"; }
        }

        public override void Prepare()
        {
            var singleton = new Singleton();

            Injector.SetResolver<ISingleton>(() => singleton);
            Injector.SetResolver<ITransient, Transient>();
            Injector.SetResolver<ICombined, Combined>();
        }

        public override object Resolve(Type type)
        {
            return Injector.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
        }
    }
}