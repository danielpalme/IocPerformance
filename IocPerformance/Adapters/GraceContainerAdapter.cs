using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Impl;
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

		public override string Version
		{
			get
			{
				return "1.0";
			}
		}

		public override bool SupportsPropertyInjection
		{
			get { return true; }
		}

		public override bool SupportGeneric
		{
			get
			{
				return true;
			}
		}

		public override bool SupportsMultiple
		{
			get { return true; }
		}

		public override bool SupportsConditional
		{
			get
			{
				return true;
			}
		}

		public override bool SupportsInterception
		{
			get
			{
				return true;
			}
		}

		public override void Prepare()
		{
			container = new DependencyInjectionContainer();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			RegisterPropertyInjection();

			RegisterOpenGeneric();

			RegisterMultiple();

			RegisterConditional();

			RegisterInterceptor();
		}

		private void RegisterInterceptor()
		{
			var pg = new Castle.DynamicProxy.ProxyGenerator();

			container.Configure(c => c.Export<Calculator>().As<ICalculator>().EnrichWith((scope,context,o) => pg.CreateInterfaceProxyWithTarget(o as ICalculator, new StructureMapInterceptionLogger())));
		}

		private void RegisterConditional()
		{
			container.Configure(
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
			container.Configure(
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
			container.Configure(c =>
				   {
						c.Export(typeof(ImportGeneric<>));
						c.Export(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
				   });
		}

		private void RegisterStandard()
		{
			container.Configure(
				ioc =>
				{
					ioc.Export<Singleton>().As<ISingleton>().AndSingleton();
					ioc.Export<Transient>().As<ITransient>();
					ioc.Export<Combined>().As<ICombined>();
				});
		}

		private void RegisterComplex()
		{
			container.Configure(
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
			container.Configure(
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

		public void RegisterPropertyInjection()
		{
			container.Configure(c =>
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

		public override object Resolve(Type type)
		{
			return container.Locate(type);
		}

		public override void Dispose()
		{
			container.Dispose();
			container = null;
		}
	}
}
