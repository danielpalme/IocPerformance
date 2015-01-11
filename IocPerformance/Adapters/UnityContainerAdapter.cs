using System;
using System.Collections.Generic;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IocPerformance.Adapters
{
    public sealed class UnityContainerAdapter : ContainerAdapterBase
    {
        private UnityContainer container;

        public override string PackageName
        {
            get { return "Unity"; }
        }

        public override string Url
        {
            get { return "http://msdn.microsoft.com/unity"; }
        }

        public override bool SupportsInterception
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


        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container == null)
                return;
            this.container.Dispose();
            this.container = null;
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new UnityChildContainerAdapter(this.container.CreateChildContainer());
        }

        public override void Prepare()
        {
            this.container = new UnityContainer();
            this.container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();

            RegisterBasic();
            
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }

        public override void PrepareBasic()
        {
            this.container = new UnityContainer();
            RegisterBasic();
        }
        
        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.RegisterType<IDummyOne, DummyOne>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyTwo, DummyTwo>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyThree, DummyThree>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyFour, DummyFour>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyFive, DummyFive>(new TransientLifetimeManager());
            this.container.RegisterType<IDummySix, DummySix>(new TransientLifetimeManager());
            this.container.RegisterType<IDummySeven, DummySeven>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyEight, DummyEight>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyNine, DummyNine>(new TransientLifetimeManager());
            this.container.RegisterType<IDummyTen, DummyTen>(new TransientLifetimeManager());
        }

        private void RegisterStandard()
        {
            this.container.RegisterType<ISingleton1, Singleton1>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISingleton2, Singleton2>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISingleton3, Singleton3>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ITransient1, Transient1>(new TransientLifetimeManager());
            this.container.RegisterType<ITransient2, Transient2>(new TransientLifetimeManager());
            this.container.RegisterType<ITransient3, Transient3>(new TransientLifetimeManager());
            this.container.RegisterType<ICombined1, Combined1>(new TransientLifetimeManager());
            this.container.RegisterType<ICombined2, Combined2>(new TransientLifetimeManager());
            this.container.RegisterType<ICombined3, Combined3>(new TransientLifetimeManager());
        }

        private void RegisterComplex()
        {
            this.container.RegisterType<IFirstService, FirstService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISecondService, SecondService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IThirdService, ThirdService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISubObjectOne, SubObjectOne>(new TransientLifetimeManager());
            this.container.RegisterType<ISubObjectTwo, SubObjectTwo>(new TransientLifetimeManager());
            this.container.RegisterType<ISubObjectThree, SubObjectThree>(new TransientLifetimeManager());
            this.container.RegisterType<IComplex1, Complex1>(new TransientLifetimeManager());
            this.container.RegisterType<IComplex2, Complex2>(new TransientLifetimeManager());
            this.container.RegisterType<IComplex3, Complex3>(new TransientLifetimeManager());
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterType<IServiceA, ServiceA>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IServiceB, ServiceB>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IServiceC, ServiceC>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISubObjectA, SubObjectA>(new TransientLifetimeManager());
            this.container.RegisterType<ISubObjectB, SubObjectB>(new TransientLifetimeManager());
            this.container.RegisterType<ISubObjectC, SubObjectC>(new TransientLifetimeManager());
            this.container.RegisterType<IComplexPropertyObject1, ComplexPropertyObject1>(new TransientLifetimeManager());
            this.container.RegisterType<IComplexPropertyObject2, ComplexPropertyObject2>(new TransientLifetimeManager());
            this.container.RegisterType<IComplexPropertyObject3, ComplexPropertyObject3>(new TransientLifetimeManager());
        }

        private void RegisterMultiple()
        {
            this.container.RegisterType<IEnumerable<ISimpleAdapter>, ISimpleAdapter[]>();

            this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>("one", new TransientLifetimeManager());
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>("two", new TransientLifetimeManager());
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>("three", new TransientLifetimeManager());
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>("four", new TransientLifetimeManager());
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>("five", new TransientLifetimeManager());

            this.container.RegisterType<ImportMultiple1, ImportMultiple1>(new TransientLifetimeManager());
            this.container.RegisterType<ImportMultiple2, ImportMultiple2>(new TransientLifetimeManager());
            this.container.RegisterType<ImportMultiple3, ImportMultiple3>(new TransientLifetimeManager());
        }

        private void RegisterInterceptor()
        {
            this.container.RegisterType<ICalculator1, Calculator1>(new TransientLifetimeManager())
                .Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
                .SetInterceptorFor<ICalculator1>(new InterfaceInterceptor());
            this.container.RegisterType<ICalculator2, Calculator2>(new TransientLifetimeManager())
                .Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
                .SetInterceptorFor<ICalculator2>(new InterfaceInterceptor());
            this.container.RegisterType<ICalculator3, Calculator3>(new TransientLifetimeManager())
                .Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
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

        public object Resolve(Type resolveType)
        {
            return this.childContainer.Resolve(resolveType);
        }
    }
}