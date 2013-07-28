using System;
using Hiro;
using Hiro.Containers;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class HiroContainerAdapter : ContainerAdapterBase
	{
		private IMicroContainer container;

		public override string PackageName
		{
			get { return "Hiro"; }
		}

		public override object Resolve(Type type)
		{
			return this.container.GetInstance(type, null);
		}

		public override bool SupportsPropertyInjection
		{
			get { return true; }
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}

		public override void Prepare()
		{
			var map = new DependencyMap();

			RegisterDummies(map);
			RegisterStandard(map);
			RegisterComplex(map);
			RegisterPropertyInjection(map);

			this.container = map.CreateContainer();
		}

		private static void RegisterDummies(DependencyMap map)
		{
			map.AddService<IDummyOne, DummyOne>();
			map.AddService<IDummyTwo, DummyTwo>();
			map.AddService<IDummyThree, DummyThree>();
			map.AddService<IDummyFour, DummyFour>();
			map.AddService<IDummyFive, DummyFive>();
			map.AddService<IDummySix, DummySix>();
			map.AddService<IDummySeven, DummySeven>();
			map.AddService<IDummyEight, DummyEight>();
			map.AddService<IDummyNine, DummyNine>();
			map.AddService<IDummyTen, DummyTen>();
		}

		private static void RegisterStandard(DependencyMap map)
		{
			map.AddSingletonService<ISingleton, Singleton>();
			map.AddService<ITransient, Transient>();
			map.AddService<ICombined, Combined>();
		}

		private static void RegisterComplex(DependencyMap map)
		{
			map.AddSingletonService<IFirstService, FirstService>();
			map.AddSingletonService<ISecondService, SecondService>();
			map.AddSingletonService<IThirdService, ThirdService>();
			map.AddService<ISubObjectOne, SubObjectOne>();
			map.AddService<ISubObjectTwo, SubObjectTwo>();
			map.AddService<ISubObjectThree, SubObjectThree>();
			map.AddService<IComplex, Complex>();
		}

		private static void RegisterPropertyInjection(DependencyMap map)
		{
			map.AddSingletonService<IServiceA,ServiceA>();
			map.AddSingletonService<IServiceB, ServiceB>();
			map.AddSingletonService<IServiceC, ServiceC>();
			map.AddService(new Func<IMicroContainer,ISubObjectA>(
				microContainer => new SubObjectA { ServiceA = microContainer.GetInstance<IServiceA>() }));
			map.AddService(new Func<IMicroContainer, ISubObjectB>(
				microContainer => new SubObjectB { ServiceB = microContainer.GetInstance<IServiceB>() }));
			map.AddService(new Func<IMicroContainer, ISubObjectC>(
				microContainer => new SubObjectC { ServiceC = microContainer.GetInstance<IServiceC>() }));
			map.AddService(new Func<IMicroContainer,IComplexPropertyObject>(
				microContainer => new ComplexPropertyObject
					                  {
												ServiceA = microContainer.GetInstance<IServiceA>(),
												ServiceB = microContainer.GetInstance<IServiceB>(),
												ServiceC = microContainer.GetInstance<IServiceC>(),
												SubObjectA = microContainer.GetInstance<ISubObjectA>(),
												SubObjectB = microContainer.GetInstance<ISubObjectB>(),
												SubObjectC = microContainer.GetInstance<ISubObjectC>()
					                  }));
		}
	}
}