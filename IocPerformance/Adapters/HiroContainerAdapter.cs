using System;
using Hiro;
using Hiro.Containers;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
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

		public override void Prepare()
		{
			var map = new DependencyMap();

			RegisterDummies(map);

			RegisterStandard(map);

			RegisterComplex(map);

			this.container = map.CreateContainer();
		}

		private void RegisterDummies(DependencyMap map)
		{
			map.AddService<IDummyOne,DummyOne>();
			map.AddService<IDummyTwo,DummyTwo>();
			map.AddService<IDummyThree,DummyThree>();
			map.AddService<IDummyFour,DummyFour>();
			map.AddService<IDummyFive,DummyFive>();
			map.AddService<IDummySix,DummySix>();
			map.AddService<IDummySeven,DummySeven>();
			map.AddService<IDummyEight,DummyEight>();
			map.AddService<IDummyNine,DummyNine>();
			map.AddService<IDummyTen,DummyTen>();
		}

		private void RegisterComplex(DependencyMap map)
		{
			map.AddSingletonService<IFirstService,FirstService>();
			map.AddSingletonService<ISecondService,SecondService>();
			map.AddSingletonService<IThirdService,ThirdService>();
			map.AddService<ISubObjectOne,SubObjectOne>();
			map.AddService<ISubObjectTwo,SubObjectTwo>();
			map.AddService<ISubObjectThree,SubObjectThree>();
			map.AddService<IComplex,Complex>();
		}

		private static void RegisterStandard(DependencyMap map)
		{
			map.AddSingletonService<ISingleton, Singleton>();
			map.AddService<ITransient, Transient>();
			map.AddService<ICombined, Combined>();
		}

		public override object Resolve(Type type)
		{
			return this.container.GetInstance(type, null);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}