using System;
using System.Composition.Hosting;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class Mef2ContainerAdapter : ContainerAdapterBase
    {
        private CompositionHost container;

        public override string PackageName
        {
            get { return "Mef2"; }
        }

        public override string Url
        {
            get { return "http://blogs.msdn.com/b/bclteam/p/composition.aspx"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override string Version
        {
            get { return typeof(CompositionHost).Assembly.GetName().Version.ToString(); }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetExport(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            var config = new ContainerConfiguration();

            RegisterDummies(config);
            RegisterStandard(config);
            RegisterComplexObject(config);
            RegisterPropertyInjection(config);
            RegisterMultiple(config);
            RegisterOpenGeneric(config);

            this.container = config.CreateContainer();
        }

        private static void RegisterOpenGeneric(ContainerConfiguration config)
        {
            config.WithParts(typeof(ImportGeneric<>), typeof(GenericExport<>));
        }

        private static void RegisterMultiple(ContainerConfiguration config)
        {
            config.WithParts(
                typeof(SimpleAdapterOne),
                typeof(SimpleAdapterTwo),
                typeof(SimpleAdapterThree),
                typeof(SimpleAdapterFour),
                typeof(SimpleAdapterFive),
                typeof(ImportMultiple));
        }

        private static void RegisterPropertyInjection(ContainerConfiguration config)
        {
            config.WithParts(
                typeof(ComplexPropertyObject),
                typeof(ServiceA),
                typeof(ServiceB),
                typeof(ServiceC),
                typeof(SubObjectA),
                typeof(SubObjectB),
                typeof(SubObjectC));
        }

        private static void RegisterComplexObject(ContainerConfiguration config)
        {
            config.WithParts(
                typeof(FirstService),
                typeof(SecondService),
                typeof(ThirdService),
                typeof(SubObjectOne),
                typeof(SubObjectTwo),
                typeof(SubObjectThree),
                typeof(Complex));
        }

        private static void RegisterStandard(ContainerConfiguration config)
        {
            config.WithParts(typeof(Singleton), typeof(Transient), typeof(Combined));
        }

        private static void RegisterDummies(ContainerConfiguration config)
        {
            config.WithParts(
                typeof(DummyOne),
                typeof(DummyTwo),
                typeof(DummyThree),
                typeof(DummyFour),
                typeof(DummyFive),
                typeof(DummySix),
                typeof(DummySeven),
                typeof(DummyEight),
                typeof(DummyNine),
                typeof(DummyTen));
        }
    }
}
