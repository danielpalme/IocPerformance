using System;
using System.Reflection;
using Abioc;
using Abioc.Registration;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class AbiocContainerAdapter : ContainerAdapterBase
    {
        private AbiocContainer _compilationContext;

        public override string PackageName => "abioc";

        public override string Url => "https://github.com/JSkimming/abioc";

        public override object Resolve(Type type)
        {
            return _compilationContext.GetService(type);
        }

        public override void Dispose()
        {
            // does not support cleanup
        }

        public override void PrepareBasic()
        {
            var setup = new RegistrationSetup();

            RegisterDummies(setup);
            RegisterStandard(setup);
            RegisterComplex(setup);

            _compilationContext = setup.Construct(GetType().GetTypeInfo().Assembly);
        }

        private static void RegisterDummies(RegistrationSetup setup)
        {
            setup
                .Register<IDummyOne, DummyOne>()
                .Register<IDummyTwo, DummyTwo>()
                .Register<IDummyThree, DummyThree>()
                .Register<IDummyFour, DummyFour>()
                .Register<IDummyFive, DummyFive>()
                .Register<IDummySix, DummySix>()
                .Register<IDummySeven, DummySeven>()
                .Register<IDummyEight, DummyEight>()
                .Register<IDummyNine, DummyNine>()
                .Register<IDummyTen, DummyTen>();
        }

        private static void RegisterStandard(RegistrationSetup setup)
        {
            var singleton1 = new Singleton1();
            var singleton2 = new Singleton2();
            var singleton3 = new Singleton3();

            setup
                .RegisterFactory<ISingleton1>(() => singleton1)
                .RegisterFactory<ISingleton2>(() => singleton2)
                .RegisterFactory<ISingleton3>(() => singleton3)
                .Register<ITransient1, Transient1>()
                .Register<ITransient2, Transient2>()
                .Register<ITransient3, Transient3>()
                .Register<ICombined1, Combined1>()
                .Register<ICombined2, Combined2>()
                .Register<ICombined3, Combined3>();
        }

        private static void RegisterComplex(RegistrationSetup setup)
        {
            var firstService = new FirstService();
            var secondService = new SecondService();
            var thirdService = new ThirdService();

            setup
                .RegisterFactory<IFirstService>(() => firstService)
                .RegisterFactory<ISecondService>(() => secondService)
                .RegisterFactory<IThirdService>(() => thirdService)
                .Register<ISubObjectOne, SubObjectOne>()
                .Register<ISubObjectTwo, SubObjectTwo>()
                .Register<ISubObjectThree, SubObjectThree>()
                .Register<IComplex1, Complex1>()
                .Register<IComplex2, Complex2>()
                .Register<IComplex3, Complex3>();
        }
    }
}
