using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using IfFastInjector.IfInjectorTypes;

namespace IfFastInjector
{
    internal abstract class IfFastInjectorInternal
    {
        protected internal interface IRegistration
        {
            bool IsSingleton { get; }
            void ConditionalClearResolver(Type touched);

            object DoResolve();
            Expression GetResolveExpr(HashSet<Type> callerDeps);
        }

        protected internal class InjectorTypeConstruct
        {
            public IRegistration MyRegistration { get; set; }
            public bool IsRecursionTestPending { get; set; }
            public bool IsInternalResolverPending { get; set; }

            public ISet<Type> ImplicitTypes { get; private set; }

            public InjectorTypeConstruct()
            {
                IsInternalResolverPending = true;
            }
        }

        /// <summary>
        /// Gets the implicit types.
        /// </summary>
        /// <returns>The implicit types.</returns>
        /// <param name="boundType">Bound type.</param>
        protected internal static ISet<Type> GetImplicitTypes(Type boundType)
        {
            var implicitTypes = new HashSet<Type>();

            foreach (Type iFace in boundType.GetInterfaces())
            {
                implicitTypes.Add(iFace);
            }

            Type wTypeChain = boundType;
            while ((wTypeChain = wTypeChain.BaseType) != null && wTypeChain != typeof(object))
            {
                implicitTypes.Add(wTypeChain);
            }

            return implicitTypes;
        }

        /// <summary>
        /// The actual injector implementation.
        /// </summary>
        internal class InjectorInternal : IfInjector
        {
            // Thread safety via lock (internalResolvers) 
            private readonly object syncLock = new object();
            private readonly SafeDictionary<Type, InjectorTypeConstruct> allTypeConstructs;
            private readonly SafeDictionary<Type, ISet<Type>> implicitTypeLookup;

            public InjectorInternal()
            {
                // Init dictionaries
                allTypeConstructs = new SafeDictionary<Type, InjectorTypeConstruct>(syncLock);
                implicitTypeLookup = new SafeDictionary<Type, ISet<Type>>(syncLock);
            }

            public override object Resolve(Type type)
            {
                return ResolveResolver(type).DoResolve();
            }

            public override T InjectProperties<T>(T instance)
            {
                return ((Registration<T>)ResolveResolver(typeof(T))).DoInject(instance);
            }

            protected internal IRegistration ResolveResolver(Type type)
            {
                ISet<Type> lookup;
                InjectorTypeConstruct typeInfo;

                if (allTypeConstructs.UnsyncedTryGetValue(type, out typeInfo) && typeInfo.MyRegistration != null)
                {
                    return typeInfo.MyRegistration;
                }
                else if (implicitTypeLookup.UnsyncedTryGetValue(type, out lookup) && lookup.Count > 0)
                {
                    if (lookup.Count == 1)
                    {
                        return ResolveResolver(lookup.First());
                    }
                    else
                    {
                        throw IfFastInjectorErrors.ErrorAmbiguousBinding.FormatEx(type.Name);
                    }
                }
                else
                {
                    return BindImplicit(type);
                }
            }

            public override IfFastInjectorBinding<TConcreteType> Bind<T, TConcreteType>()
            {
                var iResolver = BindExplicit<T, TConcreteType>();
                return new InjectorFluent<TConcreteType>(iResolver);
            }

            protected override IfInjectorTypes.IfFastInjectorBinding<CT> Bind<T, CT>(LambdaExpression factoryExpression)
            {
                var iResolver = BindExplicit<T, CT>(factoryExpression);
                return new InjectorFluent<CT>(iResolver);
            }

