﻿using System;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Classes;
using IocPerformance.Classes.Generated;

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

        public virtual string Name
        {
            get { return this.PackageName; }
        }

        public abstract string PackageName
        {
            get;
        }

        public abstract string Url
        {
            get;
        }

        public virtual bool SupportsInterception
        {
            get { return false; }
        }

        public virtual bool SupportsPropertyInjection
        {
            get { return false; }
        }

        public virtual bool SupportsChildContainer
        {
            get { return false; }
        }

        public virtual bool SupportsConditional
        {
            get { return false; }
        }

        public virtual bool SupportGeneric
        {
            get { return false; }
        }

        public virtual bool SupportsMultiple
        {
            get { return false; }
        }

        public abstract void Prepare();

        public abstract object Resolve(Type type);

        public virtual void Register(InterfaceAndImplemtation[] services)
        {
            throw new NotImplementedException();
        }

        public virtual void RegisterMultiTenant(InterfaceAndImplemtation[] services, int numberOfTenants)
        {
            throw new NotImplementedException();
        }

        public virtual IChildContainerAdapter CreateChildContainerAdapter()
        {
            throw new NotImplementedException();
        }

        public abstract void Dispose();
    }
}