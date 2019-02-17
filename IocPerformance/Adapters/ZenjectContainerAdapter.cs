using System;
using System.ComponentModel.Composition;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Zenject;
using Zenject.Internal;

namespace IocPerformance.Adapters
{
    public sealed class ZenjectContainerAdapter : ContainerAdapterBase
    {
        private DiContainer container;

        public override string PackageName => "Zenject";

        public override string Version => "8.0.0";

        public override string Url => "https://github.com/modesttree/Zenject";

        public override bool SupportsChildContainer => true;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsMultiple => true;

        public override IChildContainerAdapter CreateChildContainerAdapter() => new ZenjectChildContainerAdapter(container.CreateSubContainer());

        public override object Resolve(Type type) => container.TryResolve(type);

        public override void Dispose()
        {
            container.UnbindAll();
        }

        public override void Prepare()
        {
            this.CreateContainer();

            this.RegisterBasic();

            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
        }

        public override void PrepareBasic()
        {
            this.CreateContainer();

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
            this.container.Bind<IDummyOne>().To<DummyOne>().AsTransient();
            this.container.Bind<IDummyTwo>().To<DummyTwo>().AsTransient();
            this.container.Bind<IDummyThree>().To<DummyThree>().AsTransient();
            this.container.Bind<IDummyFour>().To<DummyFour>().AsTransient();
            this.container.Bind<IDummyFive>().To<DummyFive>().AsTransient();
            this.container.Bind<IDummySix>().To<DummySix>().AsTransient();
            this.container.Bind<IDummySeven>().To<DummySeven>().AsTransient();
            this.container.Bind<IDummyEight>().To<DummyEight>().AsTransient();
            this.container.Bind<IDummyNine>().To<DummyNine>().AsTransient();
            this.container.Bind<IDummyTen>().To<DummyTen>().AsTransient();
        }

        private void RegisterStandard()
        {
            this.container.Bind<ISingleton1>().To<Singleton1>().AsSingle();
            this.container.Bind<ISingleton2>().To<Singleton2>().AsSingle();
            this.container.Bind<ISingleton3>().To<Singleton3>().AsSingle();
            this.container.Bind<ITransient1>().To<Transient1>().AsTransient();
            this.container.Bind<ITransient2>().To<Transient2>().AsTransient();
            this.container.Bind<ITransient3>().To<Transient3>().AsTransient();
            this.container.Bind<ICombined1>().To<Combined1>().AsTransient();
            this.container.Bind<ICombined2>().To<Combined2>().AsTransient();
            this.container.Bind<ICombined3>().To<Combined3>().AsTransient();
            this.container.Bind<ICalculator1>().To<Calculator1>().AsTransient();
            this.container.Bind<ICalculator2>().To<Calculator2>().AsTransient();
            this.container.Bind<ICalculator3>().To<Calculator3>().AsTransient();
        }

        private void RegisterComplex()
        {
            this.container.Bind<ISubObjectOne>().To<SubObjectOne>().AsTransient();
            this.container.Bind<ISubObjectTwo>().To<SubObjectTwo>().AsTransient();
            this.container.Bind<ISubObjectThree>().To<SubObjectThree>().AsTransient();
            this.container.Bind<IFirstService>().To<FirstService>().AsSingle();
            this.container.Bind<ISecondService>().To<SecondService>().AsSingle();
            this.container.Bind<IThirdService>().To<ThirdService>().AsSingle();
            this.container.Bind<IComplex1>().To<Complex1>().AsTransient();
            this.container.Bind<IComplex2>().To<Complex2>().AsTransient();
            this.container.Bind<IComplex3>().To<Complex3>().AsTransient();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Bind<IServiceA>().To<ServiceA>().AsSingle();
            this.container.Bind<IServiceB>().To<ServiceB>().AsSingle();
            this.container.Bind<IServiceC>().To<ServiceC>().AsSingle();

            this.container.Bind<ISubObjectA>().To<SubObjectA>().AsTransient();
            this.container.Bind<ISubObjectB>().To<SubObjectB>().AsTransient();
            this.container.Bind<ISubObjectC>().To<SubObjectC>().AsTransient();

            this.container.Bind<IComplexPropertyObject1>().To<ComplexPropertyObject1>().AsTransient();
            this.container.Bind<IComplexPropertyObject2>().To<ComplexPropertyObject2>().AsTransient();
            this.container.Bind<IComplexPropertyObject3>().To<ComplexPropertyObject3>().AsTransient();
        }

        private void RegisterOpenGeneric()
        {
            this.container.Bind(typeof(IGenericInterface<>)).To(typeof(GenericExport<>)).AsTransient();
            this.container.Bind(typeof(ImportGeneric<>)).To(typeof(ImportGeneric<>)).AsTransient();
        }

        private void RegisterConditional()
        {
            this.container.Bind<ImportConditionObject1>().AsTransient();
            this.container.Bind<ImportConditionObject2>().AsTransient();
            this.container.Bind<ImportConditionObject3>().AsTransient();

            this.container.Bind<IExportConditionInterface>().To<ExportConditionalObject1>().AsTransient().WhenInjectedInto<ImportConditionObject1>();
            this.container.Bind<IExportConditionInterface>().To<ExportConditionalObject2>().AsTransient().WhenInjectedInto<ImportConditionObject2>();
            this.container.Bind<IExportConditionInterface>().To<ExportConditionalObject3>().AsTransient().WhenInjectedInto<ImportConditionObject3>();
        }

        private void RegisterMultiple()
        {
            this.container.Bind<ImportMultiple1>().AsTransient();
            this.container.Bind<ImportMultiple2>().AsTransient();
            this.container.Bind<ImportMultiple3>().AsTransient();

            this.container.Bind<ISimpleAdapter>().To(
                typeof(SimpleAdapterOne),
                typeof(SimpleAdapterTwo),
                typeof(SimpleAdapterThree),
                typeof(SimpleAdapterFour),
                typeof(SimpleAdapterFive)).AsTransient();
        }

        private void CreateContainer()
        {
            container = new DiContainer();
            ReflectionTypeAnalyzer.AddCustomInjectAttribute(typeof(ImportAttribute));
        }

        private sealed class ZenjectChildContainerAdapter : IChildContainerAdapter
        {
            private readonly DiContainer container;

            internal ZenjectChildContainerAdapter(DiContainer container)
            {
                this.container = container;
            }

            public void Dispose()
            {
                container.UnbindAll();
            }

            public void Prepare()
            {
                this.container.Bind<ITransient1>().To<ScopedTransient>().AsTransient();
                this.container.Bind<ICombined1>().To<ScopedCombined1>().AsTransient();
                this.container.Bind<ICombined2>().To<ScopedCombined2>().AsTransient();
                this.container.Bind<ICombined3>().To<ScopedCombined3>().AsTransient();
            }

            public object Resolve(Type resolveType) => container.Resolve(resolveType);
        }
    }
}