            private Registration<CType> BindExplicit<BType, CType>(LambdaExpression factoryExpression = null)
                where BType : class
                where CType : class, BType
            {
                lock (syncLock)
                {
                    Type bindType = typeof(BType);
                    InjectorTypeConstruct typeConstruct = new InjectorTypeConstruct();

                    implicitTypeLookup.Remove(bindType);
                    allTypeConstructs.Remove(bindType);
                    allTypeConstructs.Add(bindType, typeConstruct);
                    AddImplicitTypes(bindType, GetImplicitTypes(bindType));

                    CreateInternalResolverInstance(bindType, typeof(CType), typeConstruct, factoryExpression);

                    ClearResolver(bindType);

                    return (Registration<CType>)typeConstruct.MyRegistration;
                }
            }

            private IRegistration BindImplicit(Type bindType)
            {
                lock (syncLock)
                {
                    InjectorTypeConstruct typeConstruct;
                    if (allTypeConstructs.TryGetValue(bindType, out typeConstruct))
                    {
                        if (typeConstruct.IsInternalResolverPending)
                        {
                            throw IfFastInjectorErrors.ErrorResolutionRecursionDetected.FormatEx(bindType.Name);
                        }
                        return typeConstruct.MyRegistration;
                    }

                    typeConstruct = new InjectorTypeConstruct();
                    allTypeConstructs.Add(bindType, typeConstruct);

                    // Handle implementedBy
                    var implType = GetIfImplementedBy(bindType);
                    if (implType != null)
                    {
                        CreateInternalResolverInstance(bindType, implType, typeConstruct);
                    }
                    else
                    {
                        CreateInternalResolverInstance(bindType, bindType, typeConstruct);
                    }

                    ClearResolver(bindType);

                    return typeConstruct.MyRegistration;
                }
            }

            protected internal Type GetIfImplementedBy(Type type)
            {
                var implTypeAttrs = type.GetCustomAttributes(typeof(IfImplementedByAttribute), false);
                if (implTypeAttrs.Length > 0)
                {
                    return (implTypeAttrs[0] as IfImplementedByAttribute).Implementor;
                }
                return null;
            }

            private void CreateInternalResolverInstance(Type keyType, Type implType, InjectorTypeConstruct typeConstruct, LambdaExpression factoryExpression = null)
            {
                try
                {
                    Type iResolverType = typeof(Registration<>);
                    Type genericType = iResolverType.MakeGenericType(new Type[] { implType });
                    typeConstruct.MyRegistration = (IRegistration)Activator.CreateInstance(genericType, this, typeConstruct, keyType, syncLock, factoryExpression);
                    typeConstruct.IsInternalResolverPending = false;

                    SetupImplicitPropResolvers(typeConstruct.MyRegistration, implType);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            }

            private void AddImplicitTypes(Type boundType, ISet<Type> implicitTypes)
            {
                lock (syncLock)
                {
                    foreach (Type implicitType in implicitTypes)
                    {
                        if (GetIfImplementedBy(implicitType) == null)
                        {
                            ISet<Type> newSet, oldSet;

                            if (implicitTypeLookup.TryGetValue(implicitType, out oldSet))
                            {
                                implicitTypeLookup.Remove(implicitType);
                                newSet = new HashSet<Type>(oldSet);
                            }
                            else
                            {
                                newSet = new HashSet<Type>();
                            }

                            newSet.Add(boundType);
                            implicitTypeLookup.Add(implicitType, newSet);
                        }
                        else
                        {
                            BindImplicit(implicitType);
                        }
                    }
                }
            }

            protected internal void ClearResolver(Type keyType)
            {
                lock (syncLock)
                {
                    foreach (var constructs in allTypeConstructs.Values.Where(c => c.MyRegistration != null))
                    {
                        constructs.MyRegistration.ConditionalClearResolver(keyType);
                    }
                }
            }
        }

