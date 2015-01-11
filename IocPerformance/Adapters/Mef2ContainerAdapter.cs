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
            get { return "https://blogs.msdn.com/b/bclteam/p/composition.aspx"; }
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
            if (this.container == null)
                return;
            // Allow the container and everything it references to be garbage collected.
            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            var config = new ContainerConfiguration();
            
            RegisterBasic(config);
            
            RegisterPropertyInjection(config);
            RegisterMultiple(config);
            RegisterOpenGeneric(config);

            this.container = config.CreateContainer();
        }

        public override void PrepareBasic()
        {
            var config = new ContainerConfiguration();            
            RegisterBasic(config);        
            this.container = config.CreateContainer();
        }
        
        private void RegisterBasic(ContainerConfiguration config)
        {
            RegisterDummies(config);
            RegisterStandard(config);
            RegisterComplexObject(config);
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
                typeof(ImportMultiple1),
                typeof(ImportMultiple2),
                typeof(ImportMultiple3));
        }

        private static void RegisterPropertyInjection(ContainerConfiguration config)
        {
            config.WithParts(
                typeof(ComplexPropertyObject1),
                typeof(ComplexPropertyObject2),
                typeof(ComplexPropertyObject3),
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
                typeof(Complex1),
                typeof(Complex2),
                typeof(Complex3));
        }

        private static void RegisterStandard(ContainerConfiguration config)
        {
            config.WithParts(
                typeof(Singleton1),
                typeof(Singleton2),
                typeof(Singleton3),
                typeof(Transient1),
                typeof(Transient2),
                typeof(Transient3),
                typeof(Combined1),
                typeof(Combined2),
                typeof(Combined3));
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
