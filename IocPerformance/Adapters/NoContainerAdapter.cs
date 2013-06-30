using System;
using System.Collections.Generic;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class NoContainerAdapter : ContainerAdapterBase
	{
		private readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

		public override string PackageName
		{
			get { return "No"; }
		}

		public override string Version { get { return null; } }

		public override void Prepare()
		{
			RegisterDummies();
			
			RegisterStandard();

			RegisterComplex();
		}

		private void RegisterComplex()
		{
			IFirstService firstService = new FirstService();
			ISecondService secondService = new SecondService();
			IThirdService thirdService = new ThirdService();

			container[typeof(IFirstService)] = () => firstService;
			container[typeof(ISecondService)] = () => secondService;
			container[typeof(IThirdService)] = () => thirdService;
			container[typeof(IComplex)] = () => new Complex(firstService,
			                                                secondService,
			                                                thirdService,
			                                                new SubObjectOne(firstService),
			                                                new SubObjectTwo(secondService),
			                                                new SubObjectThree(thirdService));
		}

		private void RegisterStandard()
		{
			ISingleton singleton = new Singleton();

			container[typeof(ISingleton)] = () => singleton;
			container[typeof(ITransient)] = () => new Transient();
			container[typeof(ICombined)] = () => new Combined(singleton, new Transient());
		}

		private void RegisterDummies()
		{
			container[typeof(IDummyOne)] = () => new DummyOne();
			container[typeof(IDummyTwo)] = () => new DummyTwo();
			container[typeof(IDummyThree)] = () => new DummyThree();
			container[typeof(IDummyFour)] = () => new DummyFour();
			container[typeof(IDummyFive)] = () => new DummyFive();
			container[typeof(IDummySix)] = () => new DummySix();
			container[typeof(IDummySeven)] = () => new DummySeven();
			container[typeof(IDummyEight)] = () => new DummyEight();
			container[typeof(IDummyNine)] = () => new DummyNine();
			container[typeof(IDummyTen)] = () => new DummyTen();
		}

		public override object Resolve(Type type)
		{
			return this.container[type]();
		}

		public override void Dispose()
		{
		}
	}
}