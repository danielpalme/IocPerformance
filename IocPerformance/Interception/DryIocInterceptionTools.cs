using System;
using Castle.DynamicProxy;

namespace DryIoc.Interception
{
    // Extension methods for interceptor registration using Castle Dynamic Proxy.
    public static class DryIocInterceptionTools
    {
        public static void RegisterInterfaceInterceptor<TService, TInterceptor>(this IRegistrator registrator)
            where TInterceptor : class, IInterceptor
        {
            var serviceType = typeof(TService);
            if (!serviceType.IsInterface)
                throw new ArgumentException($"Intercepted service type {serviceType} is not an interface");

            var proxyType = ProxyBuilder.Value.CreateInterfaceProxyTypeWithTargetInterface(
                serviceType, ArrayTools.Empty<Type>(), ProxyGenerationOptions.Default);

            registrator.Register(serviceType, proxyType,
                made: Parameters.Of.Type<IInterceptor[]>(typeof(TInterceptor[])),
                setup: Setup.Decorator);
        }

        private static readonly Lazy<DefaultProxyBuilder> ProxyBuilder = new Lazy<DefaultProxyBuilder>(() => new DefaultProxyBuilder());
    }
}