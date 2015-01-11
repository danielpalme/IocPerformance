using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
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
    public sealed class WindsorContainerAdapter : ContainerAdapterBase
    {
        private WindsorContainer container;

        public override string Name
        {
            get { return "Windsor"; }
        }

        public override string PackageName
        {
            get { return "Castle.Windsor"; }
        }

        public override string Url
        {
            get { return "http://castleproject.org"; }
        }

        public override bool SupportsPropertyInjection
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

        public override bool SupportsInterception
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
            WindsorContainer childContainer = new WindsorContainer();

            this.container.AddChildContainer(childContainer);

            return new WindsorChildContainerAdapter(childContainer);
        }

        public override void Prepare()
        {
            this.PrepareBasic();            
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }

        public override void PrepareBasic()
        {
            this.container = new WindsorContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplexType();
        }

        private void RegisterDummies()
        {
            this.container.Register(Component.For<IDummyOne>().ImplementedBy<DummyOne>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyTwo>().ImplementedBy<DummyTwo>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyThree>().ImplementedBy<DummyThree>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyFour>().ImplementedBy<DummyFour>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyFive>().ImplementedBy<DummyFive>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummySix>().ImplementedBy<DummySix>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummySeven>().ImplementedBy<DummySeven>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyEight>().ImplementedBy<DummyEight>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyNine>().ImplementedBy<DummyNine>().LifeStyle.Transient);
            this.container.Register(Component.For<IDummyTen>().ImplementedBy<DummyTen>().LifeStyle.Transient);
        }

        private void RegisterStandard()
        {
            this.container.Register(Component.For<ISingleton1>().ImplementedBy<Singleton1>());
            this.container.Register(Component.For<ISingleton2>().ImplementedBy<Singleton2>());
            this.container.Register(Component.For<ISingleton3>().ImplementedBy<Singleton3>());
            this.container.Register(Component.For<ITransient1>().ImplementedBy<Transient1>().LifeStyle.Transient);
            this.container.Register(Component.For<ITransient2>().ImplementedBy<Transient2>().LifeStyle.Transient);
            this.container.Register(Component.For<ITransient3>().ImplementedBy<Transient3>().LifeStyle.Transient);
            this.container.Register(Component.For<ICombined1>().ImplementedBy<Combined1>().LifeStyle.Transient);
            this.container.Register(Component.For<ICombined2>().ImplementedBy<Combined2>().LifeStyle.Transient);
            this.container.Register(Component.For<ICombined3>().ImplementedBy<Combined3>().LifeStyle.Transient);
        }

        private void RegisterComplexType()
        {
            this.container.Register(Component.For<IFirstService>().ImplementedBy<FirstService>());
            this.container.Register(Component.For<ISecondService>().ImplementedBy<SecondService>());
            this.container.Register(Component.For<IThirdService>().ImplementedBy<ThirdService>());
            this.container.Register(Component.For<ISubObjectOne>().ImplementedBy<SubObjectOne>().LifeStyle.Transient);
            this.container.Register(Component.For<ISubObjectTwo>().ImplementedBy<SubObjectTwo>().LifeStyle.Transient);
            this.container.Register(Component.For<ISubObjectThree>().ImplementedBy<SubObjectThree>().LifeStyle.Transient);
            this.container.Register(Component.For<IComplex1>().ImplementedBy<Complex1>().LifeStyle.Transient);
            this.container.Register(Component.For<IComplex2>().ImplementedBy<Complex2>().LifeStyle.Transient);
            this.container.Register(Component.For<IComplex3>().ImplementedBy<Complex3>().LifeStyle.Transient);
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register(Component.For<IServiceA>().ImplementedBy<ServiceA>());
            this.container.Register(Component.For<IServiceB>().ImplementedBy<ServiceB>());
            this.container.Register(Component.For<IServiceC>().ImplementedBy<ServiceC>());

            this.container.Register(Component.For<ISubObjectA>().ImplementedBy<SubObjectA>().LifeStyle.Transient);
            this.container.Register(Component.For<ISubObjectB>().ImplementedBy<SubObjectB>().LifeStyle.Transient);
            this.container.Register(Component.For<ISubObjectC>().ImplementedBy<SubObjectC>().LifeStyle.Transient);

            this.container.Register(Component.For<IComplexPropertyObject1>().ImplementedBy<ComplexPropertyObject1>().LifeStyle.Transient);
            this.container.Register(Component.For<IComplexPropertyObject2>().ImplementedBy<ComplexPropertyObject2>().LifeStyle.Transient);
            this.container.Register(Component.For<IComplexPropertyObject3>().ImplementedBy<ComplexPropertyObject3>().LifeStyle.Transient);
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(Component.For(typeof(IGenericInterface<>)).ImplementedBy(typeof(GenericExport<>)).LifeStyle.Transient);

            this.container.Register(Component.For(typeof(ImportGeneric<>)).ImplementedBy(typeof(ImportGeneric<>)).LifeStyle.Transient);
        }

        private void RegisterMultiple()
        {
            this.container.Kernel.Resolver.AddSubResolver(new CollectionResolver(this.container.Kernel, true));

            this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterOne>().LifeStyle.Transient);
            this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterTwo>().LifeStyle.Transient);
            this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterThree>().LifeStyle.Transient);
            this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterFour>().LifeStyle.Transient);
            this.container.Register(Component.For<ISimpleAdapter>().ImplementedBy<SimpleAdapterFive>().LifeStyle.Transient);

            this.container.Register(Component.For<ImportMultiple1>().LifeStyle.Transient);
            this.container.Register(Component.For<ImportMultiple2>().LifeStyle.Transient);
            this.container.Register(Component.For<ImportMultiple3>().LifeStyle.Transient);
        }

        private void RegisterInterceptor()
        {
            this.container.Register(Component.For<WindsorInterceptionLogger>());
            this.container.Register(
                Component.For<ICalculator1>().ImplementedBy<Calculator1>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
            this.container.Register(
                Component.For<ICalculator2>().ImplementedBy<Calculator2>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
            this.container.Register(
                Component.For<ICalculator3>().ImplementedBy<Calculator3>().Interceptors<WindsorInterceptionLogger>().LifeStyle.Transient);
        }
    }

    public class WindsorChildContainerAdapter : IChildContainerAdapter
    {
        private IWindsorContainer container;

        public WindsorChildContainerAdapter(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public void Prepare()
        {
            this.container.Register(Component.For<ITransient1>().ImplementedBy<ScopedTransient>());
            this.container.Register(Component.For<ICombined1>().ImplementedBy<ScopedCombined1>());
            this.container.Register(Component.For<ICombined2>().ImplementedBy<ScopedCombined2>());
            this.container.Register(Component.For<ICombined3>().ImplementedBy<ScopedCombined3>());
        }

        public object Resolve(Type resolveType)
        {
            return this.container.Resolve(resolveType);
        }
    }
}