using System;
using Spring.Context;

namespace IocPerformance.Adapters
{
    public sealed class SpringContainerAdapter : ContainerAdapterBase
    {
        private IApplicationContext container;

        public override string Name
        {
            get { return "Spring.NET"; }
        }

        public override string PackageName
        {
            get { return "Spring.Core"; }
        }

        public override string Url
        {
            get { return "http://www.springframework.net/"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
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

        public override void Prepare()
        {
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }
    }
}