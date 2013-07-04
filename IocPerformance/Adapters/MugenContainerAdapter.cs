using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using MugenInjection;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : ContainerAdapterBase
    {
        private MugenInjector container;

        public override string PackageName
        {
            get { return "MugenInjection"; }
        }

        public override object Resolve(Type type)
        {
            return this.container.Get(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new MugenInjector();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Bind<IDummyOne>().To<DummyOne>().InTransientScope();
            this.container.Bind<IDummyTwo>().To<DummyTwo>().InTransientScope();
            this.container.Bind<IDummyThree>().To<DummyThree>().InTransientScope();
            this.container.Bind<IDummyFour>().To<DummyFour>().InTransientScope();
            this.container.Bind<IDummyFive>().To<DummyFive>().InTransientScope();
            this.container.Bind<IDummySix>().To<DummySix>().InTransientScope();
            this.container.Bind<IDummySeven>().To<DummySeven>().InTransientScope();
            this.container.Bind<IDummyEight>().To<DummyEight>().InTransientScope();
            this.container.Bind<IDummyNine>().To<DummyNine>().InTransientScope();
            this.container.Bind<IDummyTen>().To<DummyTen>().InTransientScope();
        }

        private void RegisterStandard()
        {
            this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            this.container.Bind<ITransient>().To<Transient>().InTransientScope();
            this.container.Bind<ICombined>().To<Combined>().InTransientScope();
        }

        private void RegisterComplex()
        {
            this.container.Bind<IFirstService>().To<FirstService>().InTransientScope();
            this.container.Bind<ISecondService>().To<SecondService>().InTransientScope();
            this.container.Bind<IThirdService>().To<ThirdService>().InTransientScope();
            this.container.Bind<ISubObjectOne>().To<SubObjectOne>().InTransientScope();
            this.container.Bind<ISubObjectTwo>().To<SubObjectTwo>().InTransientScope();
            this.container.Bind<ISubObjectThree>().To<SubObjectThree>().InTransientScope();
            this.container.Bind<IComplex>().To<Complex>().InTransientScope();
        }
    }
}