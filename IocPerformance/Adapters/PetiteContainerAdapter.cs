using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using Petite;

namespace IocPerformance.Adapters
{
	public sealed class PetiteContainerAdapter : ContainerAdapterBase
	{
		private Container container;

		public override string PackageName
		{
			get { return "Petite.Container"; }
		}

		public override void Prepare()
		{
			this.container = new Petite.Container();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();
		}

		private void RegisterComplex()
		{
			container.RegisterSingleton<IFirstService>(c => new FirstService());
			container.RegisterSingleton<ISecondService>(c => new SecondService());
			container.RegisterSingleton<IThirdService>(c => new ThirdService());
			container.Register<ISubObjectOne>(c => new SubObjectOne(c.Resolve<IFirstService>()));
			container.Register<ISubObjectTwo>(c => new SubObjectTwo(c.Resolve<ISecondService>()));
			container.Register<ISubObjectThree>(c => new SubObjectThree(c.Resolve<IThirdService>()));
			container.Register<IComplex>(c => new Complex(c.Resolve<IFirstService>(),
																		 c.Resolve<ISecondService>(),
																		 c.Resolve<IThirdService>(),
																		 c.Resolve<ISubObjectOne>(),
																		 c.Resolve<ISubObjectTwo>(),
																		 c.Resolve<ISubObjectThree>()));
		}

		private void RegisterDummies()
		{
			container.Register<IDummyOne>(c => new DummyOne());
			container.Register<IDummyTwo>(c => new DummyTwo());
			container.Register<IDummyThree>(c => new DummyThree());
			container.Register<IDummyFour>(c => new DummyFour());
			container.Register<IDummyFive>(c => new DummyFive());
			container.Register<IDummySix>(c => new DummySix());
			container.Register<IDummySeven>(c => new DummySeven());
			container.Register<IDummyEight>(c => new DummyEight());
			container.Register<IDummyNine>(c => new DummyNine());
			container.Register<IDummyTen>(c => new DummyTen());
		}

		private void RegisterStandard()
		{
			this.container.RegisterSingleton<ISingleton>(c => new Singleton());
			this.container.Register<ITransient>(c => new Transient());
			this.container.Register<ICombined>(c => new Combined(
																	 c.Resolve<ISingleton>(),
																	 c.Resolve<ITransient>()));
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