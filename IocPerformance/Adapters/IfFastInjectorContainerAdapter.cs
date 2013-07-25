using System;
using IfFastInjector;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class IfFastInjectorContainerAdapter : ContainerAdapterBase
    {
        private IfInjector injector;

        public override string PackageName
        {
            get { return "IfFastInjector"; }
        }

        public override string Version
        {
            get
            {
                return "0.1";
            }
        }

        public override object Resolve(Type type)
        {
            return injector.Resolve(type);
        }

        public override sealed void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            injector = null;
        }

        public override void Prepare()
        {
            injector = IfInjector.NewInstance();
            RegisterDummies();
            RegisterStandard();
            RegisterComplex();
        }

        private void RegisterDummies()
        {
            injector.Bind<IDummyOne, DummyOne>();
            injector.Bind<IDummyTwo, DummyTwo>();
            injector.Bind<IDummyThree, DummyThree>();
            injector.Bind<IDummyFour, DummyFour>();
            injector.Bind<IDummyFive, DummyFive>();
            injector.Bind<IDummySix, DummySix>();
            injector.Bind<IDummySeven, DummySeven>();
            injector.Bind<IDummyEight, DummyEight>();
            injector.Bind<IDummyNine, DummyNine>();
            injector.Bind<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            injector.Bind<ISingleton, Singleton>().AsSingleton();
            injector.Bind<ITransient, Transient>();
            injector.Bind<ICombined, Combined>();
        }

        private void RegisterComplex()
        {
            var firstService = new FirstService();
            var secondService = new SecondService();
            var thirdService = new ThirdService();

            injector.Bind<IFirstService, FirstService>().AsSingleton();
            injector.Bind<ISecondService, SecondService>().AsSingleton();
            injector.Bind<IThirdService, ThirdService>().AsSingleton();
            injector.Bind<ISubObjectOne, SubObjectOne>();
            injector.Bind<ISubObjectTwo, SubObjectTwo>();
            injector.Bind<ISubObjectThree, SubObjectThree>();

            injector.Bind<IComplex, Complex>();
        }
    }
}