        protected internal class Registration<T> : IRegistration
            where T : class
        {
            private readonly Type typeofT = typeof(T);
            private readonly Type keyType;

            private readonly object syncLock;

            private readonly Dictionary<PropertyInfo, SetterExpression> propertyInjectors;
            private readonly Dictionary<FieldInfo, SetterExpression> fieldInjectors;

            private LambdaExpression ResolverFactoryExpression { get; set; }
            private ConstructorInfo MyConstructor { get; set; }

            private bool isVerifiedNotRecursive;

            private Expression<Func<T>> resolverExpression;
            private Func<T> resolverExpressionCompiled;

            private Func<T> resolve;
            private Action<T> resolveProperties;

            private readonly HashSet<Type> dependencies = new HashSet<Type>();

            private readonly InjectorInternal injector;
            private readonly InjectorTypeConstruct typeConstruct;

            public bool IsSingleton { get; private set; }

            public Registration(InjectorInternal injector, InjectorTypeConstruct typeConstruct, Type keyType, object syncLock, LambdaExpression factoryExpression)
            {
                this.keyType = keyType;
                this.syncLock = syncLock;

                this.injector = injector;
                this.typeConstruct = typeConstruct;

                this.propertyInjectors = new Dictionary<PropertyInfo, SetterExpression>();
                this.fieldInjectors = new Dictionary<FieldInfo, SetterExpression>();

                if (factoryExpression == null)
                {
                    InitInitialResolver();
                }
                else
                {
                    ResolverFactoryExpression = factoryExpression;
                }
            }

            public object DoResolve()
            {
                return DoResolveTyped();
            }

            private T DoResolveTyped()
            {
                if (!IsResolved())
                {
                    CompileResolver();
                }

                return resolve();
            }

            public T DoInject(T instance)
            {
                if (instance != null)
                {
                    if (resolveProperties == null)
                    {
                        lock (this)
                        {
                            resolveProperties = CompilePropertiesResolver();
                        }
                    }

                    resolveProperties(instance);
                }

                return instance;
            }

            public Expression GetResolveExpr(HashSet<Type> callerDeps)
            {
                lock (syncLock)
                {
                    Expression<Func<T>> expr;
                    if (IsSingleton)
                    {
                        var instance = DoResolveTyped();
                        expr = () => instance;
                    }
                    else
                    {
                        if (!isVerifiedNotRecursive)
                        {
                            DoResolveTyped();
                        }
                        expr = resolverExpression;
                    }

                    callerDeps.UnionWith(dependencies);
                    callerDeps.Add(keyType);

                    return expr.Body;
                }
            }

            private void InitInitialResolver()
            {
                if (typeofT.IsInterface || typeofT.IsAbstract)
                {
                    // if we can not instantiate, set the resolver to throw an exception.
                    Expression<Func<T>> throwEx = () => ThrowInterfaceException();
                    ResolverFactoryExpression = throwEx;
                }
                else
                {
                    // try to find the default constructor and create a default resolver from it
                    var constructor = typeofT.GetConstructors().Where(v => Attribute.IsDefined(v, typeof(IfIgnoreConstructorAttribute)) == false).OrderBy(v => Attribute.IsDefined(v, typeof(IfInjectAttribute)) ? 0 : 1).ThenBy(v => v.GetParameters().Count()).FirstOrDefault();

                    if (constructor != null)
                    {
                        MyConstructor = constructor;
                    }

                    // TODO: error?
                }
            }

            private T ThrowInterfaceException()
            {
                throw IfFastInjectorErrors.ErrorUnableToResultInterface.FormatEx(typeof(T).FullName);
            }

            public void AddPropertySetter(PropertyInfo propertyInfo, LambdaExpression setter)
            {
                lock (syncLock)
                {
                    propertyInjectors[propertyInfo] = new SetterExpression { Info = propertyInfo, MemberType = propertyInfo.PropertyType, Setter = setter };
                    ClearResolverAndDependents();
                }
            }

            public void AddFieldSetter(FieldInfo fieldInfo, LambdaExpression setter)
            {
                lock (syncLock)
                {
                    fieldInjectors[fieldInfo] = new SetterExpression { Info = fieldInfo, MemberType = fieldInfo.FieldType, Setter = setter };
                    ClearResolverAndDependents();
                }
            }

            public void AsSingleton(bool singleton)
            {
                lock (syncLock)
                {
                    this.IsSingleton = singleton;
                    ClearResolverAndDependents();
                }
            }

            public void ConditionalClearResolver(Type type)
            {
                lock (syncLock)
                {
                    if (dependencies.Contains(type))
                    {
                        ClearResolver();
                    }
                }
            }

            private void ClearResolverAndDependents()
            {
                lock (syncLock)
                {
                    injector.ClearResolver(keyType);
                    ClearResolver();
                }
            }

            private void ClearResolver()
            {
                lock (syncLock)
                {
                    IsRecursionTestPending = false;
                    isVerifiedNotRecursive = false;

                    dependencies.Clear();

                    resolve = null;
                    resolverExpressionCompiled = null;
                    resolverExpression = null;
                }
            }

            private bool IsRecursionTestPending
            {
                get
                {
                    return typeConstruct.IsRecursionTestPending;
                }
                set
                {
                    typeConstruct.IsRecursionTestPending = value;
                }
            }

            private T ResolveWithRecursionCheck()
            {
                // Lock until executed once; we will compile this away once verified
                lock (syncLock)
                {
                    if (!isVerifiedNotRecursive)
                    {
                        if (IsRecursionTestPending)
                        {
                            throw IfFastInjectorErrors.ErrorResolutionRecursionDetected.FormatEx(typeofT.Name);
                        }
                        IsRecursionTestPending = true;
                    }

                    T retval = resolverExpressionCompiled();

                    isVerifiedNotRecursive = true;
                    IsRecursionTestPending = false;

                    if (this.IsSingleton)
                    {
                        resolve = () => retval;
                    }
                    else
                    {
                        resolve = resolverExpressionCompiled;
                    }
                    return retval;
                }
            }

            private void CompileResolver()
            {
                lock (syncLock)
                {
                    if (!IsResolved())
                    {
                        // START: Handle compile loop
                        if (IsRecursionTestPending)
                        {
                            throw IfFastInjectorErrors.ErrorResolutionRecursionDetected.FormatEx(typeofT.Name);
                        }
                        IsRecursionTestPending = true;

                        var constructorExpr = CompileConstructorExpr();

                        if (fieldInjectors.Any() || propertyInjectors.Any())
                        {
                            var instanceVar = Expression.Variable(typeofT);
                            var assignExpression = Expression.Assign(instanceVar, constructorExpr.Body);

                            var blockExpression = new List<Expression>();
                            blockExpression.Add(assignExpression);

                            // setters
                            AddPropertySetterExpressions(instanceVar, blockExpression);

                            // return value + Func<T>
                            blockExpression.Add(instanceVar);

                            var expressionFunc = Expression.Block(new ParameterExpression[] { instanceVar }, blockExpression);
                            resolverExpression = (Expression<Func<T>>)Expression.Lambda(expressionFunc, constructorExpr.Parameters);

                        }
                        else
                        {
                            resolverExpression = constructorExpr;
                        }

                        resolverExpressionCompiled = resolverExpression.Compile();
                        resolve = ResolveWithRecursionCheck;

                        IsRecursionTestPending = false; // END: Handle compile loop
                    }
                }
            }

            private bool IsResolved()
            {
                return resolve != null;
            }

            public Action<T> CompilePropertiesResolver()
            {
                lock (syncLock)
                {
                    if (fieldInjectors.Any() || propertyInjectors.Any())
                    {
                        var instance = Expression.Parameter(typeof(T), "instance");
                        var instanceVar = Expression.Variable(typeofT);

                        var assignExpression = Expression.Assign(instanceVar, instance);

                        var blockExpression = new List<Expression>();
                        blockExpression.Add(assignExpression);
                        AddPropertySetterExpressions(instanceVar, blockExpression);

                        var expression = Expression.Block(new[] { instanceVar }, blockExpression);

                        return Expression.Lambda<Action<T>>(expression, instance).Compile();
                    }
                    else
                    {
                        return (T x) => { };
                    }
                }
            }

            private Expression<Func<T>> CompileConstructorExpr()
            {
                if (ResolverFactoryExpression != null)
                {
                    var arguments = CompileArgumentListExprs(ResolverFactoryExpression.Parameters.Select(x => x.Type));
                    var callLambdaExpression = Expression.Invoke(ResolverFactoryExpression, arguments.ToArray());
                    return ((Expression<Func<T>>)Expression.Lambda(callLambdaExpression));
                }
                else
                {
                    var arguments = CompileArgumentListExprs(MyConstructor.GetParameters().Select(v => v.ParameterType));
                    Expression createInstanceExpression = Expression.New(MyConstructor, arguments);
                    return ((Expression<Func<T>>)Expression.Lambda(createInstanceExpression));
                }
            }

            private List<Expression> CompileArgumentListExprs(IEnumerable<Type> args)
            {
                var argumentsOut = new List<Expression>();

                foreach (var parameterType in args)
                {
                    var argument = GetResolverInvocationExpressionForType(parameterType);
                    argumentsOut.Add(argument);
                }

                return argumentsOut;
            }

            private void AddPropertySetterExpressions(ParameterExpression instanceVar, List<Expression> blockExpressions)
            {
                var fields = from kv in fieldInjectors
                             select new { pfExpr = Expression.Field(instanceVar, kv.Key) as MemberExpression, setter = kv.Value };
                var props = from kv in propertyInjectors
                            select new { pfExpr = Expression.Property(instanceVar, kv.Key) as MemberExpression, setter = kv.Value };

                foreach (var pf in fields.Union(props))
                {
                    var valueExpr = pf.setter.IsResolve() ?
                        GetResolverInvocationExpressionForType(pf.setter.MemberType) : pf.setter.Setter.Body;
                    var propOrFieldExpr = Expression.Assign(pf.pfExpr, valueExpr);
                    blockExpressions.Add(propOrFieldExpr);
                }
            }

            private Expression GetResolverInvocationExpressionForType(Type parameterType)
            {
                return injector.ResolveResolver(parameterType).GetResolveExpr(dependencies);
            }

            private class SetterExpression
            {
                public bool IsResolve()
                {
                    return Setter == null;
                }

                public LambdaExpression Setter { get; set; }
                public MemberInfo Info { get; set; }
                public Type MemberType { get; set; }
            }
        }

