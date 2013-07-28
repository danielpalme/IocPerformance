using System;
using System.Collections.Generic;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IocPerformance.Adapters
{
	public sealed class UnityContainerAdapter : ContainerAdapterBase
	{
		private UnityContainer container;

		public override string PackageName
		{
			get { return "Unity"; }
		}

		public override bool SupportsInterception
		{
			get { return true; }
		}

		public override bool SupportsMultiple
		{
			get { return true; }
		}

		public override bool SupportsPropertyInjection
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
			this.container = new UnityContainer();
			this.container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();

			this.RegisterDummies();
			this.RegisterStandard();
			this.RegisterComplex();
			this.RegisterPropertyInjection();
			this.RegisterMultiple();
			this.RegisterInterceptor();
		}

		private void RegisterDummies()
		{
			this.container.RegisterType<IDummyOne, DummyOne>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyTwo, DummyTwo>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyThree, DummyThree>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyFour, DummyFour>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyFive, DummyFive>(new TransientLifetimeManager());
			this.container.RegisterType<IDummySix, DummySix>(new TransientLifetimeManager());
			this.container.RegisterType<IDummySeven, DummySeven>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyEight, DummyEight>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyNine, DummyNine>(new TransientLifetimeManager());
			this.container.RegisterType<IDummyTen, DummyTen>(new TransientLifetimeManager());
		}

		private void RegisterStandard()
		{
			this.container.RegisterType<ISingleton, Singleton>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<ITransient, Transient>(new TransientLifetimeManager());
			this.container.RegisterType<ICombined, Combined>(new TransientLifetimeManager());
		}

		private void RegisterComplex()
		{
			this.container.RegisterType<IFirstService, FirstService>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<ISecondService, SecondService>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<IThirdService, ThirdService>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<ISubObjectOne, SubObjectOne>(new TransientLifetimeManager());
			this.container.RegisterType<ISubObjectTwo, SubObjectTwo>(new TransientLifetimeManager());
			this.container.RegisterType<ISubObjectThree, SubObjectThree>(new TransientLifetimeManager());
			this.container.RegisterType<IComplex, Complex>(new TransientLifetimeManager());
		}

		private void RegisterPropertyInjection()
		{
			this.container.RegisterType<IServiceA, ServiceA>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<IServiceB, ServiceB>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<IServiceC, ServiceC>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<ISubObjectA, SubObjectA>(new TransientLifetimeManager());
			this.container.RegisterType<ISubObjectB, SubObjectB>(new TransientLifetimeManager());
			this.container.RegisterType<ISubObjectC, SubObjectC>(new TransientLifetimeManager());
			this.container.RegisterType<IComplexPropertyObject, ComplexPropertyObject>(new TransientLifetimeManager());
		}

		private void RegisterMultiple()
		{
			this.container.RegisterType<IEnumerable<ISimpleAdapter>, ISimpleAdapter[]>();

			this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>("one", new TransientLifetimeManager());
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>("two", new TransientLifetimeManager());
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>("three", new TransientLifetimeManager());
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>("four", new TransientLifetimeManager());
			this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>("five", new TransientLifetimeManager());

			this.container.RegisterType<ImportMultiple, ImportMultiple>(new TransientLifetimeManager());
		}

		private void RegisterInterceptor()
		{
			this.container.RegisterType<ICalculator, Calculator>(new TransientLifetimeManager())
				 .Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
				 .SetInterceptorFor<ICalculator>(new InterfaceInterceptor());
		}
	}
}