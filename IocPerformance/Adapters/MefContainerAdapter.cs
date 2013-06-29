using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class MefContainerAdapter : ContainerAdapterBase
    {
        private CompositionContainer container;

		  public override string PackageName
        {
            get { return "Mef"; }
        }

        public override string Version
        {
            get { return typeof(CompositionContainer).Assembly.GetName().Version.ToString(); }
        }

        public override void Prepare()
        {
            var catalog = new TypeCatalog(typeof(Singleton), typeof(Transient), typeof(Combined));
            this.container = new CompositionContainer(catalog);
        }

        public override object Resolve(Type type)
        {
            return this.container.GetExports(type, null, null).First().Value;
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}
