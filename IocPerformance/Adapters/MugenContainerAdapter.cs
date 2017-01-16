using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using MugenInjection;
using MugenInjection.Interface;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : ContainerAdapterBase
    {
        private MugenInjector container;

        public override string Name => "Mugen";

        public override string PackageName => "MugenInjection";

        public override string Url => "http://mugeninjection.codeplex.com";

        public override bool SupportsConditional => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsInterception => true;

        public override bool SupportsChildContainer => true;

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            IInjector injector = this.container.CreateChild();

            return new MugenChildContainerAdapter(injector);
        }

        public override object Resolve(Type type) => this.container.Get(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterInterceptor();
        }

         public override void PrepareBasic()
        {
            this.container = new MugenInjector();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Bind<IDummyOne>().To<DummyOne>().InTransientScope();
            this.container.Bind<IDummyTwo>().To<DummyTwo>().InTransientScope();
            this.container.Bind<IDummyThree>().To<DummyThree>().InTransientScope();
            this.container.Bind<IDummyFour>().To<DummyFour>().InTransientScope();
            this.container.Bind<IDummyFive>().To<DummyFive>().InTransientScope();
            this.container.Bind<IDummySix>().To<DummySix>().InTransientScope();
            this.container.Bind<IDummySeven>().To<DummySeven>().InTransientScope();
            this.container.Bind<IDummyEight>().To<DummyEight>().InTransientScope();
            this.container.Bind<IDummyNine>().To<DummyNine>().InTransientScope();
            this.container.Bind<IDummyTen>().To<DummyTen>().InTransientScope();
        }

        private void RegisterStandard()
        {
            this.container.Bind<ISingleton1>().To<Singleton1>().InSingletonScope();
            this.container.Bind<ISingleton2>().To<Singleton2>().InSingletonScope();
            this.container.Bind<ISingleton3>().To<Singleton3>().InSingletonScope();
            this.container.Bind<ITransient1>().To<Transient1>().InTransientScope();
            this.container.Bind<ITransient2>().To<Transient2>().InTransientScope();
            this.container.Bind<ITransient3>().To<Transient3>().InTransientScope();
            this.container.Bind<ICombined1>().To<Combined1>().InTransientScope();
            this.container.Bind<ICombined2>().To<Combined2>().InTransientScope();
            this.container.Bind<ICombined3>().To<Combined3>().InTransientScope();
        }

        private void RegisterComplex()
        {
            this.container.Bind<IFirstService>().To<FirstService>().InTransientScope();
            this.container.Bind<ISecondService>().To<SecondService>().InTransientScope();
            this.container.Bind<IThirdService>().To<ThirdService>().InTransientScope();
            this.container.Bind<ISubObjectOne>().To<SubObjectOne>().InTransientScope();
            this.container.Bind<ISubObjectTwo>().To<SubObjectTwo>().InTransientScope();
            this.container.Bind<ISubObjectThree>().To<SubObjectThree>().InTransientScope();
            this.container.Bind<IComplex1>().To<Complex1>().InTransientScope();
            this.container.Bind<IComplex2>().To<Complex2>().InTransientScope();
            this.container.Bind<IComplex3>().To<Complex3>().InTransientScope();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Bind<IComplexPropertyObject1>().To<ComplexPropertyObject1>().InTransientScope();
            this.container.Bind<IComplexPropertyObject2>().To<ComplexPropertyObject2>().InTransientScope();
            this.container.Bind<IComplexPropertyObject3>().To<ComplexPropertyObject3>().InTransientScope();
            this.container.Bind<IServiceA>().To<ServiceA>().InSingletonScope();
            this.container.Bind<IServiceB>().To<ServiceB>().InSingletonScope();
            this.container.Bind<IServiceC>().To<ServiceC>().InSingletonScope();
            this.container.Bind<ISubObjectA>().To<SubObjectA>().InTransientScope();
            this.container.Bind<ISubObjectB>().To<SubObjectB>().InTransientScope();
            this.container.Bind<ISubObjectC>().To<SubObjectC>().InTransientScope();
        }

        private void RegisterConditional()
        {
            // conditional export
            this.container.Bind<ImportConditionObject1>().To<ImportConditionObject1>().InTransientScope();
            this.container.Bind<ImportConditionObject2>().To<ImportConditionObject2>().InTransientScope();
            this.container.Bind<ImportConditionObject3>().To<ImportConditionObject3>().InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                .To<ExportConditionalObject>()
                .WhenIntoIsAssignable<ImportConditionObject1>()
                .InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                .To<ExportConditionalObject2>()
                .WhenIntoIsAssignable<ImportConditionObject2>()
                .InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                .To<ExportConditionalObject3>()
                .WhenIntoIsAssignable<ImportConditionObject3>()
                .InTransientScope();
        }

        private void RegisterOpenGeneric()
        {
            // generic export
            this.container.Bind(typeof(IGenericInterface<>)).To(typeof(GenericExport<>)).InTransientScope();
            this.container.Bind(typeof(ImportGeneric<>)).To(typeof(ImportGeneric<>)).InTransientScope();
        }

        private void RegisterMultiple()
        {
            // multiple exports
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterOne>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterTwo>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterThree>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFour>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFive>().InTransientScope();
            this.container.Bind<ImportMultiple1>().To<ImportMultiple1>().InTransientScope();
            this.container.Bind<ImportMultiple2>().To<ImportMultiple2>().InTransientScope();
            this.container.Bind<ImportMultiple3>().To<ImportMultiple3>().InTransientScope();
        }

        private void RegisterInterceptor()
        {
            this.container.Bind<ICalculator1>().To<Calculator1>().InTransientScope().InterceptAsTarget(new MugenInjectionInterceptionLogger());
            this.container.Bind<ICalculator2>().To<Calculator2>().InTransientScope().InterceptAsTarget(new MugenInjectionInterceptionLogger());
            this.container.Bind<ICalculator3>().To<Calculator3>().InTransientScope().InterceptAsTarget(new MugenInjectionInterceptionLogger());
        }
    }

    public class MugenChildContainerAdapter : IChildContainerAdapter
    {
        private readonly IInjector injector;

        public MugenChildContainerAdapter(IInjector injector)
        {
            this.injector = injector;
        }

        public void Dispose()
        {
            this.injector.Dispose();
        }

        public void Prepare()
        {
            this.injector.Bind<ITransient1>().To<ScopedTransient>().InTransientScope();
            this.injector.Bind<ICombined1>().To<ScopedCombined1>().InSingletonScope();
            this.injector.Bind<ICombined2>().To<ScopedCombined2>().InSingletonScope();
            this.injector.Bind<ICombined3>().To<ScopedCombined3>().InSingletonScope();
        }

        public object Resolve(Type resolveType) => this.injector.Get(resolveType);
    }
}