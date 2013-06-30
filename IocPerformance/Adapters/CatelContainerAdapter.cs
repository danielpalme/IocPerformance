using System;
using System.Linq;
using System.Xml.Linq;
using Catel.IoC;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public class CatelContainerAdapter : ContainerAdapterBase
	{
		private IServiceLocator container;

		public override string PackageName
		{
			get { return "Catel.Core"; }
		}

		public override bool SupportsMultiple
		{
			get
			{
				return false;
			}
		}

		public override bool SupportGeneric
		{
			get
			{
				return false;
			}
		}

		public override void Prepare()
		{
			var serviceLocator = new ServiceLocator();

			RegisterDummies(serviceLocator);

			RegisterStandard(serviceLocator);

			RegisterComplex(serviceLocator);

			RegisterOpenGeneric(serviceLocator);

			RegisterMultiple(serviceLocator);

			container = serviceLocator;
		}

		/// <summary>
		/// This doesn't seem to work or I've configured it incorrectly. Either way it's turned off
		/// </summary>
		/// <param name="serviceLocator"></param>
		private void RegisterMultiple(ServiceLocator serviceLocator)
		{
			serviceLocator.RegisterType<ISimpleAdapter, SimpleAdapterOne>(RegistrationType.Transient);
			serviceLocator.RegisterType<ISimpleAdapter, SimpleAdapterTwo>(RegistrationType.Transient);
			serviceLocator.RegisterType<ISimpleAdapter, SimpleAdapterThree>(RegistrationType.Transient);
			serviceLocator.RegisterType<ISimpleAdapter, SimpleAdapterFour>(RegistrationType.Transient);
			serviceLocator.RegisterType<ISimpleAdapter, SimpleAdapterFive>(RegistrationType.Transient);

			serviceLocator.RegisterType<ImportMultiple, ImportMultiple>(RegistrationType.Transient);
		}

		/// <summary>
		/// This doesn't seem to work or I've configured it incorrectly. Either way it's turned off
		/// </summary>
		private void RegisterOpenGeneric(ServiceLocator serviceLocator)
		{
			serviceLocator.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>), registrationType: RegistrationType.Transient);
			serviceLocator.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>), registrationType: RegistrationType.Transient);
		}

		private void RegisterComplex(ServiceLocator serviceLocator)
		{
			serviceLocator.RegisterType<IFirstService, FirstService>();
			serviceLocator.RegisterType<ISecondService, SecondService>();
			serviceLocator.RegisterType<IThirdService, ThirdService>();
			serviceLocator.RegisterType<ISubObjectOne, SubObjectOne>(RegistrationType.Transient);
			serviceLocator.RegisterType<ISubObjectTwo, SubObjectTwo>(RegistrationType.Transient);
			serviceLocator.RegisterType<ISubObjectThree, SubObjectThree>(RegistrationType.Transient);
			serviceLocator.RegisterType<IComplex, Complex>(RegistrationType.Transient);
		}

		private void RegisterDummies(ServiceLocator serviceLocator)
		{
			serviceLocator.RegisterType<IDummyOne, DummyOne>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyTwo, DummyTwo>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyThree, DummyThree>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyFour, DummyFour>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyFive, DummyFive>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummySix, DummySix>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummySeven, DummySeven>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyEight, DummyEight>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyNine, DummyNine>(RegistrationType.Transient);
			serviceLocator.RegisterType<IDummyTen, DummyTen>(RegistrationType.Transient);
		}

		private static void RegisterStandard(ServiceLocator serviceLocator)
		{
			serviceLocator.RegisterType<ISingleton, Singleton>(RegistrationType.Singleton);

			serviceLocator.RegisterType<ITransient, Transient>(RegistrationType.Transient);

			serviceLocator.RegisterType<ICombined, Combined>(RegistrationType.Transient);
		}

		public override object Resolve(Type type)
		{
			return this.container.ResolveType(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			container = null;
		}
	}
}