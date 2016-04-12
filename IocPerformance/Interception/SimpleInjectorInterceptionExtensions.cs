using System;
using Castle.DynamicProxy;

namespace SimpleInjector.Extensions.Interception
{
    // Extension methods for interceptor registration using Castle Dynamic Proxy.
    public static class SimpleInjectorInterceptorExtensions
    {
        private static readonly DefaultProxyBuilder builder = new DefaultProxyBuilder();

        public static void InterceptWith<TService, TInterceptor>(this Container container)
            where TService : class
            where TInterceptor : class, IInterceptor
        {
            var serviceType = typeof(TService);
            if (!serviceType.IsInterface)
                throw new ArgumentException($"Intercepted service type {serviceType} is not an interface");

            var decoratorType = builder.CreateInterfaceProxyTypeWithTargetInterface(
                serviceType, Type.EmptyTypes, ProxyGenerationOptions.Default);

            // Decorator with ctor params: (IInterceptor[], TService)
            container.RegisterDecorator(serviceType, decoratorType);

            // Registration that maps TInterceptor to IInterceptor[].
            var interceptorArrayRegistration = Lifestyle.Transient.CreateRegistration(typeof(IInterceptor[]),
                () => new IInterceptor[] { container.GetInstance<TInterceptor>() },
                container);

            // Inject TInterceptor in the decorator.
            container.RegisterConditional(typeof(IInterceptor[]), interceptorArrayRegistration,
                c => c.Consumer.ImplementationType == decoratorType);
        }
    }
}