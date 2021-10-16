using System;
using Castle.DynamicProxy;
using Pure.DI;
using System.Diagnostics;
using System.Linq;
using Expression = System.Linq.Expressions.Expression;
using IInterceptor = Castle.DynamicProxy.IInterceptor;
using IProxyBuilder = Castle.DynamicProxy.IProxyBuilder;

namespace IocPerformance.Interception
{
    [Include(@"\.+Calculator\d$")]
    public sealed class PureDiInterceptionLogger<T> : IFactory<T>, IInterceptor
    {
        private readonly Func<T, T> proxyFactory;

        public PureDiInterceptionLogger(IProxyBuilder proxyBuilder) => 
            proxyFactory = CreateProxyFactory(proxyBuilder, this);

        private static Func<T, T> CreateProxyFactory(IProxyBuilder proxyBuilder, params IInterceptor[] interceptors)
        {
            var proxyType = proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(T), Type.EmptyTypes, ProxyGenerationOptions.Default);
            var ctor = proxyType.GetConstructors().Single(i => i.GetParameters().Length == 2);
            var instance = Expression.Parameter(typeof(T));
            var newProxyExpression = Expression.New(ctor, Expression.Constant(interceptors), instance);
            return Expression.Lambda<Func<T, T>>(newProxyExpression, instance).Compile();
        }

        public T Create(Func<T> factory, Type implementationType, object tag) => 
            proxyFactory(factory());

        void IInterceptor.Intercept(IInvocation invocation)
        {
            Debug.WriteLine("Pure.DI: {0}({1})", invocation.Method, string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString())));
            invocation.Proceed();
        }
    }
}