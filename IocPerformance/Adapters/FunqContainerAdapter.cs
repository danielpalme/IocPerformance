using System;
using System.Reflection;
using Funq;

namespace IocPerformance.Adapters
{
    public sealed class FunqContainerAdapter : IContainerAdapter
    {
        private Container container;
		private MethodInfo _methodInfo;

        public string Version
        {
            get { return typeof(Container).Assembly.GetName().Version.ToString(); }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            this.container = new Funq.Container();
            this.container.Register<ISingleton>(ioc => new Singleton())
                .ReusedWithin(Funq.ReuseScope.Container);

            this.container.Register<ITransient>(ioc => new Transient())
                .ReusedWithin(Funq.ReuseScope.None);

            this.container.Register<ICombined>(ioc => new Combined(
                ioc.Resolve<ISingleton>(),
                ioc.Resolve<ITransient>()))
                .ReusedWithin(Funq.ReuseScope.None);

			Func<Object> pointer = container.Resolve<Object>;
			_methodInfo = pointer.Method.GetGenericMethodDefinition();
        }

		public object Resolve(Type type)
		{
			// It only provides a generic Resolve<>() method.
			var genericMethod = _methodInfo.MakeGenericMethod(new Type[] { type });
			return genericMethod.Invoke(container, new object[] { });
		}

		public object ResolveProxy(Type type)
		{
			// It only provides a generic Resolve<>() method.
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