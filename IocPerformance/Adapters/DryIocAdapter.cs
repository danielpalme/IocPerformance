using System;
using System.ComponentModel.Composition;
using System.Reflection;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using DryIoc;

namespace IocPerformance.Adapters
{
    //[Fast]
    public sealed class DryIocAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "DryIoc"; }
        }

        public override string Url
        {
            get { return "dryioc"; }
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
            get { return false; }
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
            // Allow the container and everything it references to be disposed.
            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new Container();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
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
            this.container.Register<ISingleton, Singleton>(Reuse.Singleton);
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Register<ICalculator, Calculator>();
        }

        private void RegisterComplex()
        {
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.Register<IFirstService, FirstService>(Reuse.Singleton);
            this.container.Register<ISecondService, SecondService>(Reuse.Singleton);
            this.container.Register<IThirdService, ThirdService>(Reuse.Singleton);
            this.container.Register<IComplex, Complex>();
        }

        private void RegisterPropertyInjection()
        {
            container.ResolutionRules.PropertiesAndFields =
                container.ResolutionRules.PropertiesAndFields.Append(ResolvePropertyWithImportAttribute);
            
            this.container.Register<IServiceA, ServiceA>(Reuse.Singleton);
            this.container.Register<IServiceB, ServiceB>(Reuse.Singleton);
            this.container.Register<IServiceC, ServiceC>(Reuse.Singleton);

            this.container.Register<ISubObjectA, SubObjectA>();
            this.container.Register<ISubObjectB, SubObjectB>();
            this.container.Register<ISubObjectC, SubObjectC>();

            this.container.Register<IComplexPropertyObject, ComplexPropertyObject>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.Register(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.Register(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterConditional()
        {
            this.container.Register<ImportConditionObject>();
            this.container.Register<ImportConditionObject2>();

            this.container.Register<IExportConditionInterface>(
                new FactoryProvider((request, _) =>
                {
                    var parent = request.GetNonWrapperParentOrDefault();
                    var implType = parent != null && 
                        parent.ImplementationType == typeof(ImportConditionObject)
                        ? typeof(ExportConditionalObject)
                        : typeof(ExportConditionalObject2);
                    return new ReflectionFactory(implType);
                }));
        }

        private void RegisterMultiple()
        {
            this.container.Register<ImportMultiple>();
            this.container.Register<ISimpleAdapter, SimpleAdapterOne>();
            this.container.Register<ISimpleAdapter, SimpleAdapterTwo>();
            this.container.Register<ISimpleAdapter, SimpleAdapterThree>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFour>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFive>();
        }

        private static bool ResolvePropertyWithImportAttribute(out object key, MemberInfo member, Request _, IRegistry registry)
        {
            key = null;
            var attributes = member.GetCustomAttributes(typeof(ImportAttribute), false);
            if (attributes.Length == 0)
                return false;

            key = ((ImportAttribute)attributes[0]).ContractName;
            return true;
        }
    }
}