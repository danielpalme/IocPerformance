using System;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
	public sealed class AutofacContainerAdapter : ContainerAdapterBase
	{
		private IContainer container;

		public override string Name
		{
			get { return "AutoFac"; }
		}

		public override string PackageName
		{
			get { return "Autofac"; }
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
			var autofacContainerBuilder = new ContainerBuilder();

			autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

			RegisterDummies(autofacContainerBuilder);
			RegisterStandard(autofacContainerBuilder);
			RegisterComplexObject(autofacContainerBuilder);
			RegisterPropertyInjection(autofacContainerBuilder);
			RegisterOpenGeneric(autofacContainerBuilder);
			RegisterMultiple(autofacContainerBuilder);
			RegisterInterceptor(autofacContainerBuilder);

			this.container = autofacContainerBuilder.Build();
		}

		private static void RegisterDummies(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<DummyOne>().As<IDummyOne>();
			autofacContainerBuilder.RegisterType<DummyTwo>().As<IDummyTwo>();
			autofacContainerBuilder.RegisterType<DummyThree>().As<IDummyThree>();
			autofacContainerBuilder.RegisterType<DummyFour>().As<IDummyFour>();
			autofacContainerBuilder.RegisterType<DummyFive>().As<IDummyFive>();
			autofacContainerBuilder.RegisterType<DummySix>().As<IDummySix>();
			autofacContainerBuilder.RegisterType<DummySeven>().As<IDummySeven>();
			autofacContainerBuilder.RegisterType<DummyEight>().As<IDummyEight>();
			autofacContainerBuilder.RegisterType<DummyNine>().As<IDummyNine>();
			autofacContainerBuilder.RegisterType<DummyTen>().As<IDummyTen>();
		}

		private static void RegisterStandard(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<Singleton>()
										  .As<ISingleton>()
										  .SingleInstance();

			autofacContainerBuilder.RegisterType<Transient>()
										  .As<ITransient>();

			autofacContainerBuilder.RegisterType<Combined>()
										  .As<ICombined>();
		}

		private static void RegisterComplexObject(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<FirstService>().As<IFirstService>().SingleInstance();
			autofacContainerBuilder.RegisterType<SecondService>().As<ISecondService>().SingleInstance();
			autofacContainerBuilder.RegisterType<ThirdService>().As<IThirdService>().SingleInstance();
			autofacContainerBuilder.RegisterType<SubObjectOne>().As<ISubObjectOne>();
			autofacContainerBuilder.RegisterType<SubObjectTwo>().As<ISubObjectTwo>();
			autofacContainerBuilder.RegisterType<SubObjectThree>().As<ISubObjectThree>();
			autofacContainerBuilder.RegisterType<Complex>().As<IComplex>();
		}

		private static void RegisterPropertyInjection(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
			autofacContainerBuilder.RegisterType<ServiceB>().As<IServiceB>().SingleInstance();
			autofacContainerBuilder.RegisterType<ServiceC>().As<IServiceC>().SingleInstance();

			autofacContainerBuilder.RegisterType<SubObjectA>().As<ISubObjectA>().PropertiesAutowired();
			autofacContainerBuilder.RegisterType<SubObjectB>().As<ISubObjectB>().PropertiesAutowired();
			autofacContainerBuilder.RegisterType<SubObjectC>().As<ISubObjectC>().PropertiesAutowired();

			autofacContainerBuilder.RegisterType<ComplexPropertyObject>().As<IComplexPropertyObject>().PropertiesAutowired();
		}

		private static void RegisterOpenGeneric(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterGeneric(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
			autofacContainerBuilder.RegisterGeneric(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>));
		}

		private static void RegisterMultiple(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<SimpleAdapterOne>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterTwo>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterThree>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterFour>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterFive>().As<ISimpleAdapter>();

			autofacContainerBuilder.RegisterType<ImportMultiple>().As<ImportMultiple>();
		}

		private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<Calculator>()
										  .As<ICalculator>()
										  .EnableInterfaceInterceptors();
		}
	}
}