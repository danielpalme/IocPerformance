using System;
using Castle.DynamicProxy;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using StructureMap;

namespace IocPerformance.Adapters
{
    public sealed class StructureMapContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string Name
        {
            get { return "StructureMap"; }
        }

        public override string PackageName
        {
            get { return "structuremap"; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsMultiple
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
            var pg = new Castle.DynamicProxy.ProxyGenerator();

            this.container = new Container(r =>
            {
                RegisterDummies(r);
                RegisterStandard(r);
                RegisterComplex(r);
                RegisterGeneric(r);
                RegisterMultiple(r);
                RegisterInterceptor(r, pg);
            });
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
            r.For<ISingleton>().Singleton().Use<Singleton>();
            r.For<ITransient>().Transient().Use<Transient>();
            r.For<ICombined>().Transient().Use<Combined>();
        }

        private static void RegisterComplex(ConfigurationExpression r)
        {
            r.For<IFirstService>().Singleton().Use<FirstService>();
            r.For<ISecondService>().Singleton().Use<SecondService>();
            r.For<IThirdService>().Singleton().Use<ThirdService>();
            r.For<ISubObjectOne>().Transient().Use<SubObjectOne>();
            r.For<ISubObjectTwo>().Transient().Use<SubObjectTwo>();
            r.For<ISubObjectThree>().Transient().Use<SubObjectThree>();
            r.For<IComplex>().Transient().Use<Complex>();
        }

        private static void RegisterGeneric(ConfigurationExpression r)
        {
            r.For(typeof(IGenericInterface<>)).LifecycleIs(InstanceScope.Transient).Use(typeof(GenericExport<>));
            r.For(typeof(ImportGeneric<>)).Use(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ConfigurationExpression r)
        {
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterOne>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterTwo>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterThree>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterFour>();
            r.For<ISimpleAdapter>().Transient().Use<SimpleAdapterFive>();
            r.For<ImportMultiple>().Transient().Use<ImportMultiple>();
        }

        private static void RegisterInterceptor(ConfigurationExpression r, ProxyGenerator pg)
        {
            r.For<ICalculator>().Transient().Use<Calculator>()
             .EnrichWith(c => pg.CreateInterfaceProxyWithTarget<ICalculator>(c, new StructureMapInterceptionLogger()));
        }
    }
}