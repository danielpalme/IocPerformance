using System.Linq;
using System.Xml.Linq;
using Speedioc;
using Speedioc.Core;
using Speedioc.Registration;

namespace IocPerformance.Adapters
{
    public sealed class SpeediocContainerAdapter : IContainerAdapter
    {
        private IContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Speedioc")
                    .Attribute("version").Value;
            }
        }
        public bool SupportsInterception { get { return false; } }

        public void Prepare()
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

        public T Resolve<T>() where T : class
        {
            return this.container.GetInstance<T>();
        }

        public T ResolveProxy<T>() where T : class
        {
            return this.container.GetInstance<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}