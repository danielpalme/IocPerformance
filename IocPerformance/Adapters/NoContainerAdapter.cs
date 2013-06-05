using System;
using System.Collections.Generic;

namespace IocPerformance.Adapters
{
    public sealed class NoContainerAdapter : IContainerAdapter
    {
        private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

        public string Version { get { return null; } }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            ISingleton singleton = new Singleton();

            container[typeof(ISingleton)] = () => singleton;
            container[typeof(ITransient)] = () => new Transient();
            container[typeof(ICombined)] = () => new Combined(singleton, new Transient());
        }

		public object Resolve(Type type)
		{
			return this.container[type]();
		}

		public object ResolveProxy(Type type)
		{
			return this.container[type]();
		}

        public void Dispose()
        {
        }
    }

}