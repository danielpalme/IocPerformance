using System;
using System.Collections.Generic;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Unity;
using Unity.Injection;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;

namespace IocPerformance.Adapters
{
    public sealed class UnityContainerAdapter : ContainerAdapterBase
    {
        private UnityContainer container;

        public override string PackageName => "Unity";

        public override string Url => "https://github.com/unitycontainer/unity";

        // public override bool SupportsInterception => true;

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
            // this.container.AddNewExtension<Unity.Interception.ContainerIntegration.Interception>();

            this.RegisterBasic();
            this.RegisterOpenGeneric();
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
            this.RegisterConditional();
            this.RegisterAspCore();
            // this.RegisterInterceptor();
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
            this.container.RegisterType<ISingleton1>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new Singleton1()));
            this.container.RegisterType<ISingleton2>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new Singleton2()));
            this.container.RegisterType<ISingleton3>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new Singleton3()));
            this.container.RegisterType<ITransient1>(new InjectionFactory(c => new Transient1()));
            this.container.RegisterType<ITransient2>(new InjectionFactory(c => new Transient2()));
            this.container.RegisterType<ITransient3>(new InjectionFactory(c => new Transient3()));
            this.container.RegisterType<ICombined1>(new InjectionFactory(c => new Combined1(c.Resolve<ISingleton1>(), c.Resolve<ITransient1>())));
            this.container.RegisterType<ICombined2>(new InjectionFactory(c => new Combined2(c.Resolve<ISingleton2>(), c.Resolve<ITransient2>())));
            this.container.RegisterType<ICombined3>(new InjectionFactory(c => new Combined3(c.Resolve<ISingleton3>(), c.Resolve<ITransient3>())));
        }

        private void RegisterComplex()
        {
            this.container.RegisterType<IFirstService>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new FirstService()));
            this.container.RegisterType<ISecondService>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new SecondService()));
            this.container.RegisterType<IThirdService>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new ThirdService()));
            this.container.RegisterType<ISubObjectOne>(new InjectionFactory(c => new SubObjectOne(c.Resolve<IFirstService>())));
            this.container.RegisterType<ISubObjectTwo>(new InjectionFactory(c => new SubObjectTwo(c.Resolve<ISecondService>())));
            this.container.RegisterType<ISubObjectThree>(new InjectionFactory(c => new SubObjectThree(c.Resolve<IThirdService>())));
            this.container.RegisterType<IComplex1>(new InjectionFactory(c => new Complex1(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())));
            this.container.RegisterType<IComplex2>(new InjectionFactory(c => new Complex2(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())));
            this.container.RegisterType<IComplex3>(new InjectionFactory(c => new Complex3(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())));
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterType<IServiceA>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new ServiceA()));
            this.container.RegisterType<IServiceB>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new ServiceB()));
            this.container.RegisterType<IServiceC>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new ServiceC()));
            this.container.RegisterType<ISubObjectA>(new InjectionFactory(c => new SubObjectA { ServiceA = c.Resolve<IServiceA>() }));
            this.container.RegisterType<ISubObjectB>(new InjectionFactory(c => new SubObjectB { ServiceB = c.Resolve<IServiceB>() }));
            this.container.RegisterType<ISubObjectC>(new InjectionFactory(c => new SubObjectC { ServiceC = c.Resolve<IServiceC>() }));
            this.container.RegisterType<IComplexPropertyObject1>(new InjectionFactory(c => new ComplexPropertyObject1
            {
                ServiceA = c.Resolve<IServiceA>(),
                ServiceB = c.Resolve<IServiceB>(),
                ServiceC = c.Resolve<IServiceC>(),
                SubObjectA = c.Resolve<ISubObjectA>(),
                SubObjectB = c.Resolve<ISubObjectB>(),
                SubObjectC = c.Resolve<ISubObjectC>()
            }));
            this.container.RegisterType<IComplexPropertyObject2>(new InjectionFactory(c => new ComplexPropertyObject2
            {
                ServiceA = c.Resolve<IServiceA>(),
                ServiceB = c.Resolve<IServiceB>(),
                ServiceC = c.Resolve<IServiceC>(),
                SubObjectA = c.Resolve<ISubObjectA>(),
                SubObjectB = c.Resolve<ISubObjectB>(),
                SubObjectC = c.Resolve<ISubObjectC>()
            }));
            this.container.RegisterType<IComplexPropertyObject3>(new InjectionFactory(c => new ComplexPropertyObject3
            {
                ServiceA = c.Resolve<IServiceA>(),
                ServiceB = c.Resolve<IServiceB>(),
                ServiceC = c.Resolve<IServiceC>(),
                SubObjectA = c.Resolve<ISubObjectA>(),
                SubObjectB = c.Resolve<ISubObjectB>(),
                SubObjectC = c.Resolve<ISubObjectC>()
            }));
        }

        private void RegisterMultiple()
        {
            this.container.RegisterType<IEnumerable<ISimpleAdapter>, ISimpleAdapter[]>();

            this.container.RegisterType<ISimpleAdapter>("one", new InjectionFactory(c => new SimpleAdapterOne()));
            this.container.RegisterType<ISimpleAdapter>("two", new InjectionFactory(c => new SimpleAdapterTwo()));
            this.container.RegisterType<ISimpleAdapter>("three", new InjectionFactory(c => new SimpleAdapterThree()));
            this.container.RegisterType<ISimpleAdapter>("four", new InjectionFactory(c => new SimpleAdapterFour()));
            this.container.RegisterType<ISimpleAdapter>("five", new InjectionFactory(c => new SimpleAdapterFive()));

            this.container.RegisterType<ImportMultiple1>(new InjectionFactory(c => new ImportMultiple1(c.Resolve<IEnumerable<ISimpleAdapter>>())));
            this.container.RegisterType<ImportMultiple2>(new InjectionFactory(c => new ImportMultiple2(c.Resolve<IEnumerable<ISimpleAdapter>>())));
            this.container.RegisterType<ImportMultiple3>(new InjectionFactory(c => new ImportMultiple3(c.Resolve<IEnumerable<ISimpleAdapter>>())));
        }

        private void RegisterConditional()
        {
            this.container.RegisterType<IExportConditionInterface>("ExportConditionalObject1", new InjectionFactory(c => new ExportConditionalObject1()));
            this.container.RegisterType<IExportConditionInterface>("ExportConditionalObject2", new InjectionFactory(c => new ExportConditionalObject2()));
            this.container.RegisterType<IExportConditionInterface>("ExportConditionalObject3", new InjectionFactory(c => new ExportConditionalObject3()));
            this.container.RegisterType<ImportConditionObject1>(new InjectionFactory(c => new ImportConditionObject1(c.Resolve<IExportConditionInterface>("ExportConditionalObject1"))));
            this.container.RegisterType<ImportConditionObject2>(new InjectionFactory(c => new ImportConditionObject2(c.Resolve<IExportConditionInterface>("ExportConditionalObject2"))));
            this.container.RegisterType<ImportConditionObject3>(new InjectionFactory(c => new ImportConditionObject3(c.Resolve<IExportConditionInterface>("ExportConditionalObject3"))));
        }

        private void RegisterAspCore()
        {
            var factory = new ServiceProviderFactory(this.container);
            var builder = factory.CreateBuilder(this.CreateServiceCollection());
            this.container = (IUnityContainer)factory.CreateServiceProvider(builder)
                                                     .GetService(typeof(IUnityContainer));
        }

        // This should be called when all other tests are done before Interception is tested
        private void RegisterInterceptor()
        {
            this.container.RegisterType<ICalculator1, Calculator1>()
                .Configure<Unity.Interception.ContainerIntegration.Interception>()
                .SetInterceptorFor<ICalculator1>(new InterfaceInterceptor());
            this.container.RegisterType<ICalculator2, Calculator2>()
                .Configure<Unity.Interception.ContainerIntegration.Interception>()
                .SetInterceptorFor<ICalculator2>(new InterfaceInterceptor());
            this.container.RegisterType<ICalculator3, Calculator3>()
                .Configure<Unity.Interception.ContainerIntegration.Interception>()
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
            this.childContainer.RegisterType(typeof(ICombined1), typeof(ScopedCombined1));
            this.childContainer.RegisterType(typeof(ICombined2), typeof(ScopedCombined2));
            this.childContainer.RegisterType(typeof(ICombined3), typeof(ScopedCombined3));
            this.childContainer.RegisterType(typeof(ITransient1), typeof(ScopedTransient));
        }

        public object Resolve(Type resolveType) => this.childContainer.Resolve(type, null, null);
    }
}
