using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
	public sealed class WindsorContainerAdapter : ContainerAdapterBase
	{
		private WindsorContainer container;

		public override string PackageName
		{
			get { return "Castle.Windsor"; }
		}

		public override bool SupportsInterception { get { return true; } }

		public override bool SupportGeneric
		{
			get
			{
				return true;
			}
		}

		public override void Prepare()
		{
			this.container = new WindsorContainer();

			RegisterDummies();

			RegisterStandard();
			
			RegisterComplexType();

			RegisterOpenGeneric(); 
			
			RegisterInterceptor();
		}

		private void RegisterDummies()
		{
			container.Register(Component.For<IDummyOne>().ImplementedBy<DummyOne>().LifeStyle.Transient);
			container.Register(Component.For<IDummyTwo>().ImplementedBy<DummyTwo>().LifeStyle.Transient);
			container.Register(Component.For<IDummyThree>().ImplementedBy<DummyThree>().LifeStyle.Transient);
			container.Register(Component.For<IDummyFour>().ImplementedBy<DummyFour>().LifeStyle.Transient);
			container.Register(Component.For<IDummyFive>().ImplementedBy<DummyFive>().LifeStyle.Transient);
			container.Register(Component.For<IDummySix>().ImplementedBy<DummySix>().LifeStyle.Transient);
			container.Register(Component.For<IDummySeven>().ImplementedBy<DummySeven>().LifeStyle.Transient);
			container.Register(Component.For<IDummyEight>().ImplementedBy<DummyEight>().LifeStyle.Transient);
			container.Register(Component.For<IDummyNine>().ImplementedBy<DummyNine>().LifeStyle.Transient);
			container.Register(Component.For<IDummyTen>().ImplementedBy<DummyTen>().LifeStyle.Transient);
		}

		private void RegisterInterceptor()
		{
			this.container.Register(Component.For<WindsorInterceptionLogger>());
			this.container.Register(
				Component.For<ICalculator>().ImplementedBy<Calculator>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
		}

		private void RegisterStandard()
		{
			this.container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>());
			this.container.Register(Component.For<ITransient>().ImplementedBy<Transient>().LifeStyle.Transient);
			this.container.Register(Component.For<ICombined>().ImplementedBy<Combined>().LifeStyle.Transient);
		}

		private void RegisterOpenGeneric()
		{
			container.Register(Component.For(typeof(IGenericInterface<>)).ImplementedBy(typeof(GenericExport<>)));

			container.Register(Component.For(typeof(ImportGeneric<>)).ImplementedBy(typeof(ImportGeneric<>)));
		}

		private void RegisterComplexType()
		{
			container.Register(Component.For<IFirstService>().ImplementedBy<FirstService>());
			container.Register(Component.For<ISecondService>().ImplementedBy<SecondService>());
			container.Register(Component.For<IThirdService>().ImplementedBy<ThirdService>());
			container.Register(Component.For<ISubObjectOne>().ImplementedBy<SubObjectOne>().LifeStyle.Transient);
			container.Register(Component.For<ISubObjectTwo>().ImplementedBy<SubObjectTwo>().LifeStyle.Transient);
			container.Register(Component.For<ISubObjectThree>().ImplementedBy<SubObjectThree>().LifeStyle.Transient);
			container.Register(Component.For<IComplex>().ImplementedBy<Complex>().LifeStyle.Transient);
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