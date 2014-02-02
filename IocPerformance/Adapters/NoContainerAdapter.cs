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
        public const string PACKAGENAME = "No";

        private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

        public override string PackageName
        {
            get { return PACKAGENAME; }
        }

        public override string Url
        {
            get { return string.Empty; }
        }

        public override string Version
        {
            get { return string.Empty; }
        }

        public override bool SupportsConditional
        {
            get { return true; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportsChildContainer
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container[type]();
        }

        public override void Dispose()
        {
        }

        public override void Prepare()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new NoContainerChildContainerAdapter(this);
        }

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
            ISingleton singleton = new Singleton();

            this.container[typeof(ISingleton)] = () => singleton;
            this.container[typeof(ITransient)] = () => new Transient();
            this.container[typeof(ICombined)] = () => new Combined(singleton, new Transient());
        }

        private void RegisterComplex()
        {
            IFirstService firstService = new FirstService();
            ISecondService secondService = new SecondService();
            IThirdService thirdService = new ThirdService();

            this.container[typeof(IFirstService)] = () => firstService;
            this.container[typeof(ISecondService)] = () => secondService;
            this.container[typeof(IThirdService)] = () => thirdService;
            this.container[typeof(IComplex)] = () => new Complex(
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

            this.container[typeof(IComplexPropertyObject)] = () =>
                new ComplexPropertyObject
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
        }

        private void RegisterConditional()
        {
            this.container[typeof(ImportConditionObject)] =
                () => new ImportConditionObject(new ExportConditionalObject());

            this.container[typeof(ImportConditionObject2)] =
                () => new ImportConditionObject2(new ExportConditionalObject2());
        }

        private void RegisterMultiple()
        {
            var adapters = GetAllSimpleAdapters();

            this.container[typeof(ImportMultiple)] = () => new ImportMultiple(adapters);
        }

        private void RegisterInterceptor()
        {
            this.container[typeof(ICalculator)] = () => new Calculator();
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
            this.container[typeof(ITransient)] = () => new ScopedTransient();
            ISingleton singleton = (ISingleton)this.parentAdapter.Resolve(typeof(ISingleton));
            this.container[typeof(ICombined)] = () => new ScopedCombined(new ScopedTransient(), singleton);
        }

        public object Resolve(Type resolveType)
        {
            return this.container[resolveType]();
        }
    }
}