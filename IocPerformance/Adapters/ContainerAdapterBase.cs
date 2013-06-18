using System;
using System.Linq;
using System.Xml.Linq;

namespace IocPerformance.Adapters
{
    public abstract class ContainerAdapterBase : IContainerAdapter
    {
        public virtual string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == this.PackageName)
                    .Attribute("version").Value;
            }
        }

        protected abstract string PackageName
        {
            get;
        }

        public virtual bool SupportsInterception { get { return false; } }

        public abstract void Prepare();

        public abstract object Resolve(Type type);

        public virtual object ResolveProxy(Type type)
        {
            return this.Resolve(type);
        }

        public abstract void Dispose();
    }
}