using System;
using Castle.DynamicProxy;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using StructureMap;

namespace IocPerformance.Adapters
{
    public sealed class StructureMapContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName => "StructureMap";

        public override string Url => "http://structuremap.net/structuremap";

        public override bool SupportsInterception => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => true;

        public override object Resolve(Type type) => this.container.GetInstance(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container == null)
            {
                return;
            }

            this.container.Dispose();
            this.container = null;
        }

        public override IChildContainerAdapter CreateChildContainerAdapter() => new StructureMapChildContainerAdapter(this.container.GetNestedContainer());

        public override void Prepare()
        {
            var pg = new Castle.DynamicProxy.ProxyGenerator();

            this.container = new Container(r =>
                                           {
                                               RegisterBasic(r);

                                               RegisterPropertyInjection(r);
                                               RegisterGeneric(r);
                                               RegisterMultiple(r);
                                               RegisterInterceptor(r, pg);

                                               r.Populate(CreateServiceCollection());
                                           });
            
        }

        public override void PrepareBasic()
        {
            this.container = new Container(r =>
                                           {
                                               RegisterBasic(r);
                                           });
        }

        private static void RegisterBasic(ConfigurationExpression r)
        {
            RegisterDummies(r);
            RegisterStandard(r);
            RegisterComplex(r);
        }

        private static void RegisterDummies(ConfigurationExpression r)
        {
            r.For<IDummyOne>().Transient().Use<DummyOne>();
            r.For<IDummyTwo>().Transient().Use<DummyTwo>();
            r.For<IDummyThree>().Transient().Use<DummyThree>();
            r.For<IDummyFour>().Transient().Use<DummyFour>();
            r.For<IDummyFive>().Transient().Use<DummyFive>();
            r.For<IDummySix>().Transient().Use<DummySix>();
            r.For<IDummySeven>().Transient().Use<DummySeven>();
            r.For<IDummyEight>().Transient().Use<DummyEight>();
            r.For<IDummyNine>().Transient().Use<DummyNine>();
            r.For<IDummyTen>().Transient().Use<DummyTen>();
        }

        private static void RegisterStandard(ConfigurationExpression r)
        {
            r.For<ISingleton1>().Singleton().Use<Singleton1>();
            r.For<ISingleton2>().Singleton().Use<Singleton2>();
            r.For<ISingleton3>().Singleton().Use<Singleton3>();
            r.For<ITransient1>().Transient().Use<Transient1>();
            r.For<ITransient2>().Transient().Use<Transient2>();
            r.For<ITransient3>().Transient().Use<Transient3>();
            r.For<ICombined1>().Transient().Use<Combined1>();
            r.For<ICombined2>().Transient().Use<Combined2>();
            r.For<ICombined3>().Transient().Use<Combined3>();
        }

        private static void RegisterComplex(ConfigurationExpression r)
        {
            r.For<IFirstService>().Singleton().Use<FirstService>();
            r.For<ISecondService>().Singleton().Use<SecondService>();
            r.For<IThirdService>().Singleton().Use<ThirdService>();
            r.For<ISubObjectOne>().Transient().Use<SubObjectOne>();
            r.For<ISubObjectTwo>().Transient().Use<SubObjectTwo>();
            r.For<ISubObjectThree>().Transient().Use<SubObjectThree>();
            r.For<IComplex1>().Transient().Use<Complex1>();
            r.For<IComplex2>().Transient().Use<Complex2>();
            r.For<IComplex3>().Transient().Use<Complex3>();
        }

        private static void RegisterPropertyInjection(ConfigurationExpression r)
        {
            r.For<IServiceA>().Singleton().Use<ServiceA>();
            r.For<IServiceB>().Singleton().Use<ServiceB>();
            r.For<IServiceC>().Singleton().Use<ServiceC>();

            r.For<ISubObjectA>().Transient().Use<SubObjectA>()
                .Setter(x => x.ServiceA).IsTheDefault();

            r.For<ISubObjectB>().Transient().Use<SubObjectB>()
                .Setter(x => x.ServiceB).IsTheDefault();

            r.For<ISubObjectC>().Transient().Use<SubObjectC>()
                .Setter(x => x.ServiceC).IsTheDefault();

            r.For<IComplexPropertyObject1>().Transient().Use<ComplexPropertyObject1>()
                .Setter(x => x.ServiceA).IsTheDefault()
                .Setter(x => x.ServiceB).IsTheDefault()
                .Setter(x => x.ServiceC).IsTheDefault()
                .Setter(x => x.SubObjectA).IsTheDefault()
                .Setter(x => x.SubObjectB).IsTheDefault()
                .Setter(x => x.SubObjectC).IsTheDefault();

            r.For<IComplexPropertyObject2>().Transient().Use<ComplexPropertyObject2>()
                .Setter(x => x.ServiceA).IsTheDefault()
                .Setter(x => x.ServiceB).IsTheDefault()
                .Setter(x => x.ServiceC).IsTheDefault()
                .Setter(x => x.SubObjectA).IsTheDefault()
                .Setter(x => x.SubObjectB).IsTheDefault()
                .Setter(x => x.SubObjectC).IsTheDefault();

            r.For<IComplexPropertyObject3>().Transient().Use<ComplexPropertyObject3>()
                .Setter(x => x.ServiceA).IsTheDefault()
                .Setter(x => x.ServiceB).IsTheDefault()
                .Setter(x => x.ServiceC).IsTheDefault()
                .Setter(x => x.SubObjectA).IsTheDefault()
                .Setter(x => x.SubObjectB).IsTheDefault()
                .Setter(x => x.SubObjectC).IsTheDefault();
        }

        private static void RegisterGeneric(ConfigurationExpression r)
        {
            r.For(typeof(IGenericInterface<>)).Use(typeof(GenericExport<>));
            r.For(typeof(ImportGeneric<>)).Use(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ConfigurationExpression r)
        {
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterOne>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterTwo>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterThree>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterFour>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterFive>();
            r.For<ImportMultiple1>().Transient().Use<ImportMultiple1>();
            r.For<ImportMultiple2>().Transient().Use<ImportMultiple2>();
            r.For<ImportMultiple3>().Transient().Use<ImportMultiple3>();
        }

        private static void RegisterInterceptor(ConfigurationExpression r, ProxyGenerator pg)
        {
            r.For<ICalculator1>().Transient().Use<Calculator1>()
                .DecorateWith(c => pg.CreateInterfaceProxyWithTarget<ICalculator1>(c, new StructureMapInterceptionLogger()));
            r.For<ICalculator2>().Transient().Use<Calculator2>()
                .DecorateWith(c => pg.CreateInterfaceProxyWithTarget<ICalculator2>(c, new StructureMapInterceptionLogger()));
            r.For<ICalculator3>().Transient().Use<Calculator3>()
                .DecorateWith(c => pg.CreateInterfaceProxyWithTarget<ICalculator3>(c, new StructureMapInterceptionLogger()));
        }
    }

    public class StructureMapChildContainerAdapter : IChildContainerAdapter
    {
        private readonly IContainer container;

        public StructureMapChildContainerAdapter(IContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public void Prepare()
        {
            this.container.Configure(c =>
                                     {
                                         c.For<ICombined1>().Use<ScopedCombined1>();
                                         c.For<ICombined2>().Use<ScopedCombined2>();
                                         c.For<ICombined3>().Use<ScopedCombined3>();
                                         c.For<ITransient1>().Use<ScopedTransient>();
                                     });
        }

        public object Resolve(Type resolveType) => this.container.GetInstance(resolveType);
    }
}