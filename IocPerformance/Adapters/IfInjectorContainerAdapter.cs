using System;
using IfInjector;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class IfInjectorContainerAdapter : ContainerAdapterBase
    {
        private Injector injector;

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override string PackageName
        {
            get { return "IfInjector"; }
        }

        public override object Resolve(Type type)
        {
            return this.injector.Resolve(type);
        }

        public override sealed void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.injector = null;
        }

        public override void Prepare()
        {
            this.injector = new Injector();
            this.RegisterDummies();
        }

        private void RegisterDummies()
        {
            this.injector.Bind<IDummyOne, DummyOne>();
            this.injector.Bind<IDummyTwo, DummyTwo>();
            this.injector.Bind<IDummyThree, DummyThree>();
            this.injector.Bind<IDummyFour, DummyFour>();
            this.injector.Bind<IDummyFive, DummyFive>();
            this.injector.Bind<IDummySix, DummySix>();
            this.injector.Bind<IDummySeven, DummySeven>();
            this.injector.Bind<IDummyEight, DummyEight>();
            this.injector.Bind<IDummyNine, DummyNine>();
            this.injector.Bind<IDummyTen, DummyTen>();
        }
    }
}