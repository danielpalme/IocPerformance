using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Child;
using ZenIoc;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Conditions;
using System.Collections.Generic;

namespace IocPerformance.Adapters
{
    public sealed class ZenIocContainerAdapter : ContainerAdapterBase
    {
        private IIocContainer container;

        public override string PackageName => "ZenIoc";

        public override string Url => "https://github.com/zenmvvm/ZenIoc";

        public override bool SupportsInterception => false;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsConditional => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => false;

        public override IChildContainerAdapter CreateChildContainerAdapter()
            => new ZenIocChildContainerAdapter(this.container as IocContainer);

        public override object Resolve(Type type) => container.Resolve(type);

        public override void Dispose()
        {
            if (this.container == null)
            {
                return;
            }

            container.Dispose();

            this.container = null;
        }

        public override void Prepare()
        {
            PrepareBasic();

            RegisterPropertyInjection();
            RegisterOpenGeneric();
            RegisterMultiple();
            RegisterConditional();
        }

        public override void PrepareBasic()
        {
            this.container = new IocContainer(o => o.TryResolveUnregistered = false);
            RegisterDummies();
            RegisterStandard();
            RegisterComplexObject();
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
            container.Register<ISingleton1, Singleton1>().SingleInstance();
            container.Register<ISingleton2, Singleton2>().SingleInstance();
            container.Register<ISingleton3, Singleton3>().SingleInstance();
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

        private void RegisterComplexObject()
        {
            container.Register<IFirstService, FirstService>().SingleInstance();
            container.Register<ISecondService, SecondService>().SingleInstance();
            container.Register<IThirdService, ThirdService>().SingleInstance();

            container.Register<ISubObjectOne, SubObjectOne>();
            container.Register<ISubObjectTwo, SubObjectTwo>();
            container.Register<ISubObjectThree, SubObjectThree>();

            container.Register<IComplex1, Complex1>();
            container.Register<IComplex2, Complex2>();
            container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            container.Register<IServiceA, ServiceA>().SingleInstance();
            container.Register<IServiceB, ServiceB>().SingleInstance();
            container.Register<IServiceC, ServiceC>().SingleInstance();
            container.Register<ISubObjectA, SubObjectA>();
            container.Register<ISubObjectB, SubObjectB>();
            container.Register<ISubObjectC, SubObjectC>();
            container.Register<IComplexPropertyObject1, ComplexPropertyObject1>();
            container.Register<IComplexPropertyObject2, ComplexPropertyObject2>();
            container.Register<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private void RegisterOpenGeneric()
        {
            container.RegisterType(typeof(GenericExport<>), typeof(IGenericInterface<>));
            container.RegisterType(typeof(ImportGeneric<>));
        }

        private void RegisterMultiple()
        {
            container.Register<ISimpleAdapter, SimpleAdapterOne>();
            container.Register<ISimpleAdapter, SimpleAdapterTwo>("2");
            container.Register<ISimpleAdapter, SimpleAdapterThree>("3");
            container.Register<ISimpleAdapter, SimpleAdapterFour>("4");
            container.Register<ISimpleAdapter, SimpleAdapterFive>("5");
            container.Register<IEnumerable<ISimpleAdapter>>();

            container.Register<ImportMultiple1>();
            container.Register<ImportMultiple2>();
            container.Register<ImportMultiple3>();
        }

        private void RegisterConditional()
        {
            container.Register<IExportConditionInterface, ExportConditionalObject1>("ExportConditionalObject1");
            container.Register<IExportConditionInterface, ExportConditionalObject2>("ExportConditionalObject2");
            container.Register<IExportConditionInterface, ExportConditionalObject3>("ExportConditionalObject3");

            container.Register<ImportConditionObject1>();
            container.Register<ImportConditionObject2>();
            container.Register<ImportConditionObject3>();
        }
    }

    public class ZenIocChildContainerAdapter : IChildContainerAdapter
    {
        private readonly IIocContainer container;

        public ZenIocChildContainerAdapter(IocContainer parent)
        {
            this.container = parent.NewChildContainer();
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public void Prepare()
        {
            container.Register<ITransient1, ScopedTransient>();

            container.Register<ICombined1, ScopedCombined1>();
            container.Register<ICombined2, ScopedCombined2>();
            container.Register<ICombined3, ScopedCombined3>();
        }

        public object Resolve(Type resolveType) => container.Resolve(resolveType);
    }
}
