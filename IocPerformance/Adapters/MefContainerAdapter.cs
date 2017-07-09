﻿using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class MefContainerAdapter : ContainerAdapterBase
    {
        private CompositionContainer container;

        public override string PackageName => "Mef";

        public override string Url => "https://mef.codeplex.com";

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsMultiple => true;

        public override bool SupportGeneric => true;

        public override string Version => typeof(CompositionContainer).Assembly.GetName().Version.ToString();

        public override T Resolve<T>() => this.container.GetExports<T>().First().Value;

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            var basic = this.CreateBasic();

            var propertyInjectionCatalog = new TypeCatalog(
                typeof(ComplexPropertyObject1),
                typeof(ComplexPropertyObject2),
                typeof(ComplexPropertyObject3),
                typeof(ServiceA),
                typeof(ServiceB),
                typeof(ServiceC),
                typeof(SubObjectA),
                typeof(SubObjectB),
                typeof(SubObjectC));

            var multipleCatalog = new TypeCatalog(
                typeof(SimpleAdapterOne),
                typeof(SimpleAdapterTwo),
                typeof(SimpleAdapterThree),
                typeof(SimpleAdapterFour),
                typeof(SimpleAdapterFive),
                typeof(ImportMultiple1),
                typeof(ImportMultiple2),
                typeof(ImportMultiple3));

            var openGenericCatalog = new TypeCatalog(typeof(ImportGeneric<>), typeof(GenericExport<>));

            this.container = new CompositionContainer(
                new AggregateCatalog(basic.Item1, basic.Item2, basic.Item3, propertyInjectionCatalog, multipleCatalog, openGenericCatalog), true);
        }
        
        public override void PrepareBasic()
        {
            var basic = this.CreateBasic();

            this.container = new CompositionContainer(
                new AggregateCatalog(basic.Item1, basic.Item2, basic.Item3), true);
        }

        private Tuple<TypeCatalog, TypeCatalog, TypeCatalog> CreateBasic()
        {
            var dummyCatalog = new TypeCatalog(
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

            var standardCatalog = new TypeCatalog(
                typeof(Singleton1), 
                typeof(Singleton2), 
                typeof(Singleton3), 
                typeof(Transient1), 
                typeof(Transient2), 
                typeof(Transient3), 
                typeof(Combined1),
                typeof(Combined2),
                typeof(Combined3));

            var complexCatalog = new TypeCatalog(
                 typeof(FirstService),
                 typeof(SecondService),
                 typeof(ThirdService),
                 typeof(SubObjectOne),
                 typeof(SubObjectTwo),
                 typeof(SubObjectThree),
                 typeof(Complex1),
                 typeof(Complex2),
                 typeof(Complex3));

            return new Tuple<TypeCatalog, TypeCatalog, TypeCatalog>(dummyCatalog, standardCatalog, complexCatalog);
        }
    }
}
