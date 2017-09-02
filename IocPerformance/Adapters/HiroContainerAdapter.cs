// Ignored. Reason: Container fails
using System;
using Hiro;
using Hiro.Containers;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class HiroContainerAdapter : ContainerAdapterBase
    {
        private IMicroContainer container;

        public override string PackageName => "Hiro";

        public override string Url => "https://github.com/philiplaureano/Hiro";

        public override bool SupportsPropertyInjection => true;

        public override object Resolve(Type type) => this.container.GetInstance(type, null);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            var map = new DependencyMap();
            RegisterBasic(map);
            
            RegisterPropertyInjection(map);

            this.container = map.CreateContainer();
        }
        
        public override void PrepareBasic()
        {
            var map = new DependencyMap();
            RegisterBasic(map);  
            this.container = map.CreateContainer();
        }

        private static void RegisterBasic(DependencyMap map)
        {
            RegisterDummies(map);
            RegisterStandard(map);
            RegisterComplex(map);
        }

        private static void RegisterDummies(DependencyMap map)
        {
            map.AddService<IDummyOne, DummyOne>();
            map.AddService<IDummyTwo, DummyTwo>();
            map.AddService<IDummyThree, DummyThree>();
            map.AddService<IDummyFour, DummyFour>();
            map.AddService<IDummyFive, DummyFive>();
            map.AddService<IDummySix, DummySix>();
            map.AddService<IDummySeven, DummySeven>();
            map.AddService<IDummyEight, DummyEight>();
            map.AddService<IDummyNine, DummyNine>();
            map.AddService<IDummyTen, DummyTen>();
        }

        private static void RegisterStandard(DependencyMap map)
        {
            map.AddSingletonService<ISingleton1, Singleton1>();
            map.AddSingletonService<ISingleton2, Singleton2>();
            map.AddSingletonService<ISingleton3, Singleton3>();
            map.AddService<ITransient1, Transient1>();
            map.AddService<ITransient2, Transient2>();
            map.AddService<ITransient3, Transient3>();
            map.AddService<ICombined1, Combined1>();
            map.AddService<ICombined2, Combined2>();
            map.AddService<ICombined3, Combined3>();
        }

        private static void RegisterComplex(DependencyMap map)
        {
            map.AddSingletonService<IFirstService, FirstService>();
            map.AddSingletonService<ISecondService, SecondService>();
            map.AddSingletonService<IThirdService, ThirdService>();
            map.AddService<ISubObjectOne, SubObjectOne>();
            map.AddService<ISubObjectTwo, SubObjectTwo>();
            map.AddService<ISubObjectThree, SubObjectThree>();
            map.AddService<IComplex1, Complex1>();
            map.AddService<IComplex2, Complex2>();
            map.AddService<IComplex3, Complex3>();
        }

        private static void RegisterPropertyInjection(DependencyMap map)
        {
            map.AddSingletonService<IServiceA, ServiceA>();
            map.AddSingletonService<IServiceB, ServiceB>();
            map.AddSingletonService<IServiceC, ServiceC>();
            map.AddService(new Func<IMicroContainer, ISubObjectA>(
                microContainer => new SubObjectA { ServiceA = microContainer.GetInstance<IServiceA>() }));
            map.AddService(new Func<IMicroContainer, ISubObjectB>(
                microContainer => new SubObjectB { ServiceB = microContainer.GetInstance<IServiceB>() }));
            map.AddService(new Func<IMicroContainer, ISubObjectC>(
                microContainer => new SubObjectC { ServiceC = microContainer.GetInstance<IServiceC>() }));
            
            // HACK: We must wrap the delegate explicitly in a Func<T, TResult> or else resolving will fail.
            map.AddService(new Func<IMicroContainer, IComplexPropertyObject1>(
                microContainer => new ComplexPropertyObject1
                {
                    ServiceA = microContainer.GetInstance<IServiceA>(),
                    ServiceB = microContainer.GetInstance<IServiceB>(),
                    ServiceC = microContainer.GetInstance<IServiceC>(),
                    SubObjectA = microContainer.GetInstance<ISubObjectA>(),
                    SubObjectB = microContainer.GetInstance<ISubObjectB>(),
                    SubObjectC = microContainer.GetInstance<ISubObjectC>()
                }));

            map.AddService(new Func<IMicroContainer, IComplexPropertyObject2>(
                microContainer => new ComplexPropertyObject2
                {
                    ServiceA = microContainer.GetInstance<IServiceA>(),
                    ServiceB = microContainer.GetInstance<IServiceB>(),
                    ServiceC = microContainer.GetInstance<IServiceC>(),
                    SubObjectA = microContainer.GetInstance<ISubObjectA>(),
                    SubObjectB = microContainer.GetInstance<ISubObjectB>(),
                    SubObjectC = microContainer.GetInstance<ISubObjectC>()
                }));

            map.AddService(new Func<IMicroContainer, IComplexPropertyObject3>(
                microContainer => new ComplexPropertyObject3
                {
                    ServiceA = microContainer.GetInstance<IServiceA>(),
                    ServiceB = microContainer.GetInstance<IServiceB>(),
                    ServiceC = microContainer.GetInstance<IServiceC>(),
                    SubObjectA = microContainer.GetInstance<ISubObjectA>(),
                    SubObjectB = microContainer.GetInstance<ISubObjectB>(),
                    SubObjectC = microContainer.GetInstance<ISubObjectC>()
                }));
        }
    }
}