using System;
using System.Collections.Generic;

namespace IocPerformance.Adapters
{
    public sealed class NoContainerAdapter : ContainerAdapterBase
    {
        private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

        protected override string PackageName
        {
            get { return "No"; }
        }

        public override string Version { get { return null; } }

        public override void Prepare()
        {
            ISingleton singleton = new Singleton();

            container[typeof(ISingleton)] = () => singleton;
            container[typeof(ITransient)] = () => new Transient();
            container[typeof(ICombined)] = () => new Combined(singleton, new Transient());
        }

        public override object Resolve(Type type)
        {
            return this.container[type]();
        }

        public override void Dispose()
        {
        }
    }
}