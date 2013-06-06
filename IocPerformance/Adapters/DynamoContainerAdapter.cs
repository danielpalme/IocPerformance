using System;
using System.Linq;
using System.Xml.Linq;
using Dynamo.Ioc;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : IContainerAdapter
    {
        private IocContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Dynamo.Ioc")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new IocContainer(defaultCompileMode: CompileMode.Dynamic);

            this.container.Register<ISingleton, Singleton>().WithContainerLifetime();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Compile();
        }

        public object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public object ResolveProxy(Type type)
        {
            return this.container.Resolve(type);
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}