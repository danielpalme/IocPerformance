using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using LinFu.IoC;

namespace IocPerformance.Adapters
{
    public sealed class LinFuContainerAdapter : ContainerAdapterBase
    {
        private LinFu.IoC.ServiceContainer container;

        public override string Name => "LinFu";

        public override string PackageName => "LinFu.Core";

        public override string Url => "https://github.com/philiplaureano/LinFu";

        // After trying to configure it multiple way I'm not sure why this doesn't work
        // but it doesn't so I'm marking as false
        public override bool SupportsPropertyInjection => false;

        public override bool SupportsMultiple => false;

        public override object Resolve(Type type) => this.container.GetService(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {            
            this.PrepareBasic();            
            this.RegisterMultiple();
            this.RegisterPropertyInjection();
        }

        public override void PrepareBasic()
        {
            this.container = new LinFu.IoC.ServiceContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Inject<IDummyOne>().Using<DummyOne>().OncePerRequest();
            this.container.Inject<IDummyTwo>().Using<DummyTwo>().OncePerRequest();
            this.container.Inject<IDummyThree>().Using<DummyThree>().OncePerRequest();
            this.container.Inject<IDummyFour>().Using<DummyFour>().OncePerRequest();
            this.container.Inject<IDummyFive>().Using<DummyFive>().OncePerRequest();
            this.container.Inject<IDummySix>().Using<DummySix>().OncePerRequest();
            this.container.Inject<IDummySeven>().Using<DummySeven>().OncePerRequest();
            this.container.Inject<IDummyEight>().Using<DummyEight>().OncePerRequest();
            this.container.Inject<IDummyNine>().Using<DummyNine>().OncePerRequest();
            this.container.Inject<IDummyTen>().Using<DummyTen>().OncePerRequest();
        }

        private void RegisterStandard()
        {
            this.container.Inject<ISingleton1>().Using<Singleton1>().AsSingleton();
            this.container.Inject<ISingleton2>().Using<Singleton2>().AsSingleton();
            this.container.Inject<ISingleton3>().Using<Singleton3>().AsSingleton();
            this.container.Inject<ITransient1>().Using<Transient1>().OncePerRequest();
            this.container.Inject<ITransient2>().Using<Transient2>().OncePerRequest();
            this.container.Inject<ITransient3>().Using<Transient3>().OncePerRequest();
            this.container.Inject<ICombined1>().Using<Combined1>().OncePerRequest();
            this.container.Inject<ICombined2>().Using<Combined2>().OncePerRequest();
            this.container.Inject<ICombined3>().Using<Combined3>().OncePerRequest();
        }

        private void RegisterComplex()
        {
            this.container.Inject<IFirstService>().Using<FirstService>().AsSingleton();
            this.container.Inject<ISecondService>().Using<SecondService>().AsSingleton();
            this.container.Inject<IThirdService>().Using<ThirdService>().AsSingleton();
            this.container.Inject<ISubObjectOne>().Using<SubObjectOne>().OncePerRequest();
            this.container.Inject<ISubObjectTwo>().Using<SubObjectTwo>().OncePerRequest();
            this.container.Inject<ISubObjectThree>().Using<SubObjectThree>().OncePerRequest();

            this.container.Inject<IComplex1>().Using<Complex1>().OncePerRequest();
            this.container.Inject<IComplex2>().Using<Complex2>().OncePerRequest();
            this.container.Inject<IComplex3>().Using<Complex3>().OncePerRequest();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Inject<IServiceA>().Using<ServiceA>().AsSingleton();
            this.container.Inject<IServiceB>().Using<ServiceB>().AsSingleton();
            this.container.Inject<IServiceC>().Using<ServiceC>().AsSingleton();

            this.container.LoadFrom(GetType().Assembly);

            /* While is looks like it should work it doesn't
               Not sure why but commented out to try loadfrom container
            //container.Inject<ISubObjectA>().Using<SubObjectA>().OncePerRequest();
            //container.Initialize<SubObjectA>().With((ioc,x) => x.ServiceA = ioc.GetService<IServiceA>());

            //container.Inject<ISubObjectB>().Using<SubObjectB>().OncePerRequest();
            //container.Initialize<SubObjectB>().With((ioc, x) => x.ServiceB = ioc.GetService<IServiceB>());

            //container.Inject<ISubObjectC>().Using<SubObjectC>().OncePerRequest();
            //container.Initialize<SubObjectC>().With((ioc, x) => x.ServiceC = ioc.GetService<IServiceC>());

            //container.Inject<IComplexPropertyObject>().Using<ComplexPropertyObject>().OncePerRequest();
            container.Initialize<ComplexPropertyObject>().With((ioc, x) =>
                {
                    x.ServiceA = ioc.GetService<IServiceA>();
                    x.ServiceB = ioc.GetService<IServiceB>();
                    x.ServiceC = ioc.GetService<IServiceC>();
                    x.SubObjectA = ioc.GetService<ISubObjectA>();
                    x.SubObjectB = ioc.GetService<ISubObjectB>();
                    x.SubObjectC = ioc.GetService<ISubObjectC>();
                }); */
        }

        private void RegisterMultiple()
        {
            // TODO: This doesn't seem to work
            this.container.Inject<ISimpleAdapter>().Using<SimpleAdapterOne>().OncePerRequest();
            this.container.Inject<ISimpleAdapter>().Using<SimpleAdapterTwo>().OncePerRequest();
            this.container.Inject<ISimpleAdapter>().Using<SimpleAdapterThree>().OncePerRequest();
            this.container.Inject<ISimpleAdapter>().Using<SimpleAdapterFour>().OncePerRequest();
            this.container.Inject<ISimpleAdapter>().Using<SimpleAdapterFive>().OncePerRequest();

            this.container.Inject<ImportMultiple1>().Using<ImportMultiple1>().OncePerRequest();
            this.container.Inject<ImportMultiple2>().Using<ImportMultiple2>().OncePerRequest();
            this.container.Inject<ImportMultiple3>().Using<ImportMultiple3>().OncePerRequest();
        }
    }
}