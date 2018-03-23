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
/*
========================================================================================================
NOTE: The code below is generated automatically at compile-time and not supposed to be changed by hand.
========================================================================================================
Generation is completed successfully.
--------------------------------------------------------------------------------------------------------
*/

using System;
using System.Linq; // for Enumerable.Cast method required by LazyEnumerable<T>
using System.Collections.Generic;
using System.Threading;
using ImTools;
using static DryIocZero.ResolveManyResult;

namespace DryIocZero
{
    partial class Container
    {
        [ExcludeFromCodeCoverage]
        partial void GetLastGeneratedFactoryID(ref int lastFactoryID)
        {
            lastFactoryID = 89; // generated: equals to last used Factory.FactoryID 
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveGenerated(ref object service, Type serviceType)
        {
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple3))
                service = Get0_ImportMultiple3(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined2))
                service = Get1_ICombined2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject1))
                service = Get2_IComplexPropertyObject1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined1))
                service = Get3_ICombined1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject2))
                service = Get4_ImportConditionObject2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple2))
                service = Get5_ImportMultiple2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex2))
                service = Get6_IComplex2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex3))
                service = Get7_IComplex3(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient1))
                service = Get8_ITransient1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject3))
                service = Get9_IComplexPropertyObject3(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Generics.ImportGeneric<int>))
                service = Get10_ImportGeneric(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Generics.ImportGeneric<float>))
                service = Get11_ImportGeneric(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Generics.ImportGeneric<object>))
                service = Get12_ImportGeneric(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton2))
                service = Get13_ISingleton2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined3))
                service = Get14_ICombined3(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton1))
                service = Get15_ISingleton1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Dummy.IDummyOne))
                service = Get16_IDummyOne(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient3))
                service = Get17_ITransient3(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject1))
                service = Get18_ImportConditionObject1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex1))
                service = Get19_IComplex1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject2))
                service = Get20_IComplexPropertyObject2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient2))
                service = Get21_ITransient2(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject3))
                service = Get22_ImportConditionObject3(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple1))
                service = Get23_ImportMultiple1(this);

            else
            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton3))
                service = Get24_ISingleton3(this);
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveGenerated(ref object service,
            Type serviceType, object serviceKey, Type requiredServiceType, Request preRequestParent, object[] args)
        {
            if (serviceType == typeof(IocPerformance.Classes.Conditions.IExportConditionInterface)) 
            {
                if ((serviceKey == null || DefaultKey.Of(1).Equals(serviceKey)) &&
                    requiredServiceType == null &&
                    Equals(preRequestParent, Request.Empty.Push(typeof(IocPerformance.Classes.Conditions.ImportConditionObject2), default(System.Type), (object)null, 68, FactoryType.Service, typeof(IocPerformance.Classes.Conditions.ImportConditionObject2), Reuse.Transient, RequestFlags.IsResolutionCall))) 
                    service = GetDep0_IExportConditionInterface(this);

                else
                if ((serviceKey == null || DefaultKey.Of(0).Equals(serviceKey)) &&
                    requiredServiceType == null &&
                    Equals(preRequestParent, Request.Empty.Push(typeof(IocPerformance.Classes.Conditions.ImportConditionObject1), default(System.Type), (object)null, 67, FactoryType.Service, typeof(IocPerformance.Classes.Conditions.ImportConditionObject1), Reuse.Transient, RequestFlags.IsResolutionCall))) 
                    service = GetDep1_IExportConditionInterface(this);

                else
                if ((serviceKey == null || DefaultKey.Of(2).Equals(serviceKey)) &&
                    requiredServiceType == null &&
                    Equals(preRequestParent, Request.Empty.Push(typeof(IocPerformance.Classes.Conditions.ImportConditionObject3), default(System.Type), (object)null, 69, FactoryType.Service, typeof(IocPerformance.Classes.Conditions.ImportConditionObject3), Reuse.Transient, RequestFlags.IsResolutionCall))) 
                    service = GetDep2_IExportConditionInterface(this);
            }
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveManyGenerated(ref IEnumerable<ResolveManyResult> services, Type serviceType) 
        {
            services = ResolveManyGenerated(serviceType);
        }

        [ExcludeFromCodeCoverage]
        private IEnumerable<ResolveManyResult> ResolveManyGenerated(Type serviceType)
        {
            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple3))
            {
                yield return Of(Get0_ImportMultiple3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined2))
            {
                yield return Of(Get1_ICombined2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject1))
            {
                yield return Of(Get2_IComplexPropertyObject1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined1))
            {
                yield return Of(Get3_ICombined1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject2))
            {
                yield return Of(Get4_ImportConditionObject2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple2))
            {
                yield return Of(Get5_ImportMultiple2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex2))
            {
                yield return Of(Get6_IComplex2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex3))
            {
                yield return Of(Get7_IComplex3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient1))
            {
                yield return Of(Get8_ITransient1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject3))
            {
                yield return Of(Get9_IComplexPropertyObject3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Generics.ImportGeneric<int>))
            {
                yield return Of(Get10_ImportGeneric);
            }

            if (serviceType == typeof(IocPerformance.Classes.Generics.ImportGeneric<float>))
            {
                yield return Of(Get11_ImportGeneric);
            }

            if (serviceType == typeof(IocPerformance.Classes.Generics.ImportGeneric<object>))
            {
                yield return Of(Get12_ImportGeneric);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton2))
            {
                yield return Of(Get13_ISingleton2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ICombined3))
            {
                yield return Of(Get14_ICombined3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton1))
            {
                yield return Of(Get15_ISingleton1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Dummy.IDummyOne))
            {
                yield return Of(Get16_IDummyOne);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient3))
            {
                yield return Of(Get17_ITransient3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject1))
            {
                yield return Of(Get18_ImportConditionObject1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Complex.IComplex1))
            {
                yield return Of(Get19_IComplex1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Properties.IComplexPropertyObject2))
            {
                yield return Of(Get20_IComplexPropertyObject2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ITransient2))
            {
                yield return Of(Get21_ITransient2);
            }

            if (serviceType == typeof(IocPerformance.Classes.Conditions.ImportConditionObject3))
            {
                yield return Of(Get22_ImportConditionObject3);
            }

            if (serviceType == typeof(IocPerformance.Classes.Multiple.ImportMultiple1))
            {
                yield return Of(Get23_ImportMultiple1);
            }

            if (serviceType == typeof(IocPerformance.Classes.Standard.ISingleton3))
            {
                yield return Of(Get24_ISingleton3);
            }

        }

        // typeof(IocPerformance.Classes.Multiple.ImportMultiple3)
        internal static object Get0_ImportMultiple3(IResolverContext r)
        {
            return new IocPerformance.Classes.Multiple.ImportMultiple3(new IocPerformance.Classes.Multiple.ISimpleAdapter[] { new IocPerformance.Classes.Multiple.SimpleAdapterOne(), new IocPerformance.Classes.Multiple.SimpleAdapterTwo(), new IocPerformance.Classes.Multiple.SimpleAdapterThree(), new IocPerformance.Classes.Multiple.SimpleAdapterFour(), new IocPerformance.Classes.Multiple.SimpleAdapterFive() });
        }

        // typeof(IocPerformance.Classes.Standard.ICombined2)
        internal static object Get1_ICombined2(IResolverContext r)
        {
            return new IocPerformance.Classes.Standard.Combined2((IocPerformance.Classes.Standard.Singleton2)r.SingletonScope.GetOrAdd(38, () => new IocPerformance.Classes.Standard.Singleton2(), 0), new IocPerformance.Classes.Standard.Transient2());
        }

        // typeof(IocPerformance.Classes.Properties.IComplexPropertyObject1)
        internal static object Get2_IComplexPropertyObject1(IResolverContext r)
        {
            return new IocPerformance.Classes.Properties.ComplexPropertyObject1 { ServiceA = (IocPerformance.Classes.Properties.ServiceA)r.SingletonScope.GetOrAdd(58, () => new IocPerformance.Classes.Properties.ServiceA(), 0), ServiceB = (IocPerformance.Classes.Properties.ServiceB)r.SingletonScope.GetOrAdd(59, () => new IocPerformance.Classes.Properties.ServiceB(), 0), ServiceC = (IocPerformance.Classes.Properties.ServiceC)r.SingletonScope.GetOrAdd(60, () => new IocPerformance.Classes.Properties.ServiceC(), 0), SubObjectA = new IocPerformance.Classes.Properties.SubObjectA { ServiceA = (IocPerformance.Classes.Properties.ServiceA)r.SingletonScope.GetOrAdd(58, () => new IocPerformance.Classes.Properties.ServiceA(), 0) }, SubObjectB = new IocPerformance.Classes.Properties.SubObjectB { ServiceB = (IocPerformance.Classes.Properties.ServiceB)r.SingletonScope.GetOrAdd(59, () => new IocPerformance.Classes.Properties.ServiceB(), 0) }, SubObjectC = new IocPerformance.Classes.Properties.SubObjectC { ServiceC = (IocPerformance.Classes.Properties.ServiceC)r.SingletonScope.GetOrAdd(60, () => new IocPerformance.Classes.Properties.ServiceC(), 0) } };
        }

        // typeof(IocPerformance.Classes.Standard.ICombined1)
        internal static object Get3_ICombined1(IResolverContext r)
        {
            return new IocPerformance.Classes.Standard.Combined1((IocPerformance.Classes.Standard.Singleton1)r.SingletonScope.GetOrAdd(37, () => new IocPerformance.Classes.Standard.Singleton1(), 0), new IocPerformance.Classes.Standard.Transient1());
        }

        // typeof(IocPerformance.Classes.Conditions.ImportConditionObject2)
        internal static object Get4_ImportConditionObject2(IResolverContext r)
        {
            return new IocPerformance.Classes.Conditions.ImportConditionObject2((IocPerformance.Classes.Conditions.IExportConditionInterface)r.Resolve(typeof(IocPerformance.Classes.Conditions.IExportConditionInterface), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(IocPerformance.Classes.Conditions.ImportConditionObject2), default(System.Type), (object)null, 68, FactoryType.Service, typeof(IocPerformance.Classes.Conditions.ImportConditionObject2), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(IocPerformance.Classes.Multiple.ImportMultiple2)
        internal static object Get5_ImportMultiple2(IResolverContext r)
        {
            return new IocPerformance.Classes.Multiple.ImportMultiple2(new IocPerformance.Classes.Multiple.ISimpleAdapter[] { new IocPerformance.Classes.Multiple.SimpleAdapterOne(), new IocPerformance.Classes.Multiple.SimpleAdapterTwo(), new IocPerformance.Classes.Multiple.SimpleAdapterThree(), new IocPerformance.Classes.Multiple.SimpleAdapterFour(), new IocPerformance.Classes.Multiple.SimpleAdapterFive() });
        }

        // typeof(IocPerformance.Classes.Complex.IComplex2)
        internal static object Get6_IComplex2(IResolverContext r)
        {
            return new IocPerformance.Classes.Complex.Complex2((IocPerformance.Classes.Complex.FirstService)r.SingletonScope.GetOrAdd(52, () => new IocPerformance.Classes.Complex.FirstService(), 0), (IocPerformance.Classes.Complex.SecondService)r.SingletonScope.GetOrAdd(53, () => new IocPerformance.Classes.Complex.SecondService(), 0), (IocPerformance.Classes.Complex.ThirdService)r.SingletonScope.GetOrAdd(54, () => new IocPerformance.Classes.Complex.ThirdService(), 0), new IocPerformance.Classes.Complex.SubObjectOne((IocPerformance.Classes.Complex.FirstService)r.SingletonScope.GetOrAdd(52, () => new IocPerformance.Classes.Complex.FirstService(), 0)), new IocPerformance.Classes.Complex.SubObjectTwo((IocPerformance.Classes.Complex.SecondService)r.SingletonScope.GetOrAdd(53, () => new IocPerformance.Classes.Complex.SecondService(), 0)), new IocPerformance.Classes.Complex.SubObjectThree((IocPerformance.Classes.Complex.ThirdService)r.SingletonScope.GetOrAdd(54, () => new IocPerformance.Classes.Complex.ThirdService(), 0)));
        }

        // typeof(IocPerformance.Classes.Complex.IComplex3)
        internal static object Get7_IComplex3(IResolverContext r)
        {
            return new IocPerformance.Classes.Complex.Complex3((IocPerformance.Classes.Complex.FirstService)r.SingletonScope.GetOrAdd(52, () => new IocPerformance.Classes.Complex.FirstService(), 0), (IocPerformance.Classes.Complex.SecondService)r.SingletonScope.GetOrAdd(53, () => new IocPerformance.Classes.Complex.SecondService(), 0), (IocPerformance.Classes.Complex.ThirdService)r.SingletonScope.GetOrAdd(54, () => new IocPerformance.Classes.Complex.ThirdService(), 0), new IocPerformance.Classes.Complex.SubObjectOne((IocPerformance.Classes.Complex.FirstService)r.SingletonScope.GetOrAdd(52, () => new IocPerformance.Classes.Complex.FirstService(), 0)), new IocPerformance.Classes.Complex.SubObjectTwo((IocPerformance.Classes.Complex.SecondService)r.SingletonScope.GetOrAdd(53, () => new IocPerformance.Classes.Complex.SecondService(), 0)), new IocPerformance.Classes.Complex.SubObjectThree((IocPerformance.Classes.Complex.ThirdService)r.SingletonScope.GetOrAdd(54, () => new IocPerformance.Classes.Complex.ThirdService(), 0)));
        }

        // typeof(IocPerformance.Classes.Standard.ITransient1)
        internal static object Get8_ITransient1(IResolverContext r)
        {
            return new IocPerformance.Classes.Standard.Transient1();
        }

        // typeof(IocPerformance.Classes.Properties.IComplexPropertyObject3)
        internal static object Get9_IComplexPropertyObject3(IResolverContext r)
        {
            return new IocPerformance.Classes.Properties.ComplexPropertyObject3 { ServiceA = (IocPerformance.Classes.Properties.ServiceA)r.SingletonScope.GetOrAdd(58, () => new IocPerformance.Classes.Properties.ServiceA(), 0), ServiceB = (IocPerformance.Classes.Properties.ServiceB)r.SingletonScope.GetOrAdd(59, () => new IocPerformance.Classes.Properties.ServiceB(), 0), ServiceC = (IocPerformance.Classes.Properties.ServiceC)r.SingletonScope.GetOrAdd(60, () => new IocPerformance.Classes.Properties.ServiceC(), 0), SubObjectA = new IocPerformance.Classes.Properties.SubObjectA { ServiceA = (IocPerformance.Classes.Properties.ServiceA)r.SingletonScope.GetOrAdd(58, () => new IocPerformance.Classes.Properties.ServiceA(), 0) }, SubObjectB = new IocPerformance.Classes.Properties.SubObjectB { ServiceB = (IocPerformance.Classes.Properties.ServiceB)r.SingletonScope.GetOrAdd(59, () => new IocPerformance.Classes.Properties.ServiceB(), 0) }, SubObjectC = new IocPerformance.Classes.Properties.SubObjectC { ServiceC = (IocPerformance.Classes.Properties.ServiceC)r.SingletonScope.GetOrAdd(60, () => new IocPerformance.Classes.Properties.ServiceC(), 0) } };
        }

        // typeof(IocPerformance.Classes.Generics.ImportGeneric<int>)
        internal static object Get10_ImportGeneric(IResolverContext r)
        {
            return new IocPerformance.Classes.Generics.ImportGeneric<int>(new IocPerformance.Classes.Generics.GenericExport<int>());
        }

        // typeof(IocPerformance.Classes.Generics.ImportGeneric<float>)
        internal static object Get11_ImportGeneric(IResolverContext r)
        {
            return new IocPerformance.Classes.Generics.ImportGeneric<float>(new IocPerformance.Classes.Generics.GenericExport<float>());
        }

        // typeof(IocPerformance.Classes.Generics.ImportGeneric<object>)
        internal static object Get12_ImportGeneric(IResolverContext r)
        {
            return new IocPerformance.Classes.Generics.ImportGeneric<object>(new IocPerformance.Classes.Generics.GenericExport<object>());
        }

        // typeof(IocPerformance.Classes.Standard.ISingleton2)
        internal static object Get13_ISingleton2(IResolverContext r)
        {
            return r.SingletonScope.GetOrAdd(38, () => new IocPerformance.Classes.Standard.Singleton2(), 0);
        }

        // typeof(IocPerformance.Classes.Standard.ICombined3)
        internal static object Get14_ICombined3(IResolverContext r)
        {
            return new IocPerformance.Classes.Standard.Combined3((IocPerformance.Classes.Standard.Singleton3)r.SingletonScope.GetOrAdd(39, () => new IocPerformance.Classes.Standard.Singleton3(), 0), new IocPerformance.Classes.Standard.Transient3());
        }

        // typeof(IocPerformance.Classes.Standard.ISingleton1)
        internal static object Get15_ISingleton1(IResolverContext r)
        {
            return r.SingletonScope.GetOrAdd(37, () => new IocPerformance.Classes.Standard.Singleton1(), 0);
        }

        // typeof(IocPerformance.Classes.Dummy.IDummyOne)
        internal static object Get16_IDummyOne(IResolverContext r)
        {
            return new IocPerformance.Classes.Dummy.DummyOne();
        }

        // typeof(IocPerformance.Classes.Standard.ITransient3)
        internal static object Get17_ITransient3(IResolverContext r)
        {
            return new IocPerformance.Classes.Standard.Transient3();
        }

        // typeof(IocPerformance.Classes.Conditions.ImportConditionObject1)
        internal static object Get18_ImportConditionObject1(IResolverContext r)
        {
            return new IocPerformance.Classes.Conditions.ImportConditionObject1((IocPerformance.Classes.Conditions.IExportConditionInterface)r.Resolve(typeof(IocPerformance.Classes.Conditions.IExportConditionInterface), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(IocPerformance.Classes.Conditions.ImportConditionObject1), default(System.Type), (object)null, 67, FactoryType.Service, typeof(IocPerformance.Classes.Conditions.ImportConditionObject1), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(IocPerformance.Classes.Complex.IComplex1)
        internal static object Get19_IComplex1(IResolverContext r)
        {
            return new IocPerformance.Classes.Complex.Complex1((IocPerformance.Classes.Complex.FirstService)r.SingletonScope.GetOrAdd(52, () => new IocPerformance.Classes.Complex.FirstService(), 0), (IocPerformance.Classes.Complex.SecondService)r.SingletonScope.GetOrAdd(53, () => new IocPerformance.Classes.Complex.SecondService(), 0), (IocPerformance.Classes.Complex.ThirdService)r.SingletonScope.GetOrAdd(54, () => new IocPerformance.Classes.Complex.ThirdService(), 0), new IocPerformance.Classes.Complex.SubObjectOne((IocPerformance.Classes.Complex.FirstService)r.SingletonScope.GetOrAdd(52, () => new IocPerformance.Classes.Complex.FirstService(), 0)), new IocPerformance.Classes.Complex.SubObjectTwo((IocPerformance.Classes.Complex.SecondService)r.SingletonScope.GetOrAdd(53, () => new IocPerformance.Classes.Complex.SecondService(), 0)), new IocPerformance.Classes.Complex.SubObjectThree((IocPerformance.Classes.Complex.ThirdService)r.SingletonScope.GetOrAdd(54, () => new IocPerformance.Classes.Complex.ThirdService(), 0)));
        }

        // typeof(IocPerformance.Classes.Properties.IComplexPropertyObject2)
        internal static object Get20_IComplexPropertyObject2(IResolverContext r)
        {
            return new IocPerformance.Classes.Properties.ComplexPropertyObject2 { ServiceA = (IocPerformance.Classes.Properties.ServiceA)r.SingletonScope.GetOrAdd(58, () => new IocPerformance.Classes.Properties.ServiceA(), 0), ServiceB = (IocPerformance.Classes.Properties.ServiceB)r.SingletonScope.GetOrAdd(59, () => new IocPerformance.Classes.Properties.ServiceB(), 0), ServiceC = (IocPerformance.Classes.Properties.ServiceC)r.SingletonScope.GetOrAdd(60, () => new IocPerformance.Classes.Properties.ServiceC(), 0), SubObjectA = new IocPerformance.Classes.Properties.SubObjectA { ServiceA = (IocPerformance.Classes.Properties.ServiceA)r.SingletonScope.GetOrAdd(58, () => new IocPerformance.Classes.Properties.ServiceA(), 0) }, SubObjectB = new IocPerformance.Classes.Properties.SubObjectB { ServiceB = (IocPerformance.Classes.Properties.ServiceB)r.SingletonScope.GetOrAdd(59, () => new IocPerformance.Classes.Properties.ServiceB(), 0) }, SubObjectC = new IocPerformance.Classes.Properties.SubObjectC { ServiceC = (IocPerformance.Classes.Properties.ServiceC)r.SingletonScope.GetOrAdd(60, () => new IocPerformance.Classes.Properties.ServiceC(), 0) } };
        }

        // typeof(IocPerformance.Classes.Standard.ITransient2)
        internal static object Get21_ITransient2(IResolverContext r)
        {
            return new IocPerformance.Classes.Standard.Transient2();
        }

        // typeof(IocPerformance.Classes.Conditions.ImportConditionObject3)
        internal static object Get22_ImportConditionObject3(IResolverContext r)
        {
            return new IocPerformance.Classes.Conditions.ImportConditionObject3((IocPerformance.Classes.Conditions.IExportConditionInterface)r.Resolve(typeof(IocPerformance.Classes.Conditions.IExportConditionInterface), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(IocPerformance.Classes.Conditions.ImportConditionObject3), default(System.Type), (object)null, 69, FactoryType.Service, typeof(IocPerformance.Classes.Conditions.ImportConditionObject3), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(IocPerformance.Classes.Multiple.ImportMultiple1)
        internal static object Get23_ImportMultiple1(IResolverContext r)
        {
            return new IocPerformance.Classes.Multiple.ImportMultiple1(new IocPerformance.Classes.Multiple.ISimpleAdapter[] { new IocPerformance.Classes.Multiple.SimpleAdapterOne(), new IocPerformance.Classes.Multiple.SimpleAdapterTwo(), new IocPerformance.Classes.Multiple.SimpleAdapterThree(), new IocPerformance.Classes.Multiple.SimpleAdapterFour(), new IocPerformance.Classes.Multiple.SimpleAdapterFive() });
        }

        // typeof(IocPerformance.Classes.Standard.ISingleton3)
        internal static object Get24_ISingleton3(IResolverContext r)
        {
            return r.SingletonScope.GetOrAdd(39, () => new IocPerformance.Classes.Standard.Singleton3(), 0);
        }

        // typeof(IocPerformance.Classes.Conditions.IExportConditionInterface)
        internal static object GetDep0_IExportConditionInterface(IResolverContext r)
        {
            return new IocPerformance.Classes.Conditions.ExportConditionalObject2();
        }

        // typeof(IocPerformance.Classes.Conditions.IExportConditionInterface)
        internal static object GetDep1_IExportConditionInterface(IResolverContext r)
        {
            return new IocPerformance.Classes.Conditions.ExportConditionalObject1();
        }

        // typeof(IocPerformance.Classes.Conditions.IExportConditionInterface)
        internal static object GetDep2_IExportConditionInterface(IResolverContext r)
        {
            return new IocPerformance.Classes.Conditions.ExportConditionalObject3();
        }

    }
}
