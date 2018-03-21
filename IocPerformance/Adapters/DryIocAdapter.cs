using System;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using DryIoc;
using DryIoc.Interception;
using DryIoc.Microsoft.DependencyInjection;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    [Fast]
    public sealed class DryIocAdapter : ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName => "DryIoc.dll";

        public override string Name => "DryIoc";

        public override string Url => "https://bitbucket.org/dadhi/dryioc";

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsInterception => true;

        public override bool SupportAspNetCore => true;

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container != null)
            {
                this.container.Dispose();
            }
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
            this.RegisterAspNetCore();
        }

        private void RegisterAspNetCore()
        {
            this.container = this.container.WithDependencyInjectionAdapter(this.CreateServiceCollection());
        }

        public override void PrepareBasic()
        {
            this.container = new Container();
            this.RegisterBasic();
        }

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
            this.container.Register<ISingleton1, Singleton1>(Reuse.Singleton);
            this.container.Register<ISingleton2, Singleton2>(Reuse.Singleton);
            this.container.Register<ISingleton3, Singleton3>(Reuse.Singleton);
            this.container.Register<ITransient1, Transient1>();
            this.container.Register<ITransient2, Transient2>();
            this.container.Register<ITransient3, Transient3>();
            this.container.Register<ICombined1, Combined1>();
            this.container.Register<ICombined2, Combined2>();
            this.container.Register<ICombined3, Combined3>();
            this.container.Register<ICalculator1, Calculator1>();
            this.container.Register<ICalculator2, Calculator2>();
            this.container.Register<ICalculator3, Calculator3>();
        }

        private void RegisterComplex()
        {
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.Register<IFirstService, FirstService>(Reuse.Singleton);
            this.container.Register<ISecondService, SecondService>(Reuse.Singleton);
            this.container.Register<IThirdService, ThirdService>(Reuse.Singleton);
            this.container.Register<IComplex1, Complex1>();
            this.container.Register<IComplex2, Complex2>();
            this.container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA, ServiceA>(Reuse.Singleton);
            this.container.Register<IServiceB, ServiceB>(Reuse.Singleton);
            this.container.Register<IServiceC, ServiceC>(Reuse.Singleton);

            this.container.Register<ISubObjectA, SubObjectA>(made: PropertiesAndFields.Auto);
            this.container.Register<ISubObjectB, SubObjectB>(made: PropertiesAndFields.Auto);
            this.container.Register<ISubObjectC, SubObjectC>(made: PropertiesAndFields.Auto);

            this.container.Register<IComplexPropertyObject1, ComplexPropertyObject1>(made: PropertiesAndFields.Auto);
            this.container.Register<IComplexPropertyObject2, ComplexPropertyObject2>(made: PropertiesAndFields.Auto);
            this.container.Register<IComplexPropertyObject3, ComplexPropertyObject3>(made: PropertiesAndFields.Auto);
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

            this.container.Register<IExportConditionInterface, ExportConditionalObject1>(
                setup: Setup.With(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject1)));

            this.container.Register<IExportConditionInterface, ExportConditionalObject2>(
                setup: Setup.With(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject2)));

            this.container.Register<IExportConditionInterface, ExportConditionalObject3>(
                setup: Setup.With(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject3)));
        }

        private void RegisterMultiple()
        {
            this.container.Register<ImportMultiple1>();
            this.container.Register<ImportMultiple2>();
            this.container.Register<ImportMultiple3>();
            this.container.Register<ISimpleAdapter, SimpleAdapterOne>();
            this.container.Register<ISimpleAdapter, SimpleAdapterTwo>();
            this.container.Register<ISimpleAdapter, SimpleAdapterThree>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFour>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFive>();
        }

        private void RegisterInterceptor()
        {
            this.container.Register<CalculatorLogger>();
            this.container.Intercept<ICalculator1, CalculatorLogger>();
            this.container.Intercept<ICalculator2, CalculatorLogger>();
            this.container.Intercept<ICalculator3, CalculatorLogger>();
        }

        public sealed class CalculatorLogger : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                // Perform logging here, e.g.:
                var args = string.Join(", ", invocation.Arguments.Select(x => x + string.Empty));
                Debug.WriteLine("DryIocInterceptor: {0}({1})", invocation.GetConcreteMethod().Name, args);
                invocation.Proceed();
            }
        }
    }
}