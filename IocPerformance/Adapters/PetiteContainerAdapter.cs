using System.Linq;
using System.Xml.Linq;
using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : IContainerAdapter
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
                    .First(e => e.Attribute("id").Value == "Petite.Container")
                    .Attribute("version").Value;
            }
        }

        public void Prepare()
        {
            this.container = new Petite.Container();

            this.container.RegisterSingleton<ISingleton>(c => new Singleton());
            this.container.Register<ITransient>(c => new Transient());
            this.container.Register<ICombined>(c => new Combined(
                c.Resolve<ISingleton>(),
                c.Resolve<ITransient>()));
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}