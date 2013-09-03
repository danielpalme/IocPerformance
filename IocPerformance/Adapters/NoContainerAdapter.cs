using System;
using System.Collections.Generic;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class NoContainerAdapter : ContainerAdapterBase
    {
        private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

        public override string PackageName
        {
            get { return "No"; }
        }

        public override string Url
        {
            get { return string.Empty; }
        }

        public override string Version
        {
            get { return string.Empty; }
        }

        public override bool SupportsPropertyInjection
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
    }
}