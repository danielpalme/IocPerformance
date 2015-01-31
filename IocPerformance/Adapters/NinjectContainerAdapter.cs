using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace IocPerformance.Adapters
{
    public sealed class NinjectContainerAdapter : ContainerAdapterBase
    {
        private StandardKernel container;

        public override string PackageName
        {
            get { return "Ninject"; }
        }

        public override string Url
        {
            get { return "http://ninject.org"; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsConditional
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportsChildContainer
        {
            get { return true; }
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new NInjectChildContainerAdapter(new ChildKernel(this.container));
        }

        public override object Resolve(Type type)
        {
            return this.container.Get(type);
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

        public override void Prepare()
        {
            this.PrepareBasic();            
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }

        public override void PrepareBasic()
        {
            this.container = new StandardKernel();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplexObject();
        }

        private void RegisterDummies()
        {
            this.container.Bind<IDummyOne>().To<DummyOne>().InTransientScope();
            this.container.Bind<IDummyTwo>().To<DummyTwo>().InTransientScope();
            this.container.Bind<IDummyThree>().To<DummyThree>().InTransientScope();
            this.container.Bind<IDummyFour>().To<DummyFour>().InTransientScope();
            this.container.Bind<IDummyFive>().To<DummyFive>().InTransientScope();
            this.container.Bind<IDummySix>().To<DummySix>().InTransientScope();
            this.container.Bind<IDummySeven>().To<DummySeven>().InTransientScope();
            this.container.Bind<IDummyEight>().To<DummyEight>().InTransientScope();
            this.container.Bind<IDummyNine>().To<DummyNine>().InTransientScope();
            this.container.Bind<IDummyTen>().To<DummyTen>().InTransientScope();
        }

        private void RegisterStandard()
        {
            this.container.Bind<ISingleton1>().To<Singleton1>().InSingletonScope();
            this.container.Bind<ISingleton2>().To<Singleton2>().InSingletonScope();
            this.container.Bind<ISingleton3>().To<Singleton3>().InSingletonScope();
            this.container.Bind<ITransient1>().To<Transient1>().InTransientScope();
            this.container.Bind<ITransient2>().To<Transient2>().InTransientScope();
            this.container.Bind<ITransient3>().To<Transient3>().InTransientScope();
            this.container.Bind<ICombined1>().To<Combined1>().InTransientScope();
            this.container.Bind<ICombined2>().To<Combined2>().InTransientScope();
            this.container.Bind<ICombined3>().To<Combined3>().InTransientScope();
        }

        private void RegisterComplexObject()
        {
            this.container.Bind<IFirstService>().To<FirstService>().InSingletonScope();
            this.container.Bind<ISecondService>().To<SecondService>().InSingletonScope();
            this.container.Bind<IThirdService>().To<ThirdService>().InSingletonScope();
            this.container.Bind<ISubObjectA>().To<SubObjectA>().InTransientScope();
            this.container.Bind<ISubObjectB>().To<SubObjectB>().InTransientScope();
            this.container.Bind<ISubObjectC>().To<SubObjectC>().InTransientScope();
            this.container.Bind<IComplex1>().To<Complex1>().InTransientScope();
            this.container.Bind<IComplex2>().To<Complex2>().InTransientScope();
            this.container.Bind<IComplex3>().To<Complex3>().InTransientScope();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Bind<IComplexPropertyObject1>().To<ComplexPropertyObject1>().InTransientScope();
            this.container.Bind<IComplexPropertyObject2>().To<ComplexPropertyObject2>().InTransientScope();
            this.container.Bind<IComplexPropertyObject3>().To<ComplexPropertyObject3>().InTransientScope();
            this.container.Bind<IServiceA>().To<ServiceA>().InSingletonScope();
            this.container.Bind<IServiceB>().To<ServiceB>().InSingletonScope();
            this.container.Bind<IServiceC>().To<ServiceC>().InSingletonScope();
            this.container.Bind<ISubObjectOne>().To<SubObjectOne>().InTransientScope();
            this.container.Bind<ISubObjectTwo>().To<SubObjectTwo>().InTransientScope();
            this.container.Bind<ISubObjectThree>().To<SubObjectThree>().InTransientScope();
        }

        private void RegisterOpenGeneric()
        {
            this.container.Bind(typeof(IGenericInterface<>)).To(typeof(GenericExport<>)).InTransientScope();
            this.container.Bind(typeof(ImportGeneric<>)).To(typeof(ImportGeneric<>)).InTransientScope();
        }

        private void RegisterConditional()
        {
            this.container.Bind<ImportConditionObject1>().To<ImportConditionObject1>().InTransientScope();
            this.container.Bind<ImportConditionObject2>().To<ImportConditionObject2>().InTransientScope();
            this.container.Bind<ImportConditionObject3>().To<ImportConditionObject3>().InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                .To<ExportConditionalObject>()
                .WhenInjectedInto<ImportConditionObject1>()
                .InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                .To<ExportConditionalObject2>()
                .WhenInjectedInto<ImportConditionObject2>()
                .InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                .To<ExportConditionalObject3>()
                .WhenInjectedInto<ImportConditionObject3>()
                .InTransientScope();
        }

        private void RegisterMultiple()
        {
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterOne>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterTwo>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterThree>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFour>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFive>().InTransientScope();
            this.container.Bind<ImportMultiple1>().To<ImportMultiple1>().InTransientScope();
            this.container.Bind<ImportMultiple2>().To<ImportMultiple2>().InTransientScope();
            this.container.Bind<ImportMultiple3>().To<ImportMultiple3>().InTransientScope();
        }

        private void RegisterInterceptor()
        {
            this.container.Bind<ICalculator1>().To<Calculator1>().InTransientScope()
                .Intercept().With(new NinjectInterceptionLogger());
            this.container.Bind<ICalculator2>().To<Calculator2>().InTransientScope()
                .Intercept().With(new NinjectInterceptionLogger());
            this.container.Bind<ICalculator3>().To<Calculator3>().InTransientScope()
                .Intercept().With(new NinjectInterceptionLogger());
        }
    }

    public class NInjectChildContainerAdapter : IChildContainerAdapter
    {
        private ChildKernel childKernel;

        public NInjectChildContainerAdapter(ChildKernel childKernel)
        {
            this.childKernel = childKernel;
        }

        public void Dispose()
        {
            this.childKernel.Dispose();
        }

        public void Prepare()
        {
            this.childKernel.Bind<ITransient1>().To<ScopedTransient>();
            this.childKernel.Bind<ICombined1>().To<ScopedCombined1>();
            this.childKernel.Bind<ICombined2>().To<ScopedCombined2>();
            this.childKernel.Bind<ICombined3>().To<ScopedCombined3>();
        }

        public object Resolve(Type resolveType)
        {
            return this.childKernel.Get(resolveType);
        }
    }
}