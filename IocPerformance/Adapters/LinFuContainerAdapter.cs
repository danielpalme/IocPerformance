using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using LinFu.IoC;

namespace IocPerformance.Adapters
{
	public sealed class LinFuContainerAdapter : ContainerAdapterBase
	{
		private LinFu.IoC.ServiceContainer container;

		public override string PackageName
		{
			get { return "LinFu.Core"; }
		}

		/// <summary>
		/// doesn't seem to work
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
			this.container = new LinFu.IoC.ServiceContainer();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			RegisterMultiple();

			RegisterInterceptor();
		}

		//
		/// <summary>
		/// This doesn't seem to work
		/// </summary>
		private void RegisterMultiple()
		{
			container.Inject<ISimpleAdapter>().Using<SimpleAdapterOne>().OncePerRequest();
			container.Inject<ISimpleAdapter>().Using<SimpleAdapterTwo>().OncePerRequest();
			container.Inject<ISimpleAdapter>().Using<SimpleAdapterThree>().OncePerRequest();
			container.Inject<ISimpleAdapter>().Using<SimpleAdapterFour>().OncePerRequest();
			container.Inject<ISimpleAdapter>().Using<SimpleAdapterFive>().OncePerRequest();

			container.Inject<ImportMultiple>().Using<ImportMultiple>().OncePerRequest();
		}

		private void RegisterComplex()
		{
			container.Inject<IFirstService>().Using<FirstService>().AsSingleton();
			container.Inject<ISecondService>().Using<SecondService>().AsSingleton();
			container.Inject<IThirdService>().Using<ThirdService>().AsSingleton();
			container.Inject<ISubObjectOne>().Using<SubObjectOne>().OncePerRequest();
			container.Inject<ISubObjectTwo>().Using<SubObjectTwo>().OncePerRequest();
			container.Inject<ISubObjectThree>().Using<SubObjectThree>().OncePerRequest();

			container.Inject<IComplex>().Using<Complex>().OncePerRequest();
		}

		private void RegisterDummies()
		{
			container.Inject<IDummyOne>().Using<DummyOne>().OncePerRequest();
			container.Inject<IDummyTwo>().Using<DummyTwo>().OncePerRequest();
			container.Inject<IDummyThree>().Using<DummyThree>().OncePerRequest();
			container.Inject<IDummyFour>().Using<DummyFour>().OncePerRequest();
			container.Inject<IDummyFive>().Using<DummyFive>().OncePerRequest();
			container.Inject<IDummySix>().Using<DummySix>().OncePerRequest();
			container.Inject<IDummySeven>().Using<DummySeven>().OncePerRequest();
			container.Inject<IDummyEight>().Using<DummyEight>().OncePerRequest();
			container.Inject<IDummyNine>().Using<DummyNine>().OncePerRequest();
			container.Inject<IDummyTen>().Using<DummyTen>().OncePerRequest();
		}

		private void RegisterInterceptor()
		{
			this.container.Inject<ICalculator>().Using<Calculator>().OncePerRequest();
		}

		private void RegisterStandard()
		{
			this.container.Inject<ISingleton>().Using<Singleton>().AsSingleton();
			this.container.Inject<ITransient>().Using<Transient>().OncePerRequest();
			this.container.Inject<ICombined>().Using<Combined>().OncePerRequest();
		}

		public override object Resolve(Type type)
		{
			return this.container.GetService(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}