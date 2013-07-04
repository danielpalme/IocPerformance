/*****************************************************************************   
   Copyright 2013 bernhard.richter@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************
   LightInject version 3.0.0.6 
   http://www.lightinject.net/
   http://twitter.com/bernhardrichter
******************************************************************************/
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "No inheritance")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Single source file deployment.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:FileMustHaveHeader", Justification = "Custom header.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "All public members are documented.")]

namespace IocPerformance
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    /// <summary>
    /// Defines a set of methods used to register services into the service container.
    /// </summary>
    internal interface IServiceRegistry
    {
        /// <summary>
        /// Gets a list of <see cref="ServiceRegistration"/> instances that represents the 
        /// registered services.          
        /// </summary>
        IEnumerable<ServiceRegistration> AvailableServices { get; }

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        void Register(Type serviceType, Type implementingType);

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register(Type serviceType, Type implementingType, ILifetime lifetime);

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        /// <param name="serviceName">The name of the service.</param>
        void Register(Type serviceType, Type implementingType, string serviceName);

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register(Type serviceType, Type implementingType, string serviceName, ILifetime lifetime);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        void Register<TService, TImplementation>() where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register<TService, TImplementation>(ILifetime lifetime) where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        /// <param name="serviceName">The name of the service.</param>
        void Register<TService, TImplementation>(string serviceName) where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register<TService, TImplementation>(string serviceName, ILifetime lifetime) where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the given <paramref name="instance"/>. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="instance">The instance returned when this service is requested.</param>
        void Register<TService>(TService instance);

        /// <summary>
        /// Registers a concrete type as a service.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        void Register<TService>();

        /// <summary>
        /// Registers a concrete type as a service.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register<TService>(ILifetime lifetime);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the given <paramref name="instance"/>. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="instance">The instance returned when this service is requested.</param>
        /// <param name="serviceName">The name of the service.</param>
        void Register<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="factory"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="factory">A factory delegate used to create the <typeparamref name="TService"/> instance.</param>    
        void Register<TService>(Expression<Func<IServiceFactory, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="expression"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="expression">The lambdaExpression that describes the dependencies of the service.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register<TService>(Expression<Func<IServiceFactory, TService>> expression, ILifetime lifetime);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="expression"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="expression">The lambdaExpression that describes the dependencies of the service.</param>
        /// <param name="serviceName">The name of the service.</param>        
        void Register<TService>(Expression<Func<IServiceFactory, TService>> expression, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="expression"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="expression">The lambdaExpression that describes the dependencies of the service.</param>
        /// <param name="serviceName">The name of the service.</param>        
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register<TService>(Expression<Func<IServiceFactory, TService>> expression, string serviceName, ILifetime lifetime);

        /// <summary>
        /// Registers a custom factory delegate used to create services that is otherwise unknown to the service container.
        /// </summary>
        /// <param name="predicate">Determines if the service can be created by the <paramref name="factory"/> delegate.</param>
        /// <param name="factory">Creates a service instance according to the <paramref name="predicate"/> predicate.</param>
        void Register(Func<Type, string, bool> predicate, Func<ServiceRequest, object> factory);

        /// <summary>
        /// Registers a custom factory delegate used to create services that is otherwise unknown to the service container.
        /// </summary>
        /// <param name="predicate">Determines if the service can be created by the <paramref name="factory"/> delegate.</param>
        /// <param name="factory">Creates a service instance according to the <paramref name="predicate"/> predicate.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        void Register(Func<Type, string, bool> predicate, Func<ServiceRequest, object> factory, ILifetime lifetime);

        /// <summary>
        /// Registers a service based on a <see cref="ServiceRegistration"/> instance.
        /// </summary>
        /// <param name="serviceRegistration">The <see cref="ServiceRegistration"/> instance that contains service metadata.</param>
        void Register(ServiceRegistration serviceRegistration);

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>        
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        void RegisterAssembly(Assembly assembly);

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>
        /// <param name="shouldRegister">A function delegate that determines if a service implementation should be registered.</param>
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        void RegisterAssembly(Assembly assembly, Func<Type, Type, bool> shouldRegister);

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        void RegisterAssembly(Assembly assembly, Func<ILifetime> lifetime);

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>
        /// <param name="lifetimeFactory">The <see cref="ILifetime"/> factory that controls the lifetime of the registered service.</param>
        /// <param name="shouldRegister">A function delegate that determines if a service implementation should be registered.</param>
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        void RegisterAssembly(Assembly assembly, Func<ILifetime> lifetimeFactory, Func<Type, Type, bool> shouldRegister);

        /// <summary>
        /// Registers services from assemblies in the base directory that matches the <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="searchPattern">The search pattern used to filter the assembly files.</param>
        void RegisterAssembly(string searchPattern);

        /// <summary>
        /// Decorates the <paramref name="serviceType"/> with the given <paramref name="decoratorType"/>.
        /// </summary>
        /// <param name="serviceType">The target service type.</param>
        /// <param name="decoratorType">The decorator type used to decorate the <paramref name="serviceType"/>.</param>
        /// <param name="predicate">A function delegate that determines if the <paramref name="decoratorType"/>
        /// should be applied to the target <paramref name="serviceType"/>.</param>
        void Decorate(Type serviceType, Type decoratorType, Func<ServiceRegistration, bool> predicate);

        /// <summary>
        /// Decorates the <paramref name="serviceType"/> with the given <paramref name="decoratorType"/>.
        /// </summary>
        /// <param name="serviceType">The target service type.</param>
        /// <param name="decoratorType">The decorator type used to decorate the <paramref name="serviceType"/>.</param>        
        void Decorate(Type serviceType, Type decoratorType);

        /// <summary>
        /// Decorates the <typeparamref name="TService"/> using the given decorator <paramref name="factory"/>.
        /// </summary>
        /// <typeparam name="TService">The target service type.</typeparam>
        /// <param name="factory">A factory delegate used to create a decorator instance.</param>
        void Decorate<TService>(Expression<Func<IServiceFactory, TService, TService>> factory);
    }

    /// <summary>
    /// Defines a set of methods used to retrieve service instances.
    /// </summary>
    internal interface IServiceFactory
    {
        /// <summary>
        /// Gets an instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <returns>The requested service instance.</returns>
        object GetInstance(Type serviceType);

        /// <summary>
        /// Gets a named instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance.</returns>
        object GetInstance(Type serviceType, string serviceName);

        /// <summary>
        /// Gets an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <returns>The requested service instance.</returns>
        TService GetInstance<TService>();

        /// <summary>
        /// Gets a named instance of the given <typeparamref name="TService"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance.</returns>    
        TService GetInstance<TService>(string serviceName);

        /// <summary>
        /// Gets an instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <returns>The requested service instance if available, otherwise null.</returns>
        object TryGetInstance(Type serviceType);

        /// <summary>
        /// Gets a named instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance if available, otherwise null.</returns>
        object TryGetInstance(Type serviceType, string serviceName);

        /// <summary>
        /// Tries to get an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <returns>The requested service instance if available, otherwise default(T).</returns>
        TService TryGetInstance<TService>();

        /// <summary>
        /// Tries to get an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance if available, otherwise default(T).</returns>
        TService TryGetInstance<TService>(string serviceName);

        /// <summary>
        /// Gets all instances of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of services to resolve.</param>
        /// <returns>A list that contains all implementations of the <paramref name="serviceType"/>.</returns>
        IEnumerable<object> GetAllInstances(Type serviceType);

        /// <summary>
        /// Gets all instances of type <typeparamref name="TService"/>.
        /// </summary>
        /// <typeparam name="TService">The type of services to resolve.</typeparam>
        /// <returns>A list that contains all implementations of the <typeparamref name="TService"/> type.</returns>
        IEnumerable<TService> GetAllInstances<TService>();
    }

    /// <summary>
    /// Represents an inversion of control container.
    /// </summary>
    internal interface IServiceContainer : IServiceRegistry, IServiceFactory, IDisposable
    {
        /// <summary>
        /// Returns <b>true</b> if the container can create the requested service, otherwise <b>false</b>.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns><b>true</b> if the container can create the requested service, otherwise <b>false</b>.</returns>
        bool CanGetInstance(Type serviceType, string serviceName);

        /// <summary>
        /// Starts a new <see cref="Scope"/>.
        /// </summary>
        /// <returns><see cref="Scope"/></returns>
        Scope BeginScope();

        /// <summary>
        /// Injects the property dependencies for a given <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">The target instance for which to inject its property dependencies.</param>
        /// <returns>The <paramref name="instance"/> with its property dependencies injected.</returns>
        object InjectProperties(object instance);
    }

    /// <summary>
    /// Represents a class that manages the lifetime of a service instance.
    /// </summary>
    internal interface ILifetime
    {
        /// <summary>
        /// Returns a service instance according to the specific lifetime characteristics.
        /// </summary>
        /// <param name="createInstance">The function delegate used to create a new service instance.</param>
        /// <param name="scope">The <see cref="Scope"/> of the current service request.</param>
        /// <returns>The requested services instance.</returns>
        object GetInstance(Func<object> createInstance, Scope scope);
    }

    /// <summary>
    /// Represents a class that acts as a composition root for an <see cref="IServiceRegistry"/> instance.
    /// </summary>
    internal interface ICompositionRoot
    {
        /// <summary>
        /// Composes services by adding services to the <paramref name="serviceRegistry"/>.
        /// </summary>
        /// <param name="serviceRegistry">The target <see cref="IServiceRegistry"/>.</param>
        void Compose(IServiceRegistry serviceRegistry);
    }

    /// <summary>
    /// Represents a class that is responsible for selecting injectable properties.
    /// </summary>
    internal interface IPropertySelector
    {
        /// <summary>
        /// Selects properties that represents a dependency from the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> for which to select the properties.</param>
        /// <returns>A list of injectable properties.</returns>
        IEnumerable<PropertyInfo> Execute(Type type);
    }

    /// <summary>
    /// Represents a class that is responsible for selecting the property dependencies for a given <see cref="Type"/>.
    /// </summary>
    internal interface IPropertyDependencySelector
    {
        /// <summary>
        /// Selects the property dependencies for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> for which to select the property dependencies.</param>
        /// <returns>A list of <see cref="PropertyDependency"/> instances that represents the property
        /// dependencies for the given <paramref name="type"/>.</returns>
        IEnumerable<PropertyDependency> Execute(Type type);
    }

    /// <summary>
    /// Represents a class that is responsible for selecting the constructor dependencies for a given <see cref="ConstructorInfo"/>.
    /// </summary>
    internal interface IConstructorDependencySelector
    {
        /// <summary>
        /// Selects the constructor dependencies for the given <paramref name="constructor"/>.
        /// </summary>
        /// <param name="constructor">The <see cref="ConstructionInfo"/> for which to select the constructor dependencies.</param>
        /// <returns>A list of <see cref="ConstructorDependency"/> instances that represents the constructor
        /// dependencies for the given <paramref name="constructor"/>.</returns>
        IEnumerable<ConstructorDependency> Execute(ConstructorInfo constructor);
    }

    /// <summary>
    /// Represents a class that is capable of building a <see cref="ConstructorInfo"/> instance 
    /// based on a <see cref="Registration"/>.
    /// </summary>
    internal interface IConstructionInfoBuilder
    {
        /// <summary>
        /// Returns a <see cref="ConstructionInfo"/> instance based on the given <see cref="Registration"/>.
        /// </summary>
        /// <param name="registration">The <see cref="Registration"/> for which to return a <see cref="ConstructionInfo"/> instance.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance that describes how to create a service instance.</returns>
        ConstructionInfo Execute(Registration registration);
    }

    /// <summary>
    /// Represents a class that keeps track of a <see cref="ConstructionInfo"/> instance for each <see cref="Registration"/>.
    /// </summary>
    internal interface IConstructionInfoProvider
    {
        /// <summary>
        /// Gets a <see cref="ConstructionInfo"/> instance for the given <paramref name="registration"/>.
        /// </summary>
        /// <param name="registration">The <see cref="Registration"/> for which to get a <see cref="ConstructionInfo"/> instance.</param>
        /// <returns>The <see cref="ConstructionInfo"/> instance that describes how to create an instance of the given <paramref name="registration"/>.</returns>
        ConstructionInfo GetConstructionInfo(Registration registration);

        /// <summary>
        /// Invalidates the <see cref="IConstructionInfoProvider"/> and causes new <see cref="ConstructionInfo"/> instances 
        /// to be created when the <see cref="GetConstructionInfo"/> method is called.
        /// </summary>
        void Invalidate();
    }

    /// <summary>
    /// Represents a class that builds a <see cref="ConstructionInfo"/> instance based on a <see cref="LambdaExpression"/>.
    /// </summary>
    internal interface ILambdaConstructionInfoBuilder
    {
        /// <summary>
        /// Parses the <paramref name="lambdaExpression"/> and returns a <see cref="ConstructionInfo"/> instance.
        /// </summary>
        /// <param name="lambdaExpression">The <see cref="LambdaExpression"/> to parse.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance.</returns>
        ConstructionInfo Execute(LambdaExpression lambdaExpression);
    }

    /// <summary>
    /// Represents a class that builds a <see cref="ConstructionInfo"/> instance based on the implementing <see cref="Type"/>.
    /// </summary>
    internal interface ITypeConstructionInfoBuilder
    {
        /// <summary>
        /// Analyzes the <paramref name="implementingType"/> and returns a <see cref="ConstructionInfo"/> instance.
        /// </summary>
        /// <param name="implementingType">The <see cref="Type"/> to analyze.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance.</returns>
        ConstructionInfo Execute(Type implementingType);
    }

    /// <summary>
    /// Represents a class that selects the constructor to be used for creating a new service instance. 
    /// </summary>
    internal interface IConstructorSelector
    {
        /// <summary>
        /// Selects the constructor to be used when creating a new instance of the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="implementingType">The <see cref="Type"/> for which to return a <see cref="ConstructionInfo"/>.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance that represents the constructor to be used
        /// when creating a new instance of the <paramref name="implementingType"/>.</returns>
        ConstructorInfo Execute(Type implementingType);
    }

    /// <summary>
    /// Represents a class that is responsible loading a set of assemblies based on the given search pattern.
    /// </summary>
    internal interface IAssemblyLoader
    {
        /// <summary>
        /// Loads a set of assemblies based on the given <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="searchPattern">The search pattern to use.</param>
        /// <returns>A list of assemblies based on the given <paramref name="searchPattern"/>.</returns>
        IEnumerable<Assembly> Load(string searchPattern);
    }

    /// <summary>
    /// Represents a class that is capable of scanning an assembly and register services into an <see cref="IServiceContainer"/> instance.
    /// </summary>
    internal interface IAssemblyScanner
    {
        /// <summary>
        /// Scans the target <paramref name="assembly"/> and registers services found within the assembly.
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly"/> to scan.</param>        
        /// <param name="serviceRegistry">The target <see cref="IServiceRegistry"/> instance.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        /// <param name="shouldRegister">A function delegate that determines if a service implementation should be registered.</param>
        void Scan(Assembly assembly, IServiceRegistry serviceRegistry, Func<ILifetime> lifetime, Func<Type, Type, bool> shouldRegister);
    }

    /// <summary>
    /// Represents a dynamic method skeleton for emitting the code needed to resolve a service instance.
    /// </summary>
    internal interface IMethodSkeleton
    {
        /// <summary>
        /// Gets the <see cref="ILGenerator"/> for the this dynamic method.
        /// </summary>
        /// <returns>The <see cref="ILGenerator"/> for the this dynamic method</returns>
        ILGenerator GetILGenerator();

        /// <summary>
        /// Creates a delegate used to invoke this method.
        /// </summary>
        /// <returns>A delegate used to invoke this method.</returns>
        Func<object[], object> CreateDelegate();
    }

    internal static class TypeHelper
    {
        public static Delegate CreateDelegate(this MethodInfo methodInfo, Type delegateType, object target)
        {
            return Delegate.CreateDelegate(delegateType, target, methodInfo);
        }

        public static bool IsClass(Type type)
        {
            return type.IsClass;
        }

        public static bool IsAbstract(Type type)
        {
            return type.IsAbstract;
        }

        public static bool IsNestedPrivate(Type type)
        {
            return type.IsNestedPrivate;
        }

        public static bool IsGenericType(Type type)
        {
            return type.IsGenericType;
        }

        public static bool ContainsGenericParameters(Type type)
        {
            return type.ContainsGenericParameters;
        }

        public static Type GetBaseType(Type type)
        {
            return type.BaseType;
        }

        public static bool IsGenericTypeDefinition(Type type)
        {
            return type.IsGenericTypeDefinition;
        }

        public static MethodInfo GetSetMethod(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetSetMethod();
        }

        public static MethodInfo GetGetMethod(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetGetMethod();
        }

        public static Type[] GetTypes(this Assembly assembly)
        {
            return assembly.GetTypes();
        }

        public static Assembly GetAssembly(Type type)
        {
            return type.Assembly;
        }

        public static bool IsValueType(Type type)
        {
            return type.IsValueType;
        }
    }

    /// <summary>
    /// An ultra lightweight service container.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ServiceContainer : IServiceContainer
    {
        private const string UnresolvedDependencyError = "Unresolved dependency {0}";
        private readonly Func<IMethodSkeleton> methodSkeletonFactory;
        private readonly ServiceRegistry<Action<IMethodSkeleton>> emitters = new ServiceRegistry<Action<IMethodSkeleton>>();
        private readonly ServiceRegistry<Action<IMethodSkeleton, Type>> openGenericEmitters = new ServiceRegistry<Action<IMethodSkeleton, Type>>();
        private readonly DelegateRegistry<Type> delegates = new DelegateRegistry<Type>();
        private readonly DelegateRegistry<Tuple<Type, string>> namedDelegates = new DelegateRegistry<Tuple<Type, string>>();
        private readonly DelegateRegistry<Type> propertyInjectionDelegates = new DelegateRegistry<Type>();
        private readonly Storage<object> constants = new Storage<object>();
        private readonly Storage<FactoryRule> factoryRules = new Storage<FactoryRule>();
        private readonly Stack<Action<IMethodSkeleton>> dependencyStack = new Stack<Action<IMethodSkeleton>>();
        private readonly ThreadSafeDictionary<Tuple<Type, string>, ServiceRegistration> availableServices =
            new ThreadSafeDictionary<Tuple<Type, string>, ServiceRegistration>();

        private readonly ThreadSafeDictionary<Type, List<DecoratorRegistration>> decorators = new ThreadSafeDictionary<Type, List<DecoratorRegistration>>();

        private readonly ThreadLocal<ScopeManager> scopeManagers = new ThreadLocal<ScopeManager>(() => new ScopeManager());

        private readonly Lazy<IConstructionInfoProvider> constructionInfoProvider;

        private bool firstServiceRequest = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContainer"/> class.
        /// </summary>
        public ServiceContainer()
        {
            AssemblyScanner = new AssemblyScanner();
            PropertyDependencySelector = new PropertyDependencySelector(new PropertySelector());
            ConstructorDependencySelector = new ConstructorDependencySelector();
            constructionInfoProvider = new Lazy<IConstructionInfoProvider>(CreateConstructionInfoProvider);
            methodSkeletonFactory = () => new DynamicMethodSkeleton();
            AssemblyLoader = new AssemblyLoader();
        }
        /// <summary>
        /// Gets or sets the <see cref="IPropertyDependencySelector"/> instance that 
        /// is responsible for selecting the property dependencies for a given type.
        /// </summary>
        public IPropertyDependencySelector PropertyDependencySelector { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IConstructorDependencySelector"/> instance that 
        /// is responsible for selecting the constructor dependencies for a given constructor.
        /// </summary>
        public IConstructorDependencySelector ConstructorDependencySelector { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IAssemblyScanner"/> instance that is responsible for scanning assemblies.
        /// </summary>
        public IAssemblyScanner AssemblyScanner { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IAssemblyLoader"/> instance that is responsible for loading assemblies during assembly scanning. 
        /// </summary>
        public IAssemblyLoader AssemblyLoader { get; set; }

        /// <summary>
        /// Gets a list of <see cref="ServiceRegistration"/> instances that represents the registered services.           
        /// </summary>                  
        public IEnumerable<ServiceRegistration> AvailableServices
        {
            get
            {
                return availableServices.Values;
            }
        }

        /// <summary>
        /// Returns <b>true</b> if the container can create the requested service, otherwise <b>false</b>.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns><b>true</b> if the container can create the requested service, otherwise <b>false</b>.</returns>
        public bool CanGetInstance(Type serviceType, string serviceName)
        {
            return GetEmitMethod(serviceType, serviceName) != null;
        }

        /// <summary>
        /// Starts a new <see cref="Scope"/>.
        /// </summary>
        /// <returns><see cref="Scope"/></returns>
        public Scope BeginScope()
        {
            return scopeManagers.Value.BeginScope();
        }

        public object InjectProperties(object instance)
        {
            var type = instance.GetType();
            return propertyInjectionDelegates.GetOrAdd(type, t => CreatePropertyInjectionDelegate(type, instance))();
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="expression"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="expression">The lambdaExpression that describes the dependencies of the service.</param>
        /// <param name="serviceName">The name of the service.</param>        
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register<TService>(Expression<Func<IServiceFactory, TService>> expression, string serviceName, ILifetime lifetime)
        {
            RegisterServiceFromLambdaExpression(expression, lifetime, serviceName);
        }

        /// <summary>
        /// Registers a custom factory delegate used to create services that is otherwise unknown to the service container.
        /// </summary>
        /// <param name="predicate">Determines if the service can be created by the <paramref name="factory"/> delegate.</param>
        /// <param name="factory">Creates a service instance according to the <paramref name="predicate"/> predicate.</param>
        public void Register(Func<Type, string, bool> predicate, Func<ServiceRequest, object> factory)
        {
            factoryRules.Add(new FactoryRule { CanCreateInstance = predicate, Factory = factory });
        }

        /// <summary>
        /// Registers a custom factory delegate used to create services that is otherwise unknown to the service container.
        /// </summary>
        /// <param name="predicate">Determines if the service can be created by the <paramref name="factory"/> delegate.</param>
        /// <param name="factory">Creates a service instance according to the <paramref name="predicate"/> predicate.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register(Func<Type, string, bool> predicate, Func<ServiceRequest, object> factory, ILifetime lifetime)
        {
            factoryRules.Add(new FactoryRule { CanCreateInstance = predicate, Factory = factory, LifeTime = lifetime });
        }

        /// <summary>
        /// Registers a service based on a <see cref="ServiceRegistration"/> instance.
        /// </summary>
        /// <param name="serviceRegistration">The <see cref="ServiceRegistration"/> instance that contains service metadata.</param>
        public void Register(ServiceRegistration serviceRegistration)
        {
            UpdateServiceEmitter(serviceRegistration.ServiceType, serviceRegistration.ServiceName, GetEmitDelegate(serviceRegistration));
            UpdateServiceRegistration(serviceRegistration);
        }

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>        
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>             
        public void RegisterAssembly(Assembly assembly)
        {
            RegisterAssembly(assembly, (serviceType, implementingType) => true);
        }

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>
        /// <param name="shouldRegister">A function delegate that determines if a service implementation should be registered.</param>
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        public void RegisterAssembly(Assembly assembly, Func<Type, Type, bool> shouldRegister)
        {
            AssemblyScanner.Scan(assembly, this, () => null, shouldRegister);
        }

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>
        /// <param name="lifetimeFactory">The <see cref="ILifetime"/> factory that controls the lifetime of the registered service.</param>
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        public void RegisterAssembly(Assembly assembly, Func<ILifetime> lifetimeFactory)
        {
            AssemblyScanner.Scan(assembly, this, lifetimeFactory, (serviceType, implementingType) => true);
        }

        /// <summary>
        /// Registers services from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to be scanned for services.</param>
        /// <param name="lifetimeFactory">The <see cref="ILifetime"/> factory that controls the lifetime of the registered service.</param>
        /// <param name="shouldRegister">A function delegate that determines if a service implementation should be registered.</param>
        /// <remarks>
        /// If the target <paramref name="assembly"/> contains an implementation of the <see cref="ICompositionRoot"/> interface, this 
        /// will be used to configure the container.
        /// </remarks>     
        public void RegisterAssembly(Assembly assembly, Func<ILifetime> lifetimeFactory, Func<Type, Type, bool> shouldRegister)
        {
            AssemblyScanner.Scan(assembly, this, lifetimeFactory, shouldRegister);
        }

        /// <summary>
        /// Registers services from assemblies in the base directory that matches the <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="searchPattern">The search pattern used to filter the assembly files.</param>
        public void RegisterAssembly(string searchPattern)
        {
            foreach (Assembly assembly in AssemblyLoader.Load(searchPattern))
            {
                RegisterAssembly(assembly);
            }
        }

        /// <summary>
        /// Decorates the <paramref name="serviceType"/> with the given <paramref name="decoratorType"/>.
        /// </summary>
        /// <param name="serviceType">The target service type.</param>
        /// <param name="decoratorType">The decorator type used to decorate the <paramref name="serviceType"/>.</param>
        /// <param name="predicate">A function delegate that determines if the <paramref name="decoratorType"/>
        /// should be applied to the target <paramref name="serviceType"/>.</param>
        public void Decorate(Type serviceType, Type decoratorType, Func<ServiceRegistration, bool> predicate)
        {
            var decoratorInfo = new DecoratorRegistration { ServiceType = serviceType, ImplementingType = decoratorType, CanDecorate = predicate };
            GetRegisteredDecorators(serviceType).Add(decoratorInfo);
        }

        /// <summary>
        /// Decorates the <paramref name="serviceType"/> with the given <paramref name="decoratorType"/>.
        /// </summary>
        /// <param name="serviceType">The target service type.</param>
        /// <param name="decoratorType">The decorator type used to decorate the <paramref name="serviceType"/>.</param>        
        public void Decorate(Type serviceType, Type decoratorType)
        {
            Decorate(serviceType, decoratorType, si => true);
        }

        /// <summary>
        /// Decorates the <typeparamref name="TService"/> using the given decorator <paramref name="factory"/>.
        /// </summary>
        /// <typeparam name="TService">The target service type.</typeparam>
        /// <param name="factory">A factory delegate used to create a decorator instance.</param>
        public void Decorate<TService>(Expression<Func<IServiceFactory, TService, TService>> factory)
        {
            var decoratorInfo = new DecoratorRegistration { FactoryExpression = factory, ServiceType = typeof(TService), CanDecorate = si => true };
            GetRegisteredDecorators(typeof(TService)).Add(decoratorInfo);
        }

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register(Type serviceType, Type implementingType, ILifetime lifetime)
        {
            Register(serviceType, implementingType, string.Empty, lifetime);
        }

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register(Type serviceType, Type implementingType, string serviceName, ILifetime lifetime)
        {
            RegisterService(serviceType, implementingType, lifetime, serviceName);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            Register(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register<TService, TImplementation>(ILifetime lifetime) where TImplementation : TService
        {
            Register(typeof(TService), typeof(TImplementation), lifetime);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        /// <param name="serviceName">The name of the service.</param>
        public void Register<TService, TImplementation>(string serviceName) where TImplementation : TService
        {
            Register<TService, TImplementation>(serviceName, lifetime: null);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementing type.</typeparam>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register<TService, TImplementation>(string serviceName, ILifetime lifetime) where TImplementation : TService
        {
            Register(typeof(TService), typeof(TImplementation), serviceName, lifetime);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="factory"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="factory">The lambdaExpression that describes the dependencies of the service.</param>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register<TService>(Expression<Func<IServiceFactory, TService>> factory, ILifetime lifetime)
        {
            RegisterServiceFromLambdaExpression(factory, lifetime, string.Empty);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="factory"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="factory">The lambdaExpression that describes the dependencies of the service.</param>
        /// <param name="serviceName">The name of the service.</param>        
        public void Register<TService>(Expression<Func<IServiceFactory, TService>> factory, string serviceName)
        {
            RegisterServiceFromLambdaExpression(factory, null, serviceName);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the given <paramref name="instance"/>. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="instance">The instance returned when this service is requested.</param>
        public void Register<TService>(TService instance)
        {
            Register(instance, string.Empty);
        }

        /// <summary>
        /// Registers a concrete type as a service.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        public void Register<TService>()
        {
            Register<TService, TService>();
        }

        /// <summary>
        /// Registers a concrete type as a service.
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="lifetime">The <see cref="ILifetime"/> instance that controls the lifetime of the registered service.</param>
        public void Register<TService>(ILifetime lifetime)
        {
            Register<TService, TService>(lifetime);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the given <paramref name="instance"/>. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="instance">The instance returned when this service is requested.</param>
        /// <param name="serviceName">The name of the service.</param>
        public void Register<TService>(TService instance, string serviceName)
        {
            RegisterValue(typeof(TService), instance, serviceName);
        }

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the <paramref name="factory"/> that 
        /// describes the dependencies of the service. 
        /// </summary>
        /// <typeparam name="TService">The service type to register.</typeparam>
        /// <param name="factory">The lambdaExpression that describes the dependencies of the service.</param>       
        public void Register<TService>(Expression<Func<IServiceFactory, TService>> factory)
        {
            RegisterServiceFromLambdaExpression(factory, null, string.Empty);
        }

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        /// <param name="serviceName">The name of the service.</param>
        public void Register(Type serviceType, Type implementingType, string serviceName)
        {
            RegisterService(serviceType, implementingType, null, serviceName);
        }

        /// <summary>
        /// Registers the <paramref name="serviceType"/> with the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="serviceType">The service type to register.</param>
        /// <param name="implementingType">The implementing type.</param>
        public void Register(Type serviceType, Type implementingType)
        {
            RegisterService(serviceType, implementingType, null, string.Empty);
        }

        /// <summary>
        /// Gets an instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <returns>The requested service instance.</returns>
        public object GetInstance(Type serviceType)
        {
            return GetDefaultDelegate(serviceType, true)();
        }

        /// <summary>
        /// Gets an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <returns>The requested service instance.</returns>
        public TService GetInstance<TService>()
        {
            return (TService)GetInstance(typeof(TService));
        }

        /// <summary>
        /// Gets a named instance of the given <typeparamref name="TService"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance.</returns>    
        public TService GetInstance<TService>(string serviceName)
        {
            return (TService)GetInstance(typeof(TService), serviceName);
        }

        /// <summary>
        /// Gets an instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <returns>The requested service instance if available, otherwise null.</returns>
        public object TryGetInstance(Type serviceType)
        {
            return GetDefaultDelegate(serviceType, false)();
        }

        /// <summary>
        /// Gets a named instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance if available, otherwise null.</returns>
        public object TryGetInstance(Type serviceType, string serviceName)
        {
            return GetNamedDelegate(serviceType, serviceName, false)();
        }

        /// <summary>
        /// Tries to get an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <returns>The requested service instance if available, otherwise default(T).</returns>
        public TService TryGetInstance<TService>()
        {
            return (TService)TryGetInstance(typeof(TService));
        }

        /// <summary>
        /// Tries to get an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        /// <typeparam name="TService">The type of the requested service.</typeparam>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance if available, otherwise default(T).</returns>
        public TService TryGetInstance<TService>(string serviceName)
        {
            return (TService)TryGetInstance(typeof(TService), serviceName);
        }

        /// <summary>
        /// Gets a named instance of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <returns>The requested service instance.</returns>
        public object GetInstance(Type serviceType, string serviceName)
        {
            return GetNamedDelegate(serviceType, serviceName, true)();
        }

        /// <summary>
        /// Gets all instances of the given <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The type of services to resolve.</param>
        /// <returns>A list that contains all implementations of the <paramref name="serviceType"/>.</returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return (IEnumerable<object>)GetInstance(typeof(IEnumerable<>).MakeGenericType(serviceType));
        }

        /// <summary>
        /// Gets all instances of type <typeparamref name="TService"/>.
        /// </summary>
        /// <typeparam name="TService">The type of services to resolve.</typeparam>
        /// <returns>A list that contains all implementations of the <typeparamref name="TService"/> type.</returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return GetInstance<IEnumerable<TService>>();
        }

        /// <summary>
        /// Disposes any services registered using the <see cref="PerContainerLifetime"/>.
        /// </summary>
        public void Dispose()
        {
            var disposableLifetimeInstances = availableServices.Values
                .Where(sr => sr.Lifetime != null)
                .Select(sr => sr.Lifetime)
                .Where(lt => lt is IDisposable).Cast<IDisposable>();
            foreach (var disposableLifetimeInstance in disposableLifetimeInstances)
            {
                disposableLifetimeInstance.Dispose();
            }

            scopeManagers.Dispose();
        }

        private static void EmitLoadConstant(IMethodSkeleton dynamicMethodSkeleton, int index, Type type)
        {
            var generator = dynamicMethodSkeleton.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldc_I4, index);
            generator.Emit(OpCodes.Ldelem_Ref);
            generator.Emit(TypeHelper.IsValueType(type) ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
        }

        private static void EmitEnumerable(IList<Action<IMethodSkeleton>> serviceEmitters, Type elementType, IMethodSkeleton dynamicMethodSkeleton)
        {
            ILGenerator generator = dynamicMethodSkeleton.GetILGenerator();
            LocalBuilder array = generator.DeclareLocal(elementType.MakeArrayType());
            generator.Emit(OpCodes.Ldc_I4, serviceEmitters.Count);
            generator.Emit(OpCodes.Newarr, elementType);
            generator.Emit(OpCodes.Stloc, array);

            for (int index = 0; index < serviceEmitters.Count; index++)
            {
                generator.Emit(OpCodes.Ldloc, array);
                generator.Emit(OpCodes.Ldc_I4, index);
                var serviceEmitter = serviceEmitters[index];
                serviceEmitter(dynamicMethodSkeleton);
                generator.Emit(OpCodes.Stelem, elementType);
            }

            generator.Emit(OpCodes.Ldloc, array);
        }

        private static bool IsEnumerableOfT(Type serviceType)
        {
            return TypeHelper.IsGenericType(serviceType) && serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }

        private static bool IsFunc(Type serviceType)
        {
            return TypeHelper.IsGenericType(serviceType) && serviceType.GetGenericTypeDefinition() == typeof(Func<>);
        }

        private static bool IsClosedGeneric(Type serviceType)
        {
            return TypeHelper.IsGenericType(serviceType) && !TypeHelper.IsGenericTypeDefinition(serviceType);
        }

        private static bool IsFuncWithStringArgument(Type serviceType)
        {
            return TypeHelper.IsGenericType(serviceType) && serviceType.GetGenericTypeDefinition() == typeof(Func<,>)
                && serviceType.GetGenericArguments()[0] == typeof(string);
        }

        private static ILifetime CloneLifeTime(ILifetime lifetime)
        {
            return lifetime == null ? null : (ILifetime)Activator.CreateInstance(lifetime.GetType());
        }

        private Func<object> CreatePropertyInjectionDelegate(Type concreteType, object instance)
        {
            IMethodSkeleton methodSkeleton = new DynamicMethodSkeleton();
            var arguments = new[] { instance };
            ConstructionInfo constructionInfo = GetContructionInfoForConcreteType(concreteType);
            EmitLoadConstant(methodSkeleton, 0, concreteType);
            try
            {
                EmitPropertyDependencies(constructionInfo, methodSkeleton);
            }
            catch (Exception)
            {
                dependencyStack.Clear();
                throw;
            }

            var del = methodSkeleton.CreateDelegate();
            return () => del(arguments);
        }

        private ConstructionInfo GetContructionInfoForConcreteType(Type concreteType)
        {
            var serviceRegistration = GetServiceRegistrationForConcreteType(concreteType);
            return GetConstructionInfo(serviceRegistration);
        }

        private ServiceRegistration GetServiceRegistrationForConcreteType(Type concreteType)
        {
            var serviceKey = Tuple.Create(concreteType, string.Empty);
            return availableServices.GetOrAdd(
                serviceKey, tuple => CreateServiceRegistrationBasedOnConcreteType(tuple.Item1));
        }

        private ServiceRegistration CreateServiceRegistrationBasedOnConcreteType(Type type)
        {
            var serviceRegistration = new ServiceRegistration
            {
                ServiceType = type,
                ImplementingType = type,
                ServiceName = string.Empty
            };
            return serviceRegistration;
        }

        private ConstructionInfoProvider CreateConstructionInfoProvider()
        {
            return new ConstructionInfoProvider(CreateConstructionInfoBuilder());
        }

        private ConstructionInfoBuilder CreateConstructionInfoBuilder()
        {
            return new ConstructionInfoBuilder(() => new LambdaConstructionInfoBuilder(), CreateTypeConstructionInfoBuilder);
        }

        private TypeConstructionInfoBuilder CreateTypeConstructionInfoBuilder()
        {
            return new TypeConstructionInfoBuilder(new ConstructorSelector(), ConstructorDependencySelector, PropertyDependencySelector);
        }

        private Func<object> GetDefaultDelegate(Type serviceType, bool throwError)
        {
            Func<object> del;

            if (!this.delegates.TryGetValue(serviceType, out del))
            {
                del = this.delegates.GetOrAdd(serviceType, t => this.CreateDelegate(t, string.Empty, throwError));
            }

            return del;
        }

        private Func<object> GetNamedDelegate(Type serviceType, string serviceName, bool throwError)
        {
            Func<object> del;

            if (!this.namedDelegates.TryGetValue(Tuple.Create(serviceType, serviceName), out del))
            {
                del = this.namedDelegates.GetOrAdd(
                    Tuple.Create(serviceType, serviceName), t => this.CreateDelegate(t.Item1, serviceName, throwError));
            }

            return del;
        }

        private Func<object> CreateDynamicMethodDelegate(Action<IMethodSkeleton> serviceEmitter, Type serviceType)
        {
            var methodSkeleton = methodSkeletonFactory();
            serviceEmitter(methodSkeleton);
            if (TypeHelper.IsValueType(serviceType))
            {
                methodSkeleton.GetILGenerator().Emit(OpCodes.Box, serviceType);
            }

            var del = methodSkeleton.CreateDelegate();
            return () => del(constants.Items);
        }

        private Action<IMethodSkeleton> GetEmitMethod(Type serviceType, string serviceName)
        {
            if (FirstServiceRequest())
            {
                EnsureThatServiceRegistryIsConfigured(serviceType);
            }

            Action<IMethodSkeleton> emitter = GetRegisteredEmitMethod(serviceType, serviceName);

            return CreateEmitMethodWrapper(emitter, serviceType, serviceName);
        }

        private Action<IMethodSkeleton> CreateEmitMethodWrapper(Action<IMethodSkeleton> emitter, Type serviceType, string serviceName)
        {
            if (emitter == null)
            {
                return null;
            }

            return ms =>
            {
                if (dependencyStack.Contains(emitter))
                {
                    throw new InvalidOperationException(
                        string.Format("Recursive dependency detected: ServiceType:{0}, ServiceName:{1}]", serviceType, serviceName));
                }

                dependencyStack.Push(emitter);
                emitter(ms);
                dependencyStack.Pop();
            };
        }

        private Action<IMethodSkeleton> GetRegisteredEmitMethod(Type serviceType, string serviceName)
        {
            Action<IMethodSkeleton> emitter;
            var registrations = GetServiceEmitters(serviceType);
            registrations.TryGetValue(serviceName, out emitter);
            return emitter ?? ResolveUnknownServiceEmitter(serviceType, serviceName);
        }

        private void UpdateServiceEmitter(Type serviceType, string serviceName, Action<IMethodSkeleton> emitter)
        {
            if (emitter != null)
            {
                GetServiceEmitters(serviceType).AddOrUpdate(serviceName, s => emitter, (s, m) => emitter);
            }
        }

        private void UpdateServiceRegistration(ServiceRegistration serviceRegistration)
        {
            var key = Tuple.Create(serviceRegistration.ServiceType, serviceRegistration.ServiceName);
            var sr = serviceRegistration;
            availableServices.AddOrUpdate(
                key,
                k => sr,
                (k, s) =>
                {
                    Invalidate();
                    return serviceRegistration;
                });
        }

        private void EmitNewInstance(ServiceRegistration serviceRegistration, IMethodSkeleton dynamicMethodSkeleton)
        {
            var serviceDecorators = GetDecorators(serviceRegistration.ServiceType);
            if (serviceDecorators.Length > 0)
            {
                EmitDecorators(serviceRegistration, serviceDecorators, dynamicMethodSkeleton, () => DoEmitNewInstance(GetConstructionInfo(serviceRegistration), dynamicMethodSkeleton));
            }
            else
            {
                DoEmitNewInstance(GetConstructionInfo(serviceRegistration), dynamicMethodSkeleton);
            }
        }

        private DecoratorRegistration[] GetDecorators(Type serviceType)
        {
            var registeredDecorators = GetRegisteredDecorators(serviceType);
            if (registeredDecorators.Count == 0 && TypeHelper.IsGenericType(serviceType))
            {
                var openGenericServiceType = serviceType.GetGenericTypeDefinition();
                var openGenericDecorators = GetRegisteredDecorators(openGenericServiceType);
                if (openGenericDecorators.Count >= 0)
                {
                    foreach (DecoratorRegistration openGenericDecorator in openGenericDecorators)
                    {
                        var closedGenericDecoratorType = openGenericDecorator.ImplementingType.MakeGenericType(serviceType.GetGenericArguments());
                        var decoratorInfo = new DecoratorRegistration { ServiceType = serviceType, ImplementingType = closedGenericDecoratorType, CanDecorate = openGenericDecorator.CanDecorate };
                        registeredDecorators.Add(decoratorInfo);
                    }
                }
            }

            return registeredDecorators.ToArray();
        }

        private void DoEmitDecoratorInstance(DecoratorRegistration decoratorRegistration, IMethodSkeleton dynamicMethodSkeleton, Action pushInstance)
        {
            ConstructionInfo constructionInfo = GetConstructionInfo(decoratorRegistration);
            var constructorDependency =
                constructionInfo.ConstructorDependencies.FirstOrDefault(cd => cd.ServiceType == decoratorRegistration.ServiceType);
            if (constructorDependency != null)
            {
                constructorDependency.IsDecoratorTarget = true;
            }

            if (constructionInfo.FactoryDelegate != null)
            {
                EmitNewDecoratorUsingFactoryDelegate(constructionInfo.FactoryDelegate, dynamicMethodSkeleton, pushInstance);
            }
            else
            {
                EmitNewInstanceUsingImplementingType(dynamicMethodSkeleton, constructionInfo, pushInstance);
            }
        }

        private void EmitNewDecoratorUsingFactoryDelegate(Delegate factoryDelegate, IMethodSkeleton dynamicMethodSkeleton, Action pushInstance)
        {
            var factoryDelegateIndex = constants.Add(factoryDelegate);
            var serviceFactoryIndex = constants.Add(this);
            Type funcType = factoryDelegate.GetType();
            EmitLoadConstant(dynamicMethodSkeleton, factoryDelegateIndex, funcType);
            EmitLoadConstant(dynamicMethodSkeleton, serviceFactoryIndex, typeof(IServiceFactory));
            pushInstance();
            ILGenerator generator = dynamicMethodSkeleton.GetILGenerator();
            MethodInfo invokeMethod = funcType.GetMethod("Invoke");
            generator.Emit(OpCodes.Callvirt, invokeMethod);
        }

        private void DoEmitNewInstance(ConstructionInfo constructionInfo, IMethodSkeleton dynamicMethodSkeleton)
        {
            if (constructionInfo.FactoryDelegate != null)
            {
                EmitNewInstanceUsingFactoryDelegate(constructionInfo.FactoryDelegate, dynamicMethodSkeleton);
            }
            else
            {
                EmitNewInstanceUsingImplementingType(dynamicMethodSkeleton, constructionInfo, null);
            }
        }

        private void EmitDecorators(ServiceRegistration serviceRegistration, IEnumerable<DecoratorRegistration> serviceDecorators, IMethodSkeleton dynamicMethodSkeleton, Action decoratorTargetEmitter)
        {
            foreach (DecoratorRegistration decorator in serviceDecorators)
            {
                if (!decorator.CanDecorate(serviceRegistration))
                {
                    continue;
                }

                Action currentDecoratorTargetEmitter = decoratorTargetEmitter;
                DecoratorRegistration currentDecorator = decorator;
                decoratorTargetEmitter = () => DoEmitDecoratorInstance(currentDecorator, dynamicMethodSkeleton, currentDecoratorTargetEmitter);
            }

            decoratorTargetEmitter();
        }

        private void EmitNewInstanceUsingImplementingType(IMethodSkeleton dynamicMethodSkeleton, ConstructionInfo constructionInfo, Action decoratorTargetEmitter)
        {
            ILGenerator generator = dynamicMethodSkeleton.GetILGenerator();
            EmitConstructorDependencies(constructionInfo, dynamicMethodSkeleton, decoratorTargetEmitter);
            generator.Emit(OpCodes.Newobj, constructionInfo.Constructor);
            EmitPropertyDependencies(constructionInfo, dynamicMethodSkeleton);
        }

        private void EmitNewInstanceUsingFactoryDelegate(Delegate factoryDelegate, IMethodSkeleton dynamicMethodSkeleton)
        {
            var factoryDelegateIndex = constants.Add(factoryDelegate);
            var serviceFactoryIndex = constants.Add(this);
            Type funcType = factoryDelegate.GetType();
            EmitLoadConstant(dynamicMethodSkeleton, factoryDelegateIndex, funcType);
            EmitLoadConstant(dynamicMethodSkeleton, serviceFactoryIndex, typeof(IServiceFactory));
            ILGenerator generator = dynamicMethodSkeleton.GetILGenerator();
            MethodInfo invokeMethod = funcType.GetMethod("Invoke");
            generator.Emit(OpCodes.Callvirt, invokeMethod);
        }

        private void EmitConstructorDependencies(ConstructionInfo constructionInfo, IMethodSkeleton dynamicMethodSkeleton, Action decoratorTargetEmitter)
        {
            foreach (ConstructorDependency dependency in constructionInfo.ConstructorDependencies)
            {
                if (!dependency.IsDecoratorTarget)
                {
                    EmitDependency(dynamicMethodSkeleton, dependency);
                }
                else
                {
                    decoratorTargetEmitter();
                }
            }
        }

        private void EmitDependency(IMethodSkeleton dynamicMethodSkeleton, Dependency dependency)
        {
            var emitter = this.GetEmitMethodForDependency(dependency);

            try
            {
                emitter(dynamicMethodSkeleton);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(string.Format(UnresolvedDependencyError, dependency), ex);
            }
        }

        private void EmitPropertyDependency(IMethodSkeleton dynamicMethodSkeleton, PropertyDependency propertyDependency, LocalBuilder instance)
        {
            var emitter = GetEmitMethodForDependency(propertyDependency);
            var generator = dynamicMethodSkeleton.GetILGenerator();

            if (emitter != null)
            {
                generator.Emit(OpCodes.Ldloc, instance);
                emitter(dynamicMethodSkeleton);
                dynamicMethodSkeleton.GetILGenerator().Emit(OpCodes.Callvirt, propertyDependency.Property.GetSetMethod());
            }
        }

        private Action<IMethodSkeleton> GetEmitMethodForDependency(Dependency dependency)
        {
            if (dependency.FactoryExpression != null)
            {
                return skeleton => EmitDependencyUsingFactoryExpression(skeleton, dependency);
            }

            Action<IMethodSkeleton> emitter = this.GetEmitMethod(dependency.ServiceType, dependency.ServiceName);
            if (emitter == null)
            {
                emitter = this.GetEmitMethod(dependency.ServiceType, dependency.Name);
                if (emitter == null && dependency.IsRequired)
                {
                    throw new InvalidOperationException(string.Format(UnresolvedDependencyError, dependency));
                }
            }

            return emitter;
        }

        private void EmitDependencyUsingFactoryExpression(IMethodSkeleton dynamicMethodSkeleton, Dependency dependency)
        {
            var generator = dynamicMethodSkeleton.GetILGenerator();
            var lambda = Expression.Lambda(dependency.FactoryExpression, new ParameterExpression[] { }).Compile();
            MethodInfo methodInfo = lambda.GetType().GetMethod("Invoke");
            EmitLoadConstant(dynamicMethodSkeleton, constants.Add(lambda), lambda.GetType());
            generator.Emit(OpCodes.Callvirt, methodInfo);
        }

        private void EmitPropertyDependencies(ConstructionInfo constructionInfo, IMethodSkeleton dynamicMethodSkeleton)
        {
            if (constructionInfo.PropertyDependencies.Count == 0)
            {
                return;
            }

            ILGenerator generator = dynamicMethodSkeleton.GetILGenerator();
            LocalBuilder instance = generator.DeclareLocal(constructionInfo.ImplementingType);
            generator.Emit(OpCodes.Stloc, instance);
            foreach (var propertyDependency in constructionInfo.PropertyDependencies)
            {
                EmitPropertyDependency(dynamicMethodSkeleton, propertyDependency, instance);
            }

            generator.Emit(OpCodes.Ldloc, instance);
        }

        private Action<IMethodSkeleton> ResolveUnknownServiceEmitter(Type serviceType, string serviceName)
        {
            Action<IMethodSkeleton> emitter = null;

            var rule = factoryRules.Items.FirstOrDefault(r => r.CanCreateInstance(serviceType, serviceName));
            if (rule != null)
            {
                emitter = CreateServiceEmitterBasedOnFactoryRule(rule, serviceType, serviceName);
            }
            else if (IsFunc(serviceType))
            {
                emitter = CreateServiceEmitterBasedOnFuncServiceRequest(serviceType, false);
            }
            else if (IsEnumerableOfT(serviceType))
            {
                emitter = CreateEnumerableServiceEmitter(serviceType);
            }
            else if (IsFuncWithStringArgument(serviceType))
            {
                emitter = CreateServiceEmitterBasedOnFuncServiceRequest(serviceType, true);
            }
            else if (CanRedirectRequestForDefaultServiceToSingleNamedService(serviceType, serviceName))
            {
                emitter = CreateServiceEmitterBasedOnSingleNamedInstance(serviceType);
            }
            else if (IsClosedGeneric(serviceType))
            {
                emitter = CreateServiceEmitterBasedOnClosedGenericServiceRequest(serviceType, serviceName);
            }

            UpdateServiceEmitter(serviceType, serviceName, emitter);

            return emitter;
        }

        private Action<IMethodSkeleton> CreateServiceEmitterBasedOnFactoryRule(FactoryRule rule, Type serviceType, string serviceName)
        {
            var serviceRegistration = new ServiceRegistration { ServiceType = serviceType, ServiceName = serviceName, Lifetime = rule.LifeTime };
            ParameterExpression serviceFactoryParameterExpression = Expression.Parameter(typeof(IServiceFactory));
            ConstantExpression serviceRequestConstantExpression = Expression.Constant(new ServiceRequest(serviceType, serviceName, this));
            ConstantExpression delegateConstantExpression = Expression.Constant(rule.Factory);
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(IServiceFactory), serviceType);
            UnaryExpression convertExpression = Expression.Convert(
                Expression.Invoke(delegateConstantExpression, serviceRequestConstantExpression), serviceType);

            LambdaExpression lambdaExpression = Expression.Lambda(delegateType, convertExpression, serviceFactoryParameterExpression);
            serviceRegistration.FactoryExpression = lambdaExpression;

            if (rule.LifeTime != null)
            {
                return methodSkeleton => EmitLifetime(serviceRegistration, ms => EmitNewInstance(serviceRegistration, ms), methodSkeleton);
            }

            return methodSkeleton => EmitNewInstance(serviceRegistration, methodSkeleton);
        }

        private Action<IMethodSkeleton> CreateEnumerableServiceEmitter(Type serviceType)
        {
            Type actualServiceType = serviceType.GetGenericArguments()[0];
            if (TypeHelper.IsGenericType(actualServiceType))
            {
                EnsureEmitMethodsForOpenGenericTypesAreCreated(actualServiceType);
            }

            IList<Action<IMethodSkeleton>> serviceEmitters = GetServiceEmitters(actualServiceType).Values.ToList();

            if (dependencyStack.Count > 0 && serviceEmitters.Contains(dependencyStack.Peek()))
            {
                serviceEmitters.Remove(dependencyStack.Peek());
            }

            return ms => EmitEnumerable(serviceEmitters, actualServiceType, ms);
        }

        private void EnsureEmitMethodsForOpenGenericTypesAreCreated(Type actualServiceType)
        {
            var openGenericServiceType = actualServiceType.GetGenericTypeDefinition();
            var openGenericServiceEmitters = GetOpenGenericRegistrations(openGenericServiceType);
            foreach (var openGenericEmitterEntry in openGenericServiceEmitters.Keys)
            {
                GetRegisteredEmitMethod(actualServiceType, openGenericEmitterEntry);
            }
        }

        private Action<IMethodSkeleton> CreateServiceEmitterBasedOnFuncServiceRequest(Type serviceType, bool namedService)
        {
            var actualServiceType = serviceType.GetGenericArguments().Last();

            Delegate getInstanceDelegate = namedService ? ReflectionHelper.CreateGetNamedInstanceDelegate(actualServiceType, this)
                                               : ReflectionHelper.CreateGetInstanceDelegate(actualServiceType, this);

            var constantIndex = constants.Add(getInstanceDelegate);
            return ms => EmitLoadConstant(ms, constantIndex, serviceType);
        }

        private Action<IMethodSkeleton> CreateServiceEmitterBasedOnClosedGenericServiceRequest(Type closedGenericServiceType, string serviceName)
        {
            Type openGenericServiceType = closedGenericServiceType.GetGenericTypeDefinition();

            Action<IMethodSkeleton, Type> openGenericEmitter = GetOpenGenericTypeInfo(openGenericServiceType, serviceName);
            if (openGenericEmitter == null)
            {
                return null;
            }

            return ms => openGenericEmitter(ms, closedGenericServiceType);
        }

        private Action<IMethodSkeleton, Type> GetOpenGenericTypeInfo(Type openGenericServiceType, string serviceName)
        {
            var openGenericRegistrations = GetOpenGenericRegistrations(openGenericServiceType);
            if (CanRedirectRequestForDefaultOpenGenericServiceToSingleNamedService(openGenericServiceType, serviceName))
            {
                return openGenericRegistrations.First().Value;
            }

            Action<IMethodSkeleton, Type> openGenericEmitter;
            openGenericRegistrations.TryGetValue(serviceName, out openGenericEmitter);
            return openGenericEmitter;
        }

        private Action<IMethodSkeleton> CreateServiceEmitterBasedOnSingleNamedInstance(Type serviceType)
        {
            return GetEmitMethod(serviceType, GetServiceEmitters(serviceType).First().Key);
        }

        private bool CanRedirectRequestForDefaultServiceToSingleNamedService(Type serviceType, string serviceName)
        {
            return string.IsNullOrEmpty(serviceName) && GetServiceEmitters(serviceType).Count == 1;
        }

        private bool CanRedirectRequestForDefaultOpenGenericServiceToSingleNamedService(Type serviceType, string serviceName)
        {
            return string.IsNullOrEmpty(serviceName) && GetOpenGenericRegistrations(serviceType).Count == 1;
        }

        private ConstructionInfo GetConstructionInfo(Registration registration)
        {
            return constructionInfoProvider.Value.GetConstructionInfo(registration);
        }

        private ThreadSafeDictionary<string, Action<IMethodSkeleton>> GetServiceEmitters(Type serviceType)
        {
            return emitters.GetOrAdd(serviceType, s => new ThreadSafeDictionary<string, Action<IMethodSkeleton>>(StringComparer.CurrentCultureIgnoreCase));
        }

        private List<DecoratorRegistration> GetRegisteredDecorators(Type serviceType)
        {
            return decorators.GetOrAdd(serviceType, s => new List<DecoratorRegistration>());
        }

        private ThreadSafeDictionary<string, Action<IMethodSkeleton, Type>> GetOpenGenericRegistrations(Type serviceType)
        {
            return openGenericEmitters.GetOrAdd(serviceType, s => new ThreadSafeDictionary<string, Action<IMethodSkeleton, Type>>(StringComparer.CurrentCultureIgnoreCase));
        }

        private void RegisterService(Type serviceType, Type implementingType, ILifetime lifetime, string serviceName)
        {
            if (TypeHelper.IsGenericTypeDefinition(serviceType))
            {
                RegisterOpenGenericService(serviceType, implementingType, lifetime, serviceName);
            }
            else
            {
                var serviceRegistration = new ServiceRegistration { ServiceType = serviceType, ImplementingType = implementingType, ServiceName = serviceName, Lifetime = lifetime };
                UpdateServiceEmitter(serviceType, serviceName, GetEmitDelegate(serviceRegistration));
                UpdateServiceRegistration(serviceRegistration);
            }
        }

        private void RegisterOpenGenericService(Type openGenericServiceType, Type openGenericImplementingType, ILifetime lifetime, string serviceName)
        {
            Action<IMethodSkeleton, Type> emitter = (ms, closedGenericServiceType) =>
            {
                Type closedGenericImplementingType = openGenericImplementingType.MakeGenericType(closedGenericServiceType.GetGenericArguments());
                var serviceRegistration = new ServiceRegistration { ServiceType = closedGenericServiceType, ImplementingType = closedGenericImplementingType, ServiceName = serviceName, Lifetime = CloneLifeTime(lifetime) };
                var closedGenericEmitter = GetEmitDelegate(serviceRegistration);
                UpdateServiceEmitter(closedGenericServiceType, serviceName, closedGenericEmitter);
                UpdateServiceRegistration(serviceRegistration);
                closedGenericEmitter(ms);
            };
            GetOpenGenericRegistrations(openGenericServiceType).AddOrUpdate(serviceName, s => emitter, (s, e) => emitter);
        }

        private Action<IMethodSkeleton> GetEmitDelegate(ServiceRegistration serviceRegistration)
        {
            if (serviceRegistration.Lifetime == null)
            {
                return methodSkeleton => EmitNewInstance(serviceRegistration, methodSkeleton);
            }

            return methodSkeleton => EmitLifetime(serviceRegistration, ms => EmitNewInstance(serviceRegistration, ms), methodSkeleton);
        }

        private void EmitLifetime(ServiceRegistration serviceRegistration, Action<IMethodSkeleton> instanceEmitter, IMethodSkeleton dynamicMethodSkeleton)
        {
            ILGenerator generator = dynamicMethodSkeleton.GetILGenerator();
            int instanceDelegateIndex = CreateInstanceDelegateIndex(instanceEmitter, serviceRegistration.ServiceType);
            int lifetimeIndex = CreateLifetimeIndex(serviceRegistration.Lifetime);
            int scopeManagerIndex = CreateScopeManagerIndex();
            var getInstanceMethod = ReflectionHelper.LifetimeGetInstanceMethod;
            EmitLoadConstant(dynamicMethodSkeleton, lifetimeIndex, typeof(ILifetime));
            EmitLoadConstant(dynamicMethodSkeleton, instanceDelegateIndex, typeof(Func<object>));
            EmitLoadConstant(dynamicMethodSkeleton, scopeManagerIndex, typeof(ThreadLocal<ScopeManager>));
            generator.Emit(OpCodes.Callvirt, ReflectionHelper.GetCurrentScopeManagerMethod);
            generator.Emit(OpCodes.Callvirt, ReflectionHelper.GetCurrentScopeMethod);
            generator.Emit(OpCodes.Callvirt, getInstanceMethod);
            generator.Emit(TypeHelper.IsValueType(serviceRegistration.ServiceType) ? OpCodes.Unbox_Any : OpCodes.Castclass, serviceRegistration.ServiceType);
        }

        private int CreateScopeManagerIndex()
        {
            return constants.Add(scopeManagers);
        }

        private int CreateInstanceDelegateIndex(Action<IMethodSkeleton> instanceEmitter, Type serviceType)
        {
            return constants.Add(
                CreateDynamicMethodDelegate(instanceEmitter, serviceType));
        }

        private int CreateLifetimeIndex(ILifetime lifetime)
        {
            return constants.Add(lifetime);
        }

        private Func<object> CreateDelegate(Type serviceType, string serviceName, bool throwError)
        {
            var serviceEmitter = GetEmitMethod(serviceType, serviceName);
            if (serviceEmitter == null && throwError)
            {
                throw new InvalidOperationException(string.Format("Unable to resolve type: {0}, service name: {1}", serviceType, serviceName));
            }

            if (serviceEmitter != null)
            {
                try
                {
                    return CreateDynamicMethodDelegate(serviceEmitter, serviceType);
                }
                catch (InvalidOperationException ex)
                {
                    dependencyStack.Clear();
                    throw new InvalidOperationException(
                        string.Format("Unable to resolve type: {0}, service name: {1}", serviceType, serviceName), ex);
                }
            }

            return () => null;
        }

        private bool FirstServiceRequest()
        {
            if (firstServiceRequest)
            {
                firstServiceRequest = false;
                return true;
            }

            return false;
        }

        private void Invalidate()
        {
            delegates.Clear();
            namedDelegates.Clear();
            constants.Clear();
            constructionInfoProvider.Value.Invalidate();
        }

        private void EnsureThatServiceRegistryIsConfigured(Type serviceType)
        {
            if (ServiceRegistryIsEmpty())
            {
                RegisterAssembly(TypeHelper.GetAssembly(serviceType), () => null);
            }
        }

        private bool ServiceRegistryIsEmpty()
        {
            return emitters.Count == 0 && openGenericEmitters.Count == 0 && factoryRules.Items.Length == 0;
        }

        private void RegisterValue(Type serviceType, object value, string serviceName)
        {
            int index = constants.Add(value);
            UpdateServiceEmitter(serviceType, serviceName, ms => EmitLoadConstant(ms, index, serviceType));
        }

        private void RegisterServiceFromLambdaExpression<TService>(
            Expression<Func<IServiceFactory, TService>> factory, ILifetime lifetime, string serviceName)
        {
            var serviceRegistration = new ServiceRegistration { ServiceType = typeof(TService), FactoryExpression = factory, ServiceName = serviceName, Lifetime = lifetime };
            UpdateServiceEmitter(typeof(TService), serviceName, GetEmitDelegate(serviceRegistration));
            UpdateServiceRegistration(serviceRegistration);
        }

        private static class ReflectionHelper
        {
            private static readonly Lazy<MethodInfo> LazyLifetimeGetInstanceMethod;
            private static readonly Lazy<MethodInfo> LazyServiceFactoryGetInstanceMethod;
            private static readonly Lazy<MethodInfo> LazyServiceFactoryGetNamedInstanceMethod;
            private static readonly Lazy<MethodInfo[]> LazyGetInstanceMethods;
            private static readonly Lazy<MethodInfo> LazyGetCurrentScopeMethod;
            private static readonly Lazy<MethodInfo> LazyGetCurrentScopeManagerMethod;

            static ReflectionHelper()
            {
                LazyLifetimeGetInstanceMethod = new Lazy<MethodInfo>(() => typeof(ILifetime).GetMethod("GetInstance"));
                LazyGetInstanceMethods = new Lazy<MethodInfo[]>(
                    () => typeof(IServiceFactory).GetMethods().Where(IsGenericGetInstanceMethod).ToArray());
                LazyServiceFactoryGetInstanceMethod = new Lazy<MethodInfo>(
                    () => LazyGetInstanceMethods.Value.FirstOrDefault(m => !m.GetParameters().Any()));
                LazyServiceFactoryGetNamedInstanceMethod = new Lazy<MethodInfo>(
                    () => LazyGetInstanceMethods.Value.FirstOrDefault(m => m.GetParameters().Any()));
                LazyGetCurrentScopeMethod = new Lazy<MethodInfo>(
                    () => typeof(ScopeManager).GetProperty("CurrentScope").GetGetMethod());
                LazyGetCurrentScopeManagerMethod = new Lazy<MethodInfo>(
                    () => typeof(ThreadLocal<ScopeManager>).GetProperty("Value").GetGetMethod());
            }

            public static MethodInfo LifetimeGetInstanceMethod
            {
                get
                {
                    return LazyLifetimeGetInstanceMethod.Value;
                }
            }

            public static MethodInfo GetCurrentScopeMethod
            {
                get
                {
                    return LazyGetCurrentScopeMethod.Value;
                }
            }

            public static MethodInfo GetCurrentScopeManagerMethod
            {
                get
                {
                    return LazyGetCurrentScopeManagerMethod.Value;
                }
            }

            public static Delegate CreateGetInstanceDelegate(Type serviceType, IServiceFactory serviceFactory)
            {
                Type delegateType = typeof(Func<>).MakeGenericType(serviceType);
                MethodInfo openGenericGetInstanceMethod = LazyServiceFactoryGetInstanceMethod.Value;
                MethodInfo closedGenericGetInstanceMethod = openGenericGetInstanceMethod.MakeGenericMethod(serviceType);
                return closedGenericGetInstanceMethod.CreateDelegate(delegateType, serviceFactory);
            }

            public static Delegate CreateGetNamedInstanceDelegate(Type serviceType, IServiceFactory serviceFactory)
            {
                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(string), serviceType);
                MethodInfo openGenericGetNamedInstanceMethod = LazyServiceFactoryGetNamedInstanceMethod.Value;
                MethodInfo closedGenericGetNamedInstanceMethod = openGenericGetNamedInstanceMethod.MakeGenericMethod(serviceType);
                return closedGenericGetNamedInstanceMethod.CreateDelegate(delegateType, serviceFactory);
            }

            private static bool IsGenericGetInstanceMethod(MethodInfo m)
            {
                return m.Name == "GetInstance" && m.IsGenericMethodDefinition;
            }
        }

        private class Storage<T>
        {
            private readonly object lockObject = new object();
            private T[] items = new T[0];

            public T[] Items
            {
                get
                {
                    return items;
                }
            }

            public int Add(T value)
            {
                int index = Array.IndexOf(items, value);
                if (index == -1)
                {
                    return TryAddValue(value);
                }

                return index;
            }

            public void Clear()
            {
                lock (lockObject)
                {
                    items = new T[0];
                }
            }

            private int TryAddValue(T value)
            {
                lock (lockObject)
                {
                    int index = Array.IndexOf(items, value);
                    if (index == -1)
                    {
                        index = AddValue(value);
                    }

                    return index;
                }
            }

            private int AddValue(T value)
            {
                int index = items.Length;
                T[] snapshot = CreateSnapshot();
                snapshot[index] = value;
                items = snapshot;
                return index;
            }

            private T[] CreateSnapshot()
            {
                var snapshot = new T[items.Length + 1];
                Array.Copy(items, snapshot, items.Length);
                return snapshot;
            }
        }

        private class KeyValueStorage<TKey, TValue>
        {
            private readonly object lockObject = new object();
            private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

            public bool TryGetValue(TKey key, out TValue value)
            {
                return dictionary.TryGetValue(key, out value);
            }

            public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
            {
                TValue value;
                if (!dictionary.TryGetValue(key, out value))
                {
                    lock (lockObject)
                    {
                        value = TryAddValue(key, valueFactory);
                    }
                }

                return value;
            }

            public void Clear()
            {
                lock (lockObject)
                {
                    dictionary.Clear();
                }
            }

            private TValue TryAddValue(TKey key, Func<TKey, TValue> valueFactory)
            {
                TValue value;
                if (!dictionary.TryGetValue(key, out value))
                {
                    var snapshot = new Dictionary<TKey, TValue>(dictionary);
                    value = valueFactory(key);
                    snapshot.Add(key, value);
                    dictionary = snapshot;
                }

                return value;
            }
        }

        private class DynamicMethodSkeleton : IMethodSkeleton
        {
            private DynamicMethod dynamicMethod;

            public DynamicMethodSkeleton()
            {
                CreateDynamicMethod();
            }

            public ILGenerator GetILGenerator()
            {
                return dynamicMethod.GetILGenerator();
            }

            public Func<object[], object> CreateDelegate()
            {
                dynamicMethod.GetILGenerator().Emit(OpCodes.Ret);
                return (Func<object[], object>)dynamicMethod.CreateDelegate(typeof(Func<object[], object>));
            }

            private void CreateDynamicMethod()
            {
                dynamicMethod = new DynamicMethod(
                    "DynamicMethod", typeof(object), new[] { typeof(object[]) }, typeof(ServiceContainer).Module, false);
            }
        }

        private class ServiceRegistry<T> : ThreadSafeDictionary<Type, ThreadSafeDictionary<string, T>>
        {
        }

        private class DelegateRegistry<TKey> : KeyValueStorage<TKey, Func<object>>
        {
        }

        private class FactoryRule
        {
            public Func<Type, string, bool> CanCreateInstance { get; internal set; }

            public Func<ServiceRequest, object> Factory { get; internal set; }

            public ILifetime LifeTime { get; set; }
        }
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ThreadSafeDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
    {
        public ThreadSafeDictionary()
        {
        }

        public ThreadSafeDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }
    }



    /// <summary>
    /// Selects the <see cref="ConstructionInfo"/> from a given type that has the highest number of parameters.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ConstructorSelector : IConstructorSelector
    {
        /// <summary>
        /// Selects the constructor to be used when creating a new instance of the <paramref name="implementingType"/>.
        /// </summary>
        /// <param name="implementingType">The <see cref="Type"/> for which to return a <see cref="ConstructionInfo"/>.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance that represents the constructor to be used
        /// when creating a new instance of the <paramref name="implementingType"/>.</returns>
        public ConstructorInfo Execute(Type implementingType)
        {
            return implementingType.GetConstructors().OrderBy(c => c.GetParameters().Count()).LastOrDefault();
        }
    }

    /// <summary>
    /// Selects the constructor dependencies for a given <see cref="ConstructorInfo"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ConstructorDependencySelector : IConstructorDependencySelector
    {
        /// <summary>
        /// Selects the constructor dependencies for the given <paramref name="constructor"/>.
        /// </summary>
        /// <param name="constructor">The <see cref="ConstructionInfo"/> for which to select the constructor dependencies.</param>
        /// <returns>A list of <see cref="ConstructorDependency"/> instances that represents the constructor
        /// dependencies for the given <paramref name="constructor"/>.</returns>
        public virtual IEnumerable<ConstructorDependency> Execute(ConstructorInfo constructor)
        {
            return
                constructor.GetParameters()
                           .OrderBy(p => p.Position)
                           .Select(
                               p =>
                               new ConstructorDependency
                                   {
                                       ServiceName = string.Empty,
                                       ServiceType = p.ParameterType,
                                       Parameter = p,
                                       IsRequired = true
                                   });
        }
    }

    /// <summary>
    /// Selects the property dependencies for a given <see cref="Type"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class PropertyDependencySelector : IPropertyDependencySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyDependencySelector"/> class.
        /// </summary>
        /// <param name="propertySelector">The <see cref="IPropertySelector"/> that is 
        /// responsible for selecting a list of injectable properties.</param>
        public PropertyDependencySelector(IPropertySelector propertySelector)
        {
            PropertySelector = propertySelector;
        }

        /// <summary>
        /// Gets the <see cref="IPropertySelector"/> that is responsible for selecting a 
        /// list of injectable properties.
        /// </summary>
        protected IPropertySelector PropertySelector { get; private set; }

        /// <summary>
        /// Selects the property dependencies for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> for which to select the property dependencies.</param>
        /// <returns>A list of <see cref="PropertyDependency"/> instances that represents the property
        /// dependencies for the given <paramref name="type"/>.</returns>
        public virtual IEnumerable<PropertyDependency> Execute(Type type)
        {
            return this.PropertySelector.Execute(type).Select(
                p => new PropertyDependency { Property = p, ServiceName = string.Empty, ServiceType = p.PropertyType });
        }
    }

    /// <summary>
    /// Builds a <see cref="ConstructionInfo"/> instance based on the implementing <see cref="Type"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class TypeConstructionInfoBuilder : ITypeConstructionInfoBuilder
    {
        private readonly IConstructorSelector constructorSelector;
        private readonly IConstructorDependencySelector constructorDependencySelector;
        private readonly IPropertyDependencySelector propertyDependencySelector;

        public TypeConstructionInfoBuilder(
            IConstructorSelector constructorSelector,
            IConstructorDependencySelector constructorDependencySelector,
            IPropertyDependencySelector propertyDependencySelector)
        {
            this.constructorSelector = constructorSelector;
            this.constructorDependencySelector = constructorDependencySelector;
            this.propertyDependencySelector = propertyDependencySelector;
        }

        /// <summary>
        /// Analyzes the <paramref name="implementingType"/> and returns a <see cref="ConstructionInfo"/> instance.
        /// </summary>
        /// <param name="implementingType">The <see cref="Type"/> to analyze.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance.</returns>
        public ConstructionInfo Execute(Type implementingType)
        {
            var constructionInfo = new ConstructionInfo();
            constructionInfo.Constructor = constructorSelector.Execute(implementingType);
            constructionInfo.ImplementingType = implementingType;
            constructionInfo.PropertyDependencies.AddRange(propertyDependencySelector.Execute(implementingType));
            constructionInfo.ConstructorDependencies.AddRange(constructorDependencySelector.Execute(constructionInfo.Constructor));
            return constructionInfo;
        }
    }

    /// <summary>
    /// Keeps track of a <see cref="ConstructionInfo"/> instance for each <see cref="Registration"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ConstructionInfoProvider : IConstructionInfoProvider
    {
        private readonly IConstructionInfoBuilder constructionInfoBuilder;
        private readonly ThreadSafeDictionary<Registration, ConstructionInfo> cache = new ThreadSafeDictionary<Registration, ConstructionInfo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionInfoProvider"/> class.
        /// </summary>
        /// <param name="constructionInfoBuilder">The <see cref="IConstructionInfoBuilder"/> that 
        /// is responsible for building a <see cref="ConstructionInfo"/> instance based on a given <see cref="Registration"/>.</param>
        public ConstructionInfoProvider(IConstructionInfoBuilder constructionInfoBuilder)
        {
            this.constructionInfoBuilder = constructionInfoBuilder;
        }

        /// <summary>
        /// Gets a <see cref="ConstructionInfo"/> instance for the given <paramref name="registration"/>.
        /// </summary>
        /// <param name="registration">The <see cref="Registration"/> for which to get a <see cref="ConstructionInfo"/> instance.</param>
        /// <returns>The <see cref="ConstructionInfo"/> instance that describes how to create an instance of the given <paramref name="registration"/>.</returns>
        public ConstructionInfo GetConstructionInfo(Registration registration)
        {
            return cache.GetOrAdd(registration, constructionInfoBuilder.Execute);
        }

        /// <summary>
        /// Invalidates the <see cref="IConstructionInfoProvider"/> and causes new <see cref="ConstructionInfo"/> instances 
        /// to be created when the <see cref="IConstructionInfoProvider.GetConstructionInfo"/> method is called.
        /// </summary>
        public void Invalidate()
        {
            cache.Clear();
        }
    }

    /// <summary>
    /// Provides a <see cref="ConstructorInfo"/> instance 
    /// that describes how to create a service instance.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ConstructionInfoBuilder : IConstructionInfoBuilder
    {
        private readonly Lazy<ILambdaConstructionInfoBuilder> lambdaConstructionInfoBuilder;
        private readonly Lazy<ITypeConstructionInfoBuilder> typeConstructionInfoBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionInfoBuilder"/> class.             
        /// </summary>
        /// <param name="lambdaConstructionInfoBuilderFactory">
        /// A function delegate used to provide a <see cref="ILambdaConstructionInfoBuilder"/> instance.
        /// </param>
        /// <param name="typeConstructionInfoBuilderFactory">
        /// A function delegate used to provide a <see cref="ITypeConstructionInfoBuilder"/> instance.
        /// </param>
        public ConstructionInfoBuilder(
            Func<ILambdaConstructionInfoBuilder> lambdaConstructionInfoBuilderFactory,
            Func<ITypeConstructionInfoBuilder> typeConstructionInfoBuilderFactory)
        {
            this.typeConstructionInfoBuilder = new Lazy<ITypeConstructionInfoBuilder>(typeConstructionInfoBuilderFactory);
            this.lambdaConstructionInfoBuilder = new Lazy<ILambdaConstructionInfoBuilder>(lambdaConstructionInfoBuilderFactory);
        }

        /// <summary>
        /// Returns a <see cref="ConstructionInfo"/> instance based on the given <see cref="Registration"/>.
        /// </summary>
        /// <param name="registration">The <see cref="Registration"/> for which to return a <see cref="ConstructionInfo"/> instance.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance that describes how to create a service instance.</returns>
        public ConstructionInfo Execute(Registration registration)
        {
            return registration.FactoryExpression != null
                ? CreateConstructionInfoFromLambdaExpression(registration.FactoryExpression)
                : CreateConstructionInfoFromImplementingType(registration.ImplementingType);
        }

        private ConstructionInfo CreateConstructionInfoFromLambdaExpression(LambdaExpression lambdaExpression)
        {
            return lambdaConstructionInfoBuilder.Value.Execute(lambdaExpression);
        }

        private ConstructionInfo CreateConstructionInfoFromImplementingType(Type implementingType)
        {
            return typeConstructionInfoBuilder.Value.Execute(implementingType);
        }
    }

    /// <summary>
    /// Parses a <see cref="LambdaExpression"/> into a <see cref="ConstructionInfo"/> instance.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class LambdaConstructionInfoBuilder : ILambdaConstructionInfoBuilder
    {
        /// <summary>
        /// Parses the <paramref name="lambdaExpression"/> and returns a <see cref="ConstructionInfo"/> instance.
        /// </summary>
        /// <param name="lambdaExpression">The <see cref="LambdaExpression"/> to parse.</param>
        /// <returns>A <see cref="ConstructionInfo"/> instance.</returns>
        public ConstructionInfo Execute(LambdaExpression lambdaExpression)
        {
            var lambdaExpressionValidator = new LambdaExpressionValidator();

            if (!lambdaExpressionValidator.CanParse(lambdaExpression))
            {
                return CreateConstructionInfoBasedOnLambdaExpression(lambdaExpression);
            }

            switch (lambdaExpression.Body.NodeType)
            {
                case ExpressionType.New:
                    return CreateConstructionInfoBasedOnNewExpression((NewExpression)lambdaExpression.Body);
                case ExpressionType.MemberInit:
                    return CreateConstructionInfoBasedOnHandleMemberInitExpression((MemberInitExpression)lambdaExpression.Body);
                default:
                    return CreateConstructionInfoBasedOnLambdaExpression(lambdaExpression);
            }
        }

        private static ConstructionInfo CreateConstructionInfoBasedOnLambdaExpression(LambdaExpression lambdaExpression)
        {
            return new ConstructionInfo { FactoryDelegate = lambdaExpression.Compile() };
        }

        private static ConstructionInfo CreateConstructionInfoBasedOnNewExpression(NewExpression newExpression)
        {
            var constructionInfo = CreateConstructionInfo(newExpression);
            ParameterInfo[] parameters = newExpression.Constructor.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                ConstructorDependency constructorDependency = CreateConstructorDependency(parameters[i]);
                ApplyDependencyDetails(newExpression.Arguments[i], constructorDependency);
                constructionInfo.ConstructorDependencies.Add(constructorDependency);
            }

            return constructionInfo;
        }

        private static ConstructionInfo CreateConstructionInfo(NewExpression newExpression)
        {
            var constructionInfo = new ConstructionInfo { Constructor = newExpression.Constructor, ImplementingType = newExpression.Constructor.DeclaringType };
            return constructionInfo;
        }

        private static ConstructionInfo CreateConstructionInfoBasedOnHandleMemberInitExpression(MemberInitExpression memberInitExpression)
        {
            var constructionInfo = CreateConstructionInfoBasedOnNewExpression(memberInitExpression.NewExpression);
            foreach (MemberBinding memberBinding in memberInitExpression.Bindings)
            {
                HandleMemberAssignment((MemberAssignment)memberBinding, constructionInfo);
            }

            return constructionInfo;
        }

        private static void HandleMemberAssignment(MemberAssignment memberAssignment, ConstructionInfo constructionInfo)
        {
            var propertyDependency = CreatePropertyDependency(memberAssignment);
            ApplyDependencyDetails(memberAssignment.Expression, propertyDependency);
            constructionInfo.PropertyDependencies.Add(propertyDependency);
        }

        private static ConstructorDependency CreateConstructorDependency(ParameterInfo parameterInfo)
        {
            var constructorDependency = new ConstructorDependency
            {
                Parameter = parameterInfo,
                ServiceType = parameterInfo.ParameterType
            };
            return constructorDependency;
        }

        private static PropertyDependency CreatePropertyDependency(MemberAssignment memberAssignment)
        {
            var propertyDependecy = new PropertyDependency
            {
                Property = (PropertyInfo)memberAssignment.Member,
                ServiceType = ((PropertyInfo)memberAssignment.Member).PropertyType
            };
            return propertyDependecy;
        }

        private static void ApplyDependencyDetails(Expression expression, Dependency dependency)
        {
            if (RepresentsServiceFactoryMethod(expression))
            {
                ApplyDependencyDetailsFromMethodCall((MethodCallExpression)expression, dependency);
            }
            else
            {
                ApplyDependecyDetailsFromExpression(expression, dependency);
            }
        }

        private static bool RepresentsServiceFactoryMethod(Expression expression)
        {
            return IsMethodCall(expression) &&
                IsServiceFactoryMethod(((MethodCallExpression)expression).Method);
        }

        private static bool IsMethodCall(Expression expression)
        {
            return expression.NodeType == ExpressionType.Call;
        }

        private static bool IsServiceFactoryMethod(MethodInfo methodInfo)
        {
            return methodInfo.DeclaringType == typeof(IServiceFactory);
        }

        private static void ApplyDependecyDetailsFromExpression(Expression expression, Dependency dependency)
        {
            dependency.FactoryExpression = expression;
            dependency.ServiceName = string.Empty;
        }

        private static void ApplyDependencyDetailsFromMethodCall(MethodCallExpression methodCallExpression, Dependency dependency)
        {
            dependency.ServiceType = methodCallExpression.Method.ReturnType;
            if (RepresentsGetNamedInstanceMethod(methodCallExpression))
            {
                dependency.ServiceName = (string)((ConstantExpression)methodCallExpression.Arguments[0]).Value;
            }
            else
            {
                dependency.ServiceName = string.Empty;
            }
        }

        private static bool RepresentsGetNamedInstanceMethod(MethodCallExpression node)
        {
            return IsGetInstanceMethod(node.Method) && HasOneArgumentRepresentingServiceName(node);
        }

        private static bool IsGetInstanceMethod(MethodInfo methodInfo)
        {
            return methodInfo.Name == "GetInstance";
        }

        private static bool HasOneArgumentRepresentingServiceName(MethodCallExpression node)
        {
            return HasOneArgument(node) && IsConstantExpression(node.Arguments[0]);
        }

        private static bool HasOneArgument(MethodCallExpression node)
        {
            return node.Arguments.Count == 1;
        }

        private static bool IsConstantExpression(Expression argument)
        {
            return argument.NodeType == ExpressionType.Constant;
        }
    }

    /// <summary>
    /// Inspects the body of a <see cref="LambdaExpression"/> and determines if the expression can be parsed.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class LambdaExpressionValidator : ExpressionVisitor
    {
        private bool canParse = true;

        /// <summary>
        /// Determines if the <paramref name="lambdaExpression"/> can be parsed.
        /// </summary>
        /// <param name="lambdaExpression">The <see cref="LambdaExpression"/> to validate.</param>
        /// <returns><b>true</b>, if the expression can be parsed, otherwise <b>false</b>.</returns>
        public bool CanParse(LambdaExpression lambdaExpression)
        {
            Visit(lambdaExpression.Body);
            return canParse;
        }

        /// <summary>
        /// Visits the children of the <see cref="T:System.Linq.Expressions.Expression`1"/>.
        /// </summary>
        /// <returns>
        /// The modified expression, if it or any sub-expression was modified; otherwise, returns the original expression.
        /// </returns>
        /// <param name="node">The expression to visit.</param><typeparam name="T">The type of the delegate.</typeparam>
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            canParse = false;
            return base.VisitLambda(node);
        }

        /// <summary>
        /// Visits the children of the <see cref="T:System.Linq.Expressions.UnaryExpression"/>.
        /// </summary>
        /// <returns>
        /// The modified expression, if it or any sub-expression was modified; otherwise, returns the original expression.
        /// </returns>
        /// <param name="node">The expression to visit.</param>
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert)
            {
                canParse = false;
            }

            return base.VisitUnary(node);
        }
    }

    /// <summary>
    /// Contains information about a service request that originates from a rule based service registration.
    /// </summary>    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequest"/> class.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the requested service.</param>
        /// <param name="serviceName">The name of the requested service.</param>
        /// <param name="serviceFactory">The <see cref="IServiceFactory"/> to be associated with this <see cref="ServiceRequest"/>.</param>
        public ServiceRequest(Type serviceType, string serviceName, IServiceFactory serviceFactory)
        {
            ServiceType = serviceType;
            ServiceName = serviceName;
            ServiceFactory = serviceFactory;
        }

        /// <summary>
        /// Gets the service type.
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// Gets the service name.
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// Gets the <see cref="IServiceFactory"/> that is associated with this <see cref="ServiceRequest"/>.
        /// </summary>
        public IServiceFactory ServiceFactory { get; private set; }
    }

    /// <summary>
    /// Base class for concrete registrations within the service container.
    /// </summary>
    internal abstract class Registration
    {
        /// <summary>
        /// Gets or sets the service <see cref="Type"/>.
        /// </summary>
        public Type ServiceType { get; internal set; }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> that implements the <see cref="Registration.ServiceType"/>.
        /// </summary>
        public Type ImplementingType { get; internal set; }

        /// <summary>
        /// Gets or sets the <see cref="LambdaExpression"/> used to create a service instance.
        /// </summary>
        public LambdaExpression FactoryExpression { get; set; }
    }

    /// <summary>
    /// Contains information about a registered decorator.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class DecoratorRegistration : Registration
    {
        /// <summary>
        /// Gets or sets a function delegate that determines if the decorator can decorate the service 
        /// represented by the supplied <see cref="ServiceRegistration"/>.
        /// </summary>
        public Func<ServiceRegistration, bool> CanDecorate { get; internal set; }
    }

    /// <summary>
    /// Contains information about a registered service.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ServiceRegistration : Registration
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; internal set; }

        /// <summary>
        /// Gets or sets the <see cref="ILifetime"/> instance that controls the lifetime of the service.
        /// </summary>
        public ILifetime Lifetime { get; set; }

        /// <summary>
        /// Gets or sets the value that represents the instance of the service.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ServiceType.GetHashCode() ^ ServiceName.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            var other = obj as ServiceRegistration;
            if (other == null)
            {
                return false;
            }

            var result = ServiceName == other.ServiceName && ServiceType == other.ServiceType;
            return result;
        }
    }

    /// <summary>
    /// Contains information about how to create a service instance.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ConstructionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionInfo"/> class.
        /// </summary>
        public ConstructionInfo()
        {
            PropertyDependencies = new List<PropertyDependency>();
            ConstructorDependencies = new List<ConstructorDependency>();
        }

        /// <summary>
        /// Gets or sets the implementing type that represents the concrete class to create.
        /// </summary>
        public Type ImplementingType { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ConstructorInfo"/> that is used to create a service instance.
        /// </summary>
        public ConstructorInfo Constructor { get; set; }

        /// <summary>
        /// Gets a list of <see cref="PropertyDependency"/> instances that represent 
        /// the property dependencies for the target service instance. 
        /// </summary>
        public List<PropertyDependency> PropertyDependencies { get; private set; }

        /// <summary>
        /// Gets a list of <see cref="ConstructorDependency"/> instances that represent 
        /// the property dependencies for the target service instance. 
        /// </summary>
        public List<ConstructorDependency> ConstructorDependencies { get; private set; }

        /// <summary>
        /// Gets or sets the function delegate to be used to create the service instance.
        /// </summary>
        public Delegate FactoryDelegate { get; set; }
    }

    /// <summary>
    /// Represents a class dependency.
    /// </summary>
    internal abstract class Dependency
    {
        /// <summary>
        /// Gets or sets the service <see cref="Type"/> of the <see cref="Dependency"/>.
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the service name of the <see cref="Dependency"/>.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FactoryExpression"/> that represent getting the value of the <see cref="Dependency"/>.
        /// </summary>            
        public Expression FactoryExpression { get; set; }

        /// <summary>
        /// Gets the name of the dependency accessor.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this dependency is required.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Returns textual information about the dependency.
        /// </summary>
        /// <returns>A string that describes the dependency.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.AppendFormat("[Requested dependency: ServiceType:{0}, ServiceName:{1}]", ServiceType, ServiceName).ToString();
        }
    }

    /// <summary>
    /// Represents a property dependency.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class PropertyDependency : Dependency
    {
        /// <summary>
        /// Gets or sets the <see cref="MethodInfo"/> that is used to set the property value.
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// Gets the name of the dependency accessor.
        /// </summary>
        public override string Name
        {
            get
            {
                return Property.Name;
            }
        }

        /// <summary>
        /// Returns textual information about the dependency.
        /// </summary>
        /// <returns>A string that describes the dependency.</returns>
        public override string ToString()
        {
            return string.Format("[Target Type: {0}], [Property: {1}({2})]", Property.DeclaringType, Property.Name, Property.PropertyType) + ", " + base.ToString();
        }
    }

    /// <summary>
    /// Represents a constructor dependency.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ConstructorDependency : Dependency
    {
        /// <summary>
        /// Gets or sets the <see cref="ParameterInfo"/> for this <see cref="ConstructorDependency"/>.
        /// </summary>
        public ParameterInfo Parameter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether that this parameter represents  
        /// the decoration target passed into a decorator instance. 
        /// </summary>
        public bool IsDecoratorTarget { get; set; }

        /// <summary>
        /// Gets the name of the dependency accessor.
        /// </summary>
        public override string Name
        {
            get
            {
                return Parameter.Name;
            }
        }

        /// <summary>
        /// Returns textual information about the dependency.
        /// </summary>
        /// <returns>A string that describes the dependency.</returns>
        public override string ToString()
        {
            return string.Format("[Target Type: {0}], [Parameter: {1}({2})]", Parameter.Member.DeclaringType, Parameter.Name, Parameter.ParameterType) + ", " + base.ToString();
        }
    }

    /// <summary>
    /// Ensures that only one instance of a given service can exist within the current <see cref="IServiceContainer"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class PerContainerLifetime : ILifetime, IDisposable
    {
        private readonly object syncRoot = new object();
        private object singleton;

        /// <summary>
        /// Returns a service instance according to the specific lifetime characteristics.
        /// </summary>
        /// <param name="createInstance">The function delegate used to create a new service instance.</param>
        /// <param name="scope">The <see cref="Scope"/> of the current service request.</param>
        /// <returns>The requested services instance.</returns>
        public object GetInstance(Func<object> createInstance, Scope scope)
        {
            if (singleton != null)
            {
                return singleton;
            }

            lock (syncRoot)
            {
                if (singleton == null)
                {
                    singleton = createInstance();
                }
            }

            return singleton;
        }

        /// <summary>
        /// Disposes the service instances managed by this <see cref="PerContainerLifetime"/> instance.
        /// </summary>
        public void Dispose()
        {
            var disposable = singleton as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }

    /// <summary>
    /// Ensures that a new instance is created for each request in addition to tracking disposable instances.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class PerRequestLifeTime : ILifetime
    {
        /// <summary>
        /// Returns a service instance according to the specific lifetime characteristics.
        /// </summary>
        /// <param name="createInstance">The function delegate used to create a new service instance.</param>
        /// <param name="scope">The <see cref="Scope"/> of the current service request.</param>
        /// <returns>The requested services instance.</returns>
        public object GetInstance(Func<object> createInstance, Scope scope)
        {
            var instance = createInstance();
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                TrackInstance(scope, disposable);
            }

            return instance;
        }

        private static void TrackInstance(Scope scope, IDisposable disposable)
        {
            if (scope == null)
            {
                throw new InvalidOperationException("Attempt to create a disposable instance without a current scope.");
            }

            scope.TrackInstance(disposable);
        }
    }

    /// <summary>
    /// Ensures that only one service instance can exist within a given <see cref="Scope"/>.
    /// </summary>
    /// <remarks>
    /// If the service instance implements <see cref="IDisposable"/>, 
    /// it will be disposed when the <see cref="Scope"/> ends.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class PerScopeLifetime : ILifetime
    {
        private readonly ThreadSafeDictionary<Scope, object> instances = new ThreadSafeDictionary<Scope, object>();

        /// <summary>
        /// Returns the same service instance within the current <see cref="Scope"/>.
        /// </summary>
        /// <param name="createInstance">The function delegate used to create a new service instance.</param>
        /// <param name="scope">The <see cref="Scope"/> of the current service request.</param>
        /// <returns>The requested services instance.</returns>
        public object GetInstance(Func<object> createInstance, Scope scope)
        {
            if (scope == null)
            {
                throw new InvalidOperationException(
                    "Attempt to create a scoped instance without a current scope.");
            }

            return instances.GetOrAdd(scope, s => CreateScopedInstance(s, createInstance));
        }

        private static void RegisterForDisposal(Scope scope, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                scope.TrackInstance(disposable);
            }
        }

        private object CreateScopedInstance(Scope scope, Func<object> createInstance)
        {
            scope.Completed += OnScopeCompleted;
            var instance = createInstance();

            RegisterForDisposal(scope, instance);
            return instance;
        }

        private void OnScopeCompleted(object sender, EventArgs e)
        {
            var scope = (Scope)sender;
            scope.Completed -= OnScopeCompleted;
            object removedInstance;
            instances.TryRemove(scope, out removedInstance);
        }
    }

    /// <summary>
    /// Manages a set of <see cref="Scope"/> instances.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class ScopeManager
    {
        private readonly object syncRoot = new object();

        private Scope currentScope;

        /// <summary>
        /// Gets the current <see cref="Scope"/>.
        /// </summary>
        public Scope CurrentScope
        {
            get
            {
                lock (syncRoot)
                {
                    return currentScope;
                }
            }
        }

        /// <summary>
        /// Starts a new <see cref="Scope"/>. 
        /// </summary>
        /// <returns>A new <see cref="Scope"/>.</returns>
        public Scope BeginScope()
        {
            lock (syncRoot)
            {
                var scope = new Scope(this, currentScope);
                if (currentScope != null)
                {
                    currentScope.ChildScope = scope;
                }

                currentScope = scope;
                return scope;
            }
        }

        /// <summary>
        /// Ends the given <paramref name="scope"/> and updates the <see cref="CurrentScope"/> property.
        /// </summary>
        /// <param name="scope">The scope that is completed.</param>
        public void EndScope(Scope scope)
        {
            lock (syncRoot)
            {
                if (scope.ChildScope != null)
                {
                    throw new InvalidOperationException("Attempt to end a scope before all child scopes are completed.");
                }

                currentScope = scope.ParentScope;
                if (currentScope != null)
                {
                    currentScope.ChildScope = null;
                }
            }
        }
    }

    /// <summary>
    /// Represents a scope 
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class Scope : IDisposable
    {
        private readonly IList<IDisposable> disposableObjects = new List<IDisposable>();

        private readonly ScopeManager scopeManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scope"/> class.
        /// </summary>
        /// <param name="scopeManager">The <see cref="scopeManager"/> that manages this <see cref="Scope"/>.</param>
        /// <param name="parentScope">The parent <see cref="Scope"/>.</param>
        public Scope(ScopeManager scopeManager, Scope parentScope)
        {
            this.scopeManager = scopeManager;
            ParentScope = parentScope;
        }

        /// <summary>
        /// Raised when the <see cref="Scope"/> is completed.
        /// </summary>
        public event EventHandler<EventArgs> Completed;

        /// <summary>
        /// Gets or sets the parent <see cref="Scope"/>.
        /// </summary>
        public Scope ParentScope { get; internal set; }

        /// <summary>
        /// Gets or sets the child <see cref="Scope"/>.
        /// </summary>
        public Scope ChildScope { get; internal set; }

        /// <summary>
        /// Registers the <paramref name="disposable"/> so that it is disposed when the scope is completed.
        /// </summary>
        /// <param name="disposable">The <see cref="IDisposable"/> object to register.</param>
        public void TrackInstance(IDisposable disposable)
        {
            disposableObjects.Add(disposable);
        }

        /// <summary>
        /// Disposes all instances tracked by this scope.
        /// </summary>
        public void Dispose()
        {
            DisposeTrackedInstances();
            OnCompleted();
        }

        private void DisposeTrackedInstances()
        {
            foreach (var disposableObject in disposableObjects)
            {
                disposableObject.Dispose();
            }
        }

        private void OnCompleted()
        {
            scopeManager.EndScope(this);
            var completedHandler = Completed;
            if (completedHandler != null)
            {
                completedHandler(this, new EventArgs());
            }
        }
    }

    /// <summary>
    /// An assembly scanner that registers services based on the types contained within an <see cref="Assembly"/>.
    /// </summary>    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class AssemblyScanner : IAssemblyScanner
    {
        private static readonly List<Type> InternalTypes = new List<Type>();
        private Assembly currentAssembly;

        static AssemblyScanner()
        {
            InternalTypes.Add(typeof(LambdaConstructionInfoBuilder));
            InternalTypes.Add(typeof(LambdaExpressionValidator));
            InternalTypes.Add(typeof(ConstructorDependency));
            InternalTypes.Add(typeof(PropertyDependency));
            InternalTypes.Add(typeof(ThreadSafeDictionary<,>));
            InternalTypes.Add(typeof(Scope));
            InternalTypes.Add(typeof(PerContainerLifetime));
            InternalTypes.Add(typeof(PerScopeLifetime));
            InternalTypes.Add(typeof(ScopeManager));
            InternalTypes.Add(typeof(ServiceRegistration));
            InternalTypes.Add(typeof(DecoratorRegistration));
            InternalTypes.Add(typeof(ServiceRequest));
            InternalTypes.Add(typeof(Registration));
            InternalTypes.Add(typeof(ServiceContainer));
            InternalTypes.Add(typeof(ConstructionInfo));
            InternalTypes.Add(typeof(AssemblyLoader));
            InternalTypes.Add(typeof(TypeConstructionInfoBuilder));
            InternalTypes.Add(typeof(ConstructionInfoProvider));
            InternalTypes.Add(typeof(ConstructionInfoBuilder));
            InternalTypes.Add(typeof(ConstructorSelector));
            InternalTypes.Add(typeof(PerContainerLifetime));
            InternalTypes.Add(typeof(PerContainerLifetime));
            InternalTypes.Add(typeof(PerRequestLifeTime));
            InternalTypes.Add(typeof(PropertySelector));
            InternalTypes.Add(typeof(AssemblyScanner));
            InternalTypes.Add(typeof(ConstructorDependencySelector));
            InternalTypes.Add(typeof(PropertyDependencySelector));
        }

        /// <summary>
        /// Scans the target <paramref name="assembly"/> and registers services found within the assembly.
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly"/> to scan.</param>        
        /// <param name="serviceRegistry">The target <see cref="IServiceRegistry"/> instance.</param>
        /// <param name="lifetimeFactory">The <see cref="ILifetime"/> factory that controls the lifetime of the registered service.</param>
        /// <param name="shouldRegister">A function delegate that determines if a service implementation should be registered.</param>
        public void Scan(Assembly assembly, IServiceRegistry serviceRegistry, Func<ILifetime> lifetimeFactory, Func<Type, Type, bool> shouldRegister)
        {
            IEnumerable<Type> concreteTypes = GetConcreteTypes(assembly).ToList();
            var compositionRoots = concreteTypes.Where(t => typeof(ICompositionRoot).IsAssignableFrom(t)).ToList();
            if (compositionRoots.Count > 0 && currentAssembly != assembly)
            {
                currentAssembly = assembly;
                ExecuteCompositionRoots(compositionRoots, serviceRegistry);
            }
            else
            {
                foreach (Type type in concreteTypes)
                {
                    BuildImplementationMap(type, serviceRegistry, lifetimeFactory, shouldRegister);
                }
            }
        }

        private static void ExecuteCompositionRoots(IEnumerable<Type> compositionRoots, IServiceRegistry serviceRegistry)
        {
            foreach (var compositionRoot in compositionRoots)
            {
                ((ICompositionRoot)Activator.CreateInstance(compositionRoot)).Compose(serviceRegistry);
            }
        }

        private static string GetServiceName(Type serviceType, Type implementingType)
        {
            string implementingTypeName = implementingType.Name;
            string serviceTypeName = serviceType.Name;
            if (TypeHelper.IsGenericTypeDefinition(implementingType))
            {
                var regex = new Regex("((?:[a-z][a-z]+))", RegexOptions.IgnoreCase);
                implementingTypeName = regex.Match(implementingTypeName).Groups[1].Value;
                serviceTypeName = regex.Match(serviceTypeName).Groups[1].Value;
            }

            if (serviceTypeName.Substring(1) == implementingTypeName)
            {
                implementingTypeName = string.Empty;
            }

            return implementingTypeName;
        }

        private static IEnumerable<Type> GetBaseTypes(Type concreteType)
        {
            Type baseType = concreteType;
            while (baseType != typeof(object) && baseType != null)
            {
                yield return baseType;
                baseType = TypeHelper.GetBaseType(baseType);
            }
        }

        private static IEnumerable<Type> GetConcreteTypes(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => TypeHelper.IsClass(t) && !TypeHelper.IsNestedPrivate(t)
                && !TypeHelper.IsAbstract(t) && !(t.Namespace ?? string.Empty).StartsWith("System") && !IsCompilerGenerated(t)).Except(InternalTypes);
        }

        private static bool IsCompilerGenerated(Type type)
        {
            return type.IsDefined(typeof(CompilerGeneratedAttribute), false);
        }

        private void BuildImplementationMap(Type implementingType, IServiceRegistry serviceRegistry, Func<ILifetime> lifetimeFactory, Func<Type, Type, bool> shouldRegister)
        {
            Type[] interfaces = implementingType.GetInterfaces();
            foreach (Type interfaceType in interfaces)
            {
                if (shouldRegister(interfaceType, implementingType))
                {
                    RegisterInternal(interfaceType, implementingType, serviceRegistry, lifetimeFactory());
                }
            }

            foreach (Type baseType in GetBaseTypes(implementingType))
            {
                if (shouldRegister(baseType, implementingType))
                {
                    RegisterInternal(baseType, implementingType, serviceRegistry, lifetimeFactory());
                }
            }
        }

        private void RegisterInternal(Type serviceType, Type implementingType, IServiceRegistry serviceRegistry, ILifetime lifetime)
        {
            if (TypeHelper.IsGenericType(serviceType) && TypeHelper.ContainsGenericParameters(serviceType))
            {
                serviceType = serviceType.GetGenericTypeDefinition();
            }

            serviceRegistry.Register(serviceType, implementingType, GetServiceName(serviceType, implementingType), lifetime);
        }
    }

    /// <summary>
    /// Selects the properties that represents a dependency to the target <see cref="Type"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class PropertySelector : IPropertySelector
    {
        /// <summary>
        /// Selects properties that represents a dependency from the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> for which to select the properties.</param>
        /// <returns>A list of properties that represents a dependency to the target <paramref name="type"/></returns>
        public IEnumerable<PropertyInfo> Execute(Type type)
        {
            return type.GetProperties().Where(IsInjectable).ToList();
        }

        /// <summary>
        /// Determines if the <paramref name="propertyInfo"/> represents an injectable property.
        /// </summary>
        /// <param name="propertyInfo">The <see cref="PropertyInfo"/> that describes the target property.</param>
        /// <returns><b>true</b> if the property is injectable, otherwise <b>false</b>.</returns>
        protected virtual bool IsInjectable(PropertyInfo propertyInfo)
        {
            return !IsReadOnly(propertyInfo);
        }

        private static bool IsReadOnly(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetSetMethod() == null || propertyInfo.GetSetMethod().IsStatic || propertyInfo.GetSetMethod().IsPrivate;
        }
    }

    /// <summary>
    /// Loads all assemblies from the application base directory that matches the given search pattern.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class AssemblyLoader : IAssemblyLoader
    {
        /// <summary>
        /// Loads a set of assemblies based on the given <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="searchPattern">The search pattern to use.</param>
        /// <returns>A list of assemblies based on the given <paramref name="searchPattern"/>.</returns>
        public IEnumerable<Assembly> Load(string searchPattern)
        {
            string directory = Path.GetDirectoryName(new Uri(typeof(ServiceContainer).Assembly.CodeBase).LocalPath);
            if (directory != null)
            {
                string[] searchPatterns = searchPattern.Split('|');
                foreach (string file in searchPatterns.SelectMany(sp => Directory.GetFiles(directory, sp)).Where(CanLoad))
                {
                    yield return Assembly.LoadFrom(file);
                }
            }
        }

        /// <summary>
        /// Indicates if the current <paramref name="fileName"/> represent a file that can be loaded.
        /// </summary>
        /// <param name="fileName">The name of the target file.</param>
        /// <returns><b>true</b> if the file can be loaded, otherwise <b>false</b>.</returns>
        protected virtual bool CanLoad(string fileName)
        {
            return true;
        }
    }
}