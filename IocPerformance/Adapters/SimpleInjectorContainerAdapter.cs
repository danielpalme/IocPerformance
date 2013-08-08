﻿using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Conditional;
using IocPerformance.Interception;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Extensions;
using SimpleInjector.Extensions.Interception;

namespace IocPerformance.Adapters
{
    public sealed class SimpleInjectorContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "SimpleInjector"; }
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

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new SimpleInjector.Container();

            this.container.Options.PropertySelectionBehavior = new InjectPropertiesMarkedWith<ImportAttribute>();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
            this.RegisterIntercepter();

            this.container.Verify();
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
            this.container.RegisterSingle<ISingleton, Singleton>();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Register<ICalculator, Calculator>();
        }

        private void RegisterComplex()
        {
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.RegisterSingle<IFirstService, FirstService>();
            this.container.RegisterSingle<ISecondService, SecondService>();
            this.container.RegisterSingle<IThirdService, ThirdService>();
            this.container.Register<IComplex, Complex>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.RegisterSingle<IServiceA, ServiceA>();
            this.container.RegisterSingle<IServiceB, ServiceB>();
            this.container.RegisterSingle<IServiceC, ServiceC>();

            this.container.Register<ISubObjectA, SubObjectA>();
            this.container.Register<ISubObjectB, SubObjectB>();
            this.container.Register<ISubObjectC, SubObjectC>();

            this.container.Register<IComplexPropertyObject, ComplexPropertyObject>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.RegisterOpenGeneric(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.RegisterOpenGeneric(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            var container = this.container;

            container.Register<ImportConditionObject>();
            container.Register<ImportConditionObject2>();

            container.RegisterWithContext<IExportConditionInterface>(context =>
                 context.ImplementationType == typeof(ImportConditionObject)
                      ? (IExportConditionInterface)container.GetInstance<ExportConditionalObject>()
                      : (IExportConditionInterface)container.GetInstance<ExportConditionalObject2>());
        }

        private void RegisterMultiple()
        {
            this.container.RegisterAll<ISimpleAdapter>(
                 typeof(SimpleAdapterOne),
                 typeof(SimpleAdapterTwo),
                 typeof(SimpleAdapterThree),
                 typeof(SimpleAdapterFour),
                 typeof(SimpleAdapterFive));
        }

        private void RegisterIntercepter()
        {
            this.container.InterceptWith<SimpleInjectorInterceptionLogger>(type => type == typeof(ICalculator));
        }

        private sealed class InjectPropertiesMarkedWith<TAttribute> : IPropertySelectionBehavior
            where TAttribute : Attribute
        {
            public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
            {
                return propertyInfo.GetCustomAttributes<TAttribute>().Any();
            }
        }
    }
}