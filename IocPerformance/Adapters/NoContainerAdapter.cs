using System;
using System.Collections.Generic;
using IocPerformance.Classes.Complex;
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
			ISingleton singleton = new Singleton();
			IFirstService firstService = new FirstService();
			ISecondService secondService = new SecondService();
			IThirdService thirdService = new ThirdService();

			container[typeof(ISingleton)] = () => singleton;
			container[typeof(ITransient)] = () => new Transient();
			container[typeof(ICombined)] = () => new Combined(singleton, new Transient());
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

		public override object Resolve(Type type)
		{
			return this.container[type]();
		}

		public override void Dispose()
		{
		}
	}
}