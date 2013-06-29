using System;
using IocPerformance.Classes;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace IocPerformance.Adapters
{
	public sealed class NinjectContainerAdapter : ContainerAdapterBase
	{
		private StandardKernel container;

		public override string PackageName
		{
			get { return "Ninject"; }
		}

		public override bool SupportsInterception { get { return true; } }

		public override bool SupportGeneric
		{
			get
			{
				return true;
			}
		}

		public override bool SupportsConditional
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
			this.container = new StandardKernel();
			this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
			this.container.Bind<ITransient>().To<Transient>().InTransientScope();
			this.container.Bind<ICombined>().To<Combined>().InTransientScope();
			this.container.Bind<ICalculator>().To<Calculator>().InTransientScope()
				 .Intercept().With(new NinjectInterceptionLogger());

			// complex export
			container.Bind<IFirstService>().To<FirstService>().InSingletonScope();
			container.Bind<ISecondService>().To<SecondService>().InSingletonScope();
			container.Bind<IThirdService>().To<ThirdService>().InSingletonScope();
			container.Bind<ISubObjectOne>().To<SubObjectOne>().InTransientScope();
			container.Bind<ISubObjectTwo>().To<SubObjectTwo>().InTransientScope();
			container.Bind<ISubObjectThree>().To<SubObjectThree>().InTransientScope();
			container.Bind<IComplex>().To<Complex>().InTransientScope();
			
			// conditional export
			container.Bind<ImportConditionObject>().To<ImportConditionObject>().InTransientScope();
			container.Bind<ImportConditionObject2>().To<ImportConditionObject2>().InTransientScope();
			container.Bind<IExportConditionInterface>()
			         .To<ExportConditionalObject>()
			         .WhenInjectedInto<ImportConditionObject>()
			         .InTransientScope();
			container.Bind<IExportConditionInterface>()
			         .To<ExportConditionalObject2>()
			         .WhenInjectedInto<ImportConditionObject2>()
			         .InTransientScope();

			// generic export
			container.Bind(typeof(IGenericInterface<>)).To(typeof(GenericExport<>)).InTransientScope();
			container.Bind(typeof(ImportGeneric<>)).To(typeof(ImportGeneric<>)).InTransientScope();

			// multiple exports
			container.Bind<ISimpleAdapter>().To<SimpleAdapterOne>().InTransientScope();
			container.Bind<ISimpleAdapter>().To<SimpleAdapterTwo>().InTransientScope();
			container.Bind<ISimpleAdapter>().To<SimpleAdapterThree>().InTransientScope();
			container.Bind<ISimpleAdapter>().To<SimpleAdapterFour>().InTransientScope();
			container.Bind<ISimpleAdapter>().To<SimpleAdapterFive>().InTransientScope();
			container.Bind<ImportMultiple>().To<ImportMultiple>().InTransientScope();
		}

		public override object Resolve(Type type)
		{
			return this.container.Get(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}