using System;
using System.Reflection;
using Funq;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class FunqContainerAdapter : ContainerAdapterBase
    {
        private Container container;
        private MethodInfo methodInfo;

        protected override string PackageName
        {
            get { return "Funq"; }
        }

        public override string Version
        {
            get { return typeof(Container).Assembly.GetName().Version.ToString(); }
        }

        public override void Prepare()
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
            methodInfo = pointer.Method.GetGenericMethodDefinition();
        }

        public override object Resolve(Type type)
        {
            // It only provides a generic Resolve<>() method.
            var genericMethod = methodInfo.MakeGenericMethod(new Type[] { type });
            return genericMethod.Invoke(container, new object[] { });
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}