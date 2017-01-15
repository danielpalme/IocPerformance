using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Stashbox;
using Stashbox.Infrastructure;
using System;

namespace IocPerformance.Adapters
{
    public sealed class StashboxContainerAdapter : ContainerAdapterBase
    {
        private StashboxContainer container;

        public override string PackageName => "Stashbox";
        public override string Url => "https://github.com/z4kn4fein/stashbox";

        public override bool SupportsInterception => false;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override void PrepareBasic()
        {
            this.container = new StashboxContainer();
            this.RegisterBasic();
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
        }

        public override void Dispose()
        {
            if (this.container == null)
            {
                return;
            }

            this.container.Dispose();
            this.container = null;
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new StashboxChildContainerAdapter(this.container);
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.RegisterType<IDummyOne, DummyOne>();
            this.container.RegisterType<IDummyTwo, DummyTwo>();
            this.container.RegisterType<IDummyThree, DummyThree>();
            this.container.RegisterType<IDummyFour, DummyFour>();
            this.container.RegisterType<IDummyFive, DummyFive>();
            this.container.RegisterType<IDummySix, DummySix>();
            this.container.RegisterType<IDummySeven, DummySeven>();
            this.container.RegisterType<IDummyEight, DummyEight>();
            this.container.RegisterType<IDummyNine, DummyNine>();
            this.container.RegisterType<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.RegisterSingleton<ISingleton1, Singleton1>();
            this.container.RegisterSingleton<ISingleton2, Singleton2>();
            this.container.RegisterSingleton<ISingleton3, Singleton3>();
            this.container.RegisterType<ITransient1, Transient1>();
            this.container.RegisterType<ITransient2, Transient2>();
            this.container.RegisterType<ITransient3, Transient3>();
            this.container.RegisterType<ICombined1, Combined1>();
            this.container.RegisterType<ICombined2, Combined2>();
            this.container.RegisterType<ICombined3, Combined3>();
        }

        private void RegisterComplex()
        {
            this.container.RegisterSingleton<IFirstService, FirstService>();
            this.container.RegisterSingleton<ISecondService, SecondService>();
            this.container.RegisterSingleton<IThirdService, ThirdService>();
            this.container.RegisterType<ISubObjectOne, SubObjectOne>();
            this.container.RegisterType<ISubObjectTwo, SubObjectTwo>();
            this.container.RegisterType<ISubObjectThree, SubObjectThree>();
            this.container.RegisterType<IComplex1, Complex1>();
            this.container.RegisterType<IComplex2, Complex2>();
            this.container.RegisterType<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingleton<IServiceA, ServiceA>();
            this.container.RegisterSingleton<IServiceB, ServiceB>();
            this.container.RegisterSingleton<IServiceC, ServiceC>();
            this.container.RegisterType<ISubObjectA, SubObjectA>();
            this.container.RegisterType<ISubObjectB, SubObjectB>();
            this.container.RegisterType<ISubObjectC, SubObjectC>();
            this.container.RegisterType<IComplexPropertyObject1, ComplexPropertyObject1>();
            this.container.RegisterType<IComplexPropertyObject2, ComplexPropertyObject2>();
            this.container.RegisterType<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private void RegisterMultiple()
        {
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>("one");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>("two");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>("three");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>("four");
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>("five");

            this.container.RegisterType<ImportMultiple1>();
            this.container.RegisterType<ImportMultiple2>();
            this.container.RegisterType<ImportMultiple3>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.container.RegisterType<ImportConditionObject1>();
            this.container.RegisterType<ImportConditionObject2>();
            this.container.RegisterType<ImportConditionObject3>();
            this.container.PrepareType<IExportConditionInterface, ExportConditionalObject>()
                .WhenDependantIs<ImportConditionObject1>().Register();
            this.container.PrepareType<IExportConditionInterface, ExportConditionalObject2>()
                .WhenDependantIs<ImportConditionObject2>().Register();
            this.container.PrepareType<IExportConditionInterface, ExportConditionalObject3>()
                 .WhenDependantIs<ImportConditionObject3>().Register();
        }
    }

    public class StashboxChildContainerAdapter : IChildContainerAdapter
    {
        private readonly IStashboxContainer childContainer;

        public StashboxChildContainerAdapter(IStashboxContainer container)
        {
            this.childContainer = container.CreateChildContainer();
        }

        public void Dispose()
        {
            this.childContainer.Dispose();
        }

        public void Prepare()
        {
            this.childContainer.RegisterType<ICombined1, ScopedCombined1>();
            this.childContainer.RegisterType<ICombined2, ScopedCombined2>();
            this.childContainer.RegisterType<ICombined3, ScopedCombined3>();
            this.childContainer.RegisterType<ITransient1, ScopedTransient>();
        }

        public object Resolve(Type resolveType)
        {
            return this.childContainer.Resolve(resolveType);
        }
    }
}
