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
using SimpleInjector.Extensions.LifetimeScoping;

namespace IocPerformance.Adapters
{
    public sealed class SimpleInjectorContainerAdapter : ContainerAdapterBase
    {
        private Container container;
        private Dictionary<Type, InstanceProducer> scopedRegistrations = new Dictionary<Type, InstanceProducer>();

        public override string PackageName
        {
            get { return "SimpleInjector"; }
        }

        public override string Url
        {
            get { return "https://simpleinjector.org"; }
        }

        public override bool SupportsConditional
        {
            get { return true; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }        

        public override bool SupportsChildContainer
        {
            // SimpleInjector does not support child containers directly
            // You can enable it with some custom code, but here it is considered as not supported
            get { return false; }
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new SimpleInjectorChildContainerAdapter(this.container, this.scopedRegistrations);
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container.Dispose();
        }

        public override void Prepare()
        {
            this.container = new SimpleInjector.Container();

            this.container.Options.PropertySelectionBehavior = new InjectPropertiesMarkedWith<ImportAttribute>();

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
            this.container = new SimpleInjector.Container();
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
            var container = this.container;

            container.Register<ImportConditionObject1>();
            container.Register<ImportConditionObject2>();
            container.Register<ImportConditionObject3>();

            container.RegisterConditional<IExportConditionInterface, ExportConditionalObject>(WhenInjectedInto<ImportConditionObject1>);
            container.RegisterConditional<IExportConditionInterface, ExportConditionalObject2>(WhenInjectedInto<ImportConditionObject2>);
            container.RegisterConditional<IExportConditionInterface, ExportConditionalObject3>(WhenInjectedInto<ImportConditionObject3>);
        }

        private bool WhenInjectedInto<T>(PredicateContext context)
        {
            return context.Consumer.ImplementationType == typeof(T);
        }

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
            this.container.InterceptWith<SimpleInjectorInterceptionLogger>(type => type.Name.StartsWith("ICalculator"));
        }

        private void RegisterChild()
        {
            var scopedLifestyle = new LifetimeScopeLifestyle();

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

        private sealed class InjectPropertiesMarkedWith<TAttribute> : IPropertySelectionBehavior
            where TAttribute : Attribute
        {
            public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
            {
                return propertyInfo.GetCustomAttributes<TAttribute>().Any();
            }
        }

        private sealed class SimpleInjectorChildContainerAdapter : IChildContainerAdapter
        {
            private readonly Container container;
            private readonly Dictionary<Type, InstanceProducer> scopedRegistrations;

            private Scope lifetimeScope;

            internal SimpleInjectorChildContainerAdapter(
                Container container,
                Dictionary<Type, InstanceProducer> scopedRegistrations)
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