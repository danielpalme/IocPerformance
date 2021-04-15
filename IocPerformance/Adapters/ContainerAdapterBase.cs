using System;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Classes.AspNet;
using Microsoft.Extensions.DependencyInjection;

namespace IocPerformance.Adapters
{
    public abstract class ContainerAdapterBase : IContainerAdapter
    {
        public virtual string Version
        {
            get
            {
                return XDocument
                   .Load("../../IocPerformance.csproj")
                   .Root
                   .Descendants("PackageReference")
                   .First(e => e.Attribute("Include").Value == this.PackageName)
                   .Attribute("Version").Value;
            }
        }

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

        public virtual bool SupportAspNetCore => false;

        public virtual bool SupportsConditional => false;

        public virtual bool SupportGeneric => false;

        public virtual bool SupportsMultiple => false;

        public virtual bool SupportsTransient => true;

        public virtual bool SupportsCombined => true;

        public virtual bool SupportsBasic => true;

        public virtual bool SupportsPrepareAndRegister => true;

        public abstract void PrepareBasic();

        public override string ToString()
        {
            return this.Name;
        }

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

        protected void RegisterAspNetCoreClasses(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<TestController1>();
            serviceCollection.AddTransient<TestController2>();
            serviceCollection.AddTransient<TestController3>();
            serviceCollection.AddTransient<IRepositoryTransient1, RepositoryTransient1>();
            serviceCollection.AddTransient<IRepositoryTransient2, RepositoryTransient2>();
            serviceCollection.AddTransient<IRepositoryTransient3, RepositoryTransient3>();
            serviceCollection.AddTransient<IRepositoryTransient4, RepositoryTransient4>();
            serviceCollection.AddTransient<IRepositoryTransient5, RepositoryTransient5>();
            serviceCollection.AddScoped<IScopedService1, ScopedService1>();
            serviceCollection.AddScoped<IScopedService2, ScopedService2>();
            serviceCollection.AddScoped<IScopedService3, ScopedService3>();
            serviceCollection.AddScoped<IScopedService4, ScopedService4>();
            serviceCollection.AddScoped<IScopedService5, ScopedService5>();
        }
    }
}