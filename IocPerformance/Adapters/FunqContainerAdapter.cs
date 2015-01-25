using System;
using Funq;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class FunqContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "Funq"; }
        }

        public override string Url
        {
            get { return "https://funq.codeplex.com"; }
        }

        public override string Version
        {
            get { return typeof(Container).Assembly.GetName().Version.ToString(); }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            if (type == typeof(ITransient1))
            {
                return this.container.Resolve<ITransient1>();
            }

            if (type == typeof(ITransient2))
            {
                return this.container.Resolve<ITransient2>();
            }

            if (type == typeof(ITransient3))
            {
                return this.container.Resolve<ITransient3>();
            }

            if (type == typeof(ISingleton1))
            {
                return this.container.Resolve<ISingleton1>();
            }

            if (type == typeof(ISingleton2))
            {
                return this.container.Resolve<ISingleton2>();
            }

            if (type == typeof(ISingleton3))
            {
                return this.container.Resolve<ISingleton3>();
            }

            if (type == typeof(ICombined1))
            {
                return this.container.Resolve<ICombined1>();
            }

            if (type == typeof(ICombined2))
            {
                return this.container.Resolve<ICombined2>();
            }

            if (type == typeof(ICombined3))
            {
                return this.container.Resolve<ICombined3>();
            }

            if (type == typeof(IComplex1))
            {
                return this.container.Resolve<IComplex1>();
            }

            if (type == typeof(IComplex2))
            {
                return this.container.Resolve<IComplex2>();
            }

            if (type == typeof(IComplex3))
            {
                return this.container.Resolve<IComplex3>();
            }

            if (type == typeof(IComplexPropertyObject1))
            {
                return this.container.Resolve<IComplexPropertyObject1>();
            }

            if (type == typeof(IComplexPropertyObject2))
            {
                return this.container.Resolve<IComplexPropertyObject2>();
            }

            if (type == typeof(IComplexPropertyObject3))
            {
                return this.container.Resolve<IComplexPropertyObject3>();
            }

            if (type == typeof(IDummyOne))
            {
                return this.container.Resolve<IDummyOne>();
            }

            throw new ArgumentException("Non-injectable type requested: " + type.FullName, "type");
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.PrepareBasic();
            this.RegisterPropertyInjection();
        }

        public override void PrepareBasic()
        {
            this.container = new Funq.Container();

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
            this.container.Register<IDummyOne>(ioc => new DummyOne()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyTwo>(ioc => new DummyTwo()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyThree>(ioc => new DummyThree()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyFour>(ioc => new DummyFour()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyFive>(ioc => new DummyFive()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummySix>(ioc => new DummySix()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummySeven>(ioc => new DummySeven()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyEight>(ioc => new DummyEight()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyNine>(ioc => new DummyNine()).ReusedWithin(ReuseScope.None);
            this.container.Register<IDummyTen>(ioc => new DummyTen()).ReusedWithin(ReuseScope.None);
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton1>(ioc => new Singleton1())
                .ReusedWithin(Funq.ReuseScope.Container);
            this.container.Register<ISingleton2>(ioc => new Singleton2())
                .ReusedWithin(Funq.ReuseScope.Container);
            this.container.Register<ISingleton3>(ioc => new Singleton3())
                .ReusedWithin(Funq.ReuseScope.Container);

            this.container.Register<ITransient1>(ioc => new Transient1())
                .ReusedWithin(Funq.ReuseScope.None);
            this.container.Register<ITransient2>(ioc => new Transient2())
                .ReusedWithin(Funq.ReuseScope.None);
            this.container.Register<ITransient3>(ioc => new Transient3())
                .ReusedWithin(Funq.ReuseScope.None);

            this.container.Register<ICombined1>(ioc => new Combined1(
                ioc.Resolve<ISingleton1>(),
                ioc.Resolve<ITransient1>()))
                .ReusedWithin(Funq.ReuseScope.None);
            this.container.Register<ICombined2>(ioc => new Combined2(
                ioc.Resolve<ISingleton2>(),
                ioc.Resolve<ITransient2>()))
                .ReusedWithin(Funq.ReuseScope.None);
            this.container.Register<ICombined3>(ioc => new Combined3(
                ioc.Resolve<ISingleton3>(),
                ioc.Resolve<ITransient3>()))
                .ReusedWithin(Funq.ReuseScope.None);
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService>(ioc => new FirstService()).ReusedWithin(ReuseScope.Container);
            this.container.Register<ISecondService>(ioc => new SecondService()).ReusedWithin(ReuseScope.Container);
            this.container.Register<IThirdService>(ioc => new ThirdService()).ReusedWithin(ReuseScope.Container);

            this.container.Register<ISubObjectOne>(ioc => new SubObjectOne(ioc.Resolve<IFirstService>()))
                .ReusedWithin(ReuseScope.None);
            this.container.Register<ISubObjectTwo>(ioc => new SubObjectTwo(ioc.Resolve<ISecondService>()))
                .ReusedWithin(ReuseScope.None);
            this.container.Register<ISubObjectThree>(ioc => new SubObjectThree(ioc.Resolve<IThirdService>()))
                .ReusedWithin(ReuseScope.None);

            this.container.Register<IComplex1>(
                ioc => new Complex1(
                    ioc.Resolve<IFirstService>(),
                    ioc.Resolve<ISecondService>(),
                    ioc.Resolve<IThirdService>(),
                    ioc.Resolve<ISubObjectOne>(),
                    ioc.Resolve<ISubObjectTwo>(),
                    ioc.Resolve<ISubObjectThree>()))
                .ReusedWithin(ReuseScope.None);
            this.container.Register<IComplex2>(
                ioc => new Complex2(
                    ioc.Resolve<IFirstService>(),
                    ioc.Resolve<ISecondService>(),
                    ioc.Resolve<IThirdService>(),
                    ioc.Resolve<ISubObjectOne>(),
                    ioc.Resolve<ISubObjectTwo>(),
                    ioc.Resolve<ISubObjectThree>()))
                .ReusedWithin(ReuseScope.None);
            this.container.Register<IComplex3>(
                ioc => new Complex3(
                    ioc.Resolve<IFirstService>(),
                    ioc.Resolve<ISecondService>(),
                    ioc.Resolve<IThirdService>(),
                    ioc.Resolve<ISubObjectOne>(),
                    ioc.Resolve<ISubObjectTwo>(),
                    ioc.Resolve<ISubObjectThree>()))
                .ReusedWithin(ReuseScope.None);
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA>(ioc => new ServiceA()).ReusedWithin(ReuseScope.Container);
            this.container.Register<IServiceB>(ioc => new ServiceB()).ReusedWithin(ReuseScope.Container);
            this.container.Register<IServiceC>(ioc => new ServiceC()).ReusedWithin(ReuseScope.Container);

            this.container.Register<ISubObjectA>(ioc => new SubObjectA { ServiceA = ioc.Resolve<IServiceA>() })
                .ReusedWithin(ReuseScope.None);
            this.container.Register<ISubObjectB>(ioc => new SubObjectB { ServiceB = ioc.Resolve<IServiceB>() })
                .ReusedWithin(ReuseScope.None);
            this.container.Register<ISubObjectC>(ioc => new SubObjectC { ServiceC = ioc.Resolve<IServiceC>() })
                .ReusedWithin(ReuseScope.None);

            this.container.Register<IComplexPropertyObject1>(
                ioc => new ComplexPropertyObject1
                {
                    ServiceA = ioc.Resolve<IServiceA>(),
                    ServiceB = ioc.Resolve<IServiceB>(),
                    ServiceC = ioc.Resolve<IServiceC>(),
                    SubObjectA = ioc.Resolve<ISubObjectA>(),
                    SubObjectB = ioc.Resolve<ISubObjectB>(),
                    SubObjectC = ioc.Resolve<ISubObjectC>()
                }).ReusedWithin(ReuseScope.None);

            this.container.Register<IComplexPropertyObject2>(
                ioc => new ComplexPropertyObject2
                {
                    ServiceA = ioc.Resolve<IServiceA>(),
                    ServiceB = ioc.Resolve<IServiceB>(),
                    ServiceC = ioc.Resolve<IServiceC>(),
                    SubObjectA = ioc.Resolve<ISubObjectA>(),
                    SubObjectB = ioc.Resolve<ISubObjectB>(),
                    SubObjectC = ioc.Resolve<ISubObjectC>()
                }).ReusedWithin(ReuseScope.None);

            this.container.Register<IComplexPropertyObject3>(
                ioc => new ComplexPropertyObject3
                {
                    ServiceA = ioc.Resolve<IServiceA>(),
                    ServiceB = ioc.Resolve<IServiceB>(),
                    ServiceC = ioc.Resolve<IServiceC>(),
                    SubObjectA = ioc.Resolve<ISubObjectA>(),
                    SubObjectB = ioc.Resolve<ISubObjectB>(),
                    SubObjectC = ioc.Resolve<ISubObjectC>()
                }).ReusedWithin(ReuseScope.None);
        }
    }
}