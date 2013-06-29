using System;
using IocPerformance.Classes;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using StyleMVVM.DependencyInjection;
using StyleMVVM.DependencyInjection.Impl;

namespace IocPerformance.Adapters
{
	public class StyleMVVMContainerAdapter : ContainerAdapterBase
	{
		private IDependencyInjectionContainer container;

		public override string PackageName
		{
			get { return "StyleMVVM"; }
		}

		public override bool SupportsConditional
		{
			get
			{
				return true;
			}
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
			get
			{
				return true;
			}
		}

		public override void Prepare()
		{
			container = new DependencyInjectionContainer();

			// Register all needed types out of StyleMVVM.DotNet
			container.RegisterAssembly(typeof(DependencyInjectionContainer).Assembly);

			// Remove extra XAML based exports that aren't need (MVVM classes and what not)
			container.RemoveXAMLExports();

			// Register local exports
			container.Register<Singleton>().As<ISingleton>().AndSharedPermenantly();
			container.Register<Transient>().As<ITransient>();
			container.Register<Combined>().As<ICombined>().ImportConstructor(() => new Combined(null, null));

			// Complex
			container.Register<FirstService>().As<IFirstService>().AndSharedPermenantly();
			container.Register<SecondService>().As<ISecondService>().AndSharedPermenantly();
			container.Register<ThirdService>().As<IThirdService>().AndSharedPermenantly();
			container.Register<SubObjectOne>().As<ISubObjectOne>().ImportDefaultConstructor();
			container.Register<SubObjectTwo>().As<ISubObjectTwo>().ImportDefaultConstructor();
			container.Register<SubObjectThree>().As<ISubObjectThree>().ImportDefaultConstructor();
			container.Register<Complex>().As<IComplex>().ImportDefaultConstructor();

			// Conditional registration
			container.Register<ImportConditionObject>()
			         .As<ImportConditionObject>().ImportDefaultConstructor();
			container.Register<ImportConditionObject2>()
			         .As<ImportConditionObject2>().ImportDefaultConstructor();

			container.Register<ExportConditionalObject>()
			         .As<IExportConditionInterface>()
			         .WhenInjectedInto<ImportConditionObject>();
			container.Register<ExportConditionalObject2>()
			         .As<IExportConditionInterface>()
			         .WhenInjectedInto<ImportConditionObject2>();

			// Generic exports
			container.Register(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>)).ImportDefaultConstructor();
			container.Register(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));

			// Export all ISimpleAdapter classes and ImportMultiple
			container.RegisterAssembly(GetType().Assembly).ExportInterface<ISimpleAdapter>();
			container.Register<ImportMultiple>().As<ImportMultiple>().ImportDefaultConstructor();

			container.Start();
		}

		public override object Resolve(Type type)
		{
			return container.LocateByType(type);
		}

		public override void Dispose()
		{
			// Shutdown the container
			container.Shutdown();

			// Release container from memory
			container = null;
		}
	}
}
