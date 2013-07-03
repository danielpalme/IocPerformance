using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Extensions.Interception;

namespace IocPerformance.Adapters
{
	public sealed class SimpleInjectorContainerAdapter : ContainerAdapterBase
	{
		private Container container;

		public override string PackageName
		{
			get { return "SimpleInjector"; }
		}

		public override bool SupportGeneric
		{
			get
			{
				return true;
			}
		}

		public override bool SupportsInterception { get { return true; } }

		public override void Prepare()
		{
			container = new SimpleInjector.Container();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			RegisterOpenGeneric();

			RegisterIntercepter();

			container.Verify();
		}

		private void RegisterDummies()
		{
			container.Register<IDummyOne,DummyOne>();
			container.Register<IDummyTwo,DummyTwo>();
			container.Register<IDummyThree,DummyThree>();
			container.Register<IDummyFour,DummyFour>();
			container.Register<IDummyFive,DummyFive>();
			container.Register<IDummySix,DummySix>();
			container.Register<IDummySeven,DummySeven>();
			container.Register<IDummyEight,DummyEight>();
			container.Register<IDummyNine,DummyNine>();
			container.Register<IDummyTen,DummyTen>();
		}

		private void RegisterIntercepter()
		{
			container.InterceptWith<SimpleInjectorInterceptionLogger>(type => type == typeof(ICalculator));
		}

		private void RegisterOpenGeneric()
		{
			container.RegisterOpenGeneric(typeof(IGenericInterface<>), typeof(GenericExport<>));
			container.RegisterOpenGeneric(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
		}

		private void RegisterStandard()
		{
			container.RegisterSingle<ISingleton, Singleton>();
			container.Register<ITransient, Transient>();
			container.Register<ICombined, Combined>();
			container.Register<ICalculator, Calculator>();
		}

		private void RegisterComplex()
		{
			container.Register<ISubObjectOne, SubObjectOne>();
			container.Register<ISubObjectTwo, SubObjectTwo>();
			container.Register<ISubObjectThree, SubObjectThree>();
			container.RegisterSingle<IFirstService, FirstService>();
			container.RegisterSingle<ISecondService, SecondService>();
			container.RegisterSingle<IThirdService, ThirdService>();
			container.Register<IComplex, Complex>();
		}

		public override object Resolve(Type type)
		{
			return this.container.GetInstance(type);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}