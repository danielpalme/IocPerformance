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

        public override string Name
        {
            get { return "Caliburn.Micro"; }
        }

        public override string PackageName
        {
            get { return "Caliburn.Micro.Container"; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type, null);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new SimpleContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
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
            this.container.RegisterSingleton(typeof(ISingleton), null, typeof(Singleton));
            this.container.RegisterHandler(typeof(ITransient), null, (ioc) => new Transient());
            this.container.RegisterHandler(
                 typeof(ICombined),
                 null,
                 (ioc) => new Combined(
                                 (ISingleton)ioc.GetInstance(typeof(ISingleton), null),
                                 (ITransient)ioc.GetInstance(typeof(ITransient), null)));
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
                 typeof(IComplex),
                 null,
                 (ioc) => new Complex(
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
                    typeof(IComplexPropertyObject),
                    null,
                    (ioc) => new ComplexPropertyObject
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
                 typeof(ImportMultiple),
                 null,
                 ioc => new ImportMultiple((IEnumerable<ISimpleAdapter>)ioc.GetInstance(typeof(IEnumerable<ISimpleAdapter>), null)));
        }
    }
}