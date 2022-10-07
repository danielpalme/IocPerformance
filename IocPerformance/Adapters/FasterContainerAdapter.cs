using System;
using Faster.Ioc;
using Faster.Ioc.Contracts;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace IocPerformance.Adapters
{
    public sealed class FasterContainerAdapter : ContainerAdapterBase
    {
        private Faster.Ioc.Container container = new Faster.Ioc.Container();

        public override string Version { get; } = "1.0.0";

        public override string PackageName => "Faster.Ioc";

        public override string Url => "https://github.com/Wsm2110/Faster.Ioc";

        public override bool SupportsInterception => false;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => false;

        public override bool SupportsConditional => true;

        public override bool SupportsChildContainer => false;

        public override bool SupportAspNetCore => true;

        public override void Dispose()
        {
            container.Dispose();
        }

        public override void PrepareBasic()
        {
            container = new Container();
            RegisterDummies();
            RegisterStandard();
            RegisterComplex();
        }

        public override void Prepare()
        {
            RegisterBasic();
            RegisterMultiple();
            RegisterGeneric();
            RegisterConditional();
            RegisterAspNetCore();
        }

        public void RegisterBasic()
        {
            RegisterDummies();
            RegisterStandard();
            RegisterComplex();
        }

        public override object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        private void RegisterDummies()
        {
            container.Register<IDummyOne, DummyOne>();
            container.Register<IDummyTwo, DummyTwo>();
            container.Register<IDummyThree, DummyThree>();
            container.Register<IDummyFour, DummyFour>();
            container.Register<IDummyFive, DummyFive>();
            container.Register<IDummySix, DummySix>();
            container.Register<IDummySeven, DummySeven>();
            container.Register<IDummyEight, DummyEight>();
            container.Register<IDummyNine, DummyNine>();
            container.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            container.Register<ISingleton1, Singleton1>(Lifetime.Singleton);
            container.Register<ISingleton2, Singleton2>(Lifetime.Singleton);
            container.Register<ISingleton3, Singleton3>(Lifetime.Singleton);
            container.Register<ITransient1, Transient1>();
            container.Register<ITransient2, Transient2>();
            container.Register<ITransient3, Transient3>();
            container.Register<ICombined1, Combined1>();
            container.Register<ICombined2, Combined2>();
            container.Register<ICombined3, Combined3>();

            container.Register<ICalculator1, Calculator1>();
            container.Register<ICalculator2, Calculator2>();
            container.Register<ICalculator3, Calculator3>();
        }

        public void RegisterMultiple()
        {
            container.Register<ISimpleAdapter, SimpleAdapterOne>();
            container.Register<ISimpleAdapter, SimpleAdapterTwo>();
            container.Register<ISimpleAdapter, SimpleAdapterThree>();
            container.Register<ISimpleAdapter, SimpleAdapterFour>();
            container.Register<ISimpleAdapter, SimpleAdapterFive>();
            container.Register<ImportMultiple1>();
            container.Register<ImportMultiple2>();
            container.Register<ImportMultiple3>();
        }

        private void RegisterComplex()
        {
            container.Register<ISubObjectOne, SubObjectOne>();
            container.Register<ISubObjectTwo, SubObjectTwo>();
            container.Register<ISubObjectThree, SubObjectThree>();
            container.Register<IFirstService, FirstService>(Lifetime.Singleton);
            container.Register<ISecondService, SecondService>(Lifetime.Singleton);
            container.Register<IThirdService, ThirdService>(Lifetime.Singleton);
            container.Register<IComplex1, Complex1>();
            container.Register<IComplex2, Complex2>();
            container.Register<IComplex3, Complex3>();
        }

        private void RegisterGeneric()
        {
            container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
            container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
        }

        private void RegisterConditional()
        {
            container.Register<IExportConditionInterface, ExportConditionalObject3>();
            container.Register<IExportConditionInterface, ExportConditionalObject2>();
            container.Register<IExportConditionInterface, ExportConditionalObject1>();

            container.RegisterOverride<ImportConditionObject1>(() => new ImportConditionObject1(new ExportConditionalObject1()), Lifetime.Transient);
            container.RegisterOverride<ImportConditionObject2>(() => new ImportConditionObject2(new ExportConditionalObject2()), Lifetime.Transient);
            container.RegisterOverride<ImportConditionObject3>(() => new ImportConditionObject3(new ExportConditionalObject3()), Lifetime.Transient);
        }

        private void RegisterAspNetCore()
        {
            ServiceCollection services = new ServiceCollection();
            this.RegisterAspNetCoreClasses(services);
            container.RegisterServiceCollection(services);
        }
    }
}