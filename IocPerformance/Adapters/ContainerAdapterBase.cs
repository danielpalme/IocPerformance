using System;
using System.Linq;
using System.Xml.Linq;

namespace IocPerformance.Adapters
{
    public abstract class ContainerAdapterBase : IContainerAdapter
    {
        public virtual string Version => XDocument
      .Load("packages.config")
      .Root
      .Elements()
      .First(e => e.Attribute("id").Value == this.PackageName)
      .Attribute("version").Value;

        public virtual string Name => this.PackageName;

        public abstract string PackageName
        {
            get;
        }

        public abstract string Url
        {
            get;
        }

        public virtual bool SupportsInterception => false;

        public virtual bool SupportsPropertyInjection => false;

        public virtual bool SupportsChildContainer => false;

        public virtual bool SupportsConditional => false;

        public virtual bool SupportGeneric => false;

        public virtual bool SupportsMultiple => false;

        public virtual bool SupportsBasic
        {
            get { return true; }
        }

        public abstract void PrepareBasic();
        
        public virtual void Prepare()
        {
            this.PrepareBasic(); // by default any prepare should at least support basic one
        }

        public abstract object Resolve(Type type);

        public virtual IChildContainerAdapter CreateChildContainerAdapter()
        {
            throw new NotImplementedException();
        }

        public abstract void Dispose();
    }
}