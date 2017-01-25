using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace IocPerformance.Adapters
{
    public sealed class MicrosoftExtensionsDependencyInjectionContainerAdapter : ContainerAdapterBase
    {
        private IServiceCollection serviceCollection;

        private IServiceProvider serviceProvider;

        public override string PackageName => "Microsoft.Extensions.DependencyInjection";

        public override string Name => "Microsoft Extensions DependencyInjection";

        public override string Url => "https://github.com/aspnet/DependencyInjection";

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override object Resolve(Type type) => this.serviceProvider.GetService(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.serviceCollection = null;
            this.serviceProvider = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();

            this.RegisterOpenGeneric();
            this.RegisterMultiple();

            this.serviceProvider = this.serviceCollection.BuildServiceProvider();
        }

        public override void PrepareBasic()
        {
            this.serviceCollection = new ServiceCollection();

            this.RegisterBasic();

            this.serviceProvider = this.serviceCollection.BuildServiceProvider();
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.serviceCollection.AddTransient<IDummyOne, DummyOne>();
            this.serviceCollection.AddTransient<IDummyTwo, DummyTwo>();
            this.serviceCollection.AddTransient<IDummyThree, DummyThree>();
            this.serviceCollection.AddTransient<IDummyFour, DummyFour>();
            this.serviceCollection.AddTransient<IDummyFive, DummyFive>();
            this.serviceCollection.AddTransient<IDummySix, DummySix>();
            this.serviceCollection.AddTransient<IDummySeven, DummySeven>();
            this.serviceCollection.AddTransient<IDummyEight, DummyEight>();
            this.serviceCollection.AddTransient<IDummyNine, DummyNine>();
            this.serviceCollection.AddTransient<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.serviceCollection.AddSingleton<ISingleton1, Singleton1>();
            this.serviceCollection.AddSingleton<ISingleton2, Singleton2>();
            this.serviceCollection.AddSingleton<ISingleton3, Singleton3>();
            this.serviceCollection.AddTransient<ITransient1, Transient1>();
            this.serviceCollection.AddTransient<ITransient2, Transient2>();
            this.serviceCollection.AddTransient<ITransient3, Transient3>();
            this.serviceCollection.AddTransient<ICombined1, Combined1>();
            this.serviceCollection.AddTransient<ICombined2, Combined2>();
            this.serviceCollection.AddTransient<ICombined3, Combined3>();
            this.serviceCollection.AddTransient<ICalculator1, Calculator1>();
            this.serviceCollection.AddTransient<ICalculator2, Calculator2>();
            this.serviceCollection.AddTransient<ICalculator3, Calculator3>();
        }

        private void RegisterComplex()
        {
            this.serviceCollection.AddTransient<ISubObjectOne, SubObjectOne>();
            this.serviceCollection.AddTransient<ISubObjectTwo, SubObjectTwo>();
            this.serviceCollection.AddTransient<ISubObjectThree, SubObjectThree>();
            this.serviceCollection.AddSingleton<IFirstService, FirstService>();
            this.serviceCollection.AddSingleton<ISecondService, SecondService>();
            this.serviceCollection.AddSingleton<IThirdService, ThirdService>();
            this.serviceCollection.AddTransient<IComplex1, Complex1>();
            this.serviceCollection.AddTransient<IComplex2, Complex2>();
            this.serviceCollection.AddTransient<IComplex3, Complex3>();
        }

        private void RegisterOpenGeneric()
        {
            this.serviceCollection.AddTransient(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.serviceCollection.AddTransient(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterMultiple()
        {
            this.serviceCollection.AddTransient<ImportMultiple1>();
            this.serviceCollection.AddTransient<ImportMultiple2>();
            this.serviceCollection.AddTransient<ImportMultiple3>();
            this.serviceCollection.AddTransient<ISimpleAdapter, SimpleAdapterOne>();
            this.serviceCollection.AddTransient<ISimpleAdapter, SimpleAdapterTwo>();
            this.serviceCollection.AddTransient<ISimpleAdapter, SimpleAdapterThree>();
            this.serviceCollection.AddTransient<ISimpleAdapter, SimpleAdapterFour>();
            this.serviceCollection.AddTransient<ISimpleAdapter, SimpleAdapterFive>();
        }
    }
}