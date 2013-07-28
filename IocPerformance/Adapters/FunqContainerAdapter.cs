using System;
using System.Reflection;
using Funq;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
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

		public override bool SupportsPropertyInjection
		{
			get { return true; }
		}

		public override object Resolve(Type type)
		{
			// It only provides a generic Resolve<>() method.
			var genericMethod = this.methodInfo.MakeGenericMethod(new Type[] { type });
			return genericMethod.Invoke(this.container, new object[] { });
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}

		public override void Prepare()
		{
			this.container = new Funq.Container();

			this.RegisterDummies();
			this.RegisterStandard();
			this.RegisterComplex();
			this.RegisterPropertyInjection();

			Func<object> pointer = this.container.Resolve<object>;
			this.methodInfo = pointer.Method.GetGenericMethodDefinition();
		}

		private void RegisterDummies()
		{
			this.container.Register<IDummyOne>(ioc => new DummyOne()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyTwo>(ioc => new DummyTwo()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyThree>(ioc => new DummyThree()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyFour>(ioc => new DummyFour()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyFive>(ioc => new DummyFive()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummySix>(ioc => new DummySix()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummySeven>(ioc => new DummySeven()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyEight>(ioc => new DummyEight()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyNine>(ioc => new DummyNine()).ReusedWithin(ReuseScope.None);
			this.container.Register<IDummyTen>(ioc => new DummyTen()).ReusedWithin(ReuseScope.None);
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

		private void RegisterComplex()
		{
			this.container.Register<IFirstService>(ioc => new FirstService()).ReusedWithin(ReuseScope.Container);
			this.container.Register<ISecondService>(ioc => new SecondService()).ReusedWithin(ReuseScope.Container);
			this.container.Register<IThirdService>(ioc => new ThirdService()).ReusedWithin(ReuseScope.Container);

			this.container.Register<ISubObjectOne>(ioc => new SubObjectOne(ioc.Resolve<IFirstService>()))
						.ReusedWithin(ReuseScope.None);
			this.container.Register<ISubObjectTwo>(ioc => new SubObjectTwo(ioc.Resolve<ISecondService>()))
							.ReusedWithin(ReuseScope.None);
			this.container.Register<ISubObjectThree>(ioc => new SubObjectThree(ioc.Resolve<IThirdService>()))
						.ReusedWithin(ReuseScope.None);

			this.container.Register<IComplex>(
				 ioc => new Complex(
					  ioc.Resolve<IFirstService>(),
					  ioc.Resolve<ISecondService>(),
					  ioc.Resolve<IThirdService>(),
					  ioc.Resolve<ISubObjectOne>(),
					  ioc.Resolve<ISubObjectTwo>(),
					  ioc.Resolve<ISubObjectThree>()))
				 .ReusedWithin(ReuseScope.None);
		}

		private void RegisterPropertyInjection()
		{
			this.container.Register<IServiceA>(ioc => new ServiceA()).ReusedWithin(ReuseScope.Container);
			this.container.Register<IServiceB>(ioc => new ServiceB()).ReusedWithin(ReuseScope.Container);
			this.container.Register<IServiceC>(ioc => new ServiceC()).ReusedWithin(ReuseScope.Container);

			this.container.Register<ISubObjectA>(ioc => new SubObjectA { ServiceA = ioc.Resolve<IServiceA>() })
				 .ReusedWithin(ReuseScope.None);
			this.container.Register<ISubObjectB>(ioc => new SubObjectB { ServiceB = ioc.Resolve<IServiceB>() })
				 .ReusedWithin(ReuseScope.None);
			this.container.Register<ISubObjectC>(ioc => new SubObjectC { ServiceC = ioc.Resolve<IServiceC>() })
				 .ReusedWithin(ReuseScope.None);

			this.container.Register<IComplexPropertyObject>(
				ioc => new ComplexPropertyObject
					       {
						       ServiceA = ioc.Resolve<IServiceA>(),
								 ServiceB = ioc.Resolve<IServiceB>(),
								 ServiceC = ioc.Resolve<IServiceC>(),
								 SubObjectA = ioc.Resolve<ISubObjectA>(),
								 SubObjectB = ioc.Resolve<ISubObjectB>(),
								 SubObjectC = ioc.Resolve<ISubObjectC>()
					       });
		}
	}
}