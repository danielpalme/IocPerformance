using System;
using System.Collections.Generic;
using Caliburn.Micro;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class CaliburnMicroContainer : ContainerAdapterBase
    {
        private SimpleContainer container;

        public override string Name => "Caliburn.Micro";

        public override string PackageName => "Caliburn.Micro.Container";

        public override string Url => "https://github.com/Caliburn-Micro/Caliburn.Micro";

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override T Resolve<T>() => (T)this.container.GetInstance(typeof(T), null);

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
        }
        
        public override void PrepareBasic()
        {
            this.container = new SimpleContainer();
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
            this.container.RegisterHandler(typeof(IDummyOne), null, ioc => new DummyOne());
            this.container.RegisterHandler(typeof(IDummyTwo), null, ioc => new DummyTwo());
            this.container.RegisterHandler(typeof(IDummyThree), null, ioc => new DummyThree());
            this.container.RegisterHandler(typeof(IDummyFour), null, ioc => new DummyFour());
            this.container.RegisterHandler(typeof(IDummyFive), null, ioc => new DummyFive());
            this.container.RegisterHandler(typeof(IDummySix), null, ioc => new DummySix());
            this.container.RegisterHandler(typeof(IDummySeven), null, ioc => new DummySeven());
            this.container.RegisterHandler(typeof(IDummyEight), null, ioc => new DummyEight());
            this.container.RegisterHandler(typeof(IDummyNine), null, ioc => new DummyNine());
            this.container.RegisterHandler(typeof(IDummyTen), null, ioc => new DummyTen());
        }

        private void RegisterStandard()
        {
            this.container.RegisterSingleton(typeof(ISingleton1), null, typeof(Singleton1));
            this.container.RegisterSingleton(typeof(ISingleton2), null, typeof(Singleton2));
            this.container.RegisterSingleton(typeof(ISingleton3), null, typeof(Singleton3));
            this.container.RegisterHandler(typeof(ITransient1), null, (ioc) => new Transient1());
            this.container.RegisterHandler(typeof(ITransient2), null, (ioc) => new Transient2());
            this.container.RegisterHandler(typeof(ITransient3), null, (ioc) => new Transient3());
            this.container.RegisterHandler(
                typeof(ICombined1),
                null,
                (ioc) => new Combined1(
                    (ISingleton1)ioc.GetInstance(typeof(ISingleton1), null),
                    (ITransient1)ioc.GetInstance(typeof(ITransient1), null)));
            this.container.RegisterHandler(
                typeof(ICombined2),
                null,
                (ioc) => new Combined2(
                    (ISingleton2)ioc.GetInstance(typeof(ISingleton2), null),
                    (ITransient2)ioc.GetInstance(typeof(ITransient2), null)));
            this.container.RegisterHandler(
                typeof(ICombined3),
                null,
                (ioc) => new Combined3(
                    (ISingleton3)ioc.GetInstance(typeof(ISingleton3), null),
                    (ITransient3)ioc.GetInstance(typeof(ITransient3), null)));
        }

        private void RegisterComplex()
        {
            this.container.RegisterSingleton(typeof(IFirstService), null, typeof(FirstService));
            this.container.RegisterSingleton(typeof(ISecondService), null, typeof(SecondService));
            this.container.RegisterSingleton(typeof(IThirdService), null, typeof(ThirdService));

            this.container.RegisterHandler(
                typeof(ISubObjectOne),
                null,
                (ioc) => new SubObjectOne((IFirstService)ioc.GetInstance(typeof(IFirstService), null)));
            this.container.RegisterHandler(
                typeof(ISubObjectTwo),
                null,
                (ioc) => new SubObjectTwo((ISecondService)ioc.GetInstance(typeof(ISecondService), null)));
            this.container.RegisterHandler(
                typeof(ISubObjectThree),
                null,
                (ioc) => new SubObjectThree((IThirdService)ioc.GetInstance(typeof(IThirdService), null)));

            this.container.RegisterHandler(
                typeof(IComplex1),
                null,
                (ioc) => new Complex1(
                    (IFirstService)ioc.GetInstance(typeof(IFirstService), null),
                    (ISecondService)ioc.GetInstance(typeof(ISecondService), null),
                    (IThirdService)ioc.GetInstance(typeof(IThirdService), null),
                    (ISubObjectOne)ioc.GetInstance(typeof(ISubObjectOne), null),
                    (ISubObjectTwo)ioc.GetInstance(typeof(ISubObjectTwo), null),
                    (ISubObjectThree)ioc.GetInstance(typeof(ISubObjectThree), null)));

            this.container.RegisterHandler(
                typeof(IComplex2),
                null,
                (ioc) => new Complex2(
                    (IFirstService)ioc.GetInstance(typeof(IFirstService), null),
                    (ISecondService)ioc.GetInstance(typeof(ISecondService), null),
                    (IThirdService)ioc.GetInstance(typeof(IThirdService), null),
                    (ISubObjectOne)ioc.GetInstance(typeof(ISubObjectOne), null),
                    (ISubObjectTwo)ioc.GetInstance(typeof(ISubObjectTwo), null),
                    (ISubObjectThree)ioc.GetInstance(typeof(ISubObjectThree), null)));

            this.container.RegisterHandler(
                typeof(IComplex3),
                null,
                (ioc) => new Complex3(
                    (IFirstService)ioc.GetInstance(typeof(IFirstService), null),
                    (ISecondService)ioc.GetInstance(typeof(ISecondService), null),
                    (IThirdService)ioc.GetInstance(typeof(IThirdService), null),
                    (ISubObjectOne)ioc.GetInstance(typeof(ISubObjectOne), null),
                    (ISubObjectTwo)ioc.GetInstance(typeof(ISubObjectTwo), null),
                    (ISubObjectThree)ioc.GetInstance(typeof(ISubObjectThree), null)));
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingleton(typeof(IServiceA), null, typeof(ServiceA));
            this.container.RegisterSingleton(typeof(IServiceB), null, typeof(ServiceB));
            this.container.RegisterSingleton(typeof(IServiceC), null, typeof(ServiceC));
            this.container.RegisterHandler(
                typeof(ISubObjectA),
                null,
                (ioc) => new SubObjectA { ServiceA = (IServiceA)ioc.GetInstance(typeof(IServiceA), null) });
            this.container.RegisterHandler(
                typeof(ISubObjectB),
                null,
                (ioc) => new SubObjectB { ServiceB = (IServiceB)ioc.GetInstance(typeof(IServiceB), null) });
            this.container.RegisterHandler(
                typeof(ISubObjectC),
                null,
                (ioc) => new SubObjectC { ServiceC = (IServiceC)ioc.GetInstance(typeof(IServiceC), null) });
            this.container.RegisterHandler(
                typeof(IComplexPropertyObject1),
                null,
                (ioc) => new ComplexPropertyObject1
                {
                    ServiceA = (IServiceA)ioc.GetInstance(typeof(IServiceA), null),
                    ServiceB = (IServiceB)ioc.GetInstance(typeof(IServiceB), null),
                    ServiceC = (IServiceC)ioc.GetInstance(typeof(IServiceC), null),
                    SubObjectA = (ISubObjectA)ioc.GetInstance(typeof(ISubObjectA), null),
                    SubObjectB = (ISubObjectB)ioc.GetInstance(typeof(ISubObjectB), null),
                    SubObjectC = (ISubObjectC)ioc.GetInstance(typeof(ISubObjectC), null),
                });
            this.container.RegisterHandler(
                typeof(IComplexPropertyObject2),
                null,
                (ioc) => new ComplexPropertyObject2
                {
                    ServiceA = (IServiceA)ioc.GetInstance(typeof(IServiceA), null),
                    ServiceB = (IServiceB)ioc.GetInstance(typeof(IServiceB), null),
                    ServiceC = (IServiceC)ioc.GetInstance(typeof(IServiceC), null),
                    SubObjectA = (ISubObjectA)ioc.GetInstance(typeof(ISubObjectA), null),
                    SubObjectB = (ISubObjectB)ioc.GetInstance(typeof(ISubObjectB), null),
                    SubObjectC = (ISubObjectC)ioc.GetInstance(typeof(ISubObjectC), null),
                });
            this.container.RegisterHandler(
                typeof(IComplexPropertyObject3),
                null,
                (ioc) => new ComplexPropertyObject3
                {
                    ServiceA = (IServiceA)ioc.GetInstance(typeof(IServiceA), null),
                    ServiceB = (IServiceB)ioc.GetInstance(typeof(IServiceB), null),
                    ServiceC = (IServiceC)ioc.GetInstance(typeof(IServiceC), null),
                    SubObjectA = (ISubObjectA)ioc.GetInstance(typeof(ISubObjectA), null),
                    SubObjectB = (ISubObjectB)ioc.GetInstance(typeof(ISubObjectB), null),
                    SubObjectC = (ISubObjectC)ioc.GetInstance(typeof(ISubObjectC), null),
                });
        }

        private void RegisterMultiple()
        {
            this.container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterOne());
            this.container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterTwo());
            this.container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterThree());
            this.container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterFour());
            this.container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterFive());

            this.container.RegisterHandler(
                typeof(ImportMultiple1),
                null,
                ioc => new ImportMultiple1((IEnumerable<ISimpleAdapter>)ioc.GetInstance(typeof(IEnumerable<ISimpleAdapter>), null)));

            this.container.RegisterHandler(
                typeof(ImportMultiple2),
                null,
                ioc => new ImportMultiple2((IEnumerable<ISimpleAdapter>)ioc.GetInstance(typeof(IEnumerable<ISimpleAdapter>), null)));

            this.container.RegisterHandler(
                typeof(ImportMultiple3),
                null,
                ioc => new ImportMultiple3((IEnumerable<ISimpleAdapter>)ioc.GetInstance(typeof(IEnumerable<ISimpleAdapter>), null)));
        }
    }
}