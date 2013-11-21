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

        public override bool SupportGeneric
        {
            get
            {
                return true;
            }
        }

        public override string Url
        {
            get { return "https://github.com/iamahern/IfInjector"; }
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
            this.injector.Register(Binding.For<IDummyOne>().To<DummyOne>());
            this.injector.Register(Binding.For<IDummyTwo>().To<DummyTwo>());
            this.injector.Register(Binding.For<IDummyThree>().To<DummyThree>());
            this.injector.Register(Binding.For<IDummyFour>().To<DummyFour>());
            this.injector.Register(Binding.For<IDummyFive>().To<DummyFive>());
            this.injector.Register(Binding.For<IDummySix>().To<DummySix>());
            this.injector.Register(Binding.For<IDummySeven>().To<DummySeven>());
            this.injector.Register(Binding.For<IDummyEight>().To<DummyEight>());
            this.injector.Register(Binding.For<IDummyNine>().To<DummyNine>());
            this.injector.Register(Binding.For<IDummyTen>().To<DummyTen>());
        }
    }
}