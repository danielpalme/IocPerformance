using System;
using System.Linq;
using System.Linq.Expressions;
using Castle.DynamicProxy;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using ZenIoc;
using Pure.DI;
using static Pure.DI.Lifetime;
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameterInPartialMethod
// ReSharper disable ClassNeverInstantiated.Global
namespace IocPerformance.Adapters
{
    public sealed partial class PureDiAdapter : ContainerAdapterBase
    {
        private static void Setup()
        {
            // ThreadSafe = Off
            // OnDependencyInjection = On
            // OnDependencyInjectionContractTypeNameRegularExpression = ICalculator[\d]{1}
            // ObjectResolveMethodModifiers = public override
            // DisposeMethodModifiers = public override
            DI.Setup(nameof(PureDiAdapter))
                .TagAttribute<ResolveNamedAttribute>()

                // RegisterDummies
                .Bind<IDummyOne>().To<DummyOne>().Root<IDummyOne>()
                .Bind<IDummyTwo>().To<DummyTwo>()
                .Bind<IDummyThree>().To<DummyThree>()
                .Bind<IDummyFour>().To<DummyFour>()
                .Bind<IDummyFive>().To<DummyFive>()
                .Bind<IDummySix>().To<DummySix>()
                .Bind<IDummySeven>().To<DummySeven>()
                .Bind<IDummyEight>().To<DummyEight>()
                .Bind<IDummyNine>().To<DummyNine>()
                .Bind<IDummyTen>().To<DummyTen>()

                // RegisterStandard
                .Bind<ISingleton1>().As(Singleton).To<Singleton1>().Root<ISingleton1>()
                .Bind<ISingleton2>().As(Singleton).To<Singleton2>().Root<ISingleton2>()
                .Bind<ISingleton3>().As(Singleton).To<Singleton3>().Root<ISingleton3>()
                .Bind<ITransient1>().To<Transient1>().Root<ITransient1>()
                .Bind<ITransient2>().To<Transient2>().Root<ITransient2>()
                .Bind<ITransient3>().To<Transient3>().Root<ITransient3>()
                .Bind<ICombined1>().To<Combined1>().Root<ICombined1>()
                .Bind<ICombined2>().To<Combined2>().Root<ICombined2>()
                .Bind<ICombined3>().To<Combined3>().Root<ICombined3>()

                // RegisterComplexObject
                .Bind<IFirstService>().As(Singleton).To<FirstService>()
                .Bind<ISecondService>().As(Singleton).To<SecondService>()
                .Bind<IThirdService>().As(Singleton).To<ThirdService>()
                .Bind<ISubObjectA>().To<SubObjectA>()
                .Bind<ISubObjectB>().To<SubObjectB>()
                .Bind<ISubObjectC>().To<SubObjectC>()
                .Bind<IComplex1>().To<Complex1>().Root<IComplex1>()
                .Bind<IComplex2>().To<Complex2>().Root<IComplex2>()
                .Bind<IComplex3>().To<Complex3>().Root<IComplex3>()

                // RegisterPropertyInjection
                .Bind<IComplexPropertyObject1>().To<ComplexPropertyObject1>().Root<IComplexPropertyObject1>()
                .Bind<IComplexPropertyObject2>().To<ComplexPropertyObject2>().Root<IComplexPropertyObject2>()
                .Bind<IComplexPropertyObject3>().To<ComplexPropertyObject3>().Root<IComplexPropertyObject3>()
                .Bind<IServiceA>().As(Singleton).To<ServiceA>()
                .Bind<IServiceB>().As(Singleton).To<ServiceB>()
                .Bind<IServiceC>().As(Singleton).To<ServiceC>()
                .Bind<ISubObjectOne>().To<SubObjectOne>()
                .Bind<ISubObjectTwo>().To<SubObjectTwo>()
                .Bind<ISubObjectThree>().To<SubObjectThree>()

                // RegisterOpenGeneric
                .Bind<IGenericInterface<TT>>().To<GenericExport<TT>>()
                .Bind<ImportGeneric<TT>>().To<ImportGeneric<TT>>()
                    .Root<ImportGeneric<int>>()
                    .Root<ImportGeneric<float>>()
                    .Root<ImportGeneric<object>>()

                // RegisterConditional
                .Root<ImportConditionObject1>()
                .Root<ImportConditionObject2>()
                .Root<ImportConditionObject3>()
                .Bind<IExportConditionInterface>("ExportConditionalObject1").To<ExportConditionalObject1>()
                .Bind<IExportConditionInterface>("ExportConditionalObject2").To<ExportConditionalObject2>()
                .Bind<IExportConditionInterface>("ExportConditionalObject3").To<ExportConditionalObject3>()

                // RegisterMultiple
                .Bind<ISimpleAdapter>().To<SimpleAdapterOne>()
                .Bind<ISimpleAdapter>(2).To<SimpleAdapterTwo>()
                .Bind<ISimpleAdapter>(3).To<SimpleAdapterThree>()
                .Bind<ISimpleAdapter>(4).To<SimpleAdapterFour>()
                .Bind<ISimpleAdapter>(5).To<SimpleAdapterFive>()
                .Root<ImportMultiple1>()
                .Root<ImportMultiple2>()
                .Root<ImportMultiple3>()
                
                // RegisterInterceptor
                .Bind<ICalculator1>().To<Calculator1>().Root<ICalculator1>()
                .Bind<ICalculator2>().To<Calculator2>().Root<ICalculator2>()
                .Bind<ICalculator3>().To<Calculator3>().Root<ICalculator3>();
        }

        public override string PackageName => "Pure.DI";

        public override string Url => "https://github.com/DevTeam/Pure.DI";

        public override bool SupportsPropertyInjection => true;

        public override bool SupportGeneric => true;

        public override bool SupportsConditional => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsInterception => true;
        
        public override bool SupportsPrepareAndRegister => false;
        
        public override void PrepareBasic() { }

        public override void Dispose() { }

        public override void Prepare() { }
        
        private partial T OnDependencyInjection<T>(in T value, object tag, Lifetime lifetime) => 
            ProxyFactory<T>.Factory(value);

        private static readonly IInterceptor[] Interceptors = { new PureDiInterceptionLogger() };
        private static readonly DefaultProxyBuilder ProxyBuilder = new();

        private static class ProxyFactory<T>
        {
            public static readonly Func<T, T> Factory = CreateFactory();
            
            private static Func<T, T> CreateFactory()
            {
                var proxyType = ProxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(
                    typeof(T),
                    Type.EmptyTypes,
                    ProxyGenerationOptions.Default);

                var ctor = proxyType.GetConstructors().Single(i => i.GetParameters().Length == 2);
                var typeOfT = Expression.Parameter(typeof(T));
                var interceptors = Expression.Constant(Interceptors);
                var newProxy = Expression.New(ctor, interceptors, typeOfT);
                return Expression.Lambda<Func<T, T>>(newProxy, typeOfT).Compile();
            }
        }
    }
}