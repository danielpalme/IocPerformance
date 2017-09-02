using System;
using System.Reflection;
using Abioc;
using Abioc.Registration;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class AbiocContainerAdapter : ContainerAdapterBase
    {
        private AbiocContainer compilationContext;

        public override string PackageName => "abioc";

        public override string Url => "https://github.com/JSkimming/abioc";

        public override bool SupportsMultiple => true;

        public override object Resolve(Type type)
        {
            return this.compilationContext.GeneratedContainer.GetService(type);
        }

        public override void Dispose()
        {
            // does not support cleanup
        }

        public override void Prepare()
        {
            var setup = new RegistrationSetup();

            RegisterDummies(setup);
            RegisterStandard(setup);
            RegisterComplex(setup);
            RegisterMultiple(setup);

            this.compilationContext = setup.Construct(GetType().GetTypeInfo().Assembly);
        }

        public override void PrepareBasic()
        {
            var setup = new RegistrationSetup();

            RegisterDummies(setup);
            RegisterStandard(setup);
            RegisterComplex(setup);

            this.compilationContext = setup.Construct(GetType().GetTypeInfo().Assembly);
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
            setup
                .RegisterFixed<ISingleton1>(new Singleton1())
                .RegisterFixed<ISingleton2>(new Singleton2())
                .RegisterFixed<ISingleton3>(new Singleton3())
                .Register<ITransient1, Transient1>()
                .Register<ITransient2, Transient2>()
                .Register<ITransient3, Transient3>()
                .Register<ICombined1, Combined1>()
                .Register<ICombined2, Combined2>()
                .Register<ICombined3, Combined3>();
        }

        private static void RegisterComplex(RegistrationSetup setup)
        {
            setup
                .RegisterFixed<IFirstService>(new FirstService())
                .RegisterFixed<ISecondService>(new SecondService())
                .RegisterFixed<IThirdService>(new ThirdService())
                .RegisterInternal<ISubObjectOne, SubObjectOne>()
                .RegisterInternal<ISubObjectTwo, SubObjectTwo>()
                .RegisterInternal<ISubObjectThree, SubObjectThree>()
                .Register<IComplex1, Complex1>()
                .Register<IComplex2, Complex2>()
                .Register<IComplex3, Complex3>();
        }

        private static void RegisterMultiple(RegistrationSetup setup)
        {
            setup
                .Register<ISimpleAdapter, SimpleAdapterOne>()
                .Register<ISimpleAdapter, SimpleAdapterTwo>()
                .Register<ISimpleAdapter, SimpleAdapterThree>()
                .Register<ISimpleAdapter, SimpleAdapterFour>()
                .Register<ISimpleAdapter, SimpleAdapterFive>()
                .Register<ImportMultiple1>()
                .Register<ImportMultiple2>()
                .Register<ImportMultiple3>();
        }
    }
}
