// Ignored. Reason: Not installable in VS 2017 via Nuget
using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using TinyIoC;

namespace IocPerformance.Adapters
{
    public sealed class TinyIOCContainerAdapter : ContainerAdapterBase
    {
        private TinyIoCContainer container;

        public override string PackageName => "TinyIoC";

        public override string Url => "https://github.com/grumpydev/TinyIoC";

        /// <summary>
        /// I'm marking this as false because there's a bug in TinyIOC that makes the tests fail.
        /// </summary>
        public override bool SupportGeneric => false;

        /// <summary>
        /// I'm marking this as false because you have to register once using RegisterMultiple.
        /// Other containers allow you to register multiple interfaces separately and then resolves all known
        /// </summary>
        public override bool SupportsMultiple => false;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsChildContainer => true;

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override IChildContainerAdapter CreateChildContainerAdapter() => new TinyIoCChildContainerAdapter(this.container.GetChildContainer());

        public override void Prepare()
        {
            this.PrepareBasic();            
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
        }

         public override void PrepareBasic()
        {
            this.container = new TinyIoC.TinyIoCContainer();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne, DummyOne>().AsMultiInstance();
            this.container.Register<IDummyTwo, DummyTwo>().AsMultiInstance();
            this.container.Register<IDummyThree, DummyThree>().AsMultiInstance();
            this.container.Register<IDummyFour, DummyFour>().AsMultiInstance();
            this.container.Register<IDummyFive, DummyFive>().AsMultiInstance();
            this.container.Register<IDummySix, DummySix>().AsMultiInstance();
            this.container.Register<IDummySeven, DummySeven>().AsMultiInstance();
            this.container.Register<IDummyEight, DummyEight>().AsMultiInstance();
            this.container.Register<IDummyNine, DummyNine>().AsMultiInstance();
            this.container.Register<IDummyTen, DummyTen>().AsMultiInstance();
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton1, Singleton1>().AsSingleton();
            this.container.Register<ISingleton2, Singleton2>().AsSingleton();
            this.container.Register<ISingleton3, Singleton3>().AsSingleton();
            this.container.Register<ITransient1, Transient1>().AsMultiInstance();
            this.container.Register<ITransient2, Transient2>().AsMultiInstance();
            this.container.Register<ITransient3, Transient3>().AsMultiInstance();
            this.container.Register<ICombined1, Combined1>().AsMultiInstance();
            this.container.Register<ICombined2, Combined2>().AsMultiInstance();
            this.container.Register<ICombined3, Combined3>().AsMultiInstance();
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>().AsSingleton();
            this.container.Register<ISecondService, SecondService>().AsSingleton();
            this.container.Register<IThirdService, ThirdService>().AsSingleton();
            this.container.Register<ISubObjectOne, SubObjectOne>().AsMultiInstance();
            this.container.Register<ISubObjectTwo, SubObjectTwo>().AsMultiInstance();
            this.container.Register<ISubObjectThree, SubObjectThree>().AsMultiInstance();
            this.container.Register<IComplex1, Complex1>().AsMultiInstance();
            this.container.Register<IComplex2, Complex2>().AsMultiInstance();
            this.container.Register<IComplex3, Complex3>().AsMultiInstance();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA, ServiceA>().AsSingleton();
            this.container.Register<IServiceB, ServiceB>().AsSingleton();
            this.container.Register<IServiceC, ServiceC>().AsSingleton();
            this.container.Register<ISubObjectA>(
                (ioc, names) => new SubObjectA { ServiceA = ioc.Resolve<IServiceA>() });
            this.container.Register<ISubObjectB>(
                (ioc, names) => new SubObjectB { ServiceB = ioc.Resolve<IServiceB>() });
            this.container.Register<ISubObjectC>(
                (ioc, names) => new SubObjectC { ServiceC = ioc.Resolve<IServiceC>() });

            this.container.Register<IComplexPropertyObject1>(
                (ioc, names) => new ComplexPropertyObject1
                {
                    ServiceA = ioc.Resolve<IServiceA>(),
                    ServiceB = ioc.Resolve<IServiceB>(),
                    ServiceC = ioc.Resolve<IServiceC>(),
                    SubObjectA = ioc.Resolve<ISubObjectA>(),
                    SubObjectB = ioc.Resolve<ISubObjectB>(),
                    SubObjectC = ioc.Resolve<ISubObjectC>()
                });

            this.container.Register<IComplexPropertyObject2>(
                (ioc, names) => new ComplexPropertyObject2
                {
                    ServiceA = ioc.Resolve<IServiceA>(),
                    ServiceB = ioc.Resolve<IServiceB>(),
                    ServiceC = ioc.Resolve<IServiceC>(),
                    SubObjectA = ioc.Resolve<ISubObjectA>(),
                    SubObjectB = ioc.Resolve<ISubObjectB>(),
                    SubObjectC = ioc.Resolve<ISubObjectC>()
                });

            this.container.Register<IComplexPropertyObject3>(
                (ioc, names) => new ComplexPropertyObject3
                {
                    ServiceA = ioc.Resolve<IServiceA>(),
                    ServiceB = ioc.Resolve<IServiceB>(),
                    ServiceC = ioc.Resolve<IServiceC>(),
                    SubObjectA = ioc.Resolve<ISubObjectA>(),
                    SubObjectB = ioc.Resolve<ISubObjectB>(),
                    SubObjectC = ioc.Resolve<ISubObjectC>()
                });
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }
    }

    public class TinyIoCChildContainerAdapter : IChildContainerAdapter
    {
        private TinyIoCContainer childContainer;

        public TinyIoCChildContainerAdapter(TinyIoCContainer childContainer)
        {
            this.childContainer = childContainer;
        }

        public void Dispose()
        {
            this.childContainer.Dispose();
        }

        public void Prepare()
        {
            this.childContainer.Register(typeof(ICombined1), typeof(ScopedCombined1));
            this.childContainer.Register(typeof(ICombined2), typeof(ScopedCombined2));
            this.childContainer.Register(typeof(ICombined3), typeof(ScopedCombined3));
            this.childContainer.Register(typeof(ITransient1), typeof(ScopedTransient));
        }

        public object Resolve(Type resolveType) => this.childContainer.Resolve(resolveType);
    }
}