using System;
using fFastInjector;
using IocPerformance.Classes;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generated;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class FFastInjectorContainerAdapter : ContainerAdapterBase
    {
        public override string PackageName
        {
            get { return "fFastInjector"; }
        }

        public override string Url
        {
            get { return "https://ffastinjector.codeplex.com"; }
        }

        public override object Resolve(Type type)
        {
            return Injector.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
        }

        public override void Prepare()
        {
            RegisterDummies();
            RegisterStandard();
            RegisterComplex();
        }

        private static void RegisterDummies()
        {
            Injector.SetResolver<IDummyOne, DummyOne>();
            Injector.SetResolver<IDummyTwo, DummyTwo>();
            Injector.SetResolver<IDummyThree, DummyThree>();
            Injector.SetResolver<IDummyFour, DummyFour>();
            Injector.SetResolver<IDummyFive, DummyFive>();
            Injector.SetResolver<IDummySix, DummySix>();
            Injector.SetResolver<IDummySeven, DummySeven>();
            Injector.SetResolver<IDummyEight, DummyEight>();
            Injector.SetResolver<IDummyNine, DummyNine>();
            Injector.SetResolver<IDummyTen, DummyTen>();
        }

        private static void RegisterStandard()
        {
            var singleton1 = new Singleton1();
            var singleton2 = new Singleton2();
            var singleton3 = new Singleton3();

            Injector.SetResolver<ISingleton1>(() => singleton1);
            Injector.SetResolver<ISingleton2>(() => singleton2);
            Injector.SetResolver<ISingleton3>(() => singleton3);
            Injector.SetResolver<ITransient1, Transient1>();
            Injector.SetResolver<ITransient2, Transient2>();
            Injector.SetResolver<ITransient3, Transient3>();
            Injector.SetResolver<ICombined1, Combined1>();
            Injector.SetResolver<ICombined2, Combined2>();
            Injector.SetResolver<ICombined3, Combined3>();
        }

        private static void RegisterComplex()
        {
            var firstService = new FirstService();
            var secondService = new SecondService();
            var thirdService = new ThirdService();

            Injector.SetResolver<IFirstService>(() => firstService);
            Injector.SetResolver<ISecondService>(() => secondService);
            Injector.SetResolver<IThirdService>(() => thirdService);
            Injector.SetResolver<ISubObjectOne, SubObjectOne>();
            Injector.SetResolver<ISubObjectTwo, SubObjectTwo>();
            Injector.SetResolver<ISubObjectThree, SubObjectThree>();

            Injector.SetResolver<IComplex1, Complex1>();
            Injector.SetResolver<IComplex2, Complex2>();
            Injector.SetResolver<IComplex3, Complex3>();
        }

        public override void Register(InterfaceAndImplemtation[] services)
        {
            throw new NotImplementedException();
        }
    }
}