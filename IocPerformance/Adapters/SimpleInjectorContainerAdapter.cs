using System.Linq;
using System.Xml.Linq;
using SimpleInjector;

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

        public void Prepare()
        {
            this.container = new SimpleInjector.Container();

            this.container.RegisterSingle<ISingleton, Singleton>();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();

            this.container.Verify();
        }

        public T Resolve<T>() where T : class
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