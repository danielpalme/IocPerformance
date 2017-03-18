using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Stashbox;
using Stashbox.Infrastructure;
using System;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using Stashbox.Configuration;

namespace IocPerformance.Adapters
{
    public sealed class StashboxContainerAdapter : ContainerAdapterBase
    {
        private StashboxContainer container;

        public override string PackageName => "Stashbox";

        public override string Url => "https://github.com/z4kn4fein/stashbox";

        public override bool SupportsInterception => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        private readonly Type proxyType1;
        private readonly Type proxyType2;
        private readonly Type proxyType3;

        public StashboxContainerAdapter()
        {
            var builder = new DefaultProxyBuilder();
            this.proxyType1 = builder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ICalculator1), new Type[0], ProxyGenerationOptions.Default);
            this.proxyType2 = builder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ICalculator2), new Type[0], ProxyGenerationOptions.Default);
            this.proxyType3 = builder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ICalculator3), new Type[0], ProxyGenerationOptions.Default);
        }

        public override void PrepareBasic()
        {
            this.container = new StashboxContainer();
            this.RegisterBasic();
        }

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }

        public override void Dispose() => this.container?.Dispose();

        public override IChildContainerAdapter CreateChildContainerAdapter() =>
            new StashboxChildContainerAdapter(this.container);

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.RegisterType<IDummyOne, DummyOne>();
            this.container.RegisterType<IDummyTwo, DummyTwo>();
            this.container.RegisterType<IDummyThree, DummyThree>();
            this.container.RegisterType<IDummyFour, DummyFour>();
            this.container.RegisterType<IDummyFive, DummyFive>();
            this.container.RegisterType<IDummySix, DummySix>();
            this.container.RegisterType<IDummySeven, DummySeven>();
            this.container.RegisterType<IDummyEight, DummyEight>();
            this.container.RegisterType<IDummyNine, DummyNine>();
            this.container.RegisterType<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.RegisterSingleton<ISingleton1, Singleton1>();
            this.container.RegisterSingleton<ISingleton2, Singleton2>();
            this.container.RegisterSingleton<ISingleton3, Singleton3>();
            this.container.RegisterType<ITransient1, Transient1>();
            this.container.RegisterType<ITransient2, Transient2>();
            this.container.RegisterType<ITransient3, Transient3>();
            this.container.RegisterType<ICombined1, Combined1>();
            this.container.RegisterType<ICombined2, Combined2>();
            this.container.RegisterType<ICombined3, Combined3>();
        }

        private void RegisterComplex()
        {
            this.container.RegisterSingleton<IFirstService, FirstService>();
            this.container.RegisterSingleton<ISecondService, SecondService>();
            this.container.RegisterSingleton<IThirdService, ThirdService>();
            this.container.RegisterType<ISubObjectOne, SubObjectOne>();
            this.container.RegisterType<ISubObjectTwo, SubObjectTwo>();
            this.container.RegisterType<ISubObjectThree, SubObjectThree>();
            this.container.RegisterType<IComplex1, Complex1>();
            this.container.RegisterType<IComplex2, Complex2>();
            this.container.RegisterType<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingleton<IServiceA, ServiceA>();
            this.container.RegisterSingleton<IServiceB, ServiceB>();
            this.container.RegisterSingleton<IServiceC, ServiceC>();
            this.container.RegisterType<ISubObjectA, SubObjectA>();
            this.container.RegisterType<ISubObjectB, SubObjectB>();
            this.container.RegisterType<ISubObjectC, SubObjectC>();
            this.container.RegisterType<IComplexPropertyObject1, ComplexPropertyObject1>();
            this.container.RegisterType<IComplexPropertyObject2, ComplexPropertyObject2>();
            this.container.RegisterType<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private void RegisterMultiple()
        {
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>();
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>();
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>();
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>();
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>();

            this.container.RegisterType<ImportMultiple1>();
            this.container.RegisterType<ImportMultiple2>();
            this.container.RegisterType<ImportMultiple3>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.container.RegisterType<ImportConditionObject1>();
            this.container.RegisterType<ImportConditionObject2>();
            this.container.RegisterType<ImportConditionObject3>();
            this.container.PrepareType<IExportConditionInterface, ExportConditionalObject>()
                .WhenDependantIs<ImportConditionObject1>().Register();
            this.container.PrepareType<IExportConditionInterface, ExportConditionalObject2>()
                .WhenDependantIs<ImportConditionObject2>().Register();
            this.container.PrepareType<IExportConditionInterface, ExportConditionalObject3>()
                 .WhenDependantIs<ImportConditionObject3>().Register();
        }

        private void RegisterInterceptor()
        {
            this.container.RegisterType<IInterceptor, CalculatorLogger>();
            this.container.RegisterType<ICalculator1, Calculator1>();
            this.container.RegisterType<ICalculator2, Calculator2>();
            this.container.RegisterType<ICalculator3, Calculator3>();

            this.container.PrepareDecorator<ICalculator1>(this.proxyType1)
                .WithConstructorSelectionRule(Rules.ConstructorSelection.PreferMostParameters).Register();
            this.container.PrepareDecorator<ICalculator2>(this.proxyType2)
                .WithConstructorSelectionRule(Rules.ConstructorSelection.PreferMostParameters).Register();
            this.container.PrepareDecorator<ICalculator3>(this.proxyType3)
                .WithConstructorSelectionRule(Rules.ConstructorSelection.PreferMostParameters).Register();
        }

        public sealed class CalculatorLogger : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                // Perform logging here, e.g.:
                var args = string.Join(", ", invocation.Arguments.Select(x => x + string.Empty));
                Debug.WriteLine("Stashbox: {0}({1})", invocation.GetConcreteMethod().Name, args);
                invocation.Proceed();
            }
        }
    }

    public class StashboxChildContainerAdapter : IChildContainerAdapter
    {
        private readonly IStashboxContainer childContainer;

        public StashboxChildContainerAdapter(IStashboxContainer container)
        {
            this.childContainer = container.BeginScope();
        }

        public void Dispose() => this.childContainer.Dispose();

        public void Prepare()
        {
            this.childContainer.RegisterType<ICombined1, ScopedCombined1>();
            this.childContainer.RegisterType<ICombined2, ScopedCombined2>();
            this.childContainer.RegisterType<ICombined3, ScopedCombined3>();
            this.childContainer.RegisterType<ITransient1, ScopedTransient>();
        }

        public object Resolve(Type resolveType) => this.childContainer.Resolve(resolveType);
    }
}