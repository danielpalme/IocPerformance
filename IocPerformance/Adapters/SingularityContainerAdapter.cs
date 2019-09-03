using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using Microsoft.Extensions.DependencyInjection;
using Singularity;
using Singularity.Microsoft.DependencyInjection;

namespace IocPerformance.Adapters
{
    public class SingularityContainerAdapter : ContainerAdapterBase
    {
        private Container _container;

        public override bool SupportGeneric => true;
        public override bool SupportsChildContainer => false;
        public override bool SupportsMultiple => true;
        public override bool SupportAspNetCore => true;

        public override string PackageName { get; } = "Singularity";
        public override string Url { get; } = "https://github.com/Barsonax/Singularity";

        public override IChildContainerAdapter CreateChildContainerAdapter() => new SingularityChildContainerAdapter(this._container);

        public override void Prepare()
        {
            this._container = new Container(builder =>
            {
                this.RegisterBasic(builder);
                this.RegisterOpenGeneric(builder);
                this.RegisterMultiple(builder);
                this.RegisterAspNetCore(builder);
            }, SingularitySettings.Microsoft);
        }

        public override void PrepareBasic()
        {
            this._container = new Container(RegisterBasic, SingularitySettings.Microsoft);
        }

        private void RegisterBasic(ContainerBuilder builder)
        {
            this.RegisterDummies(builder);
            this.RegisterStandard(builder);
            this.RegisterComplex(builder);
        }

        public override object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }

        private void RegisterAspNetCore(ContainerBuilder builder)
        {
            ServiceCollection services = new ServiceCollection();

            RegisterAspNetCoreClasses(services);
            builder.RegisterServiceProvider();

            builder.RegisterServices(services);
        }

        private void RegisterDummies(ContainerBuilder builder)
        {
            builder.Register<IDummyOne, DummyOne>();
            builder.Register<IDummyTwo, DummyTwo>();
            builder.Register<IDummyThree, DummyThree>();
            builder.Register<IDummyFour, DummyFour>();
            builder.Register<IDummyFive, DummyFive>();
            builder.Register<IDummySix, DummySix>();
            builder.Register<IDummySeven, DummySeven>();
            builder.Register<IDummyEight, DummyEight>();
            builder.Register<IDummyNine, DummyNine>();
            builder.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard(ContainerBuilder builder)
        {
            builder.Register<ISingleton1, Singleton1>(c => c
                .With(Lifetimes.PerContainer));
            builder.Register<ISingleton2, Singleton2>(c => c
                .With(Lifetimes.PerContainer));
            builder.Register<ISingleton3, Singleton3>(c => c
                .With(Lifetimes.PerContainer));
            builder.Register<ITransient1, Transient1>();
            builder.Register<ITransient2, Transient2>();
            builder.Register<ITransient3, Transient3>();
            builder.Register<ICombined1, Combined1>();
            builder.Register<ICombined2, Combined2>();
            builder.Register<ICombined3, Combined3>();
            builder.Register<ICalculator1, Calculator1>();
            builder.Register<ICalculator2, Calculator2>();
            builder.Register<ICalculator3, Calculator3>();
        }

        private void RegisterComplex(ContainerBuilder builder)
        {
            builder.Register<ISubObjectOne, SubObjectOne>();
            builder.Register<ISubObjectTwo, SubObjectTwo>();
            builder.Register<ISubObjectThree, SubObjectThree>();
            builder.Register<IFirstService, FirstService>(c => c
                .With(Lifetimes.PerContainer));
            builder.Register<ISecondService, SecondService>(c => c
                .With(Lifetimes.PerContainer));
            builder.Register<IThirdService, ThirdService>(c => c
                .With(Lifetimes.PerContainer));
            builder.Register<IComplex1, Complex1>();
            builder.Register<IComplex2, Complex2>();
            builder.Register<IComplex3, Complex3>();
        }

        private void RegisterOpenGeneric(ContainerBuilder builder)
        {
            builder.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            builder.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterMultiple(ContainerBuilder builder)
        {
            builder.Register<ISimpleAdapter, SimpleAdapterOne>();
            builder.Register<ISimpleAdapter, SimpleAdapterTwo>();
            builder.Register<ISimpleAdapter, SimpleAdapterThree>();
            builder.Register<ISimpleAdapter, SimpleAdapterFour>();
            builder.Register<ISimpleAdapter, SimpleAdapterFive>();
        }

        public override void Dispose()
        {
            _container.Dispose();
        }

        private sealed class SingularityChildContainerAdapter : IChildContainerAdapter
        {
            private Container _container;
            private readonly Container _parentContainer;

            internal SingularityChildContainerAdapter(Container parentContainer)
            {
                _parentContainer = parentContainer;
            }

            public void Dispose()
            {
                this._container.Dispose();
            }

            public void Prepare()
            {
                this._container = this._parentContainer.GetNestedContainer(RegisterChild);
            }

            public object Resolve(Type resolveType)
            {
                return this._container.GetInstance(resolveType);
            }

            private void RegisterChild(ContainerBuilder config)
            {
                config.Register<ICombined1, ScopedCombined1>();
                config.Register<ICombined2, ScopedCombined2>();
                config.Register<ICombined3, ScopedCombined3>();

                config.Register<ITransient1, ScopedTransient>();
            }
        }
    }
}
