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
            get { return "http://microsliver.codeplex.com"; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetByType(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
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
            this.container.Map<ISingleton, Singleton>().ToSingletonScope();
            this.container.Map<ITransient, Transient>();
            this.container.Map<ICombined, Combined>();
        }

        private void RegisterComplex()
        {
            this.container.Map<IFirstService, FirstService>().ToSingletonScope();
            this.container.Map<ISecondService, SecondService>().ToSingletonScope();
            this.container.Map<IThirdService, ThirdService>().ToSingletonScope();
            this.container.Map<ISubObjectOne, SubObjectOne>();
            this.container.Map<ISubObjectTwo, SubObjectTwo>();
            this.container.Map<ISubObjectThree, SubObjectThree>();
            this.container.Map<IComplex, Complex>();
        }
    }
}