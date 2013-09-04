using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using MugenInjection;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : ContainerAdapterBase
    {
        private MugenInjector container;

        public override string Name
        {
            get { return "Mugen"; }
        }

        public override string PackageName
        {
            get { return "MugenInjection"; }
        }

        public override string Url
        {
            get { return "http://mugeninjection.codeplex.com"; }
        }

        public override bool SupportsConditional
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

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.Get(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new MugenInjector();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterMultiple();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
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

        private void RegisterComplex()
        {
            this.container.Bind<IFirstService>().To<FirstService>().InTransientScope();
            this.container.Bind<ISecondService>().To<SecondService>().InTransientScope();
            this.container.Bind<IThirdService>().To<ThirdService>().InTransientScope();
            this.container.Bind<ISubObjectOne>().To<SubObjectOne>().InTransientScope();
            this.container.Bind<ISubObjectTwo>().To<SubObjectTwo>().InTransientScope();
            this.container.Bind<ISubObjectThree>().To<SubObjectThree>().InTransientScope();
            this.container.Bind<IComplex>().To<Complex>().InTransientScope();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Bind<IComplexPropertyObject>().To<ComplexPropertyObject>().InTransientScope();
            this.container.Bind<IServiceA>().To<ServiceA>().InSingletonScope();
            this.container.Bind<IServiceB>().To<ServiceB>().InSingletonScope();
            this.container.Bind<IServiceC>().To<ServiceC>().InSingletonScope();
            this.container.Bind<ISubObjectA>().To<SubObjectA>().InTransientScope();
            this.container.Bind<ISubObjectB>().To<SubObjectB>().InTransientScope();
            this.container.Bind<ISubObjectC>().To<SubObjectC>().InTransientScope();
        }

        private void RegisterConditional()
        {
            // conditional export
            this.container.Bind<ImportConditionObject>().To<ImportConditionObject>().InTransientScope();
            this.container.Bind<ImportConditionObject2>().To<ImportConditionObject2>().InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                        .To<ExportConditionalObject>()
                        .WhenIntoIsAssignable<ImportConditionObject>()
                        .InTransientScope();
            this.container.Bind<IExportConditionInterface>()
                        .To<ExportConditionalObject2>()
                        .WhenIntoIsAssignable<ImportConditionObject2>()
                        .InTransientScope();
        }

        private void RegisterOpenGeneric()
        {
            // generic export
            this.container.Bind(typeof(IGenericInterface<>)).To(typeof(GenericExport<>)).InTransientScope();
            this.container.Bind(typeof(ImportGeneric<>)).To(typeof(ImportGeneric<>)).InTransientScope();
        }

        private void RegisterMultiple()
        {
            // multiple exports
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterOne>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterTwo>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterThree>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFour>().InTransientScope();
            this.container.Bind<ISimpleAdapter>().To<SimpleAdapterFive>().InTransientScope();
            this.container.Bind<ImportMultiple>().To<ImportMultiple>().InTransientScope();
        }

        private void RegisterInterceptor()
        {
            this.container.Bind<ICalculator>().To<Calculator>().InTransientScope().InterceptAsTarget(new MugenInjectionInterceptionLogger());
        }
    }
}