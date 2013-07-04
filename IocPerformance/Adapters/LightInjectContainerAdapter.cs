using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
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
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne>(c => new DummyOne(), new PerRequestLifeTime());
            this.container.Register<IDummyTwo>(c => new DummyTwo(), new PerRequestLifeTime());
            this.container.Register<IDummyThree>(c => new DummyThree(), new PerRequestLifeTime());
            this.container.Register<IDummyFour>(c => new DummyFour(), new PerRequestLifeTime());
            this.container.Register<IDummyFive>(c => new DummyFive(), new PerRequestLifeTime());
            this.container.Register<IDummySix>(c => new DummySix(), new PerRequestLifeTime());
            this.container.Register<IDummySeven>(c => new DummySeven(), new PerRequestLifeTime());
            this.container.Register<IDummyEight>(c => new DummyEight(), new PerRequestLifeTime());
            this.container.Register<IDummyNine>(c => new DummyNine(), new PerRequestLifeTime());
            this.container.Register<IDummyTen>(c => new DummyTen(), new PerRequestLifeTime());
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton>(c => new Singleton(), new PerContainerLifetime());
            this.container.Register<ITransient>(c => new Transient(), new PerRequestLifeTime());
            this.container.Register<ICombined>(
                c => new Combined(c.GetInstance<ISingleton>(), c.GetInstance<ITransient>()),
                new PerRequestLifeTime());
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService>(c => new FirstService(), new PerContainerLifetime());
            this.container.Register<ISecondService>(c => new SecondService(), new PerContainerLifetime());
            this.container.Register<IThirdService>(c => new ThirdService(), new PerContainerLifetime());
            this.container.Register<ISubObjectOne>(c => new SubObjectOne(c.GetInstance<IFirstService>()), new PerRequestLifeTime());
            this.container.Register<ISubObjectTwo>(c => new SubObjectTwo(c.GetInstance<ISecondService>()), new PerRequestLifeTime());
            this.container.Register<ISubObjectThree>(c => new SubObjectThree(c.GetInstance<IThirdService>()), new PerRequestLifeTime());

            this.container.Register<IComplex>(
                c => new Complex(
                    c.GetInstance<IFirstService>(),
                    c.GetInstance<ISecondService>(),
                    c.GetInstance<IThirdService>(),
                    c.GetInstance<ISubObjectOne>(),
                    c.GetInstance<ISubObjectTwo>(),
                    c.GetInstance<ISubObjectThree>()),
                    new PerRequestLifeTime());
        }
    }
}