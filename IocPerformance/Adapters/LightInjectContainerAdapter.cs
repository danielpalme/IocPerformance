using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using LightInject;
using LightInject.Microsoft.DependencyInjection;

namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : ContainerAdapterBase
    {
        private ServiceContainer container;

        public override string PackageName => "LightInject";

        public override string Url => "https://github.com/seesharper/LightInject";

        public override bool SupportsInterception => true;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportAspNetCore => true;

        public override T Resolve<T>() => this.container.GetInstance<T>();

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();

            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
            this.RegisterAspNetCore();
        }

        private void RegisterAspNetCore()
        {
            this.container.CreateServiceProvider(this.CreateServiceCollection());
        }

        public override void PrepareBasic()
        {
            this.container = new ServiceContainer();
            this.RegisterBasic();
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterInterceptor()
        {
            this.container.Intercept(sr => sr.ServiceType == typeof(ICalculator1), factory => new LightInjectInterceptionLogger());
            this.container.Intercept(sr => sr.ServiceType == typeof(ICalculator2), factory => new LightInjectInterceptionLogger());
            this.container.Intercept(sr => sr.ServiceType == typeof(ICalculator3), factory => new LightInjectInterceptionLogger());
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne, DummyOne>();
            this.container.Register<IDummyTwo, DummyTwo>();
            this.container.Register<IDummyThree, DummyThree>();
            this.container.Register<IDummyFour, DummyFour>();
            this.container.Register<IDummyFive, DummyFive>();
            this.container.Register<IDummySix, DummySix>();
            this.container.Register<IDummySeven, DummySeven>();
            this.container.Register<IDummyEight, DummyEight>();
            this.container.Register<IDummyNine, DummyNine>();
            this.container.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton1, Singleton1>(new PerContainerLifetime());
            this.container.Register<ISingleton2, Singleton2>(new PerContainerLifetime());
            this.container.Register<ISingleton3, Singleton3>(new PerContainerLifetime());
            this.container.Register<ITransient1, Transient1>();
            this.container.Register<ITransient2, Transient2>();
            this.container.Register<ITransient3, Transient3>();
            this.container.Register<ICombined1, Combined1>();
            this.container.Register<ICombined2, Combined2>();
            this.container.Register<ICombined3, Combined3>();
            this.container.Register<ICalculator1, Calculator1>();
            this.container.Register<ICalculator2, Calculator2>();
            this.container.Register<ICalculator3, Calculator3>();
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>(new PerContainerLifetime());
            this.container.Register<ISecondService, SecondService>(new PerContainerLifetime());
            this.container.Register<IThirdService, ThirdService>(new PerContainerLifetime());

            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            
            this.container.Register<IComplex1, Complex1>();
            this.container.Register<IComplex2, Complex2>();
            this.container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA, ServiceA>(new PerContainerLifetime());
            this.container.Register<IServiceB, ServiceB>(new PerContainerLifetime());
            this.container.Register<IServiceC, ServiceC>(new PerContainerLifetime());
            this.container.Register<ISubObjectA, SubObjectA>();
            this.container.Register<ISubObjectB, SubObjectB>();
            this.container.Register<ISubObjectC, SubObjectC>();
            this.container.Register<IComplexPropertyObject1, ComplexPropertyObject1>();
            this.container.Register<IComplexPropertyObject2, ComplexPropertyObject2>();
            this.container.Register<IComplexPropertyObject3, ComplexPropertyObject3>();                                                
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.container.Register<IExportConditionInterface, ExportConditionalObject1>("ExportConditionalObject1");
            this.container.Register<IExportConditionInterface, ExportConditionalObject2>("ExportConditionalObject2");
            this.container.Register<IExportConditionInterface, ExportConditionalObject3>("ExportConditionalObject3");
            this.container.Register(f => new ImportConditionObject1(f.GetInstance<IExportConditionInterface>("ExportConditionalObject1")));
            this.container.Register(f => new ImportConditionObject2(f.GetInstance<IExportConditionInterface>("ExportConditionalObject2")));
            this.container.Register(f => new ImportConditionObject3(f.GetInstance<IExportConditionInterface>("ExportConditionalObject3")));
        }

        private void RegisterMultiple()
        {
            this.container.Register<ImportMultiple1>();
            this.container.Register<ImportMultiple2>();
            this.container.Register<ImportMultiple3>();
            this.container.Register<ISimpleAdapter, SimpleAdapterOne>("SimpleAdapterOne");
            this.container.Register<ISimpleAdapter, SimpleAdapterTwo>("SimpleAdapterTwo");
            this.container.Register<ISimpleAdapter, SimpleAdapterThree>("SimpleAdapterThree");
            this.container.Register<ISimpleAdapter, SimpleAdapterFour>("SimpleAdapterFour");
            this.container.Register<ISimpleAdapter, SimpleAdapterFive>("SimpleAdapterFive");
        }
    }
}