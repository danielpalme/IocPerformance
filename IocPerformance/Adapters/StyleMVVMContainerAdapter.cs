using System;
using System.Linq;
using System.Xml.Linq;
using StyleMVVM.DependencyInjection;
using StyleMVVM.DependencyInjection.Impl;

namespace IocPerformance.Adapters
{
    public class StyleMVVMContainerAdapter : IContainerAdapter
    {
        private IDependencyInjectionContainer container;

        public string Version
        {
            get
            {
                return XDocument
                     .Load("packages.config")
                     .Root
                     .Elements()
                     .First(e => e.Attribute("id").Value == "StyleMVVM")
                     .Attribute("version").Value;
            }
        }

        public bool SupportsInterception
        {
            get { return false; }
        }

        public void Prepare()
        {
            container = new DependencyInjectionContainer();

            // Register all needed types out of StyleMVVM.DotNet
            container.RegisterAssembly(typeof(DependencyInjectionContainer).Assembly);

            // Remove extra XAML based exports that aren't need (MVVM classes and what not)
            container.RemoveXAMLExports();

            // Register local exports
            container.Register<Singleton>().As<ISingleton>().AndSharedPermenantly();
            container.Register<Transient>().As<ITransient>();
            container.Register<Combined>().As<ICombined>().ImportConstructor(() => new Combined(null, null));

            container.Start();
        }

        public object Resolve(Type type)
        {
            return container.LocateByType(type);
        }

        public object ResolveProxy(Type type)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Shutdown the container
            container.Shutdown();

            // Release container from memory
            container = null;
        }
    }
}
