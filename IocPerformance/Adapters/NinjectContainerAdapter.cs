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
		    return new NInjectChildContainerAdapter(new ChildKernel(container));
	    }

	    public override object Resolve(Type type)
        {
            return this.container.Get(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
			   this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new StandardKernel();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplexObject();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
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
            this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            this.container.Bind<ITransient>().To<Transient>().InTransientScope();
            this.container.Bind<ICombined>().To<Combined>().InTransientScope();
        }

        private void RegisterComplexObject()
        {
            this.container.Bind<IFirstService>().To<FirstService>().InSingletonScope();
            this.container.Bind<ISecondService>().To<SecondService>().InSingletonScope();
            this.container.Bind<IThirdService>().To<ThirdService>().InSingletonScope();
            this.container.Bind<ISubObjectA>().To<SubObjectA>().InTransientScope();
            this.container.Bind<ISubObjectB>().To<SubObjectB>().InTransientScope();
            this.container.Bind<ISubObjectC>().To<SubObjectC>().InTransientScope();
            this.container.Bind<IComplex>().To<Complex>().InTransientScope();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Bind<IComplexPropertyObject>().To<ComplexPropertyObject>().InTransientScope();
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
            this.container.Bind<ImportConditionObject>().To<ImportConditionObject>().InTransientScope();
            this.container.Bind<ImportConditionObject2>().To<ImportConditionObject2>().InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                        .To<ExportConditionalObject>()
                        .WhenInjectedInto<ImportConditionObject>()
                        .InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                        .To<ExportConditionalObject2>()
                        .WhenInjectedInto<ImportConditionObject2>()
                        .InTransientScope();
        }

        private void RegisterMultiple()
        {
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterOne>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterTwo>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterThree>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFour>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFive>().InTransientScope();
            this.container.Bind<ImportMultiple>().To<ImportMultiple>().InTransientScope();
        }

        private void RegisterInterceptor()
        {
            this.container.Bind<ICalculator>().To<Calculator>().InTransientScope()
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
			childKernel.Dispose();
		}

		public void Prepare()
		{
			childKernel.Bind<ITransient>().To<ScopedTransient>();
			childKernel.Bind<ICombined>().To<ScopedCombined>();
		}

		public object Resolve(Type resolveType)
		{
			return childKernel.Get(resolveType);
		}
	}
}