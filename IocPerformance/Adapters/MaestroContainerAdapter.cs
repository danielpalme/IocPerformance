using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using Maestro;
using Maestro.Configuration;

namespace IocPerformance.Adapters
{
	public class MaestroContainerAdapter : ContainerAdapterBase
	{
		private static IContainer Container = new Container();

		public override string PackageName
		{
			get { return "Maestro"; }
		}

		public override string Url
		{
			get { return "https://github.com/JonasSamuelsson/Maestro"; }
		}

		public override bool SupportsInterception
		{
			get { return true; }
		}

		public override bool SupportsPropertyInjection
		{
			get { return true; }
		}

		public override bool SupportsConditional
		{
			get { return true; }
		}

		public override bool SupportGeneric
		{
			get { return true; }
		}

		public override bool SupportsMultiple
		{
			get { return true; }
		}

		public override void Prepare()
		{
			Container.Configure(x =>
									  {
										  RegisterDummies(x);
										  RegisterStandard(x);
										  RegisterComplex(x);
										  RegisterPropertyInjection(x);
										  RegisterGeneric(x);
										  RegisterConditional(x);
										  RegisterMultiple(x);
										  RegisterInterceptor(x);
									  });
		}

		public override object Resolve(Type type)
		{
			return Container.Get(type);
		}

		public override void Dispose()
		{
			Container.Dispose();
		}

		private static void RegisterDummies(IContainerExpression expr)
		{
			expr.For<IDummyOne>().Use<DummyOne>();
			expr.For<IDummyTwo>().Use<DummyTwo>();
			expr.For<IDummyThree>().Use<DummyThree>();
			expr.For<IDummyFour>().Use<DummyFour>();
			expr.For<IDummyFive>().Use<DummyFive>();
			expr.For<IDummySix>().Use<DummySix>();
			expr.For<IDummySeven>().Use<DummySeven>();
			expr.For<IDummyEight>().Use<DummyEight>();
			expr.For<IDummyNine>().Use<DummyNine>();
			expr.For<IDummyTen>().Use<DummyTen>();
		}

		private static void RegisterStandard(IContainerExpression expr)
		{
			expr.For<ISingleton>().Use<Singleton>().AsSingleton();
			expr.For<ITransient>().Use<Transient>();
			expr.For<ICombined>().Use<Combined>();
		}

		private static void RegisterComplex(IContainerExpression expr)
		{
			expr.For<IFirstService>().Use<FirstService>().AsSingleton();
			expr.For<ISecondService>().Use<SecondService>().AsSingleton();
			expr.For<IThirdService>().Use<ThirdService>().AsSingleton();
			expr.For<ISubObjectOne>().Use<SubObjectOne>();
			expr.For<ISubObjectTwo>().Use<SubObjectTwo>();
			expr.For<ISubObjectThree>().Use<SubObjectThree>();
			expr.For<IComplex>().Use<Complex>();
		}

		private static void RegisterPropertyInjection(IContainerExpression expr)
		{
			expr.For<IServiceA>().Use<ServiceA>().AsSingleton();
			expr.For<IServiceB>().Use<ServiceB>().AsSingleton();
			expr.For<IServiceC>().Use<ServiceC>().AsSingleton();

			expr.For<ISubObjectA>().Use<SubObjectA>().Set(x => x.ServiceA);
			expr.For<ISubObjectB>().Use<SubObjectB>().Set(x => x.ServiceB);
			expr.For<ISubObjectC>().Use<SubObjectC>().Set(x => x.ServiceC);

			expr.For<IComplexPropertyObject>().Use<ComplexPropertyObject>()
				 .Set(x => x.ServiceA)
				 .Set(x => x.ServiceB)
				 .Set(x => x.ServiceC)
				 .Set(x => x.SubObjectA)
				 .Set(x => x.SubObjectB)
				 .Set(x => x.SubObjectC);
		}

		private static void RegisterGeneric(IContainerExpression expr)
		{
			expr.For(typeof(IGenericInterface<>)).Use(typeof(GenericExport<>));
			expr.For(typeof(ImportGeneric<>)).Use(typeof(ImportGeneric<>));
		}

		private static void RegisterConditional(IContainerExpression expr)
		{
			expr.For<ImportConditionObject>().Use<ImportConditionObject>();
			expr.For<ImportConditionObject2>().Use<ImportConditionObject2>();
			expr.For<IExportConditionInterface>()
				 .UseConditional(x =>
									  {
										  x.If(ctx => ctx.TypeStack.Root == typeof(ImportConditionObject))
											.Use<ExportConditionalObject>();
										  x.If(ctx => ctx.TypeStack.Root == typeof(ImportConditionObject2))
											.Use<ExportConditionalObject2>();
									  });
		}

		private static void RegisterMultiple(IContainerExpression expr)
		{
			expr.Add<ISimpleAdapter>().Use<SimpleAdapterOne>();
			expr.Add<ISimpleAdapter>().Use<SimpleAdapterTwo>();
			expr.Add<ISimpleAdapter>().Use<SimpleAdapterThree>();
			expr.Add<ISimpleAdapter>().Use<SimpleAdapterFour>();
			expr.Add<ISimpleAdapter>().Use<SimpleAdapterFive>();
			expr.For<ImportMultiple>().Use<ImportMultiple>();
		}

		private static void RegisterInterceptor(IContainerExpression expr)
		{
			expr.For<ICalculator>().Use<Calculator>()
				 .Proxy(x => x.ProxyGenerator.CreateInterfaceProxyWithTarget<ICalculator>(x.Instance, new MaestroInterceptionLogger()));
		}
	}
}