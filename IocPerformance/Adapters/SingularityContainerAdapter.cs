using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Standard;
using Singularity;

namespace IocPerformance.Adapters
{
    public class SingularityContainerAdapter : ContainerAdapterBase
    {
        private Container _container;

        public override bool SupportGeneric => true;
        public override bool SupportsChildContainer => true;

        public override string PackageName { get; } = "Singularity";
        public override string Url { get; } = "https://github.com/Barsonax/Singularity";

        public override IChildContainerAdapter CreateChildContainerAdapter() => new SingularityChildContainerAdapter(this._container);

        public override void Prepare()
        {
            var config = new BindingConfig();
            RegisterBasic(config);
            RegisterOpenGeneric(config);
            this._container = new Container(config);
        }

        public override void PrepareBasic()
        {
            var config = new BindingConfig();
            RegisterBasic(config);

            this._container = new Container(config);
        }

        private void RegisterBasic(BindingConfig config)
        {
            this.RegisterDummies(config);
            this.RegisterStandard(config);
            this.RegisterComplex(config);
        }

        public override object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }

        private void RegisterDummies(BindingConfig config)
        {
            config.Register<IDummyOne, DummyOne>();
            config.Register<IDummyTwo, DummyTwo>();
            config.Register<IDummyThree, DummyThree>();
            config.Register<IDummyFour, DummyFour>();
            config.Register<IDummyFive, DummyFive>();
            config.Register<IDummySix, DummySix>();
            config.Register<IDummySeven, DummySeven>();
            config.Register<IDummyEight, DummyEight>();
            config.Register<IDummyNine, DummyNine>();
            config.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard(BindingConfig config)
        {
            config.Register<ISingleton1, Singleton1>().With(CreationMode.Singleton);
            config.Register<ISingleton2, Singleton2>().With(CreationMode.Singleton);
            config.Register<ISingleton3, Singleton3>().With(CreationMode.Singleton);
            config.Register<ITransient1, Transient1>();
            config.Register<ITransient2, Transient2>();
            config.Register<ITransient3, Transient3>();
            config.Register<ICombined1, Combined1>();
            config.Register<ICombined2, Combined2>();
            config.Register<ICombined3, Combined3>();
            config.Register<ICalculator1, Calculator1>();
            config.Register<ICalculator2, Calculator2>();
            config.Register<ICalculator3, Calculator3>();
        }

        private void RegisterComplex(BindingConfig config)
        {
            config.Register<ISubObjectOne, SubObjectOne>();
            config.Register<ISubObjectTwo, SubObjectTwo>();
            config.Register<ISubObjectThree, SubObjectThree>();
            config.Register<IFirstService, FirstService>().With(CreationMode.Singleton);
            config.Register<ISecondService, SecondService>().With(CreationMode.Singleton);
            config.Register<IThirdService, ThirdService>().With(CreationMode.Singleton);
            config.Register<IComplex1, Complex1>();
            config.Register<IComplex2, Complex2>();
            config.Register<IComplex3, Complex3>();
        }

        private void RegisterOpenGeneric(BindingConfig config)
        {
            config.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            config.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        public override void Dispose()
        {
            _container.Dispose();
        }

        private sealed class SingularityChildContainerAdapter : IChildContainerAdapter
        {
            private Container _container;
            private Container _parentContainer;
            private BindingConfig _childBindingConfig;

            internal SingularityChildContainerAdapter(Container parentContainer)
            {
                _parentContainer = parentContainer;
                _childBindingConfig = new BindingConfig();
                RegisterChild(_childBindingConfig);
            }

            public void Dispose()
            {
                this._container.Dispose();
            }

            public void Prepare()
            {
                this._container = this._parentContainer.GetNestedContainer(_childBindingConfig);
            }

            public object Resolve(Type resolveType)
            {
                return this._container.GetInstance(resolveType);
            }

            private void RegisterChild(BindingConfig config)
            {
                config.Register<ICombined1, ScopedCombined1>();
                config.Register<ICombined2, ScopedCombined2>();
                config.Register<ICombined3, ScopedCombined3>();

                config.Register<ITransient1, ScopedTransient>();
            }
        }
    }
}
