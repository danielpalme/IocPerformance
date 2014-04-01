using System;
using System.Diagnostics;
using System.Linq;
using IocPerformance.Adapters;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Output;

namespace IocPerformance
{
    internal class Program
    {
        private const int LoopCount = 1000 * 500;

        // This is a decreased value, because some containers take a while
        private const int ChildContainerLoopCount = LoopCount / 10;

        public static void Main(string[] args)
        {
            if (LoopCount < ChildContainerLoopCount)
            {
                throw new InvalidOperationException("LoopCount is less than ChildContainerLoopCount");
            }

            IOutput output = new MultiOutput(new IOutput[] { new HtmlOutput(), new MarkdownOutput(), new ChartOutput(), new CsvOutput(), new CsvRateOutput(), new ConsoleOutput() });
            output.Start();

            var containers = ContainerAdapterFactory.CreateAdapters();

            bool onlyUpdateChangedContainers = args != null && args.Any(a => a.Equals("-update", StringComparison.OrdinalIgnoreCase));
            var csvOutputReader = new CsvOutputReader();

            foreach (var container in containers)
            {
                Result result = csvOutputReader.GetExistingResult(container.Name);

                if (result != null)
                {
                    result.Url = container.Url;
                }

                if (!onlyUpdateChangedContainers || result == null || result.Version != container.Version)
                {
                    try
                    {
                        result = MeasurePerformance(container);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(container.Name + " failed: " + ex.Message);
                    }
                }

                output.Result(result);
            }

            output.Finish();
        }

        private static Result MeasurePerformance(IContainerAdapter container)
        {
            ClearInstanceProperties();

            CollectMemory();

            container.Prepare();

            WarmUp(container);

            var result = new Result();
            result.Name = container.Name;
            result.Url = container.Url;
            result.Version = container.Version;

            MeasureResolvePerformance(container, result);

            CheckInstanceProperties(container);

            container.Dispose();

            return result;
        }

        private static void CheckInstanceProperties(IContainerAdapter container)
        {
            if (Singleton1.Instances != 1 || Singleton2.Instances != 1 || Singleton2.Instances != 1)
            {
                throw new Exception("Singleton instance count must be one container: " + container.PackageName);
            }

            if (Transient1.Instances < (LoopCount * 2) + 1 || Transient1.Instances > (LoopCount * 2) + 4)
            {
                throw new Exception(
                      string.Format("Transient count must be between {0} and {1} was {2}", (LoopCount * 2) + 1, (LoopCount * 2) + 4, Transient1.Instances));
            }

            if (Combined1.Instances != LoopCount + 1 && Combined1.Instances != LoopCount + 2)
            {
                throw new Exception(string.Format("Combined count must be {0} or {1} was {2}", LoopCount + 1, LoopCount + 2, Combined1.Instances));
            }

            if (Complex1.Instances != LoopCount + 1 && Complex1.Instances != LoopCount + 2)
            {
                throw new Exception(string.Format("Complex count must be {0} or {1} was {2}", LoopCount + 1, LoopCount + 2, Complex1.Instances));
            }

            if (container.SupportsInterception)
            {
                if (Calculator1.Instances != LoopCount + 1 && Calculator1.Instances != LoopCount + 2)
                {
                    throw new Exception(string.Format("Calculator count must be {0} or {1} was {2}", LoopCount + 1, LoopCount + 2, Calculator1.Instances));
                }
            }

            if (container.SupportsChildContainer)
            {
                if (ScopedCombined1.Instances != ChildContainerLoopCount + 1
                    && ScopedCombined1.Instances != ChildContainerLoopCount + 2)
                {
                    throw new Exception(string.Format(
                        "ScopedCombined count must be {0} or {1} was {2}",
                        ChildContainerLoopCount + 1,
                        ChildContainerLoopCount + 2,
                        ScopedCombined1.Instances));
                }
            }
        }

        private static void ClearInstanceProperties()
        {
            Singleton1.Instances = 0;
            Singleton2.Instances = 0;
            Singleton3.Instances = 0;
            Transient1.Instances = 0;
            Transient2.Instances = 0;
            Transient3.Instances = 0;
            Combined1.Instances = 0;
            Combined2.Instances = 0;
            Combined3.Instances = 0;
            Complex1.Instances = 0;
            Complex2.Instances = 0;
            Complex3.Instances = 0;
            Calculator1.Instances = 0;
            Calculator2.Instances = 0;
            Calculator3.Instances = 0;
            ScopedCombined1.Instances = 0;
            ScopedCombined2.Instances = 0;
            ScopedCombined3.Instances = 0;
        }

