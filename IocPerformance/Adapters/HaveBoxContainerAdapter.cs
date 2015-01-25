using System;
using HaveBox;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class HaveBoxContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "HaveBox"; }
        }

        public override string Url
        {
            get { return "https://bitbucket.org/Have/havebox"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();            
            this.RegisterPropertyInjection();
            this.RegisterInterceptor();
            this.RegisterMultiple();
        }
        
        public override void PrepareBasic()
        {
            this.container = new Container();
            this.RegisterBasic(); 
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Configure(config => config.For<IDummyOne>().Use<DummyOne>());
            this.container.Configure(config => config.For<IDummyTwo>().Use<DummyTwo>());
            this.container.Configure(config => config.For<IDummyThree>().Use<DummyThree>());
            this.container.Configure(config => config.For<IDummyFour>().Use<DummyFour>());
            this.container.Configure(config => config.For<IDummyFive>().Use<DummyFive>());
            this.container.Configure(config => config.For<IDummySix>().Use<DummySix>());
            this.container.Configure(config => config.For<IDummySeven>().Use<DummySeven>());
            this.container.Configure(config => config.For<IDummyEight>().Use<DummyEight>());
            this.container.Configure(config => config.For<IDummyNine>().Use<DummyNine>());
            this.container.Configure(config => config.For<IDummyTen>().Use<DummyTen>());
        }

        private void RegisterStandard()
        {
            this.container.Configure(config => config.For<ISingleton1>().Use<Singleton1>().AsSingleton());
            this.container.Configure(config => config.For<ISingleton2>().Use<Singleton2>().AsSingleton());
            this.container.Configure(config => config.For<ISingleton3>().Use<Singleton3>().AsSingleton());
            this.container.Configure(config => config.For<ITransient1>().Use<Transient1>());
            this.container.Configure(config => config.For<ITransient2>().Use<Transient2>());
            this.container.Configure(config => config.For<ITransient3>().Use<Transient3>());
            this.container.Configure(config => config.For<ICombined1>().Use<Combined1>());
            this.container.Configure(config => config.For<ICombined2>().Use<Combined2>());
            this.container.Configure(config => config.For<ICombined3>().Use<Combined3>());
        }

        private void RegisterComplex()
        {
            this.container.Configure(config => config.For<IFirstService>().Use<FirstService>().AsSingleton());
            this.container.Configure(config => config.For<ISecondService>().Use<SecondService>().AsSingleton());
            this.container.Configure(config => config.For<IThirdService>().Use<ThirdService>().AsSingleton());
            this.container.Configure(config => config.For<ISubObjectOne>().Use<SubObjectOne>());
            this.container.Configure(config => config.For<ISubObjectTwo>().Use<SubObjectTwo>());
            this.container.Configure(config => config.For<ISubObjectThree>().Use<SubObjectThree>());
            this.container.Configure(config => config.For<IComplex1>().Use<Complex1>());
            this.container.Configure(config => config.For<IComplex2>().Use<Complex2>());
            this.container.Configure(config => config.For<IComplex3>().Use<Complex3>());
        }

        private void RegisterPropertyInjection()
        {
            this.container.Configure(config => config.For<IServiceA>().Use<ServiceA>().AsSingleton());
            this.container.Configure(config => config.For<IServiceB>().Use<ServiceB>().AsSingleton());
            this.container.Configure(config => config.For<IServiceC>().Use<ServiceC>().AsSingleton());
            this.container.Configure(config => config.For<ISubObjectA>().Use(() => new SubObjectA { ServiceA = this.container.GetInstance<IServiceA>() }));
            this.container.Configure(config => config.For<ISubObjectB>().Use(() => new SubObjectB { ServiceB = this.container.GetInstance<IServiceB>() }));
            this.container.Configure(config => config.For<ISubObjectC>().Use(() => new SubObjectC { ServiceC = this.container.GetInstance<IServiceC>() }));
            this.container.Configure(
                config => config.For<IComplexPropertyObject1>().Use(
                    () => new ComplexPropertyObject1
                    {
                        ServiceA = this.container.GetInstance<IServiceA>(),
                        ServiceB = this.container.GetInstance<IServiceB>(),
                        ServiceC = this.container.GetInstance<IServiceC>(),
                        SubObjectA = this.container.GetInstance<ISubObjectA>(),
                        SubObjectB = this.container.GetInstance<ISubObjectB>(),
                        SubObjectC = this.container.GetInstance<ISubObjectC>()
                    }));
            this.container.Configure(
                config => config.For<IComplexPropertyObject2>().Use(
                    () => new ComplexPropertyObject2
                    {
                        ServiceA = this.container.GetInstance<IServiceA>(),
                        ServiceB = this.container.GetInstance<IServiceB>(),
                        ServiceC = this.container.GetInstance<IServiceC>(),
                        SubObjectA = this.container.GetInstance<ISubObjectA>(),
                        SubObjectB = this.container.GetInstance<ISubObjectB>(),
                        SubObjectC = this.container.GetInstance<ISubObjectC>()
                    }));
            this.container.Configure(
                config => config.For<IComplexPropertyObject3>().Use(
                    () => new ComplexPropertyObject3
                    {
                        ServiceA = this.container.GetInstance<IServiceA>(),
                        ServiceB = this.container.GetInstance<IServiceB>(),
                        ServiceC = this.container.GetInstance<IServiceC>(),
                        SubObjectA = this.container.GetInstance<ISubObjectA>(),
                        SubObjectB = this.container.GetInstance<ISubObjectB>(),
                        SubObjectC = this.container.GetInstance<ISubObjectC>()
                    }));
        }

        private void RegisterInterceptor()
        {
            this.container.Configure(config => config.For<ICalculator1>().Use<Calculator1>().AndInterceptMethodsWith<HaveBoxInterceptionLogger>());
            this.container.Configure(config => config.For<ICalculator2>().Use<Calculator2>().AndInterceptMethodsWith<HaveBoxInterceptionLogger>());
            this.container.Configure(config => config.For<ICalculator3>().Use<Calculator3>().AndInterceptMethodsWith<HaveBoxInterceptionLogger>());
        }

        private void RegisterMultiple()
        {
            this.container.Configure(config =>
                                     {
                                         config.For<ImportMultiple1>().Use<ImportMultiple1>();
                                         config.For<ImportMultiple2>().Use<ImportMultiple2>();
                                         config.For<ImportMultiple3>().Use<ImportMultiple3>();
                                         config.For<ISimpleAdapter>().Use<SimpleAdapterOne>();
                                         config.For<ISimpleAdapter>().Use<SimpleAdapterTwo>();
                                         config.For<ISimpleAdapter>().Use<SimpleAdapterThree>();
                                         config.For<ISimpleAdapter>().Use<SimpleAdapterFour>();
                                         config.For<ISimpleAdapter>().Use<SimpleAdapterFive>();
                                     });
        }
    }
}
