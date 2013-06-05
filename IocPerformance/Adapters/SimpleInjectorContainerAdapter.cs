using System;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Interception;
using SimpleInjector;
using SimpleInjector.Extensions.Interception;

namespace IocPerformance.Adapters
{
    public sealed class SimpleInjectorContainerAdapter : IContainerAdapter
    {
        private Container container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "SimpleInjector")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return true; } }

        public void Prepare()
        {
            this.container = new SimpleInjector.Container();

            this.container.RegisterSingle<ISingleton, Singleton>();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Register<ICalculator, Calculator>();

            container.InterceptWith<SimpleInjectorInterceptionLogger>(type => type == typeof(ICalculator));

            this.container.Verify();
        }

		public object Resolve(Type type)
		{
			return this.container.GetInstance(type);
		}

		public object ResolveProxy(Type type)
		{
			return this.container.GetInstance(type);
		}

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}