        private static void MeasureResolvePerformance(IContainerAdapter container, Result outputResult)
        {
            var interceptionTimeWatch = new Stopwatch();

            outputResult.SingletonTime = Measure<ISingleton1, ISingleton2, ISingleton3>(container);
            outputResult.TransientTime = Measure<ITransient1, ITransient2, ITransient3>(container);
            outputResult.CombinedTime = Measure<ICombined1, ICombined2, ICombined3>(container);
            outputResult.ComplexTime = Measure<IComplex1, IComplex2, IComplex3>(container);

            outputResult.PropertyInjectionTime =
                Measure<IComplexPropertyObject1, IComplexPropertyObject2, IComplexPropertyObject3>(container,
                    container.SupportsPropertyInjection);

            outputResult.ConditionalTime =
                Measure<ImportConditionObject1, ImportConditionObject2, ImportConditionObject3>(container,
                    container.SupportsConditional);

            outputResult.GenericTime =
                Measure<ImportGeneric<int>, ImportGeneric<float>, ImportGeneric<object>>(container,
                    container.SupportGeneric);

            outputResult.MultipleImport =
                Measure<ImportMultiple1, ImportMultiple2, ImportMultiple3>(container,
                    container.SupportsMultiple);

            outputResult.ChildContainerTime = MeasureChildContainer(container, container.SupportsChildContainer);

            outputResult.InterceptionTime = MeasureProxy(container, container.SupportsInterception);
        }

        private static long Measure<T1, T2, T3>(IContainerAdapter container)
        {
            return (long)Measure<T1, T2, T3>(container, true);
        }

        private static long? Measure<T1, T2, T3>(IContainerAdapter container, bool measure)
        {
            if (!measure)
            {
                return null;
            }

            CollectMemory();

            var watch = new Stopwatch();

            watch.Start();

            for (int i = 0; i < LoopCount; i++)
            {
                var result1 = (T1)container.Resolve(typeof(T1));
                var result2 = (T2)container.Resolve(typeof(T2));
                var result3 = (T3)container.Resolve(typeof(T3));
            }

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        private static long? MeasureChildContainer(IContainerAdapter container, bool measure)
        {
            if (!measure)
            {
                return null;
            }

            CollectMemory();

            var watch = new Stopwatch();

            watch.Start();

            for (int i = 0; i < ChildContainerLoopCount; i++)
            {
                using (var childContainer = container.CreateChildContainerAdapter())
                {
                    childContainer.Prepare();

                    var scopedCombined = (ICombined1)childContainer.Resolve(typeof(ICombined1));
                }

                using (var childContainer = container.CreateChildContainerAdapter())
                {
                    childContainer.Prepare();

                    var scopedCombined = (ICombined2)childContainer.Resolve(typeof(ICombined2));
                }

                using (var childContainer = container.CreateChildContainerAdapter())
                {
                    childContainer.Prepare();

                    var scopedCombined = (ICombined3)childContainer.Resolve(typeof(ICombined3));
                }
            }

            watch.Stop();

            return watch.ElapsedMilliseconds * 10;
        }

        private static long? MeasureProxy(IContainerAdapter container, bool measure)
        {
            if (!measure)
            {
                return null;
            }

            CollectMemory();

            var watch = new Stopwatch();

            watch.Start();

            for (int i = 0; i < LoopCount; i++)
            {
                var result1 = (ICalculator1)container.ResolveProxy(typeof(ICalculator1));
                var result2 = (ICalculator2)container.ResolveProxy(typeof(ICalculator2));
                var result3 = (ICalculator3)container.ResolveProxy(typeof(ICalculator3));

                result1.Add(5, 10);
                result2.Add(5, 10);
                result3.Add(5, 10);
            }

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        private static void CollectMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Do this a second time to ensure finalizable objects that survived the previous collect are now
            // collected.
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void WarmUp(IContainerAdapter container)
        {
            var singleton1 = (ISingleton1)container.Resolve(typeof(ISingleton1));
            var singleton2 = (ISingleton2)container.Resolve(typeof(ISingleton2));
            var singleton3 = (ISingleton3)container.Resolve(typeof(ISingleton3));

            if (singleton1 == null || singleton2 == null || singleton3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ISingleton1)));
            }

            var transient1 = (ITransient1)container.Resolve(typeof(ITransient1));
            var transient2 = (ITransient2)container.Resolve(typeof(ITransient2));
            var transient3 = (ITransient3)container.Resolve(typeof(ITransient3));

