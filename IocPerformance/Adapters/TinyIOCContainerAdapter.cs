using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Standard;
using TinyIoC;

namespace IocPerformance.Adapters
{
	public sealed class TinyIOCContainerAdapter : ContainerAdapterBase
	{
		private TinyIoCContainer container;

		public override string PackageName
		{
			get { return "TinyIoC"; }
		}

		public override bool SupportGeneric
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// I'm marking this as false because you have to register once using RegisterMultiple.
		/// Other containers allow you to register multiple interfaces separately and then resolves all known
		/// </summary>
		public override bool SupportsMultiple
		{
			get
			{
				return false;
			}
		}

		public override void Prepare()
		{
			this.container = new TinyIoC.TinyIoCContainer();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			RegisterOpenGeneric();

		}

		private void RegisterOpenGeneric()
		{
			container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
			container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
		}

		private void RegisterComplex()
		{
			container.Register<IFirstService, FirstService>().AsSingleton();
			container.Register<ISecondService, SecondService>().AsSingleton();
			container.Register<IThirdService, ThirdService>().AsSingleton();
			container.Register<ISubObjectOne, SubObjectOne>().AsMultiInstance();
			container.Register<ISubObjectTwo, SubObjectTwo>().AsMultiInstance();
			container.Register<ISubObjectThree, SubObjectThree>().AsMultiInstance();
			container.Register<IComplex, Complex>().AsMultiInstance();
		}

		private void RegisterDummies()
		{
			container.Register<IDummyOne, DummyOne>().AsMultiInstance();
			container.Register<IDummyTwo, DummyTwo>().AsMultiInstance();
			container.Register<IDummyThree, DummyThree>().AsMultiInstance();
			container.Register<IDummyFour, DummyFour>().AsMultiInstance();
			container.Register<IDummyFive, DummyFive>().AsMultiInstance();
			container.Register<IDummySix, DummySix>().AsMultiInstance();
			container.Register<IDummySeven, DummySeven>().AsMultiInstance();
			container.Register<IDummyEight, DummyEight>().AsMultiInstance();
			container.Register<IDummyNine, DummyNine>().AsMultiInstance();
			container.Register<IDummyTen, DummyTen>().AsMultiInstance();
		}

		private void RegisterStandard()
		{
			this.container.Register<ISingleton, Singleton>().AsSingleton();
			this.container.Register<ITransient, Transient>().AsMultiInstance();
			this.container.Register<ICombined, Combined>().AsMultiInstance();
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