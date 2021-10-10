using System;
using Castle.DynamicProxy;
using Pure.DI;
using System.Diagnostics;
using System.Linq;

namespace IocPerformance.Interception
{
    [Include(@".+\.Calculator\d{1}$")]
    public sealed class PureDiInterceptionLogger : IFactory, IInterceptor
    {
        private readonly IProxyGenerator proxyGenerator;
        private readonly IInterceptor[] interceptors;

        public PureDiInterceptionLogger(IProxyGenerator proxyGenerator)
        {
            this.proxyGenerator = proxyGenerator;
            interceptors = new IInterceptor[] { this };
        }

        public T Create<T>(Func<T> factory, Type implementationType, object tag) =>
            (T)proxyGenerator.CreateInterfaceProxyWithTargetInterface(typeof(T), factory(), interceptors);

        void IInterceptor.Intercept(IInvocation invocation)
        {
            Debug.WriteLine("Pure.DI: {0}({1})", invocation.Method, string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString())));
            invocation.Proceed();
        }
    }
}