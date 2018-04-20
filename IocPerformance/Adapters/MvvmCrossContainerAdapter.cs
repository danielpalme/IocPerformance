using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using MvvmCross;
using MvvmCross.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Adapters
{
    public sealed class MvvmCrossContainerAdapter : ContainerAdapterBase
    {
        private IMvxIoCProvider provider;

        public override string PackageName => "MvvmCross";

        public override string Url => "https://github.com/MvvmCross/MvvmCross";

        public override bool SupportsInterception => false;

        public override bool SupportGeneric => false;

        public override bool SupportsMultiple => false;

        public override bool SupportsPropertyInjection => false;

        public override bool SupportsConditional => false;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => false;

        public override IChildContainerAdapter CreateChildContainerAdapter() => new MvvmCrossChildContainerAdapter(this.provider.CreateChildContainer());

        public override object Resolve(Type type)
        {
            return provider.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.provider == null)
            {
                return;
            }

            this.provider = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterInterceptor();
            //this.RegisterAspNetCore();
        }

        public override void PrepareBasic()
        {
            this.provider = MvxIoCProvider.Initialize();
            RegisterBasic();
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.provider.RegisterType<IDummyOne, DummyOne>();
            this.provider.RegisterType<IDummyTwo, DummyTwo>();
            this.provider.RegisterType<IDummyThree, DummyThree>();
            this.provider.RegisterType<IDummyFour, DummyFour>();
            this.provider.RegisterType<IDummyFive, DummyFive>();
            this.provider.RegisterType<IDummySix, DummySix>();
            this.provider.RegisterType<IDummySeven, DummySeven>();
            this.provider.RegisterType<IDummyEight, DummyEight>();
            this.provider.RegisterType<IDummyNine, DummyNine>();
            this.provider.RegisterType<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            
            this.provider.RegisterSingleton<ISingleton1>(new Singleton1());
            this.provider.RegisterSingleton<ISingleton2>(new Singleton2());
            this.provider.RegisterSingleton<ISingleton3>(new Singleton3());

            /*
            this.provider.RegisterSingleton<ITransient1, Transient1>();
            this.provider.RegisterSingleton<ITransient2, Transient2>();
            this.provider.RegisterSingleton<ITransient3, Transient3>();

            this.provider.RegisterSingleton<ICombined1, Combined1>();
            this.provider.RegisterSingleton<ICombined2, Combined2>();
            this.provider.RegisterSingleton<ICombined3, Combined3>();

            this.provider.RegisterSingleton<ICalculator1, Calculator1>();
            this.provider.RegisterSingleton<ICalculator2, Calculator2>();
            this.provider.RegisterSingleton<ICalculator3, Calculator3>();*/
        }

        private void RegisterComplex()
        {
            /*
            this.provider.RegisterSingleton<ISubObjectOne, SubObjectOne>();
            this.provider.RegisterSingleton<ISubObjectTwo, SubObjectTwo>();
            this.provider.RegisterSingleton<ISubObjectThree, SubObjectThree>();

            this.provider.RegisterSingleton<IFirstService, FirstService>();
            this.provider.RegisterSingleton<ISecondService, SecondService>();
            this.provider.RegisterSingleton<IThirdService, ThirdService>();

            this.provider.RegisterSingleton<IComplex1, Complex1>();
            this.provider.RegisterSingleton<IComplex2, Complex2>();
            this.provider.RegisterSingleton<IComplex3, Complex3>();*/
        }

        private void RegisterPropertyInjection()
        {/*
            this.provider.RegisterSingleton<IServiceA, ServiceA>(Reuse.Singleton);
            this.provider.RegisterSingleton<IServiceB, ServiceB>(Reuse.Singleton);
            this.provider.RegisterSingleton<IServiceC, ServiceC>(Reuse.Singleton);

            this.provider.RegisterSingleton<ISubObjectA, SubObjectA>(made: PropertiesAndFields.Auto);
            this.provider.RegisterSingleton<ISubObjectB, SubObjectB>(made: PropertiesAndFields.Auto);
            this.provider.RegisterSingleton<ISubObjectC, SubObjectC>(made: PropertiesAndFields.Auto);

            this.provider.RegisterSingleton<IComplexPropertyObject1, ComplexPropertyObject1>(made: PropertiesAndFields.Auto);
            this.provider.RegisterSingleton<IComplexPropertyObject2, ComplexPropertyObject2>(made: PropertiesAndFields.Auto);
            this.provider.RegisterSingleton<IComplexPropertyObject3, ComplexPropertyObject3>(made: PropertiesAndFields.Auto);*/
        }

        private void RegisterOpenGeneric()
        {
            this.provider.RegisterSingleton(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.provider.RegisterSingleton(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {/*
            this.provider.RegisterSingleton<ImportConditionObject1>();
            this.provider.RegisterSingleton<ImportConditionObject2>();
            this.provider.RegisterSingleton<ImportConditionObject3>();*/

            //this.provider.RegisterSingleton<IExportConditionInterface, ExportConditionalObject1>(
            //    setup: Setup.With(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject1)));

            //this.provider.RegisterSingleton<IExportConditionInterface, ExportConditionalObject2>(
            //    setup: Setup.With(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject2)));

            //this.provider.RegisterSingleton<IExportConditionInterface, ExportConditionalObject3>(
            //    setup: Setup.With(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject3)));
        }

        private void RegisterMultiple()
        {/*
            this.provider.RegisterSingleton<ImportMultiple1>();
            this.provider.RegisterSingleton<ImportMultiple2>();
            this.provider.RegisterSingleton<ImportMultiple3>();
            this.provider.RegisterSingleton<ISimpleAdapter, SimpleAdapterOne>();
            this.provider.RegisterSingleton<ISimpleAdapter, SimpleAdapterTwo>();
            this.provider.RegisterSingleton<ISimpleAdapter, SimpleAdapterThree>();
            this.provider.RegisterSingleton<ISimpleAdapter, SimpleAdapterFour>();
            this.provider.RegisterSingleton<ISimpleAdapter, SimpleAdapterFive>();*/
        }

        private void RegisterInterceptor()
        {
            //this.provider.RegisterSingleton<CalculatorLogger>();
            //this.container.Intercept<ICalculator1, CalculatorLogger>();
            //this.container.Intercept<ICalculator2, CalculatorLogger>();
            //this.container.Intercept<ICalculator3, CalculatorLogger>();
        }
    }

    public class MvvmCrossChildContainerAdapter : IChildContainerAdapter
    {
        private IMvxIoCProvider _childProvider;

        public MvvmCrossChildContainerAdapter(IMvxIoCProvider provider)
        {
            _childProvider = provider;
        }

        public void Dispose()
        {
            _childProvider = null;
        }

        public void Prepare()
        {
            //childContainer.RegisterType<ITransient1>(new InjectionFactory((c) => new ScopedTransient()));

            //childContainer.RegisterType<ICombined1>(new InjectionFactory((c) => new ScopedCombined1(c.Resolve<ITransient1>(), c.Resolve<ISingleton1>())));
            //childContainer.RegisterType<ICombined2>(new InjectionFactory((c) => new ScopedCombined2(c.Resolve<ITransient1>(), c.Resolve<ISingleton1>())));
            //childContainer.RegisterType<ICombined3>(new InjectionFactory((c) => new ScopedCombined3(c.Resolve<ITransient1>(), c.Resolve<ISingleton1>())));
        }

        public object Resolve(Type resolveType)
        {
            return _childProvider.Resolve(resolveType);
        }
    }
}
