using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Munq;
using Munq.LifetimeManagers;

namespace IocPerformance.Adapters
{
    public sealed class MunqContainerAdapter : ContainerAdapterBase
    {
        private IocContainer container;

        public override string Name
        {
            get { return "Munq"; }
        }

        public override string PackageName
        {
            get { return "Munq.IocContainer"; }
        }

        public override string Url
        {
            get { return "http://munq.codeplex.com"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new IocContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne, DummyOne>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyTwo, DummyTwo>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyThree, DummyThree>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyFour, DummyFour>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyFive, DummyFive>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummySix, DummySix>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummySeven, DummySeven>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyEight, DummyEight>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyNine, DummyNine>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IDummyTen, DummyTen>().WithLifetimeManager(new AlwaysNewLifetime());
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton, Singleton>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ITransient, Transient>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined, Combined>().WithLifetimeManager(new AlwaysNewLifetime());
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ISecondService, SecondService>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<IThirdService, ThirdService>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ISubObjectOne, SubObjectOne>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ISubObjectTwo, SubObjectTwo>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ISubObjectThree, SubObjectThree>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IComplex, Complex>().WithLifetimeManager(new AlwaysNewLifetime());
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA, ServiceA>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<IServiceB, ServiceB>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<IServiceC, ServiceC>().WithLifetimeManager(new ContainerLifetime());

            this.container.Register<ISubObjectA>(x => new SubObjectA { ServiceA = x.Resolve<IServiceA>() })
                .WithLifetimeManager(new AlwaysNewLifetime());

            this.container.Register<ISubObjectB>(x => new SubObjectB { ServiceB = x.Resolve<IServiceB>() })
                 .WithLifetimeManager(new AlwaysNewLifetime());

            this.container.Register<ISubObjectC>(x => new SubObjectC { ServiceC = x.Resolve<IServiceC>() })
                .WithLifetimeManager(new AlwaysNewLifetime());

            this.container.Register<IComplexPropertyObject>(x => new ComplexPropertyObject
            {
                ServiceA = x.Resolve<IServiceA>(),
                ServiceB = x.Resolve<IServiceB>(),
                ServiceC = x.Resolve<IServiceC>(),
                SubObjectA = x.Resolve<ISubObjectA>(),
                SubObjectB = x.Resolve<ISubObjectB>(),
                SubObjectC = x.Resolve<ISubObjectC>()
            }).WithLifetimeManager(new AlwaysNewLifetime());
        }
    }
}