using System;
using System.Collections.Generic;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class NoContainerAdapter : ContainerAdapterBase
    {
        private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

        public override string PackageName => "No";

        public override string Url => string.Empty;

        public override string Version => string.Empty;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsInterception => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportsBasic => true;

        public override object Resolve(Type type) => this.container[type]();

        public override void Dispose()
        {
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }

        public override void PrepareBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        public override IChildContainerAdapter CreateChildContainerAdapter() => new NoContainerChildContainerAdapter(this);

        private static IEnumerable<ISimpleAdapter> GetAllSimpleAdapters()
        {
            yield return new SimpleAdapterOne();
            yield return new SimpleAdapterTwo();
            yield return new SimpleAdapterThree();
            yield return new SimpleAdapterFour();
            yield return new SimpleAdapterFive();
        }

        private void RegisterDummies()
        {
            this.container[typeof(IDummyOne)] = () => new DummyOne();
            this.container[typeof(IDummyTwo)] = () => new DummyTwo();
            this.container[typeof(IDummyThree)] = () => new DummyThree();
            this.container[typeof(IDummyFour)] = () => new DummyFour();
            this.container[typeof(IDummyFive)] = () => new DummyFive();
            this.container[typeof(IDummySix)] = () => new DummySix();
            this.container[typeof(IDummySeven)] = () => new DummySeven();
            this.container[typeof(IDummyEight)] = () => new DummyEight();
            this.container[typeof(IDummyNine)] = () => new DummyNine();
            this.container[typeof(IDummyTen)] = () => new DummyTen();
        }

        private void RegisterStandard()
        {
            ISingleton1 singleton1 = new Singleton1();

            this.container[typeof(ISingleton1)] = () => singleton1;
            this.container[typeof(ITransient1)] = () => new Transient1();
            this.container[typeof(ICombined1)] = () => new Combined1(singleton1, new Transient1());

            ISingleton2 singleton2 = new Singleton2();

            this.container[typeof(ISingleton2)] = () => singleton2;
            this.container[typeof(ITransient2)] = () => new Transient2();
            this.container[typeof(ICombined2)] = () => new Combined2(singleton2, new Transient2());

            ISingleton3 singleton3 = new Singleton3();

            this.container[typeof(ISingleton3)] = () => singleton3;
            this.container[typeof(ITransient3)] = () => new Transient3();
            this.container[typeof(ICombined3)] = () => new Combined3(singleton3, new Transient3());
        }

        private void RegisterComplex()
        {
            IFirstService firstService = new FirstService();
            ISecondService secondService = new SecondService();
            IThirdService thirdService = new ThirdService();

            this.container[typeof(IFirstService)] = () => firstService;
            this.container[typeof(ISecondService)] = () => secondService;
            this.container[typeof(IThirdService)] = () => thirdService;
            this.container[typeof(IComplex1)] = () => new Complex1(
                firstService,
                secondService,
                thirdService,
                new SubObjectOne(firstService),
                new SubObjectTwo(secondService),
                new SubObjectThree(thirdService));
            this.container[typeof(IComplex2)] = () => new Complex2(
                firstService,
                secondService,
                thirdService,
                new SubObjectOne(firstService),
                new SubObjectTwo(secondService),
                new SubObjectThree(thirdService));
            this.container[typeof(IComplex3)] = () => new Complex3(
                firstService,
                secondService,
                thirdService,
                new SubObjectOne(firstService),
                new SubObjectTwo(secondService),
                new SubObjectThree(thirdService));
        }

        private void RegisterPropertyInjection()
        {
            IServiceA serviceA = new ServiceA();
            IServiceB serviceB = new ServiceB();
            IServiceC serviceC = new ServiceC();

            this.container[typeof(IComplexPropertyObject1)] = () =>
                new ComplexPropertyObject1
            {
                ServiceA = serviceA,
                ServiceB = serviceB,
                ServiceC = serviceC,
                SubObjectA = new SubObjectA { ServiceA = serviceA },
                SubObjectB = new SubObjectB { ServiceB = serviceB },
                SubObjectC = new SubObjectC { ServiceC = serviceC }
            };

            this.container[typeof(IComplexPropertyObject2)] = () =>
                new ComplexPropertyObject2
            {
                ServiceA = serviceA,
                ServiceB = serviceB,
                ServiceC = serviceC,
                SubObjectA = new SubObjectA { ServiceA = serviceA },
                SubObjectB = new SubObjectB { ServiceB = serviceB },
                SubObjectC = new SubObjectC { ServiceC = serviceC }
            };

            this.container[typeof(IComplexPropertyObject3)] = () =>
                new ComplexPropertyObject3
            {
                ServiceA = serviceA,
                ServiceB = serviceB,
                ServiceC = serviceC,
                SubObjectA = new SubObjectA { ServiceA = serviceA },
                SubObjectB = new SubObjectB { ServiceB = serviceB },
                SubObjectC = new SubObjectC { ServiceC = serviceC }
            };
        }

        private void RegisterOpenGeneric()
        {
            this.container[typeof(ImportGeneric<int>)] =
                () => new ImportGeneric<int>(new GenericExport<int>());
            this.container[typeof(ImportGeneric<float>)] =
                () => new ImportGeneric<float>(new GenericExport<float>());
            this.container[typeof(ImportGeneric<object>)] =
                () => new ImportGeneric<object>(new GenericExport<object>());
        }

        private void RegisterConditional()
        {
            this.container[typeof(ImportConditionObject1)] =
                () => new ImportConditionObject1(new ExportConditionalObject());

            this.container[typeof(ImportConditionObject2)] =
                () => new ImportConditionObject2(new ExportConditionalObject2());

            this.container[typeof(ImportConditionObject3)] =
                () => new ImportConditionObject3(new ExportConditionalObject3());
        }

        private void RegisterMultiple()
        {
            var adapters = GetAllSimpleAdapters();

            this.container[typeof(ImportMultiple1)] = () => new ImportMultiple1(adapters);
            this.container[typeof(ImportMultiple2)] = () => new ImportMultiple2(adapters);
            this.container[typeof(ImportMultiple3)] = () => new ImportMultiple3(adapters);
        }

        private void RegisterInterceptor()
        {
            this.container[typeof(ICalculator1)] = () => new Calculator1();
            this.container[typeof(ICalculator2)] = () => new Calculator2();
            this.container[typeof(ICalculator3)] = () => new Calculator3();
        }
    }

    public class NoContainerChildContainerAdapter : IChildContainerAdapter
    {
        private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

        private NoContainerAdapter parentAdapter = null;

        public NoContainerChildContainerAdapter(NoContainerAdapter adapter)
        {
            this.parentAdapter = adapter;
        }

        public void Dispose()
        {
        }

        public void Prepare()
        {
            this.container[typeof(ITransient1)] = () => new ScopedTransient();
            ISingleton1 singleton = (ISingleton1)this.parentAdapter.Resolve(typeof(ISingleton1));
            this.container[typeof(ICombined1)] = () => new ScopedCombined1(new ScopedTransient(), singleton);
            this.container[typeof(ICombined2)] = () => new ScopedCombined2(new ScopedTransient(), singleton);
            this.container[typeof(ICombined3)] = () => new ScopedCombined3(new ScopedTransient(), singleton);
        }

        public object Resolve(Type resolveType) => this.container[resolveType]();
    }
}