        protected internal class InjectorFluent<T> : IfFastInjectorBinding<T>
            where T : class
        {
            private readonly Registration<T> resolver;

            protected internal InjectorFluent(Registration<T> resolver)
            {
                this.resolver = resolver;
            }

            public IfFastInjectorBinding<T> AddPropertyInjector<TPropertyType>(Expression<Func<T, TPropertyType>> propertyExpression)
                where TPropertyType : class
            {
                return AddPropertyInjectorInner(propertyExpression, null);
            }

            public IfFastInjectorBinding<T> AddPropertyInjector<TPropertyType>(Expression<Func<T, TPropertyType>> propertyExpression, Expression<Func<TPropertyType>> setter)
            {
                return AddPropertyInjectorInner(propertyExpression, setter);
            }

            private IfFastInjectorBinding<T> AddPropertyInjectorInner<TPropertyType>(Expression<Func<T, TPropertyType>> propertyExpression, Expression<Func<TPropertyType>> setter)
            {
                var propertyMemberExpression = propertyExpression.Body as MemberExpression;
                if (propertyMemberExpression == null)
                {
                    throw IfFastInjectorErrors.ErrorMustContainMemberExpression.FormatEx("propertyExpression");
                }

                var member = propertyMemberExpression.Member;
                if (member is PropertyInfo)
                {
                    resolver.AddPropertySetter(member as PropertyInfo, setter);
                }
                else if (member is FieldInfo)
                {
                    resolver.AddFieldSetter(member as FieldInfo, setter);
                }
                else
                {
                    throw IfFastInjectorErrors.ErrorMustContainMemberExpression.FormatEx("propertyExpression");
                }

                return this;
            }

            public IfFastInjectorBinding<T> AsSingleton(bool singlton = true)
            {
                resolver.AsSingleton(singlton);
                return this;
            }
        }