            if (transient1 == null || transient2 == null || transient3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ITransient1)));
            }

            var combined1 = (ICombined1)container.Resolve(typeof(ICombined1));
            var combined2 = (ICombined2)container.Resolve(typeof(ICombined2));
            var combined3 = (ICombined3)container.Resolve(typeof(ICombined3));

            if (combined1 == null || combined2 == null || combined3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ICombined1)));
            }

            var complex1 = (IComplex1)container.Resolve(typeof(IComplex1));
            var complex2 = (IComplex2)container.Resolve(typeof(IComplex2));
            var complex3 = (IComplex3)container.Resolve(typeof(IComplex3));

            if (complex1 == null || complex2 == null || complex3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(IComplex1)));
            }

            if (container.SupportsPropertyInjection)
            {
                var propertyInjectionObject = (ComplexPropertyObject1)container.Resolve(typeof(IComplexPropertyObject1));
                var propertyInjectionObject2 = (ComplexPropertyObject2)container.Resolve(typeof(IComplexPropertyObject2));
                var propertyInjectionObject3 = (ComplexPropertyObject3)container.Resolve(typeof(IComplexPropertyObject3));

                if (propertyInjectionObject == null || propertyInjectionObject2 == null ||
                    propertyInjectionObject3 == null)
                {
                    throw new Exception(
                         string.Format(
                         "Container {0} could not create type {1}",
                         container.PackageName,
                         typeof(IComplexPropertyObject1)));
                }

                if (object.ReferenceEquals(propertyInjectionObject, propertyInjectionObject2) ||
                     !object.ReferenceEquals(propertyInjectionObject.ServiceA, propertyInjectionObject2.ServiceA) ||
                     !object.ReferenceEquals(propertyInjectionObject.ServiceB, propertyInjectionObject2.ServiceB) ||
                     !object.ReferenceEquals(propertyInjectionObject.ServiceC, propertyInjectionObject2.ServiceC) ||
                     object.ReferenceEquals(propertyInjectionObject.SubObjectA, propertyInjectionObject2.SubObjectA) ||
                     object.ReferenceEquals(propertyInjectionObject.SubObjectB, propertyInjectionObject2.SubObjectB) ||
                     object.ReferenceEquals(propertyInjectionObject.SubObjectC, propertyInjectionObject2.SubObjectC))
                {
                    throw new Exception(
                         string.Format(
                         "Container {0} could not correctly create type {1}",
                         container.PackageName,
                         typeof(IComplexPropertyObject1)));
                }

                propertyInjectionObject.Verify(container.PackageName);
            }

            if (container.SupportGeneric)
            {
                var generic1 = (ImportGeneric<int>)container.Resolve(typeof(ImportGeneric<int>));
                var generic2 = (ImportGeneric<float>)container.Resolve(typeof(ImportGeneric<float>));
                var generic3 = (ImportGeneric<object>)container.Resolve(typeof(ImportGeneric<object>));

                if (generic1 == null || generic2 == null || generic3 == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportGeneric<int>)));
                }
            }

            if (container.SupportsMultiple)
            {
                var importMultiple1 = (ImportMultiple1)container.Resolve(typeof(ImportMultiple1));
                var importMultiple2 = (ImportMultiple2)container.Resolve(typeof(ImportMultiple2));
                var importMultiple3 = (ImportMultiple3)container.Resolve(typeof(ImportMultiple3));

                if (importMultiple1 == null || importMultiple2 == null || importMultiple3 == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportMultiple1)));
                }
            }

            if (container.SupportsConditional)
            {
                var importObject1 = (ImportConditionObject1)container.Resolve(typeof(ImportConditionObject1));
                var importObject2 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));
                var importObject3 = (ImportConditionObject3)container.Resolve(typeof(ImportConditionObject3));

                if (importObject1 == null || importObject2 == null || importObject3 == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportConditionObject1)));
                }
            }

            if (container.SupportsInterception)
            {
                var calculator1 = (ICalculator1)container.ResolveProxy(typeof(ICalculator1));
                calculator1.Add(1, 2);
                var calculator2 = (ICalculator2)container.ResolveProxy(typeof(ICalculator2));
                calculator2.Add(1, 2);
            }

            if (container.SupportsChildContainer)
            {
                using (var childContainer = container.CreateChildContainerAdapter())
                {
                    childContainer.Prepare();

                    ICombined1 scopedCombined1 = (ICombined1)childContainer.Resolve(typeof(ICombined1));
                    ICombined2 scopedCombined2 = (ICombined2)childContainer.Resolve(typeof(ICombined2));
                    ICombined3 scopedCombined3 = (ICombined3)childContainer.Resolve(typeof(ICombined3));

                    if (scopedCombined1 == null || scopedCombined2 == null || scopedCombined3 == null)
                    {
                        throw new Exception(string.Format("Child Container {0} could not create type {1}", container.PackageName, typeof(ICombined1)));
                    }

                    if (!(scopedCombined1 is ScopedCombined1) || !(scopedCombined2 is ScopedCombined2) ||
                        !(scopedCombined3 is ScopedCombined3))
                    {
                        throw new Exception(string.Format("Child Container {0} resolved type incorrectly should have been {1} but was {2}",
                            container.PackageName, typeof(ICombined1), scopedCombined1.GetType()));
                    }
                }
            }
        }
    }
}

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute
    {
    }
}