using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Models.IoC;

namespace IocPerformance.Adapters
{
    public sealed class MugenMvvmToolkitContainerAdapter : ContainerAdapterBase
    {
        private MugenContainer container;

        public MugenMvvmToolkitContainerAdapter()
        {
            if (ServiceProvider.ReflectionManager == null)
            {
                ServiceProvider.ReflectionManager = new ExpressionReflectionManager();
            }
        }

        public override string Name => "Mugen MVVM Toolkit";

        public override string PackageName => "MugenMvvmToolkit";

        public override string Url => "https://github.com/MugenMvvmToolkit/MugenMvvmToolkit";

        public override bool SupportsConditional => false;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportGeneric => false;

        public override bool SupportsMultiple => true;

        public override bool SupportsInterception => false;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => false;

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            IIocContainer childContainer = this.container.CreateChild();

            return new MugenMvvmToolkitChildContainerAdapter(childContainer);
        }

        public override object Resolve(Type type) => this.container.Get(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
        }

        public override void PrepareBasic()
        {
            this.container = new MugenContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Bind<IDummyOne, DummyOne>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyTwo, DummyTwo>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyThree, DummyThree>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyFour, DummyFour>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyFive, DummyFive>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummySix, DummySix>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummySeven, DummySeven>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyEight, DummyEight>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyNine, DummyNine>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IDummyTen, DummyTen>(DependencyLifecycle.TransientInstance);
        }

        private void RegisterStandard()
        {
            this.container.Bind<ISingleton1, Singleton1>(DependencyLifecycle.SingleInstance);
            this.container.Bind<ISingleton2, Singleton2>(DependencyLifecycle.SingleInstance);
            this.container.Bind<ISingleton3, Singleton3>(DependencyLifecycle.SingleInstance);
            this.container.Bind<ITransient1, Transient1>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ITransient2, Transient2>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ITransient3, Transient3>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ICombined1, Combined1>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ICombined2, Combined2>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ICombined3, Combined3>(DependencyLifecycle.TransientInstance);
        }

        private void RegisterComplex()
        {
            this.container.Bind<IFirstService, FirstService>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISecondService, SecondService>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IThirdService, ThirdService>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISubObjectOne, SubObjectOne>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISubObjectTwo, SubObjectTwo>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISubObjectThree, SubObjectThree>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IComplex1, Complex1>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IComplex2, Complex2>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IComplex3, Complex3>(DependencyLifecycle.TransientInstance);
        }

        private void RegisterPropertyInjection()
        {
            this.container.Bind<IComplexPropertyObject1, ComplexPropertyObject1>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IComplexPropertyObject2, ComplexPropertyObject2>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IComplexPropertyObject3, ComplexPropertyObject3>(DependencyLifecycle.TransientInstance);
            this.container.Bind<IServiceA, ServiceA>(DependencyLifecycle.SingleInstance);
            this.container.Bind<IServiceB, ServiceB>(DependencyLifecycle.SingleInstance);
            this.container.Bind<IServiceC, ServiceC>(DependencyLifecycle.SingleInstance);
            this.container.Bind<ISubObjectA, SubObjectA>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISubObjectB, SubObjectB>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISubObjectC, SubObjectC>(DependencyLifecycle.TransientInstance);
        }

        private void RegisterMultiple()
        {
            // multiple exports
            this.container.Bind<ISimpleAdapter, SimpleAdapterOne>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISimpleAdapter, SimpleAdapterTwo>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISimpleAdapter, SimpleAdapterThree>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISimpleAdapter, SimpleAdapterFour>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ISimpleAdapter, SimpleAdapterFive>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ImportMultiple1, ImportMultiple1>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ImportMultiple2, ImportMultiple2>(DependencyLifecycle.TransientInstance);
            this.container.Bind<ImportMultiple3, ImportMultiple3>(DependencyLifecycle.TransientInstance);
        }
    }

    public class MugenMvvmToolkitChildContainerAdapter : IChildContainerAdapter
    {
        private readonly IIocContainer childContainer;

        public MugenMvvmToolkitChildContainerAdapter(IIocContainer childContainer)
        {
            this.childContainer = childContainer;
        }

        public void Dispose()
        {
            this.childContainer.Dispose();
        }

        public void Prepare()
        {
            this.childContainer.Bind<ITransient1, ScopedTransient>(DependencyLifecycle.TransientInstance);
            this.childContainer.Bind<ICombined1, ScopedCombined1>(DependencyLifecycle.SingleInstance);
            this.childContainer.Bind<ICombined2, ScopedCombined2>(DependencyLifecycle.SingleInstance);
            this.childContainer.Bind<ICombined3, ScopedCombined3>(DependencyLifecycle.SingleInstance);
        }

        public object Resolve(Type resolveType) => this.childContainer.Get(resolveType);
    }
}
