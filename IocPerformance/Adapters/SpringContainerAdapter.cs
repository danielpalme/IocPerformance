using System;
using Spring.Context;

namespace IocPerformance.Adapters
{
    public sealed class SpringContainerAdapter : ContainerAdapterBase
    {
        private IApplicationContext container;

        protected override string PackageName
        {
            get { return "Spring.Core"; }
        }

        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
        {
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }

        public override object Resolve(Type type)
        {
            return this.container.GetObject(type.FullName);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}