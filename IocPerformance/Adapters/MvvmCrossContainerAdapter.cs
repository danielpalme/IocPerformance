using IocPerformance.Classes.Child;
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

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => false;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsConditional => false;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => false;

        public override bool SupportsCombined => true;

        public override bool SupportsTransient => true;

        public override bool SupportsBasic => true;

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
            this.RegisterAspNetCore();
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
                        
            this.provider.RegisterType<ITransient1, Transient1>();
            this.provider.RegisterType<ITransient2, Transient2>();
            this.provider.RegisterType<ITransient3, Transient3>();
                        
            this.provider.RegisterType<ICombined1, Combined1>();
            this.provider.RegisterType<ICombined2, Combined2>();
            this.provider.RegisterType<ICombined3, Combined3>();

            this.provider.RegisterType<ICalculator1, Calculator1>();
            this.provider.RegisterType<ICalculator2, Calculator2>();
            this.provider.RegisterType<ICalculator3, Calculator3>();
        }

        private void RegisterComplex()
        {
            this.provider.RegisterType<ISubObjectOne, SubObjectOne>();
            this.provider.RegisterType<ISubObjectTwo, SubObjectTwo>();
            this.provider.RegisterType<ISubObjectThree, SubObjectThree>();

            this.provider.RegisterSingleton<IFirstService>( new FirstService());
            this.provider.RegisterSingleton<ISecondService>(new SecondService());
            this.provider.RegisterSingleton<IThirdService>(new ThirdService());

            this.provider.RegisterType<IComplex1, Complex1>();
            this.provider.RegisterType<IComplex2, Complex2>();
            this.provider.RegisterType<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.provider.RegisterSingleton<IServiceA>(new ServiceA());
            this.provider.RegisterSingleton<IServiceB>(new ServiceB());
            this.provider.RegisterSingleton<IServiceC>(new ServiceC());

            this.provider.RegisterType<ISubObjectA, SubObjectA>();
            this.provider.RegisterType<ISubObjectB, SubObjectB>();
            this.provider.RegisterType<ISubObjectC, SubObjectC>();

            this.provider.RegisterType<IComplexPropertyObject1, ComplexPropertyObject1>();
            this.provider.RegisterType<IComplexPropertyObject2, ComplexPropertyObject2>();
            this.provider.RegisterType<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private void RegisterOpenGeneric()
        {
            this.provider.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.provider.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.provider.RegisterType<ImportConditionObject1, ImportConditionObject1>();
            this.provider.RegisterType<ImportConditionObject2, ImportConditionObject2>();
            this.provider.RegisterType<ImportConditionObject3, ImportConditionObject3>();

            //this.provider.RegisterType<IExportConditionInterface, ExportConditionalObject1>(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject1));
            //this.provider.RegisterType<IExportConditionInterface, ExportConditionalObject2>(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject2));
            //this.provider.RegisterType<IExportConditionInterface, ExportConditionalObject3>(condition: r => r.Parent.ImplementationType == typeof(ImportConditionObject3));
        }

        private void RegisterMultiple()
        {
            this.provider.RegisterType<ImportMultiple1, ImportMultiple1>();
            this.provider.RegisterType<ImportMultiple2, ImportMultiple2>();
            this.provider.RegisterType<ImportMultiple3, ImportMultiple3>();
            this.provider.RegisterType<ISimpleAdapter, SimpleAdapterOne>();
            this.provider.RegisterType<ISimpleAdapter, SimpleAdapterTwo>();
            this.provider.RegisterType<ISimpleAdapter, SimpleAdapterThree>();
            this.provider.RegisterType<ISimpleAdapter, SimpleAdapterFour>();
            this.provider.RegisterType<ISimpleAdapter, SimpleAdapterFive>();
        }

        private void RegisterInterceptor()
        {
            //this.provider.RegisterSingleton<CalculatorLogger>();
            //this.provider.Intercept<ICalculator1, CalculatorLogger>();
            //this.provider.Intercept<ICalculator2, CalculatorLogger>();
            //this.provider.Intercept<ICalculator3, CalculatorLogger>();
        }

        private void RegisterAspNetCore()
        {

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
            _childProvider.RegisterType<ITransient1, ScopedTransient>();

            _childProvider.RegisterType<ICombined1, ScopedCombined1>();
            _childProvider.RegisterType<ICombined2, ScopedCombined2>();
            _childProvider.RegisterType<ICombined3, ScopedCombined3>();
        }

        public object Resolve(Type resolveType)
        {
            return _childProvider.Resolve(resolveType);
        }
    }
}
