using System;
using System.Collections;
using System.Collections.Generic;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
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
			get { return false; }
		}

		public override void Prepare()
		{
			this.container = new UnityContainer();
			this.container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();

			RegisterDummies();

			RegisterStandard();
			
			RegisterComplex();

			RegisterMultiple();
			
			RegisterInterceptor();
		}

		private void RegisterDummies()
		{
			container.RegisterType<IDummyOne, DummyOne>(new TransientLifetimeManager());
			container.RegisterType<IDummyTwo, DummyTwo>(new TransientLifetimeManager());
			container.RegisterType<IDummyThree, DummyThree>(new TransientLifetimeManager());
			container.RegisterType<IDummyFour, DummyFour>(new TransientLifetimeManager());
			container.RegisterType<IDummyFive, DummyFive>(new TransientLifetimeManager());
			container.RegisterType<IDummySix, DummySix>(new TransientLifetimeManager());
			container.RegisterType<IDummySeven, DummySeven>(new TransientLifetimeManager());
			container.RegisterType<IDummyEight, DummyEight>(new TransientLifetimeManager());
			container.RegisterType<IDummyNine, DummyNine>(new TransientLifetimeManager());
			container.RegisterType<IDummyTen, DummyTen>(new TransientLifetimeManager());
		}

		private void RegisterInterceptor()
		{
			this.container.RegisterType<ICalculator, Calculator>(new TransientLifetimeManager())
			    .Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
			    .SetInterceptorFor<ICalculator>(new InterfaceInterceptor());
		}

		private void RegisterStandard()
		{
			this.container.RegisterType<ISingleton, Singleton>(new ContainerControlledLifetimeManager());
			this.container.RegisterType<ITransient, Transient>(new TransientLifetimeManager());
			this.container.RegisterType<ICombined, Combined>(new TransientLifetimeManager());
		}

		// This is supposed to work, its not so I'm marking as no multiple support for the moment
		private void RegisterMultiple()
		{
			container.RegisterType<IEnumerable<ISimpleAdapter>, ISimpleAdapter[]>();

			container.RegisterType<ISimpleAdapter, SimpleAdapterOne>(new TransientLifetimeManager());
			container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>(new TransientLifetimeManager());
			container.RegisterType<ISimpleAdapter, SimpleAdapterThree>(new TransientLifetimeManager());
			container.RegisterType<ISimpleAdapter, SimpleAdapterFour>(new TransientLifetimeManager());
			container.RegisterType<ISimpleAdapter, SimpleAdapterFive>(new TransientLifetimeManager());

			container.RegisterType<ImportMultiple, ImportMultiple>(new TransientLifetimeManager());
		}

		private void RegisterComplex()
		{
			container.RegisterType<IFirstService, FirstService>(new ContainerControlledLifetimeManager());
			container.RegisterType<ISecondService, SecondService>(new ContainerControlledLifetimeManager());
			container.RegisterType<IThirdService, ThirdService>(new ContainerControlledLifetimeManager());
			container.RegisterType<ISubObjectOne, SubObjectOne>(new TransientLifetimeManager());
			container.RegisterType<ISubObjectTwo, SubObjectTwo>(new TransientLifetimeManager());
			container.RegisterType<ISubObjectThree, SubObjectThree>(new TransientLifetimeManager());
			container.RegisterType<IComplex, Complex>(new TransientLifetimeManager());
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