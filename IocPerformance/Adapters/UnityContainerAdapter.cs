using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Microsoft.Extensions.DependencyInjection;
using Unity;
using Unity.Injection;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;

namespace IocPerformance.Adapters
{
    public sealed class UnityContainerAdapter : ContainerAdapterBase
    {
        private IUnityContainer container;

        public override string PackageName => "Unity";

        public override string Url => "https://github.com/unitycontainer/unity";

        public override bool SupportsInterception => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsConditional => true;

        public override bool SupportAspNetCore => true;

        public override bool SupportsChildContainer => true;

        public override object Resolve(Type type) => container.Resolve(type, null, null);

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

        public override IChildContainerAdapter CreateChildContainerAdapter() => new UnityChildContainerAdapter(this.container.CreateChildContainer());

        public override void Prepare()
        {
            this.container = new UnityContainer();
            this.container.AddNewExtension<Unity.Interception.Interception>();

            this.RegisterBasic();
            this.RegisterOpenGeneric();
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
            this.RegisterConditional();
            this.RegisterAspCore();
            this.RegisterInterceptor();
        }

        public override void PrepareBasic()
        {
            this.container = new UnityContainer();
            this.RegisterBasic();
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterOpenGeneric()
        {
            this.container.RegisterType(typeof(ImportGeneric<>));
            this.container.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>));
        }

        private void RegisterDummies()
        {
            this.container.RegisterType<IDummyOne, DummyOne>();
            this.container.RegisterType<IDummyTwo, DummyTwo>();
            this.container.RegisterType<IDummyThree, DummyThree>();
            this.container.RegisterType<IDummyFour, DummyFour>();
            this.container.RegisterType<IDummyFive, DummyFive>();
            this.container.RegisterType<IDummySix, DummySix>();
            this.container.RegisterType<IDummySeven, DummySeven>();
            this.container.RegisterType<IDummyEight, DummyEight>();
            this.container.RegisterType<IDummyNine, DummyNine>();
            this.container.RegisterType<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.RegisterType<ISingleton1, Singleton1>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISingleton2, Singleton2>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISingleton3, Singleton3>(new ContainerControlledLifetimeManager());

            this.container.RegisterType<ITransient1, Transient1>();
            this.container.RegisterType<ITransient2, Transient2>();
            this.container.RegisterType<ITransient3, Transient3>();

            this.container.RegisterType<ICombined1, Combined1>();
            this.container.RegisterType<ICombined2, Combined2>();
            this.container.RegisterType<ICombined3, Combined3>();
        }

        private void RegisterComplex()
        {
            this.container.RegisterType<IFirstService, FirstService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISecondService, SecondService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IThirdService, ThirdService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISubObjectOne, SubObjectOne>();
            this.container.RegisterType<ISubObjectTwo, SubObjectTwo>();
            this.container.RegisterType<ISubObjectThree, SubObjectThree>();
            this.container.RegisterType<IComplex1, Complex1>();
            this.container.RegisterType<IComplex2, Complex2>();
            this.container.RegisterType<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterType<IServiceA, ServiceA>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IServiceB, ServiceB>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IServiceC, ServiceC>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISubObjectA, SubObjectA>(new InjectionConstructor(), new InjectionProperty(nameof(SubObjectA.ServiceA)));
            this.container.RegisterType<ISubObjectB, SubObjectB>(new InjectionConstructor(), new InjectionProperty(nameof(SubObjectB.ServiceB)));
            this.container.RegisterType<ISubObjectC, SubObjectC>(new InjectionConstructor(), new InjectionProperty(nameof(SubObjectC.ServiceC)));
            this.container.RegisterType<IComplexPropertyObject1, ComplexPropertyObject1>(
                new InjectionConstructor(),
                new InjectionProperty(nameof(ComplexPropertyObject1.ServiceA)),
                new InjectionProperty(nameof(ComplexPropertyObject1.ServiceB)),
                new InjectionProperty(nameof(ComplexPropertyObject1.ServiceC)),
                new InjectionProperty(nameof(ComplexPropertyObject1.SubObjectA)),
                new InjectionProperty(nameof(ComplexPropertyObject1.SubObjectB)),
                new InjectionProperty(nameof(ComplexPropertyObject1.SubObjectC)));
            this.container.RegisterType<IComplexPropertyObject2, ComplexPropertyObject2>(
                new InjectionConstructor(),
                new InjectionProperty(nameof(ComplexPropertyObject2.ServiceA)),
                new InjectionProperty(nameof(ComplexPropertyObject2.ServiceB)),
                new InjectionProperty(nameof(ComplexPropertyObject2.ServiceC)),
                new InjectionProperty(nameof(ComplexPropertyObject2.SubObjectA)),
                new InjectionProperty(nameof(ComplexPropertyObject2.SubObjectB)),
                new InjectionProperty(nameof(ComplexPropertyObject2.SubObjectC)));
            this.container.RegisterType<IComplexPropertyObject3, ComplexPropertyObject3>(
                new InjectionConstructor(),
                new InjectionProperty(nameof(ComplexPropertyObject3.ServiceA)),
                new InjectionProperty(nameof(ComplexPropertyObject3.ServiceB)),
                new InjectionProperty(nameof(ComplexPropertyObject3.ServiceC)),
                new InjectionProperty(nameof(ComplexPropertyObject3.SubObjectA)),
                new InjectionProperty(nameof(ComplexPropertyObject3.SubObjectB)),
                new InjectionProperty(nameof(ComplexPropertyObject3.SubObjectC)));
        }

