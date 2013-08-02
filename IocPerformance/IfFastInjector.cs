using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IfFastInjector
{
    /// <summary>
    /// Inject attribute. Used to flag constructors for preferred injection. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Property | AttributeTargets.Field)]
    public class IfInjectAttribute : Attribute { }

    /// <summary>
    /// Ignore constructor attribute. Used to flage constructors to be ignored.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public class IfIgnoreConstructorAttribute : Attribute { }

    /// <summary>
    /// Implemented by attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IfImplementedByAttribute : Attribute
    {
        private readonly Type implementor;
        public IfImplementedByAttribute(Type implementor)
        {
            this.implementor = implementor;
        }

        public Type Implementor { get { return implementor; } }
    }

    /// <summary>
    /// Singleton attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IfSingletonAttribute : Attribute { }

    /// <summary>
    /// Injector.
    /// </summary>
    public abstract class IfInjector
    {
        /// <summary>
        /// News the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        public static IfInjector NewInstance()
        {
            return new IfFastInjectorInternal.InjectorInternal();
        }

        /// <summary>
        /// Resolve this instance.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        /// Resolve the specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        public abstract object Resolve(Type type);

        /// <summary>
        /// Sets the resolver.
        /// </summary>
        /// <returns>The resolver.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TConcreteType">The 2nd type parameter.</typeparam>
        public abstract IfInjectorTypes.IfFastInjectorBinding<TConcreteType> Bind<T, TConcreteType>()
            where T : class
            where TConcreteType : class, T;

        /// <summary>
        /// Sets the resolver.
        /// </summary>
        /// <typeparam name="TConcreteType">The 1st type parameter.</typeparam>
        public IfInjectorTypes.IfFastInjectorBinding<TConcreteType> Bind<TConcreteType>()
            where TConcreteType : class
        {
            return Bind<TConcreteType, TConcreteType>();
        }

        /// <summary>
        /// Bind the specified factoryExpression.
        /// </summary>
        /// <param name="factoryExpression">Factory expression.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="CT">The 2nd type parameter. This parameter is required to allow for auto-injection of factory provided object.</typeparam>
        public IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, CT>(Expression<Func<CT>> factoryExpression)
            where T : class
            where CT : class, T
        {
            return Bind<T, CT>(factoryExpression as LambdaExpression);
        }

        /// <summary>
        /// Bind the specified factoryExpression.
        /// </summary>
        /// <param name="factoryExpression">Factory expression.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="CT">The 2nd type parameter.</typeparam>
        protected abstract IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, CT>(LambdaExpression factoryExpression)
            where T : class
            where CT : class, T;

        /// <summary>
        /// Injects the properties of an instance.
        /// </summary>
        /// <returns>The properties.</returns>
        /// <param name="instance">Instance.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public abstract T InjectProperties<T>(T instance)
            where T : class;

        /// <summary>
        /// Binds the lambda factory. Do not use thid directly, but instead create extension methods that take N-input Func<> methods.
        /// </summary>
        /// <returns>The lambda factory.</returns>
        /// <param name="injector">Injector.</param>
        /// <param name="factoryExpression">Factory expression.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="CT">The 2nd type parameter.</typeparam>
        public static IfInjectorTypes.IfFastInjectorBinding<CT> BindFactory<T, CT>(IfInjector injector, LambdaExpression factoryExpression)
            where T : class
            where CT : class, T
        {
            return injector.Bind<T, CT>(factoryExpression);
        }
    }

    namespace IfFastExtensions
    {
        /// <summary>
        /// Provide extension methods up to Func<P1..P4,CT>
        /// </summary>
        public static class IfInjectorBindingExtensions
        {
            public static IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, P1, CT>(this IfInjector injector, Expression<Func<P1, CT>> factoryExpression)
                where T : class
                where CT : class, T
                where P1 : class
            {
                return IfInjector.BindFactory<T, CT>(injector, factoryExpression as LambdaExpression);
            }

            public static IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, P1, P2, CT>(this IfInjector injector, Expression<Func<P1, P2, CT>> factoryExpression)
                where T : class
                where CT : class, T
                where P1 : class
                where P2 : class
            {
                return IfInjector.BindFactory<T, CT>(injector, factoryExpression as LambdaExpression);
            }

            public static IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, P1, P2, P3, CT>(this IfInjector injector, Expression<Func<P1, P2, P3, CT>> factoryExpression)
                where T : class
                where CT : class, T
                where P1 : class
                where P2 : class
                where P3 : class
            {
                return IfInjector.BindFactory<T, CT>(injector, factoryExpression as LambdaExpression);
            }

            public static IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, P1, P2, P3, P4, CT>(this IfInjector injector, Expression<Func<P1, P2, P3, P4, CT>> factoryExpression)
                where T : class
                where CT : class, T
                where P1 : class
                where P2 : class
                where P3 : class
                where P4 : class
            {
                return IfInjector.BindFactory<T, CT>(injector, factoryExpression as LambdaExpression);
            }
        }
    }

    /// <summary>
    /// Holder of secondary IfInjector types and interfaces. Most API users will not need to access these types directly.
    /// </summary>
    namespace IfInjectorTypes
    {
        /// <summary>
        /// Represents an error code constant.
        /// </summary>
        public class IfFastInjectorError
        {
            internal IfFastInjectorError(int messageCode, string messageTemplate)
            {
                MessageCode = string.Format("IF{0:D4}", messageCode);
                MessageTemplate = messageTemplate;
            }

            public string MessageCode { get; private set; }
            public string MessageTemplate { get; private set; }

            public IfFastInjectorException FormatEx(params object[] args)
            {
                var msgFormatted = string.Format(MessageTemplate, args);
                return new IfFastInjectorException(this, msgFormatted);
            }

            public IfFastInjectorException FormatEx(Exception innerException, params object[] args)
            {
                var msgFormatted = string.Format(MessageTemplate, args);
                return new IfFastInjectorException(this, msgFormatted, innerException);
            }
        }

        /// <summary>
        /// If fast injector errors.
        /// </summary>
        public static class IfFastInjectorErrors
        {
            public static readonly IfFastInjectorError ErrorResolutionRecursionDetected = new IfFastInjectorError(1, "Resolution recursion detected.  Resolve<{0}> is called by a dependency of Resolve<{0}> leading to an infinite loop.");
            public static readonly IfFastInjectorError ErrorUnableToResultInterface = new IfFastInjectorError(2, "Error on {0}. Unable to resolve Interface and Abstract classes without a configuration.");
            public static readonly IfFastInjectorError ErrorMustContainMemberExpression = new IfFastInjectorError(3, "Must contain a MemberExpression");
            public static readonly IfFastInjectorError ErrorAmbiguousBinding = new IfFastInjectorError(4, "Multiple implicit bindings exist for type: {0}. Please disambiguate by adding an explicit binding for this type.");
            public static readonly IfFastInjectorError ErrorUnableToBindNonClassFieldsProperties = new IfFastInjectorError(5, "Autoinjection is only supported on single instance 'class' fields. Please define a manual binding for the field or property '{0}' on class '{1}'.");
        }

        /// <summary>
        /// If fast injector exception.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
        public class IfFastInjectorException : Exception
        {
            public IfFastInjectorException(IfFastInjectorError errorType, string message)
                : base(message)
            {
                ErrorType = errorType;
            }

            public IfFastInjectorException(IfFastInjectorError errorType, string message, Exception innerException)
                : base(message, innerException)
            {
                ErrorType = errorType;
            }

            public IfFastInjectorError ErrorType { get; private set; }
        }

        /// <summary>
        /// The fluent class is really only important to give the extension methods the type for T. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IfFastInjectorBinding<T> where T : class
        {
            IfFastInjectorBinding<T> AddPropertyInjector<TPropertyType>(Expression<Func<T, TPropertyType>> propertyExpression)
                where TPropertyType : class;

            IfFastInjectorBinding<T> AddPropertyInjector<TPropertyType>(Expression<Func<T, TPropertyType>> propertyExpression, Expression<Func<TPropertyType>> setter);

            IfFastInjectorBinding<T> AsSingleton(bool singlton = true);
        }
    }
}