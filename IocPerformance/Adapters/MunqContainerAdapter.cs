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

        public override string Name => "Munq";

        public override string PackageName => "Munq.IocContainer";

        public override string Url => "http://munq.codeplex.com";

        public override bool SupportsPropertyInjection => true;

        public override T Resolve<T>() => (T)this.container.Resolve<T>();

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
            this.container = new IocContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
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
            this.container.Register<ISingleton1, Singleton1>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ISingleton2, Singleton2>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ISingleton3, Singleton3>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ITransient1, Transient1>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ITransient2, Transient2>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ITransient3, Transient3>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined1, Combined1>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined2, Combined2>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined3, Combined3>().WithLifetimeManager(new AlwaysNewLifetime());
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ISecondService, SecondService>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<IThirdService, ThirdService>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ISubObjectOne, SubObjectOne>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ISubObjectTwo, SubObjectTwo>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ISubObjectThree, SubObjectThree>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IComplex1, Complex1>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IComplex2, Complex2>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<IComplex3, Complex3>().WithLifetimeManager(new AlwaysNewLifetime());
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

            this.container.Register<IComplexPropertyObject1>(x => new ComplexPropertyObject1
                                                             {
                                                                 ServiceA = x.Resolve<IServiceA>(),
                                                                 ServiceB = x.Resolve<IServiceB>(),
                                                                 ServiceC = x.Resolve<IServiceC>(),
                                                                 SubObjectA = x.Resolve<ISubObjectA>(),
                                                                 SubObjectB = x.Resolve<ISubObjectB>(),
                                                                 SubObjectC = x.Resolve<ISubObjectC>()
                                                             }).WithLifetimeManager(new AlwaysNewLifetime());

            this.container.Register<IComplexPropertyObject2>(x => new ComplexPropertyObject2
                                                             {
                                                                 ServiceA = x.Resolve<IServiceA>(),
                                                                 ServiceB = x.Resolve<IServiceB>(),
                                                                 ServiceC = x.Resolve<IServiceC>(),
                                                                 SubObjectA = x.Resolve<ISubObjectA>(),
                                                                 SubObjectB = x.Resolve<ISubObjectB>(),
                                                                 SubObjectC = x.Resolve<ISubObjectC>()
                                                             }).WithLifetimeManager(new AlwaysNewLifetime());

            this.container.Register<IComplexPropertyObject3>(x => new ComplexPropertyObject3
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