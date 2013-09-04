using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using StyleMVVM.DependencyInjection;
using StyleMVVM.DependencyInjection.Impl;

namespace IocPerformance.Adapters
{
    public class StyleMVVMContainerAdapter : ContainerAdapterBase
    {
        private IDependencyInjectionContainer container;

        public override string PackageName
        {
            get { return "StyleMVVM"; }
        }

        public override string Url
        {
            get { return "http://stylemvvm.codeplex.com"; }
        }

        public override bool SupportsConditional
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

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.LocateByType(type);
        }

        public override void Dispose()
        {
            // Shutdown the container
            this.container.Shutdown();

            // Release container from memory
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new DependencyInjectionContainer();

            // Register all needed types out of StyleMVVM.DotNet
            this.container.RegisterAssembly(typeof(DependencyInjectionContainer).Assembly);

            // Remove extra XAML based exports that aren't needed (MVVM classes and what not)
            this.container.RemoveXAMLExports();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();

            this.container.Start();
        }

        private void RegisterDummies()
        {
            this.container.Register<DummyOne>().As<IDummyOne>();
            this.container.Register<DummyTwo>().As<IDummyTwo>();
            this.container.Register<DummyThree>().As<IDummyThree>();
            this.container.Register<DummyFour>().As<IDummyFour>();
            this.container.Register<DummyFive>().As<IDummyFive>();
            this.container.Register<DummySix>().As<IDummySix>();
            this.container.Register<DummySeven>().As<IDummySeven>();
            this.container.Register<DummyEight>().As<IDummyEight>();
            this.container.Register<DummyNine>().As<IDummyNine>();
            this.container.Register<DummyTen>().As<IDummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.Register<Singleton>().As<ISingleton>().AndSharedPermenantly();
            this.container.Register<Transient>().As<ITransient>();
            this.container.Register<Combined>().As<ICombined>().ImportConstructor(() => new Combined(null, null));
        }

        private void RegisterComplex()
        {
            this.container.Register<FirstService>().As<IFirstService>().AndSharedPermenantly();
            this.container.Register<SecondService>().As<ISecondService>().AndSharedPermenantly();
            this.container.Register<ThirdService>().As<IThirdService>().AndSharedPermenantly();
            this.container.Register<SubObjectOne>().As<ISubObjectOne>().ImportDefaultConstructor();
            this.container.Register<SubObjectTwo>().As<ISubObjectTwo>().ImportDefaultConstructor();
            this.container.Register<SubObjectThree>().As<ISubObjectThree>().ImportDefaultConstructor();
            this.container.Register<Complex>().As<IComplex>().ImportDefaultConstructor();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<ServiceA>().As<IServiceA>().AndSharedPermenantly();
            this.container.Register<ServiceB>().As<IServiceB>().AndSharedPermenantly();
            this.container.Register<ServiceC>().As<IServiceC>().AndSharedPermenantly();

            this.container.Register<SubObjectA>().As<ISubObjectA>().ImportProperty(x => x.ServiceA);
            this.container.Register<SubObjectB>().As<ISubObjectB>().ImportProperty(x => x.ServiceB);
            this.container.Register<SubObjectC>().As<ISubObjectC>().ImportProperty(x => x.ServiceC);

            this.container.Register<ComplexPropertyObject>().As<IComplexPropertyObject>()
                .ImportProperty(x => x.ServiceA)
                .ImportProperty(x => x.ServiceB)
                .ImportProperty(x => x.ServiceC)
                .ImportProperty(x => x.SubObjectA)
                .ImportProperty(x => x.SubObjectB)
                .ImportProperty(x => x.SubObjectC);
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>)).ImportDefaultConstructor();
            this.container.Register(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
        }

        private void RegisterConditional()
        {
            this.container.Register<ImportConditionObject>()
                            .As<ImportConditionObject>().ImportDefaultConstructor();
            this.container.Register<ImportConditionObject2>()
                            .As<ImportConditionObject2>().ImportDefaultConstructor();

            this.container.Register<ExportConditionalObject>()
                            .As<IExportConditionInterface>()
                            .WhenInjectedInto<ImportConditionObject>();
            this.container.Register<ExportConditionalObject2>()
                            .As<IExportConditionInterface>()
                            .WhenInjectedInto<ImportConditionObject2>();
        }

        private void RegisterMultiple()
        {
            this.container.RegisterAssembly(GetType().Assembly).ExportInterface<ISimpleAdapter>();
            this.container.Register<ImportMultiple>().As<ImportMultiple>().ImportDefaultConstructor();
        }
    }
}
