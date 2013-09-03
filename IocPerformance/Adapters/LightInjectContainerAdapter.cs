using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : ContainerAdapterBase
    {
        private IServiceContainer container;

        public override string PackageName
        {
            get { return "LightInject"; }
        }

        public override string Url
        {
            get { return "https://github.com/seesharper/LightInject"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new ServiceContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne, DummyOne>(new PerRequestLifeTime());
            this.container.Register<IDummyTwo, DummyTwo>(new PerRequestLifeTime());
            this.container.Register<IDummyThree, DummyThree>(new PerRequestLifeTime());
            this.container.Register<IDummyFour, DummyFour>(new PerRequestLifeTime());
            this.container.Register<IDummyFive, DummyFive>(new PerRequestLifeTime());
            this.container.Register<IDummySix, DummySix>(new PerRequestLifeTime());
            this.container.Register<IDummySeven, DummySeven>(new PerRequestLifeTime());
            this.container.Register<IDummyEight, DummyEight>(new PerRequestLifeTime());
            this.container.Register<IDummyNine, DummyNine>(new PerRequestLifeTime());
            this.container.Register<IDummyTen, DummyTen>(new PerRequestLifeTime());
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton, Singleton>(new PerContainerLifetime());
            this.container.Register<ITransient, Transient>(new PerRequestLifeTime());
            this.container.Register<ICombined, Combined>(new PerRequestLifeTime());
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>(new PerContainerLifetime());
            this.container.Register<ISecondService, SecondService>(new PerContainerLifetime());
            this.container.Register<IThirdService, ThirdService>(new PerContainerLifetime());
            this.container.Register<ISubObjectOne>(c => new SubObjectOne(c.GetInstance<IFirstService>()), new PerRequestLifeTime());
            this.container.Register<ISubObjectTwo>(c => new SubObjectTwo(c.GetInstance<ISecondService>()), new PerRequestLifeTime());
            this.container.Register<ISubObjectThree>(c => new SubObjectThree(c.GetInstance<IThirdService>()), new PerRequestLifeTime());

            this.container.Register<IComplex, Complex>(new PerRequestLifeTime());
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA, ServiceA>(new PerContainerLifetime());
            this.container.Register<IServiceB, ServiceB>(new PerContainerLifetime());
            this.container.Register<IServiceC, ServiceC>(new PerContainerLifetime());
            this.container.Register<ISubObjectA>(c => new SubObjectA { ServiceA = c.GetInstance<IServiceA>() }, new PerRequestLifeTime());
            this.container.Register<ISubObjectB>(c => new SubObjectB { ServiceB = c.GetInstance<IServiceB>() }, new PerRequestLifeTime());
            this.container.Register<ISubObjectC>(c => new SubObjectC { ServiceC = c.GetInstance<IServiceC>() }, new PerRequestLifeTime());
            this.container.Register<IComplexPropertyObject>(
                c => new ComplexPropertyObject
                {
                    ServiceA = c.GetInstance<IServiceA>(),
                    ServiceB = c.GetInstance<IServiceB>(),
                    ServiceC = c.GetInstance<IServiceC>(),
                    SubObjectA = c.GetInstance<ISubObjectA>(),
                    SubObjectB = c.GetInstance<ISubObjectB>(),
                    SubObjectC = c.GetInstance<ISubObjectC>()
                },
                new PerRequestLifeTime());
        }
    }
}