﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
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
            container = Container.Create(typeof (StilettoModule));
        }

        public override object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public override T Resolve<T>()
        {
            return container.Get<T>();
        }

        public override void Dispose()
        {
            container = null;
        }

        [Module(
            Injects = new [] {
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
