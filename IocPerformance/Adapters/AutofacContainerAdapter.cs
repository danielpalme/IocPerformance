﻿using System;
using System.Linq;
using System.Xml.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
	public sealed class AutofacContainerAdapter : ContainerAdapterBase
	{
		private IContainer container;

		public override string PackageName
		{
			get { return "Autofac"; }
		}

		public override bool SupportsInterception { get { return true; } }

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

		public override void Prepare()
		{
			var autofacContainerBuilder = new ContainerBuilder();

			autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

			RegisterDummies(autofacContainerBuilder);

			RegisterStandard(autofacContainerBuilder);

			RegisterInterceptor(autofacContainerBuilder);

			RegisterComplexObject(autofacContainerBuilder);

			RegisterOpenGeneric(autofacContainerBuilder);

			RegisterMultiple(autofacContainerBuilder);

			this.container = autofacContainerBuilder.Build();
		}

		private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<Calculator>()
			                       .As<ICalculator>()
			                       .EnableInterfaceInterceptors();
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

		private void RegisterDummies(ContainerBuilder autofacContainerBuilder)
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

		private void RegisterMultiple(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterType<SimpleAdapterOne>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterTwo>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterThree>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterFour>().As<ISimpleAdapter>();
			autofacContainerBuilder.RegisterType<SimpleAdapterFive>().As<ISimpleAdapter>();

			autofacContainerBuilder.RegisterType<ImportMultiple>().As<ImportMultiple>();
		}

		private void RegisterOpenGeneric(ContainerBuilder autofacContainerBuilder)
		{
			autofacContainerBuilder.RegisterGeneric(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));

			autofacContainerBuilder.RegisterGeneric(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>));
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

		public override object Resolve(Type type)
		{
			return this.container.Resolve(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}