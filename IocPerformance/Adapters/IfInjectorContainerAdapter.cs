using System;
using IfInjector;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class IfInjectorContainerAdapter : ContainerAdapterBase
    {
        private Injector container;

        public override bool SupportsPropertyInjection => true;

        public override string PackageName => "IfInjector";

        public override bool SupportGeneric => true;

        public override string Url => "https://github.com/iamahern/IfInjector";

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override sealed void Dispose()
        {
            // Allow the container and everything it references to be collected.    
            this.container = null;            
        }

        public override void PrepareBasic()
        {
            this.container = new Injector();
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }
                
        private void RegisterStandard()
        {
            this.container.Register(Binding.For<ISingleton1>().To<Singleton1>().AsSingleton());
            this.container.Register(Binding.For<ISingleton2>().To<Singleton2>().AsSingleton());
            this.container.Register(Binding.For<ISingleton3>().To<Singleton3>().AsSingleton());
            this.container.Register(Binding.For<ITransient1>().To<Transient1>());
            this.container.Register(Binding.For<ITransient2>().To<Transient2>());
            this.container.Register(Binding.For<ITransient3>().To<Transient3>());
            this.container.Register(Binding.For<ICombined1>().To<Combined1>());
            this.container.Register(Binding.For<ICombined2>().To<Combined2>());
            this.container.Register(Binding.For<ICombined3>().To<Combined3>());
        }

        private void RegisterComplex()
        {
            this.container.Register(Binding.For<IFirstService>().To<FirstService>().AsSingleton());
            this.container.Register(Binding.For<ISecondService>().To<SecondService>().AsSingleton());
            this.container.Register(Binding.For<IThirdService>().To<ThirdService>().AsSingleton());
            this.container.Register(Binding.For<ISubObjectOne>().To<SubObjectOne>());
            this.container.Register(Binding.For<ISubObjectTwo>().To<SubObjectTwo>());
            this.container.Register(Binding.For<ISubObjectThree>().To<SubObjectThree>());
            this.container.Register(Binding.For<IComplex1>().To<Complex1>());
            this.container.Register(Binding.For<IComplex2>().To<Complex2>());
            this.container.Register(Binding.For<IComplex3>().To<Complex3>());
        }

        private void RegisterDummies()
        {
            this.container.Register(Binding.For<IDummyOne>().To<DummyOne>());
            this.container.Register(Binding.For<IDummyTwo>().To<DummyTwo>());
            this.container.Register(Binding.For<IDummyThree>().To<DummyThree>());
            this.container.Register(Binding.For<IDummyFour>().To<DummyFour>());
            this.container.Register(Binding.For<IDummyFive>().To<DummyFive>());
            this.container.Register(Binding.For<IDummySix>().To<DummySix>());
            this.container.Register(Binding.For<IDummySeven>().To<DummySeven>());
            this.container.Register(Binding.For<IDummyEight>().To<DummyEight>());
            this.container.Register(Binding.For<IDummyNine>().To<DummyNine>());
            this.container.Register(Binding.For<IDummyTen>().To<DummyTen>());
        }
    }
}