using System;
using System.Linq;
using System.Xml.Linq;
using Dynamo.Ioc;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class DynamoContainerAdapter : ContainerAdapterBase
	{
		private IocContainer container;

		public override string PackageName
		{
			get { return "Dynamo.Ioc"; }
		}

		public override void Prepare()
		{
			this.container = new IocContainer(defaultCompileMode: CompileMode.Dynamic);

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			this.container.Compile();
		}

		private void RegisterComplex()
		{
			container.Register<IFirstService, FirstService>().WithContainerLifetime();
			container.Register<ISecondService, SecondService>().WithContainerLifetime();
			container.Register<IThirdService, ThirdService>().WithContainerLifetime();
			container.Register<ISubObjectOne, SubObjectOne>();
			container.Register<ISubObjectTwo, SubObjectTwo>();
			container.Register<ISubObjectThree, SubObjectThree>();
			container.Register<IComplex, Complex>();
		}

		private void RegisterDummies()
		{
			container.Register<IDummyOne, DummyOne>();
			container.Register<IDummyTwo, DummyTwo>();
			container.Register<IDummyThree, DummyThree>();
			container.Register<IDummyFour, DummyFour>();
			container.Register<IDummyFive, DummyFive>();
			container.Register<IDummySix, DummySix>();
			container.Register<IDummySeven, DummySeven>();
			container.Register<IDummyEight, DummyEight>();
			container.Register<IDummyNine, DummyNine>();
			container.Register<IDummyTen, DummyTen>();
		}

		private void RegisterStandard()
		{
			this.container.Register<ISingleton, Singleton>().WithContainerLifetime();
			this.container.Register<ITransient, Transient>();
			this.container.Register<ICombined, Combined>();
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