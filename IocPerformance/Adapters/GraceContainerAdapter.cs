using System;
using Grace.DependencyInjection;
using IocPerformance.Classes;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generated;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public class GraceContainerAdapter : ContainerAdapterBase
    {
        private DependencyInjectionContainer container;

        public override string PackageName
        {
            get { return "Grace"; }
        }

        public override string Url
        {
            get { return "https://github.com/ipjohnson/Grace"; }
        }

        public override bool SupportsPropertyInjection
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

        public override bool SupportsConditional
        {
            get { return true; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportsChildContainer
        {
            get { return true; }
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new GraceChildContainerAdapter(this.container.CreateChildScope());
        }

        public override object Resolve(Type type)
        {
            return this.container.Locate(type);
        }

        public override void Dispose()
        {
            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new DependencyInjectionContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterMultiple();
            this.RegisterConditional();
            this.RegisterInterceptor();
        }

        private void RegisterInterceptor()
        {
            var pg = new Castle.DynamicProxy.ProxyGenerator();

            this.container.Configure(
                ioc => ioc.Export<Calculator1>()
                    .As<ICalculator1>()
                    .EnrichWith((scope, context, o) => pg.CreateInterfaceProxyWithTarget(o as ICalculator1, new StructureMapInterceptionLogger())));

            this.container.Configure(
                ioc => ioc.Export<Calculator2>()
                    .As<ICalculator2>()
                    .EnrichWith((scope, context, o) => pg.CreateInterfaceProxyWithTarget(o as ICalculator2, new StructureMapInterceptionLogger())));

            this.container.Configure(
                ioc => ioc.Export<Calculator3>()
                    .As<ICalculator3>()
                    .EnrichWith((scope, context, o) => pg.CreateInterfaceProxyWithTarget(o as ICalculator3, new StructureMapInterceptionLogger())));
        }

        private void RegisterConditional()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<ImportConditionObject1>();
                    ioc.Export<ImportConditionObject2>();
                    ioc.Export<ImportConditionObject3>();

                    ioc.Export<ExportConditionalObject>()
                        .As<IExportConditionInterface>()
                        .WhenInjectedInto<ImportConditionObject1>();

                    ioc.Export<ExportConditionalObject2>()
                        .As<IExportConditionInterface>()
                        .WhenInjectedInto<ImportConditionObject2>();

                    ioc.Export<ExportConditionalObject3>()
                        .As<IExportConditionInterface>()
                        .WhenInjectedInto<ImportConditionObject3>();
                });
        }

        private void RegisterMultiple()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<SimpleAdapterOne>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterTwo>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterThree>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterFour>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterFive>().As<ISimpleAdapter>();
                    ioc.Export<ImportMultiple1>();
                    ioc.Export<ImportMultiple2>();
                    ioc.Export<ImportMultiple3>();
                });
        }

        private void RegisterOpenGeneric()
        {
            this.container.Configure(c =>
                   {
                       c.Export(typeof(ImportGeneric<>));
                       c.Export(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
                   });
        }

        private void RegisterStandard()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<Singleton1>().As<ISingleton1>().AndSingleton();
                    ioc.Export<Singleton2>().As<ISingleton2>().AndSingleton();
                    ioc.Export<Singleton3>().As<ISingleton3>().AndSingleton();
                    ioc.Export<Transient1>().As<ITransient1>();
                    ioc.Export<Transient2>().As<ITransient2>();
                    ioc.Export<Transient3>().As<ITransient3>();
                    ioc.Export<Combined1>().As<ICombined1>();
                    ioc.Export<Combined2>().As<ICombined2>();
                    ioc.Export<Combined3>().As<ICombined3>();
                });
        }

        private void RegisterComplex()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<FirstService>().As<IFirstService>().AndSingleton();
                    ioc.Export<SecondService>().As<ISecondService>().AndSingleton();
                    ioc.Export<ThirdService>().As<IThirdService>().AndSingleton();
                    ioc.Export<SubObjectOne>().As<ISubObjectOne>();
                    ioc.Export<SubObjectTwo>().As<ISubObjectTwo>();
                    ioc.Export<SubObjectThree>().As<ISubObjectThree>();
                    ioc.Export<Complex1>().As<IComplex1>();
                    ioc.Export<Complex2>().As<IComplex2>();
                    ioc.Export<Complex3>().As<IComplex3>();
                });
        }

        private void RegisterDummies()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<DummyOne>().As<IDummyOne>();
                    ioc.Export<DummyTwo>().As<IDummyTwo>();
                    ioc.Export<DummyThree>().As<IDummyThree>();
                    ioc.Export<DummyFour>().As<IDummyFour>();
                    ioc.Export<DummyFive>().As<IDummyFive>();
                    ioc.Export<DummySix>().As<IDummySix>();
                    ioc.Export<DummySeven>().As<IDummySeven>();
                    ioc.Export<DummyEight>().As<IDummyEight>();
                    ioc.Export<DummyNine>().As<IDummyNine>();
                    ioc.Export<DummyTen>().As<IDummyTen>();
                });
        }

        private void RegisterPropertyInjection()
        {
            this.container.Configure(c =>
                {
                    c.Export<ServiceA>().As<IServiceA>().AndSingleton();
                    c.Export<ServiceB>().As<IServiceB>().AndSingleton();
                    c.Export<ServiceC>().As<IServiceC>().AndSingleton();

                    c.Export<SubObjectA>().As<ISubObjectA>().ImportProperty(x => x.ServiceA);
                    c.Export<SubObjectB>().As<ISubObjectB>().ImportProperty(x => x.ServiceB);
                    c.Export<SubObjectC>().As<ISubObjectC>().ImportProperty(x => x.ServiceC);

                    c.Export<ComplexPropertyObject1>().As<IComplexPropertyObject1>().AutoWireProperties();
                    c.Export<ComplexPropertyObject2>().As<IComplexPropertyObject2>().AutoWireProperties();
                    c.Export<ComplexPropertyObject3>().As<IComplexPropertyObject3>().AutoWireProperties();
                });
        }

        public override void Register(InterfaceAndImplemtation[] services)
        {
            var tmpContainer = new DependencyInjectionContainer();
            foreach (var service in services)
            {
                Type implType = service.Implementation;
                Type interfaceType = service.Interface;
                tmpContainer.Configure(c => c.Export(implType).As(interfaceType));
            }
            tmpContainer.Locate(services[0].Interface);
        }
    }

    public class GraceChildContainerAdapter : IChildContainerAdapter
    {
        private IInjectionScope injectionScope;

        public GraceChildContainerAdapter(IInjectionScope injectionScope)
        {
            this.injectionScope = injectionScope;
        }

        public void Dispose()
        {
            this.injectionScope.Dispose();
        }

        public void Prepare()
        {
            this.injectionScope.Configure(c =>
            {
                // SimpleExport was written specifically to register a class very quickly
                // it doesn't support Property injection or method injection
                // but you can do those with an Enrichment delegate
                c.SimpleExport<ScopedCombined1>().As<ICombined1>();
                c.SimpleExport<ScopedCombined2>().As<ICombined2>();
                c.SimpleExport<ScopedCombined3>().As<ICombined3>();
                c.SimpleExport<ScopedTransient>().As<ITransient1>();
            });
        }

        public object Resolve(Type resolveType)
        {
            return this.injectionScope.Locate(resolveType);
        }
    }
}
