using System;
using IocPerformance.Classes.Standard;
using Speedioc;
using Speedioc.Core;
using Speedioc.Registration;

namespace IocPerformance.Adapters
{
    public sealed class SpeediocContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

		  public override string PackageName
        {
            get { return "Speedioc"; }
        }

        public override void Prepare()
        {
            ContainerSettings settings = new DefaultContainerSettings("Speedioc");
            settings.ForceCompile = true;

            IRegistry registry = new Registry();

            registry.Register<Singleton>().As<ISingleton>().WithLifetime(Lifetime.Container).PreCreateInstance();
            registry.Register<Transient>().As<ITransient>().WithLifetime(Lifetime.Transient);
            registry.Register<Combined>().As<ICombined>().WithLifetime(Lifetime.Transient)
                .UsingConstructor()
                .WithResolvedParameter<ISingleton>()
                .WithResolvedParameter<ITransient>()
                .AsLastParameter();

            IContainerBuilder containerBuilder = DefaultContainerBuilderFactory.GetInstance(settings, registry);
            container = containerBuilder.Build();
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}