using System;
using System.Diagnostics;
using System.Linq;
using Catel;
using Catel.IoC;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public class CatelContainerAdapter : ContainerAdapterBase
    {
        private IServiceLocator container;

        public override string Name
        {
            get { return "Catel"; }
        }

        public override string PackageName
        {
            get { return "Catel.Core"; }
        }

        public override string Url
        {
            get { return "http://www.catelproject.com"; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return false; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.ResolveType(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterOpenGeneric();
            this.RegisterMultiple();
            this.RegisterInterceptor();
        }
        
        public override void PrepareBasic()
        {
            this.container = IoCFactory.CreateServiceLocator();

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
            this.container.RegisterType<IDummyOne, DummyOne>(RegistrationType.Transient);
            this.container.RegisterType<IDummyTwo, DummyTwo>(RegistrationType.Transient);
            this.container.RegisterType<IDummyThree, DummyThree>(RegistrationType.Transient);
            this.container.RegisterType<IDummyFour, DummyFour>(RegistrationType.Transient);
            this.container.RegisterType<IDummyFive, DummyFive>(RegistrationType.Transient);
            this.container.RegisterType<IDummySix, DummySix>(RegistrationType.Transient);
            this.container.RegisterType<IDummySeven, DummySeven>(RegistrationType.Transient);
            this.container.RegisterType<IDummyEight, DummyEight>(RegistrationType.Transient);
            this.container.RegisterType<IDummyNine, DummyNine>(RegistrationType.Transient);
            this.container.RegisterType<IDummyTen, DummyTen>(RegistrationType.Transient);
        }

        private void RegisterStandard()
        {
            this.container.RegisterType<ISingleton1, Singleton1>(RegistrationType.Singleton);
            this.container.RegisterType<ISingleton2, Singleton2>(RegistrationType.Singleton);
            this.container.RegisterType<ISingleton3, Singleton3>(RegistrationType.Singleton);

            this.container.RegisterType<ITransient1, Transient1>(RegistrationType.Transient);
            this.container.RegisterType<ITransient2, Transient2>(RegistrationType.Transient);
            this.container.RegisterType<ITransient3, Transient3>(RegistrationType.Transient);

            this.container.RegisterType<ICombined1, Combined1>(RegistrationType.Transient);
            this.container.RegisterType<ICombined2, Combined2>(RegistrationType.Transient);
            this.container.RegisterType<ICombined3, Combined3>(RegistrationType.Transient);
        }

        private void RegisterComplex()
        {
            this.container.RegisterType<IFirstService, FirstService>();
            this.container.RegisterType<ISecondService, SecondService>();
            this.container.RegisterType<IThirdService, ThirdService>();
            this.container.RegisterType<ISubObjectOne, SubObjectOne>(RegistrationType.Transient);
            this.container.RegisterType<ISubObjectTwo, SubObjectTwo>(RegistrationType.Transient);
            this.container.RegisterType<ISubObjectThree, SubObjectThree>(RegistrationType.Transient);
            this.container.RegisterType<IComplex1, Complex1>(RegistrationType.Transient);
            this.container.RegisterType<IComplex2, Complex2>(RegistrationType.Transient);
            this.container.RegisterType<IComplex3, Complex3>(RegistrationType.Transient);
        }

        private void RegisterOpenGeneric()
        {
            this.container.RegisterType(typeof(IGenericInterface<>), typeof(GenericExport<>), registrationType: RegistrationType.Transient);
            this.container.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>), registrationType: RegistrationType.Transient);
        }

        // TODO: This doesn't seem to work or I've configured it incorrectly. Either way it's turned off
        private void RegisterMultiple()
        {
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterOne>(RegistrationType.Transient);
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterTwo>(RegistrationType.Transient);
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterThree>(RegistrationType.Transient);
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFour>(RegistrationType.Transient);
            this.container.RegisterType<ISimpleAdapter, SimpleAdapterFive>(RegistrationType.Transient);

            this.container.RegisterType<ImportMultiple1, ImportMultiple1>(RegistrationType.Transient);
            this.container.RegisterType<ImportMultiple2, ImportMultiple2>(RegistrationType.Transient);
            this.container.RegisterType<ImportMultiple3, ImportMultiple3>(RegistrationType.Transient);
        }

        private void RegisterInterceptor()
        {
            this.container.RegisterType<ICalculator1, Calculator1>(RegistrationType.Transient);
            this.container.RegisterType<ICalculator2, Calculator2>(RegistrationType.Transient);
            this.container.RegisterType<ICalculator3, Calculator3>(RegistrationType.Transient);
            this.container.ConfigureInterceptionForType<ICalculator1, Calculator1>()
                .InterceptAll()
                .OnBefore(i =>
                          {
                              var args = string.Join(", ", i.Arguments.Select(x => (x ?? string.Empty).ToString()));
                              Debug.WriteLine(string.Format("Catel: {0}({1})", i.Method.Name, args));
                          });
            this.container.ConfigureInterceptionForType<ICalculator2, Calculator2>()
                .InterceptAll()
                .OnBefore(i =>
                          {
                              var args = string.Join(", ", i.Arguments.Select(x => (x ?? string.Empty).ToString()));
                              Debug.WriteLine(string.Format("Catel: {0}({1})", i.Method.Name, args));
                          });
            this.container.ConfigureInterceptionForType<ICalculator3, Calculator3>()
                .InterceptAll()
                .OnBefore(i =>
                          {
                              var args = string.Join(", ", i.Arguments.Select(x => (x ?? string.Empty).ToString()));
                              Debug.WriteLine(string.Format("Catel: {0}({1})", i.Method.Name, args));
                          });
        }
    }
}
