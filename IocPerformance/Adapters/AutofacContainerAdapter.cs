using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
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

        public override string PackageName
        {
            get { return "Autofac"; }
        }

        public override string Url
        {
            get { return "https://github.com/autofac/Autofac"; }
        }

        public override bool SupportsInterception
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

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override bool SupportsChildContainer
        {
            get { return true; }
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new AutofacChildContainerAdapter(this.container.BeginLifetimeScope());
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

            RegisterDummies(autofacContainerBuilder);
            RegisterStandard(autofacContainerBuilder);
            RegisterComplexObject(autofacContainerBuilder);
            RegisterPropertyInjection(autofacContainerBuilder);
            RegisterOpenGeneric(autofacContainerBuilder);
            RegisterMultiple(autofacContainerBuilder);
            RegisterInterceptor(autofacContainerBuilder);

            this.container = autofacContainerBuilder.Build();
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
            autofacContainerBuilder.RegisterType<Singleton1>().As<ISingleton1>().SingleInstance();
            autofacContainerBuilder.RegisterType<Singleton2>().As<ISingleton2>().SingleInstance();
            autofacContainerBuilder.RegisterType<Singleton3>().As<ISingleton3>().SingleInstance();

            autofacContainerBuilder.RegisterType<Transient1>().As<ITransient1>();
            autofacContainerBuilder.RegisterType<Transient2>().As<ITransient2>();
            autofacContainerBuilder.RegisterType<Transient3>().As<ITransient3>();

            autofacContainerBuilder.RegisterType<Combined1>().As<ICombined1>();
            autofacContainerBuilder.RegisterType<Combined2>().As<ICombined2>();
            autofacContainerBuilder.RegisterType<Combined3>().As<ICombined3>();
        }

        private static void RegisterComplexObject(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterType<FirstService>().As<IFirstService>().SingleInstance();
            autofacContainerBuilder.RegisterType<SecondService>().As<ISecondService>().SingleInstance();
            autofacContainerBuilder.RegisterType<ThirdService>().As<IThirdService>().SingleInstance();
            autofacContainerBuilder.RegisterType<SubObjectOne>().As<ISubObjectOne>();
            autofacContainerBuilder.RegisterType<SubObjectTwo>().As<ISubObjectTwo>();
            autofacContainerBuilder.RegisterType<SubObjectThree>().As<ISubObjectThree>();
            autofacContainerBuilder.RegisterType<Complex1>().As<IComplex1>();
            autofacContainerBuilder.RegisterType<Complex2>().As<IComplex2>();
            autofacContainerBuilder.RegisterType<Complex3>().As<IComplex3>();
        }

        private static void RegisterPropertyInjection(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
            autofacContainerBuilder.RegisterType<ServiceB>().As<IServiceB>().SingleInstance();
            autofacContainerBuilder.RegisterType<ServiceC>().As<IServiceC>().SingleInstance();
            autofacContainerBuilder.RegisterType<SubObjectA>().As<ISubObjectA>().PropertiesAutowired();
            autofacContainerBuilder.RegisterType<SubObjectB>().As<ISubObjectB>().PropertiesAutowired();
            autofacContainerBuilder.RegisterType<SubObjectC>().As<ISubObjectC>().PropertiesAutowired();

            autofacContainerBuilder.RegisterType<ComplexPropertyObject1>().As<IComplexPropertyObject1>()
                .PropertiesAutowired();
            autofacContainerBuilder.RegisterType<ComplexPropertyObject2>().As<IComplexPropertyObject2>()
                .PropertiesAutowired();
            autofacContainerBuilder.RegisterType<ComplexPropertyObject3>().As<IComplexPropertyObject3>()
                .PropertiesAutowired();
        }

        private static void RegisterOpenGeneric(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterGeneric(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
            autofacContainerBuilder.RegisterGeneric(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterType<SimpleAdapterOne>().As<ISimpleAdapter>();
            autofacContainerBuilder.RegisterType<SimpleAdapterTwo>().As<ISimpleAdapter>();
            autofacContainerBuilder.RegisterType<SimpleAdapterThree>().As<ISimpleAdapter>();
            autofacContainerBuilder.RegisterType<SimpleAdapterFour>().As<ISimpleAdapter>();
            autofacContainerBuilder.RegisterType<SimpleAdapterFive>().As<ISimpleAdapter>();

            autofacContainerBuilder.RegisterType<ImportMultiple1>().As<ImportMultiple1>();
            autofacContainerBuilder.RegisterType<ImportMultiple2>().As<ImportMultiple2>();
            autofacContainerBuilder.RegisterType<ImportMultiple3>().As<ImportMultiple3>();
        }

        private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterType<Calculator1>().As<ICalculator1>().EnableInterfaceInterceptors();
            autofacContainerBuilder.RegisterType<Calculator2>().As<ICalculator2>().EnableInterfaceInterceptors();
            autofacContainerBuilder.RegisterType<Calculator3>().As<ICalculator3>().EnableInterfaceInterceptors();
        }
    }

    public class AutofacChildContainerAdapter : IChildContainerAdapter
    {
        private ILifetimeScope lifetimeScope;

        public AutofacChildContainerAdapter(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public void Dispose()
        {
            this.lifetimeScope.Dispose();
        }

        public void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.RegisterType<ScopedTransient>().As<ITransient1>();

            autofacContainerBuilder.RegisterType<ScopedCombined1>().As<ICombined1>();
            autofacContainerBuilder.RegisterType<ScopedCombined2>().As<ICombined2>();
            autofacContainerBuilder.RegisterType<ScopedCombined3>().As<ICombined3>();

            autofacContainerBuilder.Update(this.lifetimeScope.ComponentRegistry);
        }

        public object Resolve(Type resolveType)
        {
            return this.lifetimeScope.Resolve(resolveType);
        }
    }
}