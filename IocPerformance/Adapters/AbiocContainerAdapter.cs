using System;
using Abioc;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class AbiocContainerAdapter : ContainerAdapterBase
    {
        private readonly DefaultContructionContext _contructionContext = new DefaultContructionContext();
        private CompilationContext<DefaultContructionContext> _compilationContext;

        public override string PackageName => "abioc";

        public override string Url => "https://github.com/JSkimming/abioc";

        public override object Resolve(Type type)
        {
            return _compilationContext.GetService(_contructionContext, type);
        }

        public override void Dispose()
        {
            // does not support cleanup
        }

        public override void PrepareBasic()
        {
            var registrationContext = new RegistrationContext<DefaultContructionContext>();

            RegisterDummies(registrationContext);
            RegisterStandard(registrationContext);
            RegisterComplex(registrationContext);

            _compilationContext = registrationContext.Compile(GetType().Assembly);
        }

        private static void RegisterDummies(RegistrationContext<DefaultContructionContext> registrationContext)
        {
            registrationContext
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

        private static void RegisterStandard(RegistrationContext<DefaultContructionContext> registrationContext)
        {
            var singleton1 = new Singleton1();
            var singleton2 = new Singleton2();
            var singleton3 = new Singleton3();

            registrationContext
                .Register<ISingleton1>(c => singleton1)
                .Register<ISingleton2>(c => singleton2)
                .Register<ISingleton3>(c => singleton3)
                .Register<ITransient1, Transient1>()
                .Register<ITransient2, Transient2>()
                .Register<ITransient3, Transient3>()
                .Register<ICombined1, Combined1>()
                .Register<ICombined2, Combined2>()
                .Register<ICombined3, Combined3>();
        }

        private static void RegisterComplex(RegistrationContext<DefaultContructionContext> registrationContext)
        {
            var firstService = new FirstService();
            var secondService = new SecondService();
            var thirdService = new ThirdService();

            registrationContext
                .Register<IFirstService>(c => firstService)
                .Register<ISecondService>(c => secondService)
                .Register<IThirdService>(c => thirdService)
                .Register<ISubObjectOne, SubObjectOne>()
                .Register<ISubObjectTwo, SubObjectTwo>()
                .Register<ISubObjectThree, SubObjectThree>()
                .Register<IComplex1, Complex1>()
                .Register<IComplex2, Complex2>()
                .Register<IComplex3, Complex3>();
        }
    }
}
