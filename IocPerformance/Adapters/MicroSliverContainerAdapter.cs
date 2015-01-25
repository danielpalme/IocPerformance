using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using MicroSliver;

namespace IocPerformance.Adapters
{
    public sealed class MicroSliverContainerAdapter : ContainerAdapterBase
    {
        private IoC container;

        public override string PackageName
        {
            get { return "MicroSliver"; }
        }

        public override string Url
        {
            get { return "https://microsliver.codeplex.com"; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetByType(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void PrepareBasic()
        {
            this.container = new IoC();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Map<IDummyOne, DummyOne>();
            this.container.Map<IDummyTwo, DummyTwo>();
            this.container.Map<IDummyThree, DummyThree>();
            this.container.Map<IDummyFour, DummyFour>();
            this.container.Map<IDummyFive, DummyFive>();
            this.container.Map<IDummySix, DummySix>();
            this.container.Map<IDummySeven, DummySeven>();
            this.container.Map<IDummyEight, DummyEight>();
            this.container.Map<IDummyNine, DummyNine>();
            this.container.Map<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.Map<ISingleton1, Singleton1>().ToSingletonScope();
            this.container.Map<ISingleton2, Singleton2>().ToSingletonScope();
            this.container.Map<ISingleton3, Singleton3>().ToSingletonScope();
            this.container.Map<ITransient1, Transient1>();
            this.container.Map<ITransient2, Transient2>();
            this.container.Map<ITransient3, Transient3>();
            this.container.Map<ICombined1, Combined1>();
            this.container.Map<ICombined2, Combined2>();
            this.container.Map<ICombined3, Combined3>();
        }

        private void RegisterComplex()
        {
            this.container.Map<IFirstService, FirstService>().ToSingletonScope();
            this.container.Map<ISecondService, SecondService>().ToSingletonScope();
            this.container.Map<IThirdService, ThirdService>().ToSingletonScope();
            this.container.Map<ISubObjectOne, SubObjectOne>();
            this.container.Map<ISubObjectTwo, SubObjectTwo>();
            this.container.Map<ISubObjectThree, SubObjectThree>();
            this.container.Map<IComplex1, Complex1>();
            this.container.Map<IComplex2, Complex2>();
            this.container.Map<IComplex3, Complex3>();
        }
    }
}