using System;
using Grace.DependencyInjection;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
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
            get { return "http://grace.codeplex.com"; }
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
		      return new GraceChildContainerAdapter(container.CreateChildScope());
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
                ioc => ioc.Export<Calculator>()
                    .As<ICalculator>()
                    .EnrichWith((scope, context, o) => pg.CreateInterfaceProxyWithTarget(o as ICalculator, new StructureMapInterceptionLogger())));
        }

        private void RegisterConditional()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<ImportConditionObject>();
                    ioc.Export<ImportConditionObject2>();

                    ioc.Export<ExportConditionalObject>()
                        .As<IExportConditionInterface>()
                        .WhenInjectedInto<ImportConditionObject>();

                    ioc.Export<ExportConditionalObject2>()
                        .As<IExportConditionInterface>()
                        .WhenInjectedInto<ImportConditionObject2>();
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
                    ioc.Export<ImportMultiple>();
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
                    ioc.Export<Singleton>().As<ISingleton>().AndSingleton();
                    ioc.Export<Transient>().As<ITransient>();
                    ioc.Export<Combined>().As<ICombined>();
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
                    ioc.Export<Complex>().As<IComplex>();
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

                    c.Export<ComplexPropertyObject>().As<IComplexPropertyObject>().AutoWireProperties();
                });
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
			 injectionScope.Dispose();
		 }

		 public void Prepare()
		 {
			 injectionScope.Configure(c =>
			 {
				 // SimpleExport was written specifically to register a class very quickly
				 // it doesn't support Property injection or method injection
				 // but you can do those with an Enrichment delegate
				 c.SimpleExport<ScopedCombined>().As<ICombined>();
				 c.SimpleExport<ScopedTransient>().As<ITransient>();
			 });
		 }

		 public object Resolve(Type resolveType)
		 {
			 return injectionScope.Locate(resolveType);
		 }
	 }
}
