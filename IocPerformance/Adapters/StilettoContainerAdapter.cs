using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Stiletto;

namespace IocPerformance.Adapters
{
    public class StilettoContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName
        {
            get { return "Stiletto"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override void Prepare()
        {
            this.container = Container.Create(typeof(StilettoModule));
        }

        public override object Resolve(Type type)
        {
            // Because Resolve(Type) is non-generic, we can't rely on efficient dispatch from the
            // container.  Resolvable types are hard-coded in the [Module] attribute anyways, so
            // there's minimal harm in reproducing that here.
            if (type == typeof(ITransient))
            {
                return this.container.Get<ITransient>();
            }

            if (type == typeof(ISingleton))
            {
                return this.container.Get<ISingleton>();
            }

            if (type == typeof(ICombined))
            {
                return this.container.Get<ICombined>();
            }

            if (type == typeof(IComplex))
            {
                return this.container.Get<IComplex>();
            }

            if (type == typeof(IComplexPropertyObject))
            {
                return this.container.Get<IComplexPropertyObject>();
            }

            // This is an unexpected type, and should have been configured.
            throw new Stiletto.Internal.BindingException("Non-injectable type requested: " + type.FullName);
        }

        public override void Dispose()
        {
            this.container = null;
        }

        [Module(
            Injects = new[] {
                typeof(ITransient),
                typeof(ISingleton),
                typeof(ICombined),
                typeof(IComplex),
                typeof(IComplexPropertyObject),
            },

            IncludedModules = new[] { typeof(ProvideComplexDependencies) },

            // Because no concrete objects have ICombined, IComplex, and IComplexPropertyObject
            // injected, the compiler will complain about dead code unless we set IsLibrary to true.
            IsLibrary = true)]
        public class StilettoModule
        {
            [Provides]
            public ITransient ProvideTransient(Transient transient)
            {
                return transient;
            }

            [Provides]
            public ISingleton ProvideSingleton(Singleton singleton)
            {
                return singleton;
            }

            [Provides]
            public ICombined ProvideCombined(Combined combined)
            {
                return combined;
            }

            [Provides]
            public IComplex ProvideComplex(Complex complex)
            {
                return complex;
            }

            [Provides]
            public IComplexPropertyObject ProvideComplexPropertyObject(ComplexPropertyObject complex)
            {
                return complex;
            }
        }

        [Module(IsComplete = false)]
        public class ProvideComplexDependencies
        {
            [Provides]
            public IFirstService ProvideFirstService(FirstService service)
            {
                return service;
            }

            [Provides]
            public ISecondService ProvideSecondService(SecondService service)
            {
                return service;
            }

            [Provides]
            public IThirdService ProvideThirdService(ThirdService service)
            {
                return service;
            }

            [Provides]
            public ISubObjectOne ProvideSubObjectOne(SubObjectOne obj)
            {
                return obj;
            }

            [Provides]
            public ISubObjectTwo ProvideSubObjectTwo(SubObjectTwo obj)
            {
                return obj;
            }

            [Provides]
            public ISubObjectThree ProvidSubObjectThree(SubObjectThree obj)
            {
                return obj;
            }

            [Provides]
            public IServiceA ProvideServiceA(ServiceA service)
            {
                return service;
            }

            [Provides]
            public IServiceB ProvideServiceB(ServiceB service)
            {
                return service;
            }

            [Provides]
            public IServiceC ProvideServiceC(ServiceC service)
            {
                return service;
            }

            [Provides]
            public ISubObjectA ProvideSubObjectA(SubObjectA obj)
            {
                return obj;
            }

            [Provides]
            public ISubObjectB ProvideSubObjectB(SubObjectB obj)
            {
                return obj;
            }

            [Provides]
            public ISubObjectC ProvidSubObjectC(SubObjectC obj)
            {
                return obj;
            }
        }
    }
}
