using System;
using System.ComponentModel.Composition;
using System.Reflection;
using DryIoc;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class DryIocAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "DryIoc"; }
        }

        public override string Url
        {
            get { return "https://bitbucket.org/dadhi/dryioc"; }
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
        
        public override bool SupportsBasic
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
            if (this.container == null)
                return;
            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new Container();
            
            RegisterBasic();
            
            this.RegisterPropertyInjection();
            this.RegisterOpenGeneric();
            this.RegisterConditional();
            this.RegisterMultiple();
        }


        public override void PrepareBasic()
        {
            this.container = new Container();
            
            RegisterBasic();
        }        

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }
        
        private static bool ResolvePropertyWithImportAttribute(out object key, MemberInfo member, Request request, IRegistry registry)
        {
            key = null;
            var attributes = member.GetCustomAttributes(typeof(ImportAttribute), false);
            if (attributes.Length == 0)
            {
                return false;
            }

            key = ((ImportAttribute)attributes[0]).ContractName;
            return true;
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
            this.container.Register<ISingleton1, Singleton1>(Reuse.Singleton);
            this.container.Register<ISingleton2, Singleton2>(Reuse.Singleton);
            this.container.Register<ISingleton3, Singleton3>(Reuse.Singleton);
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
            this.container.Register<IFirstService, FirstService>(Reuse.Singleton);
            this.container.Register<ISecondService, SecondService>(Reuse.Singleton);
            this.container.Register<IThirdService, ThirdService>(Reuse.Singleton);
            this.container.Register<IComplex1, Complex1>();
            this.container.Register<IComplex2, Complex2>();
            this.container.Register<IComplex3, Complex3>();
        }

        private void RegisterPropertyInjection()
        {
            this.container.ResolutionRules.PropertiesAndFields =
                this.container.ResolutionRules.PropertiesAndFields.Append(ResolvePropertyWithImportAttribute);

            this.container.Register<IServiceA, ServiceA>(Reuse.Singleton);
            this.container.Register<IServiceB, ServiceB>(Reuse.Singleton);
            this.container.Register<IServiceC, ServiceC>(Reuse.Singleton);

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

            this.container.Register<IExportConditionInterface>(
                new FactoryProvider((request, _) =>
                                    {
                                        var parent = request.GetNonWrapperParentOrDefault();
                                        var implType = parent != null &&
                                            parent.ImplementationType == typeof(ImportConditionObject1)
                                            ? typeof(ExportConditionalObject)
                                            : (parent.ImplementationType == typeof(ImportConditionObject2)
                                               ? typeof(ExportConditionalObject2)
                                               : typeof(ExportConditionalObject3));
                                        return new ReflectionFactory(implType);
                                    }));
        }

        private void RegisterMultiple()
        {
            this.container.Register<ImportMultiple1>();
            this.container.Register<ImportMultiple2>();
            this.container.Register<ImportMultiple3>();
            this.container.Register<ISimpleAdapter, SimpleAdapterOne>();
            this.container.Register<ISimpleAdapter, SimpleAdapterTwo>();
            this.container.Register<ISimpleAdapter, SimpleAdapterThree>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFour>();
            this.container.Register<ISimpleAdapter, SimpleAdapterFive>();
        }
    }
}