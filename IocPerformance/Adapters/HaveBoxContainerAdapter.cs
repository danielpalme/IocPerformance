using System;
using HaveBox;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class HaveBoxContainerAdapter : ContainerAdapterBase
	{
		private Container container;

		public override string PackageName
		{
			get { return "HaveBox"; }
		}

		public override void Prepare()
		{
			this.container = new Container();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();
		}

		private void RegisterComplex()
		{
			container.Configure(config => config.For<IFirstService>().Use<FirstService>().AsSingleton());
			container.Configure(config => config.For<ISecondService>().Use<SecondService>().AsSingleton());
			container.Configure(config => config.For<IThirdService>().Use<ThirdService>().AsSingleton());
			container.Configure(config => config.For<ISubObjectOne>().Use<SubObjectOne>());
			container.Configure(config => config.For<ISubObjectTwo>().Use<SubObjectTwo>());
			container.Configure(config => config.For<ISubObjectThree>().Use<SubObjectThree>());
			container.Configure(config => config.For<IComplex>().Use<Complex>());
		}

		private void RegisterDummies()
		{
			container.Configure(config => config.For<IDummyOne>().Use<DummyOne>());
			container.Configure(config => config.For<IDummyTwo>().Use<DummyTwo>());
			container.Configure(config => config.For<IDummyThree>().Use<DummyThree>());
			container.Configure(config => config.For<IDummyFour>().Use<DummyFour>());
			container.Configure(config => config.For<IDummyFive>().Use<DummyFive>());
			container.Configure(config => config.For<IDummySix>().Use<DummySix>());
			container.Configure(config => config.For<IDummySeven>().Use<DummySeven>());
			container.Configure(config => config.For<IDummyEight>().Use<DummyEight>());
			container.Configure(config => config.For<IDummyNine>().Use<DummyNine>());
			container.Configure(config => config.For<IDummyTen>().Use<DummyTen>());
		}

		private void RegisterStandard()
		{
			this.container.Configure(config => config.For<ISingleton>().Use<Singleton>().AsSingleton());
			this.container.Configure(config => config.For<ITransient>().Use<Transient>());
			this.container.Configure(config => config.For<ICombined>().Use<Combined>());
		}

		public override object Resolve(Type type)
		{
			return container.GetInstance(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}