        private void RegisterMultiple()
        {
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>("one");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>("two");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>("three");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>("four");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>("five");

            this.container.RegisterType<ImportMultiple1, ImportMultiple1>();
            this.container.RegisterType<ImportMultiple2, ImportMultiple2>();
            this.container.RegisterType<ImportMultiple3, ImportMultiple3>();
        }

        private void RegisterConditional()
        {
            this.container.RegisterType<IExportConditionInterface, ExportConditionalObject1>("ExportConditionalObject1");
            this.container.RegisterType<IExportConditionInterface, ExportConditionalObject2>("ExportConditionalObject2");
            this.container.RegisterType<IExportConditionInterface, ExportConditionalObject3>("ExportConditionalObject3");
            this.container.RegisterType<ImportConditionObject1>(new InjectionConstructor(new ResolvedParameter<IExportConditionInterface>("ExportConditionalObject1")));
            this.container.RegisterType<ImportConditionObject2>(new InjectionConstructor(new ResolvedParameter<IExportConditionInterface>("ExportConditionalObject2")));
            this.container.RegisterType<ImportConditionObject3>(new InjectionConstructor(new ResolvedParameter<IExportConditionInterface>("ExportConditionalObject3")));
        }

        private void RegisterAspCore()
        {
            ServiceCollection services = new ServiceCollection();
            this.RegisterAspNetCoreClasses(services);

            var adapter = Unity.Microsoft.DependencyInjection.ServiceProviderExtensions.BuildServiceProvider(this.container, services);
            this.container = (IUnityContainer)adapter.GetService(typeof(IUnityContainer));
            container.RegisterInstance(adapter);
        }

        // This should be called when all other tests are done before Interception is tested
        private void RegisterInterceptor()
        {
            this.container.RegisterType<ICalculator1, Calculator1>()
                .Configure<Unity.Interception.Interception>()
                .SetInterceptorFor<ICalculator1>(new InterfaceInterceptor());
            this.container.RegisterType<ICalculator2, Calculator2>()
                .Configure<Unity.Interception.Interception>()
                .SetInterceptorFor<ICalculator2>(new InterfaceInterceptor());
            this.container.RegisterType<ICalculator3, Calculator3>()
                .Configure<Unity.Interception.Interception>()
                .SetInterceptorFor<ICalculator3>(new InterfaceInterceptor());
        }
    }

    public class UnityChildContainerAdapter : IChildContainerAdapter
    {
        private IUnityContainer childContainer;

        public UnityChildContainerAdapter(IUnityContainer childContainer)
        {
            this.childContainer = childContainer;
        }

        public void Dispose()
        {
            this.childContainer.Dispose();
        }

        public void Prepare()
        {
            childContainer.RegisterType<ITransient1, ScopedTransient>();

            childContainer.RegisterType<ICombined1, ScopedCombined1>();
            childContainer.RegisterType<ICombined2, ScopedCombined2>();
            childContainer.RegisterType<ICombined3, ScopedCombined3>();
        }

        public object Resolve(Type resolveType) => this.childContainer.Resolve(resolveType, null, null);
    }
}
