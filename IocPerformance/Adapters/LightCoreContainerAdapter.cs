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

        public override string PackageName => "LightCore";

        public override string Url => "http://www.lightcore.ch";

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            var builder = new ContainerBuilder();

            RegisterBasic(builder);
            
            RegisterPropertyInjection(builder);
            RegisterOpenGeneric(builder);
            RegisterMultiple(builder);

            this.container = builder.Build();
        }

        public override void PrepareBasic()
        {
            var builder = new ContainerBuilder();

            RegisterBasic(builder);

            this.container = builder.Build();
        }

        private static void RegisterBasic(ContainerBuilder builder)
        {
            RegisterDummies(builder);
            RegisterStandard(builder);
            RegisterComplex(builder);
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
            builder.Register<ISingleton1, Singleton1>().ControlledBy<SingletonLifecycle>();
            builder.Register<ISingleton2, Singleton2>().ControlledBy<SingletonLifecycle>();
            builder.Register<ISingleton3, Singleton3>().ControlledBy<SingletonLifecycle>();
            builder.Register<ITransient1, Transient1>().ControlledBy<TransientLifecycle>();
            builder.Register<ITransient2, Transient2>().ControlledBy<TransientLifecycle>();
            builder.Register<ITransient3, Transient3>().ControlledBy<TransientLifecycle>();
            builder.Register<ICombined1, Combined1>().ControlledBy<TransientLifecycle>();
            builder.Register<ICombined2, Combined2>().ControlledBy<TransientLifecycle>();
            builder.Register<ICombined3, Combined3>().ControlledBy<TransientLifecycle>();
        }

        private static void RegisterComplex(ContainerBuilder builder)
        {
            builder.Register<IFirstService, FirstService>().ControlledBy<SingletonLifecycle>();
            builder.Register<ISecondService, SecondService>().ControlledBy<SingletonLifecycle>();
            builder.Register<IThirdService, ThirdService>().ControlledBy<SingletonLifecycle>();
            builder.Register<ISubObjectOne, SubObjectOne>().ControlledBy<TransientLifecycle>();
            builder.Register<ISubObjectTwo, SubObjectTwo>().ControlledBy<TransientLifecycle>();
            builder.Register<ISubObjectThree, SubObjectThree>().ControlledBy<TransientLifecycle>();
            builder.Register<IComplex1, Complex1>().ControlledBy<TransientLifecycle>();
            builder.Register<IComplex2, Complex2>().ControlledBy<TransientLifecycle>();
            builder.Register<IComplex3, Complex3>().ControlledBy<TransientLifecycle>();
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

            builder.Register<IComplexPropertyObject1>(x => new ComplexPropertyObject1
                                                      {
                                                          ServiceA = x.Resolve<IServiceA>(),
                                                          ServiceB = x.Resolve<IServiceB>(),
                                                          ServiceC = x.Resolve<IServiceC>(),
                                                          SubObjectA = x.Resolve<ISubObjectA>(),
                                                          SubObjectB = x.Resolve<ISubObjectB>(),
                                                          SubObjectC = x.Resolve<ISubObjectC>()
                                                      }).ControlledBy<TransientLifecycle>();

            builder.Register<IComplexPropertyObject2>(x => new ComplexPropertyObject2
                                                      {
                                                          ServiceA = x.Resolve<IServiceA>(),
                                                          ServiceB = x.Resolve<IServiceB>(),
                                                          ServiceC = x.Resolve<IServiceC>(),
                                                          SubObjectA = x.Resolve<ISubObjectA>(),
                                                          SubObjectB = x.Resolve<ISubObjectB>(),
                                                          SubObjectC = x.Resolve<ISubObjectC>()
                                                      }).ControlledBy<TransientLifecycle>();

            builder.Register<IComplexPropertyObject3>(x => new ComplexPropertyObject3
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

            builder.Register<ImportMultiple1, ImportMultiple1>().ControlledBy<TransientLifecycle>();
            builder.Register<ImportMultiple2, ImportMultiple2>().ControlledBy<TransientLifecycle>();
            builder.Register<ImportMultiple3, ImportMultiple3>().ControlledBy<TransientLifecycle>();
        }
    }
}