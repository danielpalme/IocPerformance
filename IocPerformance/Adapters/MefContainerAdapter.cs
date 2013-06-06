using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace IocPerformance.Adapters
{
    public sealed class MefContainerAdapter : IContainerAdapter
    {
        private CompositionContainer container;

        public string Version
        {
            get { return typeof(CompositionContainer).Assembly.GetName().Version.ToString(); }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            var catalog = new TypeCatalog(typeof(Singleton), typeof(Transient), typeof(Combined));
            this.container = new CompositionContainer(catalog);
        }

		public object Resolve(Type type)
		{
			return this.container.GetExports(type, null, null).First().Value;
		}

		public object ResolveProxy(Type type)
		{
			return this.container.GetExports(type, null, null).First().Value;
		}

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}
