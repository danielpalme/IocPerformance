/*
The MIT License (MIT)

Copyright (c) 2016 Maksim Volkau

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/



//========================================================================================================
// NOTE: The code below is generated automatically at compile-time and not supposed to be changed by hand.
//========================================================================================================
using System;
using System.Linq; // for Enumerable.Cast method required by LazyEnumerable<T>
using System.Collections.Generic;
using System.Threading;
using ImTools;

namespace DryIocZero
{
/* 
Resolution generation is completed without errors.
----------------------------------
*/

    partial class Container
    {
        private int _lastFactoryID = 82; // generated, equals to last used Factory.FactoryID 

        /// <summary>The unique factory ID, which may be used for runtime scoped registrations.</summary>
        /// <returns>New factory ID.</returns>
        public int GetNextFactoryID() 
        {
            return Interlocked.Increment(ref _lastFactoryID);
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveGenerated(ref object service, Type serviceType, IScope scope)
        {
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject2))
                service = Create_0(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject3))
                service = Create_1(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined2))
                service = Create_2(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton1))
                service = Create_3(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject1))
                service = Create_4(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined1))
                service = Create_5(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject2))
                service = Create_6(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple1))
                service = Create_7(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient3))
                service = Create_8(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject1))
                service = Create_9(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton3))
                service = Create_10(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple3))
                service = Create_11(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient1))
                service = Create_12(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined3))
                service = Create_13(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton2))
                service = Create_14(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex3))
                service = Create_15(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex2))
                service = Create_16(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex1))
                service = Create_17(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Dummy.IDummyOne))
                service = Create_18(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject3))
                service = Create_19(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient2))
                service = Create_20(this, scope);

            else
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple2))
                service = Create_21(this, scope);
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveGenerated(ref object service, Type serviceType, object serviceKey, 
            Type requiredServiceType, RequestInfo preRequestParent, IScope scope)
        {
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveManyGenerated(ref IEnumerable<KV<object, FactoryDelegate>> services, Type serviceType) 
        {
            services = ResolveManyGenerated(serviceType);
        }

        [ExcludeFromCodeCoverage]
        private IEnumerable<KV<object, FactoryDelegate>> ResolveManyGenerated(Type serviceType)
        {
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_0);
            }

            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_4);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_5);
            }

            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_6);
            }

            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_7);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_8);
            }

            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_9);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_10);
            }

            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_11);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_12);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_13);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_14);
            }

            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_15);
            }

            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_16);
            }

            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex1))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_17);
            }

            if (serviceType == typeof(IocPerformance.Classes.Dummy.IDummyOne))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_18);
            }

            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject3))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_19);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_20);
            }

            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple2))
            {
                yield return new KV<object, FactoryDelegate>(null, Create_21);
            }

        }

        // typeof(IocPerformance.Classes.Conditions.ImportConditionObject2)
        internal static object Create_0(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Conditions.ImportConditionObject2(new IocPerformance.Classes.Conditions.ExportConditionalObject2());
        }

        // typeof(IocPerformance.Classes.Conditions.ImportConditionObject3)
        internal static object Create_1(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Conditions.ImportConditionObject3(new IocPerformance.Classes.Conditions.ExportConditionalObject3());
        }

        // typeof(IocPerformance.Classes.Standard.ICombined2)
        internal static object Create_2(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Standard.Combined2((IocPerformance.Classes.Standard.Singleton2)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 39, () => new IocPerformance.Classes.Standard.Singleton2()), new IocPerformance.Classes.Standard.Transient2());
        }

        // typeof(IocPerformance.Classes.Standard.ISingleton1)
        internal static object Create_3(IResolverContext r, IScope scope)
        {
            return SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 38, () => new IocPerformance.Classes.Standard.Singleton1());
        }

        // typeof(IocPerformance.Classes.Conditions.ImportConditionObject1)
        internal static object Create_4(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Conditions.ImportConditionObject1(new IocPerformance.Classes.Conditions.ExportConditionalObject());
        }

        // typeof(IocPerformance.Classes.Standard.ICombined1)
        internal static object Create_5(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Standard.Combined1((IocPerformance.Classes.Standard.Singleton1)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 38, () => new IocPerformance.Classes.Standard.Singleton1()), new IocPerformance.Classes.Standard.Transient1());
        }

        // typeof(IocPerformance.Classes.Properties.IComplexPropertyObject2)
        internal static object Create_6(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Properties.ComplexPropertyObject2 { ServiceA = (IocPerformance.Classes.Properties.ServiceA)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 59, () => new IocPerformance.Classes.Properties.ServiceA()), ServiceB = (IocPerformance.Classes.Properties.ServiceB)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 60, () => new IocPerformance.Classes.Properties.ServiceB()), ServiceC = (IocPerformance.Classes.Properties.ServiceC)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 61, () => new IocPerformance.Classes.Properties.ServiceC()), SubObjectA = new IocPerformance.Classes.Properties.SubObjectA { ServiceA = (IocPerformance.Classes.Properties.ServiceA)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 59, () => new IocPerformance.Classes.Properties.ServiceA()) }, SubObjectB = new IocPerformance.Classes.Properties.SubObjectB { ServiceB = (IocPerformance.Classes.Properties.ServiceB)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 60, () => new IocPerformance.Classes.Properties.ServiceB()) }, SubObjectC = new IocPerformance.Classes.Properties.SubObjectC { ServiceC = (IocPerformance.Classes.Properties.ServiceC)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 61, () => new IocPerformance.Classes.Properties.ServiceC()) } };
        }

        // typeof(IocPerformance.Classes.Multiple.ImportMultiple1)
        internal static object Create_7(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Multiple.ImportMultiple1(new IocPerformance.Classes.Multiple.ISimpleAdapter[] { new IocPerformance.Classes.Multiple.SimpleAdapterOne(), new IocPerformance.Classes.Multiple.SimpleAdapterTwo(), new IocPerformance.Classes.Multiple.SimpleAdapterThree(), new IocPerformance.Classes.Multiple.SimpleAdapterFour(), new IocPerformance.Classes.Multiple.SimpleAdapterFive() });
        }

        // typeof(IocPerformance.Classes.Standard.ITransient3)
        internal static object Create_8(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Standard.Transient3();
        }

        // typeof(IocPerformance.Classes.Properties.IComplexPropertyObject1)
        internal static object Create_9(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Properties.ComplexPropertyObject1 { ServiceA = (IocPerformance.Classes.Properties.ServiceA)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 59, () => new IocPerformance.Classes.Properties.ServiceA()), ServiceB = (IocPerformance.Classes.Properties.ServiceB)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 60, () => new IocPerformance.Classes.Properties.ServiceB()), ServiceC = (IocPerformance.Classes.Properties.ServiceC)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 61, () => new IocPerformance.Classes.Properties.ServiceC()), SubObjectA = new IocPerformance.Classes.Properties.SubObjectA { ServiceA = (IocPerformance.Classes.Properties.ServiceA)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 59, () => new IocPerformance.Classes.Properties.ServiceA()) }, SubObjectB = new IocPerformance.Classes.Properties.SubObjectB { ServiceB = (IocPerformance.Classes.Properties.ServiceB)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 60, () => new IocPerformance.Classes.Properties.ServiceB()) }, SubObjectC = new IocPerformance.Classes.Properties.SubObjectC { ServiceC = (IocPerformance.Classes.Properties.ServiceC)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 61, () => new IocPerformance.Classes.Properties.ServiceC()) } };
        }

        // typeof(IocPerformance.Classes.Standard.ISingleton3)
        internal static object Create_10(IResolverContext r, IScope scope)
        {
            return SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 40, () => new IocPerformance.Classes.Standard.Singleton3());
        }

        // typeof(IocPerformance.Classes.Multiple.ImportMultiple3)
        internal static object Create_11(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Multiple.ImportMultiple3(new IocPerformance.Classes.Multiple.ISimpleAdapter[] { new IocPerformance.Classes.Multiple.SimpleAdapterOne(), new IocPerformance.Classes.Multiple.SimpleAdapterTwo(), new IocPerformance.Classes.Multiple.SimpleAdapterThree(), new IocPerformance.Classes.Multiple.SimpleAdapterFour(), new IocPerformance.Classes.Multiple.SimpleAdapterFive() });
        }

        // typeof(IocPerformance.Classes.Standard.ITransient1)
        internal static object Create_12(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Standard.Transient1();
        }

        // typeof(IocPerformance.Classes.Standard.ICombined3)
        internal static object Create_13(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Standard.Combined3((IocPerformance.Classes.Standard.Singleton3)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 40, () => new IocPerformance.Classes.Standard.Singleton3()), new IocPerformance.Classes.Standard.Transient3());
        }

        // typeof(IocPerformance.Classes.Standard.ISingleton2)
        internal static object Create_14(IResolverContext r, IScope scope)
        {
            return SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 39, () => new IocPerformance.Classes.Standard.Singleton2());
        }

        // typeof(IocPerformance.Classes.Complex.IComplex3)
        internal static object Create_15(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Complex.Complex3((IocPerformance.Classes.Complex.FirstService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 53, () => new IocPerformance.Classes.Complex.FirstService()), (IocPerformance.Classes.Complex.SecondService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 54, () => new IocPerformance.Classes.Complex.SecondService()), (IocPerformance.Classes.Complex.ThirdService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 55, () => new IocPerformance.Classes.Complex.ThirdService()), new IocPerformance.Classes.Complex.SubObjectOne((IocPerformance.Classes.Complex.FirstService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 53, () => new IocPerformance.Classes.Complex.FirstService())), new IocPerformance.Classes.Complex.SubObjectTwo((IocPerformance.Classes.Complex.SecondService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 54, () => new IocPerformance.Classes.Complex.SecondService())), new IocPerformance.Classes.Complex.SubObjectThree((IocPerformance.Classes.Complex.ThirdService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 55, () => new IocPerformance.Classes.Complex.ThirdService())));
        }

        // typeof(IocPerformance.Classes.Complex.IComplex2)
        internal static object Create_16(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Complex.Complex2((IocPerformance.Classes.Complex.FirstService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 53, () => new IocPerformance.Classes.Complex.FirstService()), (IocPerformance.Classes.Complex.SecondService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 54, () => new IocPerformance.Classes.Complex.SecondService()), (IocPerformance.Classes.Complex.ThirdService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 55, () => new IocPerformance.Classes.Complex.ThirdService()), new IocPerformance.Classes.Complex.SubObjectOne((IocPerformance.Classes.Complex.FirstService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 53, () => new IocPerformance.Classes.Complex.FirstService())), new IocPerformance.Classes.Complex.SubObjectTwo((IocPerformance.Classes.Complex.SecondService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 54, () => new IocPerformance.Classes.Complex.SecondService())), new IocPerformance.Classes.Complex.SubObjectThree((IocPerformance.Classes.Complex.ThirdService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 55, () => new IocPerformance.Classes.Complex.ThirdService())));
        }

        // typeof(IocPerformance.Classes.Complex.IComplex1)
        internal static object Create_17(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Complex.Complex1((IocPerformance.Classes.Complex.FirstService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 53, () => new IocPerformance.Classes.Complex.FirstService()), (IocPerformance.Classes.Complex.SecondService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 54, () => new IocPerformance.Classes.Complex.SecondService()), (IocPerformance.Classes.Complex.ThirdService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 55, () => new IocPerformance.Classes.Complex.ThirdService()), new IocPerformance.Classes.Complex.SubObjectOne((IocPerformance.Classes.Complex.FirstService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 53, () => new IocPerformance.Classes.Complex.FirstService())), new IocPerformance.Classes.Complex.SubObjectTwo((IocPerformance.Classes.Complex.SecondService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 54, () => new IocPerformance.Classes.Complex.SecondService())), new IocPerformance.Classes.Complex.SubObjectThree((IocPerformance.Classes.Complex.ThirdService)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 55, () => new IocPerformance.Classes.Complex.ThirdService())));
        }

        // typeof(IocPerformance.Classes.Dummy.IDummyOne)
        internal static object Create_18(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Dummy.DummyOne();
        }

        // typeof(IocPerformance.Classes.Properties.IComplexPropertyObject3)
        internal static object Create_19(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Properties.ComplexPropertyObject3 { ServiceA = (IocPerformance.Classes.Properties.ServiceA)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 59, () => new IocPerformance.Classes.Properties.ServiceA()), ServiceB = (IocPerformance.Classes.Properties.ServiceB)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 60, () => new IocPerformance.Classes.Properties.ServiceB()), ServiceC = (IocPerformance.Classes.Properties.ServiceC)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 61, () => new IocPerformance.Classes.Properties.ServiceC()), SubObjectA = new IocPerformance.Classes.Properties.SubObjectA { ServiceA = (IocPerformance.Classes.Properties.ServiceA)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 59, () => new IocPerformance.Classes.Properties.ServiceA()) }, SubObjectB = new IocPerformance.Classes.Properties.SubObjectB { ServiceB = (IocPerformance.Classes.Properties.ServiceB)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 60, () => new IocPerformance.Classes.Properties.ServiceB()) }, SubObjectC = new IocPerformance.Classes.Properties.SubObjectC { ServiceC = (IocPerformance.Classes.Properties.ServiceC)SingletonReuse.GetOrAddItem(r.SingletonScope(), false, 61, () => new IocPerformance.Classes.Properties.ServiceC()) } };
        }

        // typeof(IocPerformance.Classes.Standard.ITransient2)
        internal static object Create_20(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Standard.Transient2();
        }

        // typeof(IocPerformance.Classes.Multiple.ImportMultiple2)
        internal static object Create_21(IResolverContext r, IScope scope)
        {
            return new IocPerformance.Classes.Multiple.ImportMultiple2(new IocPerformance.Classes.Multiple.ISimpleAdapter[] { new IocPerformance.Classes.Multiple.SimpleAdapterOne(), new IocPerformance.Classes.Multiple.SimpleAdapterTwo(), new IocPerformance.Classes.Multiple.SimpleAdapterThree(), new IocPerformance.Classes.Multiple.SimpleAdapterFour(), new IocPerformance.Classes.Multiple.SimpleAdapterFive() });
        }

    }
}