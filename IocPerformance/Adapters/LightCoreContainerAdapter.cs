using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using LightCore;
using LightCore.Lifecycle;

namespace IocPerformance.Adapters
{
    public sealed class LightCoreContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName
        {
            get { return "LightCore"; }
        }

        public override string Url
        {
            get { return "http://www.lightcore.ch"; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
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
            var builder = new ContainerBuilder();

            RegisterDummies(builder);
            RegisterStandard(builder);
            RegisterComplex(builder);
            RegisterPropertyInjection(builder);
            RegisterOpenGeneric(builder);
            RegisterMultiple(builder);

            this.container = builder.Build();
        }

        private static void RegisterDummies(ContainerBuilder builder)
        {
            builder.Register<IDummyOne, DummyOne>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyTwo, DummyTwo>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyThree, DummyThree>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyFour, DummyFour>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyFive, DummyFive>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummySix, DummySix>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummySeven, DummySeven>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyEight, DummyEight>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyNine, DummyNine>().ControlledBy<TransientLifecycle>();
            builder.Register<IDummyTen, DummyTen>().ControlledBy<TransientLifecycle>();
        }

        private static void RegisterStandard(ContainerBuilder builder)
        {
            builder.Register<ISingleton, Singleton>().ControlledBy<SingletonLifecycle>();
            builder.Register<ITransient, Transient>().ControlledBy<TransientLifecycle>();
            builder.Register<ICombined, Combined>().ControlledBy<TransientLifecycle>();
        }

        private static void RegisterComplex(ContainerBuilder builder)
        {
            builder.Register<IFirstService, FirstService>().ControlledBy<SingletonLifecycle>();
            builder.Register<ISecondService, SecondService>().ControlledBy<SingletonLifecycle>();
            builder.Register<IThirdService, ThirdService>().ControlledBy<SingletonLifecycle>();
            builder.Register<ISubObjectOne, SubObjectOne>().ControlledBy<TransientLifecycle>();
            builder.Register<ISubObjectTwo, SubObjectTwo>().ControlledBy<TransientLifecycle>();
            builder.Register<ISubObjectThree, SubObjectThree>().ControlledBy<TransientLifecycle>();
            builder.Register<IComplex, Complex>().ControlledBy<TransientLifecycle>();
        }

        private static void RegisterPropertyInjection(ContainerBuilder builder)
        {
            builder.Register<IServiceA, ServiceA>().ControlledBy<SingletonLifecycle>();
            builder.Register<IServiceB, ServiceB>().ControlledBy<SingletonLifecycle>();
            builder.Register<IServiceC, ServiceC>().ControlledBy<SingletonLifecycle>();

            builder.Register<ISubObjectA>(x => new SubObjectA { ServiceA = x.Resolve<IServiceA>() })
                   .ControlledBy<TransientLifecycle>();
            builder.Register<ISubObjectB>(x => new SubObjectB { ServiceB = x.Resolve<IServiceB>() })
                     .ControlledBy<TransientLifecycle>();
            builder.Register<ISubObjectC>(x => new SubObjectC { ServiceC = x.Resolve<IServiceC>() })
                     .ControlledBy<TransientLifecycle>();

            builder.Register<IComplexPropertyObject>(x => new ComplexPropertyObject
                                                              {
                                                                  ServiceA = x.Resolve<IServiceA>(),
                                                                  ServiceB = x.Resolve<IServiceB>(),
                                                                  ServiceC = x.Resolve<IServiceC>(),
                                                                  SubObjectA = x.Resolve<ISubObjectA>(),
                                                                  SubObjectB = x.Resolve<ISubObjectB>(),
                                                                  SubObjectC = x.Resolve<ISubObjectC>()
                                                              }).ControlledBy<TransientLifecycle>();
        }

        private static void RegisterOpenGeneric(ContainerBuilder builder)
        {
            builder.Register(typeof(IGenericInterface<>), typeof(GenericExport<>)).ControlledBy<TransientLifecycle>();
            builder.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>)).ControlledBy<TransientLifecycle>();
        }

        private static void RegisterMultiple(ContainerBuilder builder)
        {
            builder.Register<ISimpleAdapter, SimpleAdapterOne>().ControlledBy<TransientLifecycle>();
            builder.Register<ISimpleAdapter, SimpleAdapterTwo>().ControlledBy<TransientLifecycle>();
            builder.Register<ISimpleAdapter, SimpleAdapterThree>().ControlledBy<TransientLifecycle>();
            builder.Register<ISimpleAdapter, SimpleAdapterFour>().ControlledBy<TransientLifecycle>();
            builder.Register<ISimpleAdapter, SimpleAdapterFive>().ControlledBy<TransientLifecycle>();

            builder.Register<ImportMultiple, ImportMultiple>().ControlledBy<TransientLifecycle>();
        }
    }
}