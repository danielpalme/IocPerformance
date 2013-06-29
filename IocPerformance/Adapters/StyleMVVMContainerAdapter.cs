using System;
using IocPerformance.Classes.Standard;
using StyleMVVM.DependencyInjection;
using StyleMVVM.DependencyInjection.Impl;

namespace IocPerformance.Adapters
{
    public class StyleMVVMContainerAdapter : ContainerAdapterBase
    {
        private IDependencyInjectionContainer container;

        protected override string PackageName
        {
            get { return "StyleMVVM"; }

        }

        public override void Prepare()
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

        public override object Resolve(Type type)
        {
            return container.LocateByType(type);
        }

        public override void Dispose()
        {
            // Shutdown the container
            container.Shutdown();

            // Release container from memory
            container = null;
        }
    }
}
