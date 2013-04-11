using System;
using System.Collections.Generic;
using IocPerformance.Interception;

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

        public T Resolve<T>() where T : class
        {
            return (T)this.container[typeof(T)]();
        }

        public T ResolveProxy<T>() where T : class
        {
            return (T)this.container[typeof(T)]();
        }

        public void Dispose()
        {
        }
    }

}