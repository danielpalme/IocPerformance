using System;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Extensions;
using Grace.Dynamic;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public class GraceContainerAdapter : ContainerAdapterBase
    {
        private DependencyInjectionContainer container;

        public override string PackageName => "Grace";

        public override string Url => "https://github.com/ipjohnson/Grace";

        public override bool SupportsPropertyInjection => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsConditional => true;

        public override bool SupportsInterception => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => true;

        public override IChildContainerAdapter CreateChildContainerAdapter() => new GraceChildContainerAdapter(this.container.CreateChildScope());

        public override object Resolve(Type type) => this.container.Locate(type);

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
            this.RegisterMultiple();
            this.RegisterConditional();
            this.RegisterInterceptor();
            this.RegisterAspNetCore();
        }

        public override void PrepareBasic()
        {
            this.container = new DependencyInjectionContainer(GraceDynamicMethod.Configuration());
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
            this.container.Configure(c =>
            {
                c.Export<Calculator1>().As<ICalculator1>();
                c.Export<Calculator2>().As<ICalculator2>();
                c.Export<Calculator3>().As<ICalculator3>();

                c.Intercept<ICalculator1, GraceInterceptionLogger>();
                c.Intercept<ICalculator2, GraceInterceptionLogger>();
                c.Intercept<ICalculator3, GraceInterceptionLogger>();
            });
        }

        private void RegisterAspNetCore()
        {
            this.container.Populate(this.CreateServiceCollection());
        }

        private void RegisterConditional()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<ImportConditionObject1>();
                    ioc.Export<ImportConditionObject2>();
                    ioc.Export<ImportConditionObject3>();

                    ioc.Export<ExportConditionalObject1>()
                        .As<IExportConditionInterface>()
                        .When.InjectedInto<ImportConditionObject1>();

                    ioc.Export<ExportConditionalObject2>()
                        .As<IExportConditionInterface>()
                        .When.InjectedInto<ImportConditionObject2>();

                    ioc.Export<ExportConditionalObject3>()
                        .As<IExportConditionInterface>()
                        .When.InjectedInto<ImportConditionObject3>();
                });
        }

        private void RegisterMultiple()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<SimpleAdapterOne>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterTwo>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterThree>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterFour>().As<ISimpleAdapter>();
                    ioc.Export<SimpleAdapterFive>().As<ISimpleAdapter>();
                    ioc.Export<ImportMultiple1>();
                    ioc.Export<ImportMultiple2>();
                    ioc.Export<ImportMultiple3>();
                });
        }

        private void RegisterOpenGeneric()
        {
            this.container.Configure(c =>
                                     {
                                         c.Export(typeof(ImportGeneric<>));
                                         c.Export(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
                                     });
        }

        private void RegisterStandard()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<Singleton1>().As<ISingleton1>().Lifestyle.Singleton();
                    ioc.Export<Singleton2>().As<ISingleton2>().Lifestyle.Singleton();
                    ioc.Export<Singleton3>().As<ISingleton3>().Lifestyle.Singleton();
                    ioc.Export<Transient1>().As<ITransient1>();
                    ioc.Export<Transient2>().As<ITransient2>();
                    ioc.Export<Transient3>().As<ITransient3>();
                    ioc.Export<Combined1>().As<ICombined1>();
                    ioc.Export<Combined2>().As<ICombined2>();
                    ioc.Export<Combined3>().As<ICombined3>();
                });
        }

        private void RegisterComplex()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<FirstService>().As<IFirstService>().Lifestyle.Singleton();
                    ioc.Export<SecondService>().As<ISecondService>().Lifestyle.Singleton();
                    ioc.Export<ThirdService>().As<IThirdService>().Lifestyle.Singleton();
                    ioc.Export<SubObjectOne>().As<ISubObjectOne>();
                    ioc.Export<SubObjectTwo>().As<ISubObjectTwo>();
                    ioc.Export<SubObjectThree>().As<ISubObjectThree>();
                    ioc.Export<Complex1>().As<IComplex1>();
                    ioc.Export<Complex2>().As<IComplex2>();
                    ioc.Export<Complex3>().As<IComplex3>();
                });
        }

        private void RegisterDummies()
        {
            this.container.Configure(
                ioc =>
                {
                    ioc.Export<DummyOne>().As<IDummyOne>();
                    ioc.Export<DummyTwo>().As<IDummyTwo>();
                    ioc.Export<DummyThree>().As<IDummyThree>();
                    ioc.Export<DummyFour>().As<IDummyFour>();
                    ioc.Export<DummyFive>().As<IDummyFive>();
                    ioc.Export<DummySix>().As<IDummySix>();
                    ioc.Export<DummySeven>().As<IDummySeven>();
                    ioc.Export<DummyEight>().As<IDummyEight>();
                    ioc.Export<DummyNine>().As<IDummyNine>();
                    ioc.Export<DummyTen>().As<IDummyTen>();
                });
        }

        private void RegisterPropertyInjection()
        {
            this.container.Configure(c =>
                {
                    c.Export<ServiceA>().As<IServiceA>().Lifestyle.Singleton();
                    c.Export<ServiceB>().As<IServiceB>().Lifestyle.Singleton();
                    c.Export<ServiceC>().As<IServiceC>().Lifestyle.Singleton();

                    c.Export<SubObjectA>().As<ISubObjectA>().ImportProperty(x => x.ServiceA);
                    c.Export<SubObjectB>().As<ISubObjectB>().ImportProperty(x => x.ServiceB);
                    c.Export<SubObjectC>().As<ISubObjectC>().ImportProperty(x => x.ServiceC);

                    c.Export<ComplexPropertyObject1>().As<IComplexPropertyObject1>().AutoWireProperties();
                    c.Export<ComplexPropertyObject2>().As<IComplexPropertyObject2>().AutoWireProperties();
                    c.Export<ComplexPropertyObject3>().As<IComplexPropertyObject3>().AutoWireProperties();
                });
        }
    }

    public class GraceChildContainerAdapter : IChildContainerAdapter
    {
        private IInjectionScope injectionScope;

        public GraceChildContainerAdapter(IInjectionScope injectionScope)
        {
            this.injectionScope = injectionScope;
        }

        public void Dispose()
        {
            this.injectionScope.Dispose();
        }

        public void Prepare()
        {
            this.injectionScope.Configure(c =>
                                          {
                                              c.ExportFunc<ICombined1>(
                                                  scope => new ScopedCombined1(scope.Locate<ITransient1>(), scope.Locate<ISingleton1>()));

                                              c.ExportFunc<ICombined2>(
                                                  scope => new ScopedCombined2(scope.Locate<ITransient1>(), scope.Locate<ISingleton1>()));

                                              c.ExportFunc<ICombined3>(
                                                  scope => new ScopedCombined3(scope.Locate<ITransient1>(), scope.Locate<ISingleton1>()));

                                              c.ExportFunc<ITransient1>(scope => new ScopedTransient());
                                          });
        }

        public object Resolve(Type resolveType) => this.injectionScope.Locate(resolveType);
    }
}
