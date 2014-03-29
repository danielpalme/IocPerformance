using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using Speedioc;
using Speedioc.Core;
using Speedioc.Registration;

namespace IocPerformance.Adapters
{
    public sealed class SpeediocContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName
        {
            get { return "Speedioc"; }
        }

        public override string Url
        {
            get { return "https://github.com/wade/Speedioc"; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            ContainerSettings settings = new DefaultContainerSettings("Speedioc");
            settings.ForceCompile = true;

            IRegistry registry = new Registry();

            RegisterDummies(registry);
            RegisterStandard(registry);
            RegisterComplex(registry);

            registry.Register<Singleton1>().As<ISingleton1>().WithLifetime(Lifetime.Container).PreCreateInstance();
            registry.Register<Transient1>().As<ITransient1>().WithLifetime(Lifetime.Transient);
            registry.Register<Combined1>().As<ICombined1>().WithLifetime(Lifetime.Transient)
                .UsingConstructor()
                .WithResolvedParameter<ISingleton1>()
                .WithResolvedParameter<ITransient1>()
                .AsLastParameter();

            IContainerBuilder containerBuilder = DefaultContainerBuilderFactory.GetInstance(settings, registry);
            this.container = containerBuilder.Build();
        }

        private static void RegisterDummies(IRegistry registry)
        {
            registry.Register<DummyOne>().As<IDummyOne>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyTwo>().As<IDummyTwo>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyThree>().As<IDummyThree>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyFour>().As<IDummyFour>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyFive>().As<IDummyFive>().WithLifetime(Lifetime.Transient);
            registry.Register<DummySix>().As<IDummySix>().WithLifetime(Lifetime.Transient);
            registry.Register<DummySeven>().As<IDummySeven>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyEight>().As<IDummyEight>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyNine>().As<IDummyNine>().WithLifetime(Lifetime.Transient);
            registry.Register<DummyTen>().As<IDummyTen>().WithLifetime(Lifetime.Transient);
        }

        private static void RegisterStandard(IRegistry registry)
        {
            registry.Register<Singleton1>().As<ISingleton1>().WithLifetime(Lifetime.Container).PreCreateInstance();
            registry.Register<Transient1>().As<ITransient1>().WithLifetime(Lifetime.Transient);
            registry.Register<Combined1>().As<ICombined1>().WithLifetime(Lifetime.Transient)
                .UsingConstructor()
                .WithResolvedParameter<ISingleton1>()
                .WithResolvedParameter<ITransient1>()
                .AsLastParameter();
        }

        private static void RegisterComplex(IRegistry registry)
        {
            registry.Register<SubObjectOne>().As<ISubObjectOne>().WithLifetime(Lifetime.Transient);
            registry.Register<SubObjectTwo>().As<ISubObjectTwo>().WithLifetime(Lifetime.Transient);
            registry.Register<SubObjectThree>().As<ISubObjectThree>().WithLifetime(Lifetime.Transient);
            registry.Register<FirstService>().As<IFirstService>().WithLifetime(Lifetime.Container).PreCreateInstance();
            registry.Register<SecondService>().As<ISecondService>().WithLifetime(Lifetime.Container).PreCreateInstance();
            registry.Register<ThirdService>().As<IThirdService>().WithLifetime(Lifetime.Container).PreCreateInstance();
            registry.Register<Complex1>().As<IComplex1>().WithLifetime(Lifetime.Transient);
        }
    }
}