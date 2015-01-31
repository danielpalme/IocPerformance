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
        private IContainer container;

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
            this.container = new Container();

            this.container.Configure(x =>
                                     {
                                         RegisterBasic(x);
                                         RegisterPropertyInjection(x);
                                         RegisterGeneric(x);
                                         RegisterConditional(x);
                                         RegisterMultiple(x);
                                         RegisterInterceptor(x);
                                     });
        }

        public override void PrepareBasic()
        {
            this.container = new Container();

            this.container.Configure(x =>
                                     {
                                         RegisterBasic(x);
                                     });
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container == null)
            {
                return;
            }

            this.container.Dispose();
            this.container = null;
        }

        public override object Resolve(Type type)
        {
            return this.container.Get(type);
        }

        private static void RegisterBasic(IContainerExpression x)
        {
            RegisterDummies(x);
            RegisterStandard(x);
            RegisterComplex(x);
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
            expr.For<ISingleton1>().Use<Singleton1>().Lifetime.Singleton();
            expr.For<ISingleton2>().Use<Singleton2>().Lifetime.Singleton();
            expr.For<ISingleton3>().Use<Singleton3>().Lifetime.Singleton();
            expr.For<ITransient1>().Use<Transient1>();
            expr.For<ITransient2>().Use<Transient2>();
            expr.For<ITransient3>().Use<Transient3>();
            expr.For<ICombined1>().Use<Combined1>();
            expr.For<ICombined2>().Use<Combined2>();
            expr.For<ICombined3>().Use<Combined3>();
        }

        private static void RegisterComplex(IContainerExpression expr)
        {
            expr.For<IFirstService>().Use<FirstService>().Lifetime.Singleton();
            expr.For<ISecondService>().Use<SecondService>().Lifetime.Singleton();
            expr.For<IThirdService>().Use<ThirdService>().Lifetime.Singleton();
            expr.For<ISubObjectOne>().Use<SubObjectOne>();
            expr.For<ISubObjectTwo>().Use<SubObjectTwo>();
            expr.For<ISubObjectThree>().Use<SubObjectThree>();
            expr.For<IComplex1>().Use<Complex1>();
            expr.For<IComplex2>().Use<Complex2>();
            expr.For<IComplex3>().Use<Complex3>();
        }

        private static void RegisterPropertyInjection(IContainerExpression expr)
        {
            expr.For<IServiceA>().Use<ServiceA>().Lifetime.Singleton();
            expr.For<IServiceB>().Use<ServiceB>().Lifetime.Singleton();
            expr.For<IServiceC>().Use<ServiceC>().Lifetime.Singleton();

            expr.For<ISubObjectA>().Use<SubObjectA>().Set(x => x.ServiceA);
            expr.For<ISubObjectB>().Use<SubObjectB>().Set(x => x.ServiceB);
            expr.For<ISubObjectC>().Use<SubObjectC>().Set(x => x.ServiceC);

            expr.For<IComplexPropertyObject1>().Use<ComplexPropertyObject1>()
                .Set(x => x.ServiceA)
                .Set(x => x.ServiceB)
                .Set(x => x.ServiceC)
                .Set(x => x.SubObjectA)
                .Set(x => x.SubObjectB)
                .Set(x => x.SubObjectC);
            expr.For<IComplexPropertyObject2>().Use<ComplexPropertyObject2>()
                .Set(x => x.ServiceA)
                .Set(x => x.ServiceB)
                .Set(x => x.ServiceC)
                .Set(x => x.SubObjectA)
                .Set(x => x.SubObjectB)
                .Set(x => x.SubObjectC);
            expr.For<IComplexPropertyObject3>().Use<ComplexPropertyObject3>()
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
            expr.For<ImportConditionObject1>().Use<ImportConditionObject1>();
            expr.For<ImportConditionObject2>().Use<ImportConditionObject2>();
            expr.For<ImportConditionObject3>().Use<ImportConditionObject3>();
            expr.For<IExportConditionInterface>()
                .Use(x =>
                     {
                         x.If(ctx => ctx.TypeStack.Root == typeof(ImportConditionObject1))
                             .Use<ExportConditionalObject>();
                         x.If(ctx => ctx.TypeStack.Root == typeof(ImportConditionObject2))
                             .Use<ExportConditionalObject2>();
                         x.If(ctx => ctx.TypeStack.Root == typeof(ImportConditionObject3))
                             .Use<ExportConditionalObject3>();
                     });
        }

        private static void RegisterMultiple(IContainerExpression expr)
        {
            expr.For<ISimpleAdapter>().Add<SimpleAdapterOne>();
            expr.For<ISimpleAdapter>().Add<SimpleAdapterTwo>();
            expr.For<ISimpleAdapter>().Add<SimpleAdapterThree>();
            expr.For<ISimpleAdapter>().Add<SimpleAdapterFour>();
            expr.For<ISimpleAdapter>().Add<SimpleAdapterFive>();
            expr.For<ImportMultiple1>().Use<ImportMultiple1>();
            expr.For<ImportMultiple2>().Use<ImportMultiple2>();
            expr.For<ImportMultiple3>().Use<ImportMultiple3>();
        }

        private static void RegisterInterceptor(IContainerExpression expr)
        {
            expr.For<ICalculator1>().Use<Calculator1>()
                .Proxy(x => x.ProxyGenerator.CreateInterfaceProxyWithTarget<ICalculator1>(x.Instance, new MaestroInterceptionLogger()));
            expr.For<ICalculator2>().Use<Calculator2>()
                .Proxy(x => x.ProxyGenerator.CreateInterfaceProxyWithTarget<ICalculator2>(x.Instance, new MaestroInterceptionLogger()));
            expr.For<ICalculator3>().Use<Calculator3>()
                .Proxy(x => x.ProxyGenerator.CreateInterfaceProxyWithTarget<ICalculator3>(x.Instance, new MaestroInterceptionLogger()));
        }
    }
}