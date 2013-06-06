using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using HaveBox;

namespace IocPerformance.Adapters
{
    public sealed class HaveBoxContainerAdapter : IContainerAdapter
    {
        private Container container;
        private MethodInfo _methodInfo;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "HaveBox")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new Container();

            this.container.Configure(config => config.For<ISingleton>().Use<Singleton>().AsSingleton());
            this.container.Configure(config => config.For<ITransient>().Use<Transient>());
            this.container.Configure(config => config.For<ICombined>().Use<Combined>());

            Func<Object> pointer = container.GetInstance<Object>;
            _methodInfo = pointer.Method.GetGenericMethodDefinition();
        }

        public object Resolve(Type type)
        {
            // It only provides a generic GetInstance<>() method.
            var genericMethod = _methodInfo.MakeGenericMethod(new Type[] { type });
            return genericMethod.Invoke(container, new object[] { });
        }

        public object ResolveProxy(Type type)
        {
            // It only provides a generic GetInstance<>() method.
            var genericMethod = _methodInfo.MakeGenericMethod(new Type[] { type });
            return genericMethod.Invoke(container, new object[] { });
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}