using System;
using Griffin.Container;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class GriffinContainerAdapter : ContainerAdapterBase
    {
        private IParentContainer container;
        private IParentContainer containerWithLoggingInterception;

        public override string Name
        {
            get { return "Griffin"; }
        }

        public override string PackageName
        {
            get { return "Griffin.Container"; }
        }

        public override string Url
        {
            get { return "https://github.com/jgauffin/griffin.container"; }
        }

        // The container is extremly slow, when creating proxies, so it's currently disabled
        public override bool SupportsInterception
        {
            get { return false; }
        }

        // It says it supports property injection but there is no documentation on how to turn it on and it doesn't work out of the box so ... it's turned off
        public override bool SupportsPropertyInjection
        {
            get { return false; }
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override object ResolveProxy(Type type)
        {
            return this.containerWithLoggingInterception.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
            this.containerWithLoggingInterception = null;
        }

        public override void Prepare()
        {
            var registrar = new ContainerRegistrar();

            RegisterDummies(registrar);
            RegisterStandard(registrar);
            RegisterComplex(registrar);
            RegisterPropertyInjection(registrar);

            this.container = registrar.Build();

            registrar = new ContainerRegistrar();
            registrar.RegisterType<ICalculator1, Calculator1>(Lifetime.Transient);
            registrar.RegisterType<ICalculator2, Calculator2>(Lifetime.Transient);
            registrar.RegisterType<ICalculator3, Calculator3>(Lifetime.Transient);

            var containerWithLoggingInterception = registrar.Build();
            containerWithLoggingInterception.AddDecorator(new GriffinLoggingDecorator());
            this.containerWithLoggingInterception = containerWithLoggingInterception;
        }

        private static void RegisterDummies(ContainerRegistrar registrar)
        {
            registrar.RegisterType<IDummyOne, DummyOne>(Lifetime.Transient);
            registrar.RegisterType<IDummyTwo, DummyTwo>(Lifetime.Transient);
            registrar.RegisterType<IDummyThree, DummyThree>(Lifetime.Transient);
            registrar.RegisterType<IDummyFour, DummyFour>(Lifetime.Transient);
            registrar.RegisterType<IDummyFive, DummyFive>(Lifetime.Transient);
            registrar.RegisterType<IDummySix, DummySix>(Lifetime.Transient);
            registrar.RegisterType<IDummySeven, DummySeven>(Lifetime.Transient);
            registrar.RegisterType<IDummyEight, DummyEight>(Lifetime.Transient);
            registrar.RegisterType<IDummyNine, DummyNine>(Lifetime.Transient);
            registrar.RegisterType<IDummyTen, DummyTen>(Lifetime.Transient);
        }

        private static void RegisterStandard(ContainerRegistrar registrar)
        {
            registrar.RegisterType<ISingleton1, Singleton1>(Lifetime.Singleton);
            registrar.RegisterType<ISingleton2, Singleton2>(Lifetime.Singleton);
            registrar.RegisterType<ISingleton3, Singleton3>(Lifetime.Singleton);
            registrar.RegisterType<ITransient1, Transient1>(Lifetime.Transient);
            registrar.RegisterType<ITransient2, Transient2>(Lifetime.Transient);
            registrar.RegisterType<ITransient3, Transient3>(Lifetime.Transient);
            registrar.RegisterType<ICombined1, Combined1>(Lifetime.Transient);
            registrar.RegisterType<ICombined2, Combined2>(Lifetime.Transient);
            registrar.RegisterType<ICombined3, Combined3>(Lifetime.Transient);
        }

        private static void RegisterComplex(ContainerRegistrar registrar)
        {
            registrar.RegisterType<IFirstService, FirstService>(Lifetime.Singleton);
            registrar.RegisterType<ISecondService, SecondService>(Lifetime.Singleton);
            registrar.RegisterType<IThirdService, ThirdService>(Lifetime.Singleton);
            registrar.RegisterType<ISubObjectOne, SubObjectOne>(Lifetime.Transient);
            registrar.RegisterType<ISubObjectTwo, SubObjectTwo>(Lifetime.Transient);
            registrar.RegisterType<ISubObjectThree, SubObjectThree>(Lifetime.Transient);

            registrar.RegisterType<IComplex1, Complex1>(Lifetime.Transient);
            registrar.RegisterType<IComplex2, Complex2>(Lifetime.Transient);
            registrar.RegisterType<IComplex3, Complex3>(Lifetime.Transient);
        }

        private static void RegisterPropertyInjection(ContainerRegistrar registrar)
        {
            registrar.RegisterType<IServiceA, ServiceA>(Lifetime.Singleton);
            registrar.RegisterType<IServiceB, ServiceB>(Lifetime.Singleton);
            registrar.RegisterType<IServiceC, ServiceC>(Lifetime.Singleton);
            registrar.RegisterService<ISubObjectA>(x => new SubObjectA { ServiceA = x.Resolve<IServiceA>() }, Lifetime.Transient);
            registrar.RegisterService<ISubObjectB>(x => new SubObjectB { ServiceB = x.Resolve<IServiceB>() }, Lifetime.Transient);
            registrar.RegisterService<ISubObjectC>(x => new SubObjectC { ServiceC = x.Resolve<IServiceC>() }, Lifetime.Transient);
            registrar.RegisterService<IComplexPropertyObject1>(
                x => new ComplexPropertyObject1
                {
                    ServiceA = x.Resolve<IServiceA>(),
                    ServiceB = x.Resolve<IServiceB>(),
                    ServiceC = x.Resolve<IServiceC>(),
                    SubObjectA = x.Resolve<ISubObjectA>(),
                    SubObjectB = x.Resolve<ISubObjectB>(),
                    SubObjectC = x.Resolve<ISubObjectC>()
                },
                Lifetime.Transient);
            registrar.RegisterService<IComplexPropertyObject2>(
                x => new ComplexPropertyObject2
                {
                    ServiceA = x.Resolve<IServiceA>(),
                    ServiceB = x.Resolve<IServiceB>(),
                    ServiceC = x.Resolve<IServiceC>(),
                    SubObjectA = x.Resolve<ISubObjectA>(),
                    SubObjectB = x.Resolve<ISubObjectB>(),
                    SubObjectC = x.Resolve<ISubObjectC>()
                },
                Lifetime.Transient);
            registrar.RegisterService<IComplexPropertyObject3>(
                x => new ComplexPropertyObject3
                {
                    ServiceA = x.Resolve<IServiceA>(),
                    ServiceB = x.Resolve<IServiceB>(),
                    ServiceC = x.Resolve<IServiceC>(),
                    SubObjectA = x.Resolve<ISubObjectA>(),
                    SubObjectB = x.Resolve<ISubObjectB>(),
                    SubObjectC = x.Resolve<ISubObjectC>()
                },
                Lifetime.Transient);
        }
    }
}