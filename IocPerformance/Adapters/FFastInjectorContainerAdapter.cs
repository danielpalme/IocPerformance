using System;
using fFastInjector;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using Container = fFastInjector.Injector;

namespace IocPerformance.Adapters
{
    public sealed class FFastInjectorContainerAdapter : ContainerAdapterBase
    {
        public override string PackageName => "fFastInjector";

        public override string Url => "https://ffastinjector.codeplex.com";

        public override object Resolve(Type type) => Container.Resolve(type);

        public override void Dispose()
        {
            // does not support cleanup
        }

        public override void PrepareBasic()
        {
            RegisterDummies();
            RegisterStandard();
            RegisterComplex();
        }

        private static void RegisterDummies()
        {
            Container.SetResolver<IDummyOne, DummyOne>();
            Container.SetResolver<IDummyTwo, DummyTwo>();
            Container.SetResolver<IDummyThree, DummyThree>();
            Container.SetResolver<IDummyFour, DummyFour>();
            Container.SetResolver<IDummyFive, DummyFive>();
            Container.SetResolver<IDummySix, DummySix>();
            Container.SetResolver<IDummySeven, DummySeven>();
            Container.SetResolver<IDummyEight, DummyEight>();
            Container.SetResolver<IDummyNine, DummyNine>();
            Container.SetResolver<IDummyTen, DummyTen>();
        }

        private static void RegisterStandard()
        {
            var singleton1 = new Singleton1();
            var singleton2 = new Singleton2();
            var singleton3 = new Singleton3();

            Container.SetResolver<ISingleton1>(() => singleton1);
            Container.SetResolver<ISingleton2>(() => singleton2);
            Container.SetResolver<ISingleton3>(() => singleton3);
            Container.SetResolver<ITransient1, Transient1>();
            Container.SetResolver<ITransient2, Transient2>();
            Container.SetResolver<ITransient3, Transient3>();
            Container.SetResolver<ICombined1, Combined1>();
            Container.SetResolver<ICombined2, Combined2>();
            Container.SetResolver<ICombined3, Combined3>();
        }

        private static void RegisterComplex()
        {
            var firstService = new FirstService();
            var secondService = new SecondService();
            var thirdService = new ThirdService();

            Container.SetResolver<IFirstService>(() => firstService);
            Container.SetResolver<ISecondService>(() => secondService);
            Container.SetResolver<IThirdService>(() => thirdService);
            Container.SetResolver<ISubObjectOne, SubObjectOne>();
            Container.SetResolver<ISubObjectTwo, SubObjectTwo>();
            Container.SetResolver<ISubObjectThree, SubObjectThree>();

            Container.SetResolver<IComplex1, Complex1>();
            Container.SetResolver<IComplex2, Complex2>();
            Container.SetResolver<IComplex3, Complex3>();
        }
    }
}