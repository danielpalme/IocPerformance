﻿using System;
using HaveBox;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class HaveBoxContainerAdapter : ContainerAdapterBase
	{
		private Container container;

		public override string PackageName
		{
			get { return "HaveBox"; }
		}

		public override object Resolve(Type type)
		{
			return this.container.GetInstance(type);
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
			this.container = new Container();

			this.RegisterDummies();
			this.RegisterStandard();
			this.RegisterComplex();
			this.RegisterPropertyInjection();
		}

		private void RegisterDummies()
		{
			this.container.Configure(config => config.For<IDummyOne>().Use<DummyOne>());
			this.container.Configure(config => config.For<IDummyTwo>().Use<DummyTwo>());
			this.container.Configure(config => config.For<IDummyThree>().Use<DummyThree>());
			this.container.Configure(config => config.For<IDummyFour>().Use<DummyFour>());
			this.container.Configure(config => config.For<IDummyFive>().Use<DummyFive>());
			this.container.Configure(config => config.For<IDummySix>().Use<DummySix>());
			this.container.Configure(config => config.For<IDummySeven>().Use<DummySeven>());
			this.container.Configure(config => config.For<IDummyEight>().Use<DummyEight>());
			this.container.Configure(config => config.For<IDummyNine>().Use<DummyNine>());
			this.container.Configure(config => config.For<IDummyTen>().Use<DummyTen>());
		}

		private void RegisterStandard()
		{
			this.container.Configure(config => config.For<ISingleton>().Use<Singleton>().AsSingleton());
			this.container.Configure(config => config.For<ITransient>().Use<Transient>());
			this.container.Configure(config => config.For<ICombined>().Use<Combined>());
		}

		private void RegisterComplex()
		{
			this.container.Configure(config => config.For<IFirstService>().Use<FirstService>().AsSingleton());
			this.container.Configure(config => config.For<ISecondService>().Use<SecondService>().AsSingleton());
			this.container.Configure(config => config.For<IThirdService>().Use<ThirdService>().AsSingleton());
			this.container.Configure(config => config.For<ISubObjectOne>().Use<SubObjectOne>());
			this.container.Configure(config => config.For<ISubObjectTwo>().Use<SubObjectTwo>());
			this.container.Configure(config => config.For<ISubObjectThree>().Use<SubObjectThree>());
			this.container.Configure(config => config.For<IComplex>().Use<Complex>());
		}

		private void RegisterPropertyInjection()
		{
			this.container.Configure(config => config.For<IServiceA>().Use<ServiceA>().AsSingleton());
			this.container.Configure(config => config.For<IServiceB>().Use<ServiceB>().AsSingleton());
			this.container.Configure(config => config.For<IServiceC>().Use<ServiceC>().AsSingleton());
			this.container.Configure(config => config.For<ISubObjectA>().Use(() => new SubObjectA { ServiceA = container.GetInstance<IServiceA>() }));
			this.container.Configure(config => config.For<ISubObjectB>().Use(() => new SubObjectB { ServiceB = container.GetInstance<IServiceB>() }));
			this.container.Configure(config => config.For<ISubObjectC>().Use(() => new SubObjectC { ServiceC = container.GetInstance<IServiceC>() }));
			this.container.Configure(
				config => config.For<IComplexPropertyObject>().Use(
					() => new ComplexPropertyObject
								{
					             ServiceA = container.GetInstance<IServiceA>(),
									 ServiceB = container.GetInstance<IServiceB>(),
									 ServiceC = container.GetInstance<IServiceC>(),
									 SubObjectA = container.GetInstance<ISubObjectA>(),
									 SubObjectB = container.GetInstance<ISubObjectB>(),
									 SubObjectC = container.GetInstance<ISubObjectC>()
								}));
		}
	}
}