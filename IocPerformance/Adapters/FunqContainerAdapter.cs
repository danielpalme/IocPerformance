using System;
using System.Reflection;
using Funq;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class FunqContainerAdapter : ContainerAdapterBase
	{
		private Container container;
		private MethodInfo methodInfo;

		public override string PackageName
		{
			get { return "Funq"; }
		}

		public override string Version
		{
			get { return typeof(Container).Assembly.GetName().Version.ToString(); }
		}

		public override void Prepare()
		{
			this.container = new Funq.Container();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			Func<Object> pointer = container.Resolve<Object>;
			methodInfo = pointer.Method.GetGenericMethodDefinition();
		}

		private void RegisterComplex()
		{
			container.Register<IFirstService>(ioc => new FirstService()).ReusedWithin(ReuseScope.Container);
			container.Register<ISecondService>(ioc => new SecondService()).ReusedWithin(ReuseScope.Container);
			container.Register<IThirdService>(ioc => new ThirdService()).ReusedWithin(ReuseScope.Container);

			container.Register<ISubObjectOne>(ioc => new SubObjectOne(ioc.Resolve<IFirstService>()))
			         .ReusedWithin(ReuseScope.None);
			container.Register<ISubObjectTwo>(ioc => new SubObjectTwo(ioc.Resolve<ISecondService>()))
						.ReusedWithin(ReuseScope.None);
			container.Register<ISubObjectThree>(ioc => new SubObjectThree(ioc.Resolve<IThirdService>()))
			         .ReusedWithin(ReuseScope.None);

			container.Register<IComplex>(
				ioc => new Complex(ioc.Resolve<IFirstService>(),
				                   ioc.Resolve<ISecondService>(),
				                   ioc.Resolve<IThirdService>(),
				                   ioc.Resolve<ISubObjectOne>(),
				                   ioc.Resolve<ISubObjectTwo>(),
				                   ioc.Resolve<ISubObjectThree>())).ReusedWithin(ReuseScope.None);
		}

		private void RegisterDummies()
		{
			container.Register<IDummyOne>(ioc => new DummyOne()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyTwo>(ioc => new DummyTwo()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyThree>(ioc => new DummyThree()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyFour>(ioc => new DummyFour()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyFive>(ioc => new DummyFive()).ReusedWithin(ReuseScope.None);
			container.Register<IDummySix>(ioc => new DummySix()).ReusedWithin(ReuseScope.None);
			container.Register<IDummySeven>(ioc => new DummySeven()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyEight>(ioc => new DummyEight()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyNine>(ioc => new DummyNine()).ReusedWithin(ReuseScope.None);
			container.Register<IDummyTen>(ioc => new DummyTen()).ReusedWithin(ReuseScope.None);
		}

		private void RegisterStandard()
		{
			this.container.Register<ISingleton>(ioc => new Singleton())
			    .ReusedWithin(Funq.ReuseScope.Container);

			this.container.Register<ITransient>(ioc => new Transient())
			    .ReusedWithin(Funq.ReuseScope.None);

			this.container.Register<ICombined>(ioc => new Combined(
				                                          ioc.Resolve<ISingleton>(),
				                                          ioc.Resolve<ITransient>()))
			    .ReusedWithin(Funq.ReuseScope.None);
		}

		public override object Resolve(Type type)
		{
			// It only provides a generic Resolve<>() method.
			var genericMethod = methodInfo.MakeGenericMethod(new Type[] { type });
			return genericMethod.Invoke(container, new object[] { });
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}