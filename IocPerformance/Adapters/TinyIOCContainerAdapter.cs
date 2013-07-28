using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Properties;
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
			get { return true; }
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
			this.container = new TinyIoC.TinyIoCContainer();

			this.RegisterDummies();
			this.RegisterStandard();
			this.RegisterComplex();
			this.RegisterPropertyInjection();
			this.RegisterOpenGeneric();
		}

		private void RegisterDummies()
		{
			this.container.Register<IDummyOne, DummyOne>().AsMultiInstance();
			this.container.Register<IDummyTwo, DummyTwo>().AsMultiInstance();
			this.container.Register<IDummyThree, DummyThree>().AsMultiInstance();
			this.container.Register<IDummyFour, DummyFour>().AsMultiInstance();
			this.container.Register<IDummyFive, DummyFive>().AsMultiInstance();
			this.container.Register<IDummySix, DummySix>().AsMultiInstance();
			this.container.Register<IDummySeven, DummySeven>().AsMultiInstance();
			this.container.Register<IDummyEight, DummyEight>().AsMultiInstance();
			this.container.Register<IDummyNine, DummyNine>().AsMultiInstance();
			this.container.Register<IDummyTen, DummyTen>().AsMultiInstance();
		}

		private void RegisterStandard()
		{
			this.container.Register<ISingleton, Singleton>().AsSingleton();
			this.container.Register<ITransient, Transient>().AsMultiInstance();
			this.container.Register<ICombined, Combined>().AsMultiInstance();
		}

		private void RegisterComplex()
		{
			this.container.Register<IFirstService, FirstService>().AsSingleton();
			this.container.Register<ISecondService, SecondService>().AsSingleton();
			this.container.Register<IThirdService, ThirdService>().AsSingleton();
			this.container.Register<ISubObjectOne, SubObjectOne>().AsMultiInstance();
			this.container.Register<ISubObjectTwo, SubObjectTwo>().AsMultiInstance();
			this.container.Register<ISubObjectThree, SubObjectThree>().AsMultiInstance();
			this.container.Register<IComplex, Complex>().AsMultiInstance();
		}

		private void RegisterPropertyInjection()
		{
			this.container.Register<IServiceA, ServiceA>().AsSingleton();
			this.container.Register<IServiceB, ServiceB>().AsSingleton();
			this.container.Register<IServiceC, ServiceC>().AsSingleton();
			this.container.Register<ISubObjectA>(
				(ioc, names) => new SubObjectA { ServiceA = ioc.Resolve<IServiceA>() });
			this.container.Register<ISubObjectB>(
				(ioc, names) => new SubObjectB { ServiceB = ioc.Resolve<IServiceB>() });
			this.container.Register<ISubObjectC>(
				(ioc, names) => new SubObjectC { ServiceC = ioc.Resolve<IServiceC>() });

			this.container.Register<IComplexPropertyObject>(
				(ioc, names) => new ComplexPropertyObject
					                {
						                ServiceA = ioc.Resolve<IServiceA>(),
						                ServiceB = ioc.Resolve<IServiceB>(),
						                ServiceC = ioc.Resolve<IServiceC>(),
						                SubObjectA = ioc.Resolve<ISubObjectA>(),
						                SubObjectB = ioc.Resolve<ISubObjectB>(),
						                SubObjectC = ioc.Resolve<ISubObjectC>()
					                });
		}

		private void RegisterOpenGeneric()
		{
			this.container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
			this.container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
		}
	}
}