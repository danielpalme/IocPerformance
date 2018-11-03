using System;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Microsoft.Extensions.DependencyInjection;
using Stashbox;

namespace IocPerformance.Adapters
{
    public sealed class StashboxContainerAdapter : ContainerAdapterBase
    {
        private IStashboxContainer container;

        public override string PackageName => "Stashbox";

        public override string Url => "https://github.com/z4kn4fein/stashbox";

        public override bool SupportsInterception => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportAspNetCore => true;

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
            ServiceCollection services = new ServiceCollection();
            this.RegisterAspNetCoreClasses(services);

            this.container = services.CreateBuilder();
            this.RegisterBasic();
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
            this.container.Register<IDummyOne, DummyOne>();
            this.container.Register<IDummyTwo, DummyTwo>();
            this.container.Register<IDummyThree, DummyThree>();
            this.container.Register<IDummyFour, DummyFour>();
            this.container.Register<IDummyFive, DummyFive>();
            this.container.Register<IDummySix, DummySix>();
            this.container.Register<IDummySeven, DummySeven>();
            this.container.Register<IDummyEight, DummyEight>();
            this.container.Register<IDummyNine, DummyNine>();
            this.container.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.RegisterSingleton<ISingleton1, Singleton1>();
            this.container.RegisterSingleton<ISingleton2, Singleton2>();
            this.container.RegisterSingleton<ISingleton3, Singleton3>();
            this.container.Register<ITransient1, Transient1>();
            this.container.Register<ITransient2, Transient2>();
            this.container.Register<ITransient3, Transient3>();
            this.container.Register<ICombined1, Combined1>();
            this.container.Register<ICombined2, Combined2>();
            this.container.Register<ICombined3, Combined3>();
        }

        private void RegisterComplex()
        {
            this.container.RegisterSingleton<IFirstService, FirstService>();
            this.container.RegisterSingleton<ISecondService, SecondService>();
            this.container.RegisterSingleton<IThirdService, ThirdService>();
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.Register<IComplex1, Complex1>();
            this.container.Register<IComplex2, Complex2>();
            this.container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingleton<IServiceA, ServiceA>();
            this.container.RegisterSingleton<IServiceB, ServiceB>();
            this.container.RegisterSingleton<IServiceC, ServiceC>();
            this.container.Register<ISubObjectA, SubObjectA>();
            this.container.Register<ISubObjectB, SubObjectB>();
            this.container.Register<ISubObjectC, SubObjectC>();
            this.container.Register<IComplexPropertyObject1, ComplexPropertyObject1>();
            this.container.Register<IComplexPropertyObject2, ComplexPropertyObject2>();
            this.container.Register<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private void RegisterMultiple()
        {
            this.container.Register<ISimpleAdapter, SimpleAdapterOne>();
            this.container.Register<ISimpleAdapter, SimpleAdapterTwo>();
            this.container.Register<ISimpleAdapter, SimpleAdapterThree>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFour>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFive>();

            this.container.Register<ImportMultiple1>();
            this.container.Register<ImportMultiple2>();
            this.container.Register<ImportMultiple3>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.container.Register<ImportConditionObject1>();
            this.container.Register<ImportConditionObject2>();
            this.container.Register<ImportConditionObject3>();
            this.container.Register<IExportConditionInterface, ExportConditionalObject1>(context => context
                .WhenDependantIs<ImportConditionObject1>());
            this.container.Register<IExportConditionInterface, ExportConditionalObject2>(context => context
                .WhenDependantIs<ImportConditionObject2>());
            this.container.Register<IExportConditionInterface, ExportConditionalObject3>(context => context
                .WhenDependantIs<ImportConditionObject3>());
        }

        private void RegisterInterceptor()
        {
            this.container.Register<IInterceptor, CalculatorLogger>();
            this.container.Register<ICalculator1, Calculator1>();
            this.container.Register<ICalculator2, Calculator2>();
            this.container.Register<ICalculator3, Calculator3>();

            this.container.RegisterDecorator<ICalculator1>(this.proxyType1);
            this.container.RegisterDecorator<ICalculator2>(this.proxyType2);
            this.container.RegisterDecorator<ICalculator3>(this.proxyType3);
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
            this.childContainer = container.CreateChildContainer();
        }

        public void Dispose() => this.childContainer.Dispose();

        public void Prepare()
        {
            this.childContainer.Register<ICombined1, ScopedCombined1>();
            this.childContainer.Register<ICombined2, ScopedCombined2>();
            this.childContainer.Register<ICombined3, ScopedCombined3>();
            this.childContainer.Register<ITransient1, ScopedTransient>();
        }

        public object Resolve(Type resolveType) => this.childContainer.Resolve(resolveType);
    }
}