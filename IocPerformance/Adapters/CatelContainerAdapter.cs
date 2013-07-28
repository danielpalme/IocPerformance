using System;
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

		public override string Name
		{
			get { return "Catel"; }
		}

		public override string PackageName
		{
			get { return "Catel.Core"; }
		}

		public override bool SupportGeneric
		{
			get { return false; }
		}

		public override bool SupportsMultiple
		{
			get { return false; }
		}

		public override object Resolve(Type type)
		{
			return this.container.ResolveType(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}

		public override void Prepare()
		{
			this.container = new ServiceLocator();

			this.RegisterDummies();
			this.RegisterStandard();
			this.RegisterComplex();
			this.RegisterOpenGeneric();
			this.RegisterMultiple();
		}

		private void RegisterDummies()
		{
			this.container.RegisterType<IDummyOne, DummyOne>(RegistrationType.Transient);
			this.container.RegisterType<IDummyTwo, DummyTwo>(RegistrationType.Transient);
			this.container.RegisterType<IDummyThree, DummyThree>(RegistrationType.Transient);
			this.container.RegisterType<IDummyFour, DummyFour>(RegistrationType.Transient);
			this.container.RegisterType<IDummyFive, DummyFive>(RegistrationType.Transient);
			this.container.RegisterType<IDummySix, DummySix>(RegistrationType.Transient);
			this.container.RegisterType<IDummySeven, DummySeven>(RegistrationType.Transient);
			this.container.RegisterType<IDummyEight, DummyEight>(RegistrationType.Transient);
			this.container.RegisterType<IDummyNine, DummyNine>(RegistrationType.Transient);
			this.container.RegisterType<IDummyTen, DummyTen>(RegistrationType.Transient);
		}

		private void RegisterStandard()
		{
			this.container.RegisterType<ISingleton, Singleton>(RegistrationType.Singleton);

			this.container.RegisterType<ITransient, Transient>(RegistrationType.Transient);

			this.container.RegisterType<ICombined, Combined>(RegistrationType.Transient);
		}

		private void RegisterComplex()
		{
			this.container.RegisterType<IFirstService, FirstService>();
			this.container.RegisterType<ISecondService, SecondService>();
			this.container.RegisterType<IThirdService, ThirdService>();
			this.container.RegisterType<ISubObjectOne, SubObjectOne>(RegistrationType.Transient);
			this.container.RegisterType<ISubObjectTwo, SubObjectTwo>(RegistrationType.Transient);
			this.container.RegisterType<ISubObjectThree, SubObjectThree>(RegistrationType.Transient);
			this.container.RegisterType<IComplex, Complex>(RegistrationType.Transient);
		}

		// TODO: This doesn't seem to work or I've configured it incorrectly. Either way it's turned off
		private void RegisterOpenGeneric()
		{
			this.container.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>), registrationType: RegistrationType.Transient);
			this.container.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>), registrationType: RegistrationType.Transient);
		}

		// TODO: This doesn't seem to work or I've configured it incorrectly. Either way it's turned off
		private void RegisterMultiple()
		{
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>(RegistrationType.Transient);
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>(RegistrationType.Transient);
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>(RegistrationType.Transient);
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>(RegistrationType.Transient);
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>(RegistrationType.Transient);

			this.container.RegisterType<ImportMultiple, ImportMultiple>(RegistrationType.Transient);
		}
	}
}