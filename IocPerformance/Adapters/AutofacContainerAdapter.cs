using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class AutofacContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName => "Autofac";

        public override string Url => "https://github.com/autofac/Autofac";

        public override bool SupportsInterception => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsConditional => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => true;

        public override IChildContainerAdapter CreateChildContainerAdapter() => new AutofacChildContainerAdapter(this.container);

        public override object Resolve(Type type) => this.container.Resolve(type);

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

        public override void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

            RegisterBasic(autofacContainerBuilder);

            RegisterPropertyInjection(autofacContainerBuilder);
            RegisterOpenGeneric(autofacContainerBuilder);
            RegisterMultiple(autofacContainerBuilder);
            RegisterConditional(autofacContainerBuilder);
            RegisterInterceptor(autofacContainerBuilder);
            RegisterAspNetCore(autofacContainerBuilder);

            this.container = autofacContainerBuilder.Build();
        }

        private void RegisterAspNetCore(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Populate(CreateServiceCollection());
        }

        public override void PrepareBasic()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            RegisterBasic(autofacContainerBuilder);

            this.container = autofacContainerBuilder.Build();
        }

        private static void RegisterBasic(ContainerBuilder autofacContainerBuilder)
        {
            RegisterDummies(autofacContainerBuilder);
            RegisterStandard(autofacContainerBuilder);
            RegisterComplexObject(autofacContainerBuilder);
        }

        private static void RegisterDummies(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new DummyOne()).As<IDummyOne>();
            autofacContainerBuilder.Register(c => new DummyTwo()).As<IDummyTwo>();
            autofacContainerBuilder.Register(c => new DummyThree()).As<IDummyThree>();
            autofacContainerBuilder.Register(c => new DummyFour()).As<IDummyFour>();
            autofacContainerBuilder.Register(c => new DummyFive()).As<IDummyFive>();
            autofacContainerBuilder.Register(c => new DummySix()).As<IDummySix>();
            autofacContainerBuilder.Register(c => new DummySeven()).As<IDummySeven>();
            autofacContainerBuilder.Register(c => new DummyEight()).As<IDummyEight>();
            autofacContainerBuilder.Register(c => new DummyNine()).As<IDummyNine>();
            autofacContainerBuilder.Register(c => new DummyTen()).As<IDummyTen>();
        }

        private static void RegisterStandard(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Singleton1()).As<ISingleton1>().SingleInstance();
            autofacContainerBuilder.Register(c => new Singleton2()).As<ISingleton2>().SingleInstance();
            autofacContainerBuilder.Register(c => new Singleton3()).As<ISingleton3>().SingleInstance();

            autofacContainerBuilder.Register(c => new Transient1()).As<ITransient1>();
            autofacContainerBuilder.Register(c => new Transient2()).As<ITransient2>();
            autofacContainerBuilder.Register(c => new Transient3()).As<ITransient3>();

            autofacContainerBuilder.Register(c => new Combined1(c.Resolve<ISingleton1>(), c.Resolve<ITransient1>())).As<ICombined1>();
            autofacContainerBuilder.Register(c => new Combined2(c.Resolve<ISingleton2>(), c.Resolve<ITransient2>())).As<ICombined2>();
            autofacContainerBuilder.Register(c => new Combined3(c.Resolve<ISingleton3>(), c.Resolve<ITransient3>())).As<ICombined3>();
        }

        private static void RegisterComplexObject(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new FirstService()).As<IFirstService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SecondService()).As<ISecondService>().SingleInstance();
            autofacContainerBuilder.Register(c => new ThirdService()).As<IThirdService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SubObjectOne(c.Resolve<IFirstService>())).As<ISubObjectOne>();
            autofacContainerBuilder.Register(c => new SubObjectTwo(c.Resolve<ISecondService>())).As<ISubObjectTwo>();
            autofacContainerBuilder.Register(c => new SubObjectThree(c.Resolve<IThirdService>())).As<ISubObjectThree>();
            autofacContainerBuilder.Register(c => new Complex1(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex1>();
            autofacContainerBuilder.Register(c => new Complex2(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex2>();
            autofacContainerBuilder.Register(c => new Complex3(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex3>();
        }

        private static void RegisterPropertyInjection(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new ServiceA()).As<IServiceA>().SingleInstance();
            autofacContainerBuilder.Register(c => new ServiceB()).As<IServiceB>().SingleInstance();
            autofacContainerBuilder.Register(c => new ServiceC()).As<IServiceC>().SingleInstance();

            autofacContainerBuilder.Register(c => new SubObjectA {ServiceA = c.Resolve<IServiceA>()}).As<ISubObjectA>();
            autofacContainerBuilder.Register(c => new SubObjectB {ServiceB = c.Resolve<IServiceB>()}).As<ISubObjectB>();
            autofacContainerBuilder.Register(c => new SubObjectC {ServiceC = c.Resolve<IServiceC>()}).As<ISubObjectC>();

            autofacContainerBuilder.Register(c => new ComplexPropertyObject1
                {
                    ServiceA = c.Resolve<IServiceA>(),
                    ServiceB = c.Resolve<IServiceB>(),
                    ServiceC = c.Resolve<IServiceC>(),
                    SubObjectA = c.Resolve<ISubObjectA>(),
                    SubObjectB = c.Resolve<ISubObjectB>(),
                    SubObjectC = c.Resolve<ISubObjectC>()
                })
                .As<IComplexPropertyObject1>();

            autofacContainerBuilder.Register(c => new ComplexPropertyObject2
                {
                    ServiceA = c.Resolve<IServiceA>(),
                    ServiceB = c.Resolve<IServiceB>(),
                    ServiceC = c.Resolve<IServiceC>(),
                    SubObjectA = c.Resolve<ISubObjectA>(),
                    SubObjectB = c.Resolve<ISubObjectB>(),
                    SubObjectC = c.Resolve<ISubObjectC>()
                })
                .As<IComplexPropertyObject2>();

            autofacContainerBuilder.Register(c => new ComplexPropertyObject3
                {
                    ServiceA = c.Resolve<IServiceA>(),
                    ServiceB = c.Resolve<IServiceB>(),
                    ServiceC = c.Resolve<IServiceC>(),
                    SubObjectA = c.Resolve<ISubObjectA>(),
                    SubObjectB = c.Resolve<ISubObjectB>(),
                    SubObjectC = c.Resolve<ISubObjectC>()
                })
                .As<IComplexPropertyObject3>();
        }

        private static void RegisterOpenGeneric(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterGeneric(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
            autofacContainerBuilder.RegisterGeneric(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new SimpleAdapterOne()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterTwo()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterThree()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterFour()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterFive()).As<ISimpleAdapter>();

            autofacContainerBuilder.Register(c => new ImportMultiple1(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple1>();
            autofacContainerBuilder.Register(c => new ImportMultiple2(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple2>();
            autofacContainerBuilder.Register(c => new ImportMultiple3(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple3>();
        }

        private static void RegisterConditional(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new ExportConditionalObject()).Named<IExportConditionInterface>("ExportConditionalObject");
            autofacContainerBuilder.Register(c => new ExportConditionalObject2()).Named<IExportConditionInterface>("ExportConditionalObject2");
            autofacContainerBuilder.Register(c => new ExportConditionalObject3()).Named<IExportConditionInterface>("ExportConditionalObject3");
            autofacContainerBuilder.Register(c => new ImportConditionObject1(c.ResolveNamed<IExportConditionInterface>("ExportConditionalObject")));
            autofacContainerBuilder.Register(c => new ImportConditionObject2(c.ResolveNamed<IExportConditionInterface>("ExportConditionalObject2")));
            autofacContainerBuilder.Register(c => new ImportConditionObject3(c.ResolveNamed<IExportConditionInterface>("ExportConditionalObject3")));
        }

        private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Calculator1()).As<ICalculator1>().EnableInterfaceInterceptors();
            autofacContainerBuilder.Register(c => new Calculator2()).As<ICalculator2>().EnableInterfaceInterceptors();
            autofacContainerBuilder.Register(c => new Calculator3()).As<ICalculator3>().EnableInterfaceInterceptors();
        }
    }

    public class AutofacChildContainerAdapter : IChildContainerAdapter
    {
        private readonly ILifetimeScope rootLifetimeScope;
        private ILifetimeScope childLifetimeScope;

        public AutofacChildContainerAdapter(ILifetimeScope rootLifetimeScope)
        {
            this.rootLifetimeScope = rootLifetimeScope;
        }

        public void Dispose()
        {
            this.childLifetimeScope.Dispose();
        }

        public void Prepare()
        {
            childLifetimeScope = rootLifetimeScope.BeginLifetimeScope(builder =>
            {
                builder.Register(c => new ScopedTransient()).As<ITransient1>();

                builder.Register(c => new ScopedCombined1(c.Resolve<ITransient1>(), c.Resolve<ISingleton1>())).As<ICombined1>();
                builder.Register(c => new ScopedCombined2(c.Resolve<ITransient1>(), c.Resolve<ISingleton1>())).As<ICombined2>();
                builder.Register(c => new ScopedCombined3(c.Resolve<ITransient1>(), c.Resolve<ISingleton1>())).As<ICombined3>();
            });
        }

        public object Resolve(Type resolveType) => this.childLifetimeScope.Resolve(resolveType);
    }
}