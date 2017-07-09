using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Extensions.Interception;

namespace IocPerformance.Adapters
{
    public sealed class SimpleInjectorContainerAdapter : ContainerAdapterBase
    {
        private Container container;
        private Dictionary<Type, InstanceProducer> scopedRegistrations = new Dictionary<Type, InstanceProducer>();

        public override string PackageName => "SimpleInjector";

        public override string Url => "https://simpleinjector.org";

        public override bool SupportsChildContainer => false;

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsInterception => true;

        public override IChildContainerAdapter CreateChildContainerAdapter() => new SimpleInjectorChildContainerAdapter(this.container, this.scopedRegistrations);

        public override T Resolve<T>() => this.container.GetInstance<T>();

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container.Dispose();
        }

        public override void Prepare()
        {
            this.CreateContainer();

            this.RegisterBasic();

            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterIntercepter();
            this.RegisterChild();
        }

        public override void PrepareBasic()
        {
            this.CreateContainer();

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
            this.container.RegisterSingleton<ISingleton1, Singleton1>();
            this.container.RegisterSingleton<ISingleton2, Singleton2>();
            this.container.RegisterSingleton<ISingleton3, Singleton3>();
            this.container.Register<ITransient1, Transient1>();
            this.container.Register<ITransient2, Transient2>();
            this.container.Register<ITransient3, Transient3>();
            this.container.Register<ICombined1, Combined1>();
            this.container.Register<ICombined2, Combined2>();
            this.container.Register<ICombined3, Combined3>();
            this.container.Register<ICalculator1, Calculator1>();
            this.container.Register<ICalculator2, Calculator2>();
            this.container.Register<ICalculator3, Calculator3>();
        }

        private void RegisterComplex()
        {
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.RegisterSingleton<IFirstService, FirstService>();
            this.container.RegisterSingleton<ISecondService, SecondService>();
            this.container.RegisterSingleton<IThirdService, ThirdService>();
            this.container.Register<IComplex1, Complex1>();
            this.container.Register<IComplex2, Complex2>();
            this.container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingleton<IServiceA, ServiceA>();
            this.container.RegisterSingleton<IServiceB, ServiceB>();
            this.container.RegisterSingleton<IServiceC, ServiceC>();

            this.container.Register<ISubObjectA, SubObjectA>();
            this.container.Register<ISubObjectB, SubObjectB>();
            this.container.Register<ISubObjectC, SubObjectC>();

            this.container.Register<IComplexPropertyObject1, ComplexPropertyObject1>();
            this.container.Register<IComplexPropertyObject2, ComplexPropertyObject2>();
            this.container.Register<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.container.Register<ImportConditionObject1>();
            this.container.Register<ImportConditionObject2>();
            this.container.Register<ImportConditionObject3>();

            this.container.RegisterConditional<IExportConditionInterface, ExportConditionalObject>(this.WhenInjectedInto<ImportConditionObject1>);
            this.container.RegisterConditional<IExportConditionInterface, ExportConditionalObject2>(this.WhenInjectedInto<ImportConditionObject2>);
            this.container.RegisterConditional<IExportConditionInterface, ExportConditionalObject3>(this.WhenInjectedInto<ImportConditionObject3>);
        }

        private bool WhenInjectedInto<T>(PredicateContext context) => context.Consumer.ImplementationType == typeof(T);

        private void RegisterMultiple()
        {
            this.container.RegisterCollection<ISimpleAdapter>(new[]
            {
                typeof(SimpleAdapterOne),
                typeof(SimpleAdapterTwo),
                typeof(SimpleAdapterThree),
                typeof(SimpleAdapterFour),
                typeof(SimpleAdapterFive)
            });
        }

        private void RegisterIntercepter()
        {
            this.container.InterceptWith<SimpleInjectorInterceptionLogger>(t => t.Equals(typeof(ICalculator1))
                || t.Equals(typeof(ICalculator2))
                || t.Equals(typeof(ICalculator3)));
        }

        private void RegisterChild()
        {
            this.scopedRegistrations[typeof(ICombined1)] = Lifestyle.Transient.CreateProducer<ICombined1>(
                () => new ScopedCombined1(new ScopedTransient(), this.container.GetInstance<ISingleton1>()),
                this.container);

            this.scopedRegistrations[typeof(ICombined2)] = Lifestyle.Transient.CreateProducer<ICombined2>(
                () => new ScopedCombined2(new ScopedTransient(), this.container.GetInstance<ISingleton1>()),
                this.container);

            this.scopedRegistrations[typeof(ICombined3)] = Lifestyle.Transient.CreateProducer<ICombined3>(
                () => new ScopedCombined3(new ScopedTransient(), this.container.GetInstance<ISingleton1>()),
                this.container);
        }

        private void CreateContainer()
        {
            this.container = new Container();
            this.container.Options.EnableDynamicAssemblyCompilation = true;
            this.container.Options.PropertySelectionBehavior = new InjectPropertiesMarkedWithImportAttribute();
        }

        private sealed class InjectPropertiesMarkedWithImportAttribute : IPropertySelectionBehavior
        {
            public bool SelectProperty(Type serviceType, PropertyInfo property) => property.GetCustomAttributes<ImportAttribute>().Any();
        }

        private sealed class SimpleInjectorChildContainerAdapter : IChildContainerAdapter
        {
            private readonly Container container;
            private readonly Dictionary<Type, InstanceProducer> scopedRegistrations;

            private Scope lifetimeScope;

            internal SimpleInjectorChildContainerAdapter(Container container, Dictionary<Type, InstanceProducer> scopedRegistrations)
            {
                this.container = container;
                this.scopedRegistrations = scopedRegistrations;
            }

            public void Prepare()
            {
                this.lifetimeScope = this.container.BeginLifetimeScope();
            }

            public void Dispose()
            {
                this.lifetimeScope.Dispose();
            }

            public object Resolve(Type resolveType)
            {
                InstanceProducer producer;

                if (this.scopedRegistrations.TryGetValue(resolveType, out producer))
                {
                    return producer.GetInstance();
                }

                return this.container.GetInstance(resolveType);
            }
        }
    }
}