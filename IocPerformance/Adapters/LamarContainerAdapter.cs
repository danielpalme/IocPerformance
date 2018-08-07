using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace IocPerformance.Adapters
{
    public sealed class LamarContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName => "Lamar";

        public override string Url => "https://jasperfx.github.io/lamar/";

        public override bool SupportsInterception => false;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsChildContainer => false;

        public override bool SupportAspNetCore => false;

        public override object Resolve(Type type) => this.container.GetService(type);

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
            var registry = new ServiceRegistry();

            RegisterBasic(registry);
            RegisterPropertyInjection(registry);
            RegisterGeneric(registry);
            RegisterMultiple(registry);

            this.container = new Container(registry);
        }

        public override void PrepareBasic()
        {
            var registry = new ServiceRegistry();
            RegisterBasic(registry);
            this.container = new Container(registry);
        }

        private static void RegisterBasic(ServiceRegistry r)
        {
            RegisterDummies(r);
            RegisterStandard(r);
            RegisterComplex(r);
        }

        private static void RegisterDummies(ServiceRegistry r)
        {
            r.AddTransient<IDummyOne, DummyOne>();
            r.AddTransient<IDummyTwo, DummyTwo>();
            r.AddTransient<IDummyThree, DummyThree>();
            r.AddTransient<IDummyFour, DummyFour>();
            r.AddTransient<IDummyFive, DummyFive>();
            r.AddTransient<IDummySix, DummySix>();
            r.AddTransient<IDummySeven, DummySeven>();
            r.AddTransient<IDummyEight, DummyEight>();
            r.AddTransient<IDummyNine, DummyNine>();
            r.AddTransient<IDummyTen, DummyTen>();
        }

        private static void RegisterStandard(ServiceRegistry r)
        {
            r.AddSingleton<ISingleton1, Singleton1>();
            r.AddSingleton<ISingleton2, Singleton2>();
            r.AddSingleton<ISingleton3, Singleton3>();
            r.AddTransient<ITransient1, Transient1>();
            r.AddTransient<ITransient2, Transient2>();
            r.AddTransient<ITransient3, Transient3>();
            r.AddTransient<ICombined1, Combined1>();
            r.AddTransient<ICombined2, Combined2>();
            r.AddTransient<ICombined3, Combined3>();
        }

        private static void RegisterComplex(ServiceRegistry r)
        {
            r.AddSingleton<IFirstService, FirstService>();
            r.AddSingleton<ISecondService, SecondService>();
            r.AddSingleton<IThirdService, ThirdService>();
            r.AddTransient<ISubObjectOne, SubObjectOne>();
            r.AddTransient<ISubObjectTwo, SubObjectTwo>();
            r.AddTransient<ISubObjectThree, SubObjectThree>();
            r.AddTransient<IComplex1, Complex1>();
            r.AddTransient<IComplex2, Complex2>();
            r.AddTransient<IComplex3, Complex3>();
        }

        private static void RegisterPropertyInjection(ServiceRegistry r)
        {
            r.AddSingleton<IServiceA, ServiceA>();
            r.AddSingleton<IServiceB, ServiceB>();
            r.AddSingleton<IServiceC, ServiceC>();

            r.AddTransient<ISubObjectA, SubObjectA>();
            r.AddTransient<ISubObjectB, SubObjectB>();
            r.AddTransient<ISubObjectC, SubObjectC>();

            r.AddTransient<IComplexPropertyObject1, ComplexPropertyObject1>();
            r.AddTransient<IComplexPropertyObject2, ComplexPropertyObject2>();
            r.AddTransient<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private static void RegisterGeneric(ServiceRegistry r)
        {
            r.For(typeof(IGenericInterface<>)).Use(typeof(GenericExport<>));
            r.For(typeof(ImportGeneric<>)).Use(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ServiceRegistry r)
        {
            r.AddTransient<ISimpleAdapter, SimpleAdapterOne>();
            r.AddTransient<ISimpleAdapter, SimpleAdapterTwo>();
            r.AddTransient<ISimpleAdapter, SimpleAdapterThree>();
            r.AddTransient<ISimpleAdapter, SimpleAdapterFour>();
            r.AddTransient<ISimpleAdapter, SimpleAdapterFive>();
            r.AddTransient<ImportMultiple1, ImportMultiple1>();
            r.AddTransient<ImportMultiple2, ImportMultiple2>();
            r.AddTransient<ImportMultiple3, ImportMultiple3>();
        }
    }
}