        /// <summary>
        /// Thread safe dictionary wrapper. 
        /// </summary>
        protected internal class SafeDictionary<TKey, TValue>
        {
            private readonly object syncLock;
            private readonly Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            private Dictionary<TKey, TValue> unsyncDict = new Dictionary<TKey, TValue>();

            public SafeDictionary(object syncLock)
            {
                this.syncLock = syncLock;
            }

            public void Add(TKey key, TValue value)
            {
                lock (syncLock)
                {
                    dict.Add(key, value);
                    unsyncDict = new Dictionary<TKey, TValue>(dict);
                }
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                lock (syncLock)
                {
                    return dict.TryGetValue(key, out value);
                }
            }

            public bool UnsyncedTryGetValue(TKey key, out TValue value)
            {
                return unsyncDict.TryGetValue(key, out value);
            }

            public IEnumerable<TValue> Values
            {
                get
                {
                    lock (syncLock)
                    {
                        // use unsync since copy on write
                        return unsyncDict.Values;
                    }
                }
            }

            public bool Remove(TKey key)
            {
                lock (syncLock)
                {
                    bool res = dict.Remove(key);
                    if (res)
                    {
                        unsyncDict = new Dictionary<TKey, TValue>(dict);
                    }
                    return res;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////
        #region ImplicitBindingsHelpers

        private static readonly MethodInfo GenericSetupImplicitPropResolvers;

        static IfFastInjectorInternal()
        {
            Expression<Action<Registration<Exception>>> TmpBindingExpression = (r) => SetupImplicitPropResolvers<Exception>(r);
            GenericSetupImplicitPropResolvers = ((MethodCallExpression)TmpBindingExpression.Body).Method.GetGenericMethodDefinition();
        }

        protected internal static void SetupImplicitPropResolvers(IRegistration resolver, Type implType)
        {
            GenericSetupImplicitPropResolvers.MakeGenericMethod(implType).Invoke(null, new object[] { resolver });
        }

        protected internal static void SetupImplicitPropResolvers<T>(Registration<T> resolver) where T : class
        {
            Type typeT = typeof(T);
            do
            {
                var props = from p in typeT.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            select new { Info = p as MemberInfo, MemType = p.PropertyType };
                var fields = from f in typeT.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                             select new { Info = f as MemberInfo, MemType = f.FieldType };

                var propsAndFields = props.Union(fields)
                        .Where(pf => pf.Info.GetCustomAttributes(typeof(IfInjectAttribute), true).Length != 0)
                        .Where(pf => pf.Info.DeclaringType == typeT);

                foreach (var pf in propsAndFields)
                {
                    InvokeSetupImplicitPropResolvers<T>(pf.Info, pf.MemType, pf.Info.Name, resolver);
                }
            } while ((typeT = typeT.BaseType) != null && typeT != typeof(object));

            // setup singleton
            if (typeof(T).GetCustomAttributes(typeof(IfSingletonAttribute), false).Length > 0)
            {
                resolver.AsSingleton(true);
            }
        }

        private static void InvokeSetupImplicitPropResolvers<T>(MemberInfo memberInfo, Type memberType, string memberName, Registration<T> resolver)
            where T : class
        {
            if (!memberType.IsClass && !memberType.IsInterface)
            {
                throw IfFastInjectorErrors.ErrorUnableToBindNonClassFieldsProperties.FormatEx(memberName, typeof(T).Name);
            }

            if (memberInfo is PropertyInfo)
            {
                resolver.AddPropertySetter(memberInfo as PropertyInfo, null);
            }
            else
            {
                resolver.AddFieldSetter(memberInfo as FieldInfo, null);
            }
        }

        #endregion // ImplicitBindingsHelpers
        ////////////////////////////////////////////////////////////////////////////////
    }
}