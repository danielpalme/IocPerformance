using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
	public sealed class WindsorContainerAdapter : ContainerAdapterBase
	{
		private WindsorContainer container;

		public override string Name
		{
			get { return "Windsor"; }
		}

		public override string PackageName
		{
			get { return "Castle.Windsor"; }
		}

		public override bool SupportsPropertyInjection
		{
			get { return true; }
		}

		public override bool SupportGeneric
		{
			get { return true; }
		}

		public override bool SupportsMultiple
		{
			get { return true; }
		}

		public override bool SupportsInterception
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
			this.container = new WindsorContainer();

			this.RegisterDummies();
			this.RegisterStandard();
			this.RegisterComplexType();
			this.RegisterPropertyInjection();
			this.RegisterOpenGeneric();
			this.RegisterMultiple();
			this.RegisterInterceptor();
		}

		private void RegisterDummies()
		{
			this.container.Register(Component.For<IDummyOne>().ImplementedBy<DummyOne>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyTwo>().ImplementedBy<DummyTwo>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyThree>().ImplementedBy<DummyThree>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyFour>().ImplementedBy<DummyFour>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyFive>().ImplementedBy<DummyFive>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummySix>().ImplementedBy<DummySix>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummySeven>().ImplementedBy<DummySeven>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyEight>().ImplementedBy<DummyEight>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyNine>().ImplementedBy<DummyNine>().LifeStyle.Transient);
			this.container.Register(Component.For<IDummyTen>().ImplementedBy<DummyTen>().LifeStyle.Transient);
		}

		private void RegisterStandard()
		{
			this.container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>());
			this.container.Register(Component.For<ITransient>().ImplementedBy<Transient>().LifeStyle.Transient);
			this.container.Register(Component.For<ICombined>().ImplementedBy<Combined>().LifeStyle.Transient);
		}

		private void RegisterComplexType()
		{
			this.container.Register(Component.For<IFirstService>().ImplementedBy<FirstService>());
			this.container.Register(Component.For<ISecondService>().ImplementedBy<SecondService>());
			this.container.Register(Component.For<IThirdService>().ImplementedBy<ThirdService>());
			this.container.Register(Component.For<ISubObjectOne>().ImplementedBy<SubObjectOne>().LifeStyle.Transient);
			this.container.Register(Component.For<ISubObjectTwo>().ImplementedBy<SubObjectTwo>().LifeStyle.Transient);
			this.container.Register(Component.For<ISubObjectThree>().ImplementedBy<SubObjectThree>().LifeStyle.Transient);
			this.container.Register(Component.For<IComplex>().ImplementedBy<Complex>().LifeStyle.Transient);
		}

		private void RegisterPropertyInjection()
		{
			this.container.Register(Component.For<IServiceA>().ImplementedBy<ServiceA>());
			this.container.Register(Component.For<IServiceB>().ImplementedBy<ServiceB>());
			this.container.Register(Component.For<IServiceC>().ImplementedBy<ServiceC>());

			this.container.Register(Component.For<ISubObjectA>().ImplementedBy<SubObjectA>().LifeStyle.Transient);
			this.container.Register(Component.For<ISubObjectB>().ImplementedBy<SubObjectB>().LifeStyle.Transient);
			this.container.Register(Component.For<ISubObjectC>().ImplementedBy<SubObjectC>().LifeStyle.Transient);

			this.container.Register(Component.For<IComplexPropertyObject>().ImplementedBy<ComplexPropertyObject>().LifeStyle.Transient);
		}

		private void RegisterOpenGeneric()
		{
			this.container.Register(Component.For(typeof(IGenericInterface<>)).ImplementedBy(typeof(GenericExport<>)));

			this.container.Register(Component.For(typeof(ImportGeneric<>)).ImplementedBy(typeof(ImportGeneric<>)));
		}

		private void RegisterMultiple()
		{
			this.container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));

			this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterOne>().LifeStyle.Transient);
			this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterTwo>().LifeStyle.Transient);
			this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterThree>().LifeStyle.Transient);
			this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterFour>().LifeStyle.Transient);
			this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterFive>().LifeStyle.Transient);

			this.container.Register(Component.For<ImportMultiple>().LifeStyle.Transient);
		}

		private void RegisterInterceptor()
		{
			this.container.Register(Component.For<WindsorInterceptionLogger>());
			this.container.Register(
				 Component.For<ICalculator>().ImplementedBy<Calculator>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
		}
	}
}