using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string Name => "Petite";

        public override string PackageName => "Petite.Container";

        public override string Url => "https://github.com/andlju/Petite";

        public override bool SupportsPropertyInjection => true;

        public override T Resolve<T>() => this.container.Resolve<T>();

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
        }

        public override void PrepareBasic()
        {
            this.container = new Petite.Container();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne>(c => new DummyOne());
            this.container.Register<IDummyTwo>(c => new DummyTwo());
            this.container.Register<IDummyThree>(c => new DummyThree());
            this.container.Register<IDummyFour>(c => new DummyFour());
            this.container.Register<IDummyFive>(c => new DummyFive());
            this.container.Register<IDummySix>(c => new DummySix());
            this.container.Register<IDummySeven>(c => new DummySeven());
            this.container.Register<IDummyEight>(c => new DummyEight());
            this.container.Register<IDummyNine>(c => new DummyNine());
            this.container.Register<IDummyTen>(c => new DummyTen());
        }

        private void RegisterStandard()
        {
            this.container.RegisterSingleton<ISingleton1>(c => new Singleton1());
            this.container.RegisterSingleton<ISingleton2>(c => new Singleton2());
            this.container.RegisterSingleton<ISingleton3>(c => new Singleton3());
            this.container.Register<ITransient1>(c => new Transient1());
            this.container.Register<ITransient2>(c => new Transient2());
            this.container.Register<ITransient3>(c => new Transient3());
            this.container.Register<ICombined1>(c => new Combined1(
                c.Resolve<ISingleton1>(),
                c.Resolve<ITransient1>()));
            this.container.Register<ICombined2>(c => new Combined2(
                c.Resolve<ISingleton2>(),
                c.Resolve<ITransient2>()));
            this.container.Register<ICombined3>(c => new Combined3(
                c.Resolve<ISingleton3>(),
                c.Resolve<ITransient3>()));
        }

        private void RegisterComplex()
        {
            this.container.RegisterSingleton<IFirstService>(c => new FirstService());
            this.container.RegisterSingleton<ISecondService>(c => new SecondService());
            this.container.RegisterSingleton<IThirdService>(c => new ThirdService());
            this.container.Register<ISubObjectOne>(c => new SubObjectOne(c.Resolve<IFirstService>()));
            this.container.Register<ISubObjectTwo>(c => new SubObjectTwo(c.Resolve<ISecondService>()));
            this.container.Register<ISubObjectThree>(c => new SubObjectThree(c.Resolve<IThirdService>()));
            this.container.Register<IComplex1>(c => new Complex1(
                c.Resolve<IFirstService>(),
                c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(),
                c.Resolve<ISubObjectOne>(),
                c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>()));
            this.container.Register<IComplex2>(c => new Complex2(
                c.Resolve<IFirstService>(),
                c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(),
                c.Resolve<ISubObjectOne>(),
                c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>()));
            this.container.Register<IComplex3>(c => new Complex3(
                c.Resolve<IFirstService>(),
                c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(),
                c.Resolve<ISubObjectOne>(),
                c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>()));
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingleton<IServiceA>(c => new ServiceA());
            this.container.RegisterSingleton<IServiceB>(c => new ServiceB());
            this.container.RegisterSingleton<IServiceC>(c => new ServiceC());
            this.container.Register<ISubObjectA>(c => new SubObjectA { ServiceA = c.Resolve<IServiceA>() });
            this.container.Register<ISubObjectB>(c => new SubObjectB { ServiceB = c.Resolve<IServiceB>() });
            this.container.Register<ISubObjectC>(c => new SubObjectC { ServiceC = c.Resolve<IServiceC>() });
            this.container.Register<IComplexPropertyObject1>(c => new ComplexPropertyObject1
                                                             {
                                                                 ServiceA = c.Resolve<IServiceA>(),
                                                                 ServiceB = c.Resolve<IServiceB>(),
                                                                 ServiceC = c.Resolve<IServiceC>(),
                                                                 SubObjectA = c.Resolve<ISubObjectA>(),
                                                                 SubObjectB = c.Resolve<ISubObjectB>(),
                                                                 SubObjectC = c.Resolve<ISubObjectC>()
                                                             });

            this.container.Register<IComplexPropertyObject2>(c => new ComplexPropertyObject2
                                                             {
                                                                 ServiceA = c.Resolve<IServiceA>(),
                                                                 ServiceB = c.Resolve<IServiceB>(),
                                                                 ServiceC = c.Resolve<IServiceC>(),
                                                                 SubObjectA = c.Resolve<ISubObjectA>(),
                                                                 SubObjectB = c.Resolve<ISubObjectB>(),
                                                                 SubObjectC = c.Resolve<ISubObjectC>()
                                                             });

            this.container.Register<IComplexPropertyObject3>(c => new ComplexPropertyObject3
                                                             {
                                                                 ServiceA = c.Resolve<IServiceA>(),
                                                                 ServiceB = c.Resolve<IServiceB>(),
                                                                 ServiceC = c.Resolve<IServiceC>(),
                                                                 SubObjectA = c.Resolve<ISubObjectA>(),
                                                                 SubObjectB = c.Resolve<ISubObjectB>(),
                                                                 SubObjectC = c.Resolve<ISubObjectC>()
                                                             });
        }
    }
}