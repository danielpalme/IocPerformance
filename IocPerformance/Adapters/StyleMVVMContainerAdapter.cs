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

        public override string PackageName => "StyleMVVM";

        public override string Url => "https://stylemvvm.codeplex.com";

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override object Resolve(Type type) => this.container.LocateByType(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container == null)
            {
                return;
            }

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

            this.RegisterBasic();

            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();

            this.container.Start();
        }

        public override void PrepareBasic()
        {
            this.container = new DependencyInjectionContainer();

            // Register all needed types out of StyleMVVM.DotNet
            this.container.RegisterAssembly(typeof(DependencyInjectionContainer).Assembly);

            // Remove extra XAML based exports that aren't needed (MVVM classes and what not)
            this.container.RemoveXAMLExports();

            this.RegisterBasic();

            this.container.Start();
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
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
            this.container.Register<Singleton1>().As<ISingleton1>().AndSharedPermenantly();
            this.container.Register<Singleton2>().As<ISingleton2>().AndSharedPermenantly();
            this.container.Register<Singleton3>().As<ISingleton3>().AndSharedPermenantly();
            this.container.Register<Transient1>().As<ITransient1>();
            this.container.Register<Transient2>().As<ITransient2>();
            this.container.Register<Transient3>().As<ITransient3>();
            this.container.Register<Combined1>().As<ICombined1>().ImportConstructor(() => new Combined1(null, null));
            this.container.Register<Combined2>().As<ICombined2>().ImportConstructor(() => new Combined2(null, null));
            this.container.Register<Combined3>().As<ICombined3>().ImportConstructor(() => new Combined3(null, null));
        }

        private void RegisterComplex()
        {
            this.container.Register<FirstService>().As<IFirstService>().AndSharedPermenantly();
            this.container.Register<SecondService>().As<ISecondService>().AndSharedPermenantly();
            this.container.Register<ThirdService>().As<IThirdService>().AndSharedPermenantly();
            this.container.Register<SubObjectOne>().As<ISubObjectOne>().ImportDefaultConstructor();
            this.container.Register<SubObjectTwo>().As<ISubObjectTwo>().ImportDefaultConstructor();
            this.container.Register<SubObjectThree>().As<ISubObjectThree>().ImportDefaultConstructor();
            this.container.Register<Complex1>().As<IComplex1>().ImportDefaultConstructor();
            this.container.Register<Complex2>().As<IComplex2>().ImportDefaultConstructor();
            this.container.Register<Complex3>().As<IComplex3>().ImportDefaultConstructor();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<ServiceA>().As<IServiceA>().AndSharedPermenantly();
            this.container.Register<ServiceB>().As<IServiceB>().AndSharedPermenantly();
            this.container.Register<ServiceC>().As<IServiceC>().AndSharedPermenantly();

            this.container.Register<SubObjectA>().As<ISubObjectA>().ImportProperty(x => x.ServiceA);
            this.container.Register<SubObjectB>().As<ISubObjectB>().ImportProperty(x => x.ServiceB);
            this.container.Register<SubObjectC>().As<ISubObjectC>().ImportProperty(x => x.ServiceC);

            this.container.Register<ComplexPropertyObject1>().As<IComplexPropertyObject1>()
                .ImportProperty(x => x.ServiceA)
                .ImportProperty(x => x.ServiceB)
                .ImportProperty(x => x.ServiceC)
                .ImportProperty(x => x.SubObjectA)
                .ImportProperty(x => x.SubObjectB)
                .ImportProperty(x => x.SubObjectC);

            this.container.Register<ComplexPropertyObject2>().As<IComplexPropertyObject2>()
                .ImportProperty(x => x.ServiceA)
                .ImportProperty(x => x.ServiceB)
                .ImportProperty(x => x.ServiceC)
                .ImportProperty(x => x.SubObjectA)
                .ImportProperty(x => x.SubObjectB)
                .ImportProperty(x => x.SubObjectC);

            this.container.Register<ComplexPropertyObject3>().As<IComplexPropertyObject3>()
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
            this.container.Register<ImportConditionObject1>().As<ImportConditionObject1>().ImportDefaultConstructor();
            this.container.Register<ImportConditionObject2>().As<ImportConditionObject2>().ImportDefaultConstructor();
            this.container.Register<ImportConditionObject3>().As<ImportConditionObject3>().ImportDefaultConstructor();

            this.container.Register<ExportConditionalObject>()
                .As<IExportConditionInterface>()
                .WhenInjectedInto<ImportConditionObject1>();
            this.container.Register<ExportConditionalObject2>()
                .As<IExportConditionInterface>()
                .WhenInjectedInto<ImportConditionObject2>();
            this.container.Register<ExportConditionalObject3>()
                .As<IExportConditionInterface>()
                .WhenInjectedInto<ImportConditionObject3>();
        }

        private void RegisterMultiple()
        {
            this.container.RegisterAssembly(GetType().Assembly).ExportInterface<ISimpleAdapter>();
            this.container.Register<ImportMultiple1>().As<ImportMultiple1>().ImportDefaultConstructor();
            this.container.Register<ImportMultiple2>().As<ImportMultiple2>().ImportDefaultConstructor();
            this.container.Register<ImportMultiple3>().As<ImportMultiple3>().ImportDefaultConstructor();
        }
    }
}
