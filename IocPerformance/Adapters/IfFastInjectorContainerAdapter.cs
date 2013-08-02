using System;
using IfFastInjector;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class IfFastInjectorContainerAdapter : ContainerAdapterBase
    {
        private IfInjector injector;

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override string PackageName
        {
            get { return "IfFastInjector"; }
        }

        public override string Version
        {
            get { return "0.2"; }
        }

        public override object Resolve(Type type)
        {
            return this.injector.Resolve(type);
        }

        public override sealed void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.injector = null;
        }

        public override void Prepare()
        {
            injector = IfInjector.NewInstance();
            RegisterDummies();
            RegisterStandard();
            RegisterComplex();
            RegisterPropertyInjection();
        }

        private void RegisterDummies()
        {
            this.injector.Bind<IDummyOne, DummyOne>();
            this.injector.Bind<IDummyTwo, DummyTwo>();
            this.injector.Bind<IDummyThree, DummyThree>();
            this.injector.Bind<IDummyFour, DummyFour>();
            this.injector.Bind<IDummyFive, DummyFive>();
            this.injector.Bind<IDummySix, DummySix>();
            this.injector.Bind<IDummySeven, DummySeven>();
            this.injector.Bind<IDummyEight, DummyEight>();
            this.injector.Bind<IDummyNine, DummyNine>();
            this.injector.Bind<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.injector.Bind<ISingleton, Singleton>().AsSingleton();
            this.injector.Bind<ITransient, Transient>();
            this.injector.Bind<ICombined, Combined>();
        }

        private void RegisterComplex()
        {
            this.injector.Bind<IFirstService, FirstService>().AsSingleton();
            this.injector.Bind<ISecondService, SecondService>().AsSingleton();
            this.injector.Bind<IThirdService, ThirdService>().AsSingleton();
            this.injector.Bind<ISubObjectOne, SubObjectOne>();
            this.injector.Bind<ISubObjectTwo, SubObjectTwo>();
            this.injector.Bind<ISubObjectThree, SubObjectThree>();

            this.injector.Bind<IComplex, Complex>();
        }

        private void RegisterPropertyInjection()
        {
            this.injector.Bind<IServiceA,ServiceA>().AsSingleton();
            this.injector.Bind<IServiceB,ServiceB>().AsSingleton();
            this.injector.Bind<IServiceC,ServiceC>().AsSingleton();

            this.injector.Bind<ISubObjectA,SubObjectA>()
                .AddPropertyInjector((i) => i.ServiceA);
            this.injector.Bind<ISubObjectB,SubObjectB>()
                .AddPropertyInjector((i) => i.ServiceB);
            this.injector.Bind<ISubObjectC,SubObjectC>()
                .AddPropertyInjector((i) => i.ServiceC);

            this.injector.Bind<IComplexPropertyObject, ComplexPropertyObject>()
                .AddPropertyInjector((i) => i.ServiceA)
                .AddPropertyInjector((i) => i.ServiceB)
                .AddPropertyInjector((i) => i.ServiceC)
                .AddPropertyInjector((i) => i.SubObjectA)
                .AddPropertyInjector((i) => i.SubObjectB)
                .AddPropertyInjector((i) => i.SubObjectC);
        }
    }
}