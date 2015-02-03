using System;
using Dynamo.Ioc;
using IocPerformance.Classes;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generated;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : ContainerAdapterBase
    {
        private IocContainer container;

        public override string Name
        {
            get { return "Dynamo"; }
        }

        public override string PackageName
        {
            get { return "Dynamo.Ioc"; }
        }

        public override string Url
        {
            get { return "http://www.dynamoioc.com"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new IocContainer(defaultCompileMode: CompileMode.Dynamic);

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.container.Compile();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne, DummyOne>();
            this.container.Register<IDummyTwo, DummyTwo>();
            this.container.Register<IDummyThree, DummyThree>();
            this.container.Register<IDummyFour, DummyFour>();
            this.container.Register<IDummyFive, DummyFive>();
            this.container.Register<IDummySix, DummySix>();
            this.container.Register<IDummySeven, DummySeven>();
            this.container.Register<IDummyEight, DummyEight>();
            this.container.Register<IDummyNine, DummyNine>();
            this.container.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton1, Singleton1>().WithContainerLifetime();
            this.container.Register<ISingleton2, Singleton2>().WithContainerLifetime();
            this.container.Register<ISingleton3, Singleton3>().WithContainerLifetime();
            this.container.Register<ITransient1, Transient1>();
            this.container.Register<ITransient2, Transient2>();
            this.container.Register<ITransient3, Transient3>();
            this.container.Register<ICombined1, Combined1>();
            this.container.Register<ICombined2, Combined2>();
            this.container.Register<ICombined3, Combined3>();
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>().WithContainerLifetime();
            this.container.Register<ISecondService, SecondService>().WithContainerLifetime();
            this.container.Register<IThirdService, ThirdService>().WithContainerLifetime();
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.Register<IComplex1, Complex1>();
            this.container.Register<IComplex2, Complex2>();
            this.container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.Register<IServiceA, ServiceA>().WithContainerLifetime();
            this.container.Register<IServiceB, ServiceB>().WithContainerLifetime();
            this.container.Register<IServiceC, ServiceC>().WithContainerLifetime();

            this.container.Register<ISubObjectA>(x => new SubObjectA { ServiceA = x.Resolve<IServiceA>() })
                .WithTransientLifetime();
            this.container.Register<ISubObjectB>(x => new SubObjectB { ServiceB = x.Resolve<IServiceB>() }).WithTransientLifetime();
            this.container.Register<ISubObjectC>(x => new SubObjectC { ServiceC = x.Resolve<IServiceC>() }).WithTransientLifetime();

            this.container.Register<IComplexPropertyObject1>(x => new ComplexPropertyObject1
                                                                     {
                                                                         ServiceA = x.Resolve<IServiceA>(),
                                                                         ServiceB = x.Resolve<IServiceB>(),
                                                                         ServiceC = x.Resolve<IServiceC>(),
                                                                         SubObjectA = x.Resolve<ISubObjectA>(),
                                                                         SubObjectB = x.Resolve<ISubObjectB>(),
                                                                         SubObjectC = x.Resolve<ISubObjectC>()
                                                                     }).WithTransientLifetime();

            this.container.Register<IComplexPropertyObject2>(x => new ComplexPropertyObject2
                                                                    {
                                                                        ServiceA = x.Resolve<IServiceA>(),
                                                                        ServiceB = x.Resolve<IServiceB>(),
                                                                        ServiceC = x.Resolve<IServiceC>(),
                                                                        SubObjectA = x.Resolve<ISubObjectA>(),
                                                                        SubObjectB = x.Resolve<ISubObjectB>(),
                                                                        SubObjectC = x.Resolve<ISubObjectC>()
                                                                    }).WithTransientLifetime();

            this.container.Register<IComplexPropertyObject3>(x => new ComplexPropertyObject3
                                                                    {
                                                                        ServiceA = x.Resolve<IServiceA>(),
                                                                        ServiceB = x.Resolve<IServiceB>(),
                                                                        ServiceC = x.Resolve<IServiceC>(),
                                                                        SubObjectA = x.Resolve<ISubObjectA>(),
                                                                        SubObjectB = x.Resolve<ISubObjectB>(),
                                                                        SubObjectC = x.Resolve<ISubObjectC>()
                                                                    }).WithTransientLifetime();
        }

        public override void Register(InterfaceAndImplemtation[] services)
        {
            var tmpContainer = new IocContainer(defaultCompileMode: CompileMode.Dynamic);
            foreach (var service in services)
            {
                tmpContainer.Register(service.Interface, service.Implementation);
            }
            tmpContainer.Resolve(services[0].Interface);
        }
    }
}