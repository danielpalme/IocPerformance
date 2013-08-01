using System;
using System.Diagnostics;
using System.Linq;
using IocPerformance.Adapters;
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
        private const int LoopCount = 1000000;

        public static void Main(string[] args)
        {
            IOutput output = new MultiOutput(new IOutput[] { new HtmlOutput(), new MarkdownOutput(), new ChartOutput(), new CsvOutput(), new ConsoleOutput() });
            output.Start();

            var containers = ContainerAdapterFactory.CreateAdapters();

            bool onlyUpdateChangedContainers = args != null && args.Any(a => a.Equals("-update", StringComparison.OrdinalIgnoreCase));
            var csvOutputReader = new CsvOutputReader();

            foreach (var container in containers)
            {
                Result result = csvOutputReader.GetExistingResult(container.Name);

                if (!onlyUpdateChangedContainers || result == null || result.Version != container.Version)
                {
                    result = MeasurePerformance(container);
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
            result.Version = container.Version;

            MeasureResolvePerformance(container, result);

            if (container.SupportsInterception)
            {
                result.InterceptionTime = MeasureProxy(container);
            }

            CheckInstanceProperties(container);

            container.Dispose();

            return result;
        }

        private static void CheckInstanceProperties(IContainerAdapter container)
        {
            if (Singleton.Instances != 1)
            {
                throw new Exception("Singleton instance count must be one container: " + container.PackageName);
            }

            if (Transient.Instances < (LoopCount * 2) + 1 || Transient.Instances > (LoopCount * 2) + 4)
            {
                throw new Exception(
                     string.Format("Transient count must be between {0} and {1} was {2}", (LoopCount * 2) + 1, (LoopCount * 2) + 4, Transient.Instances));
            }

            if (Combined.Instances != LoopCount + 1 && Combined.Instances != LoopCount + 2)
            {
                throw new Exception(string.Format("Combined count must be {0} or {1} was {2}", LoopCount + 1, LoopCount + 2, Combined.Instances));
            }

            if (Complex.Instances != LoopCount + 1 && Complex.Instances != LoopCount + 2)
            {
                throw new Exception(string.Format("Complex count must be {0} or {1} was {2}", LoopCount + 1, LoopCount + 2, Complex.Instances));
            }

            if (container.SupportsInterception)
            {
                if (Calculator.Instances != LoopCount + 1 && Calculator.Instances != LoopCount + 2)
                {
                    throw new Exception(string.Format("Calculator count must be {0} or {1} was {2}", LoopCount + 1, LoopCount + 2, Calculator.Instances));
                }
            }
        }

        private static void ClearInstanceProperties()
        {
            Singleton.Instances = 0;
            Transient.Instances = 0;
            Combined.Instances = 0;
            Complex.Instances = 0;
            Calculator.Instances = 0;
        }

        private static void MeasureResolvePerformance(IContainerAdapter container, Result outputResult)
        {
            var singletonWatch = new Stopwatch();
            var transientWatch = new Stopwatch();
            var combinedWatch = new Stopwatch();
            var conditionsWatch = new Stopwatch();
            var genericWatch = new Stopwatch();
            var complexWatch = new Stopwatch();
            var multipleWatch = new Stopwatch();
            var propertyWatch = new Stopwatch();

            for (int i = 0; i < LoopCount; i++)
            {
                singletonWatch.Start();
                var result1 = container.Resolve<ISingleton>();
                singletonWatch.Stop();

                transientWatch.Start();
                var result2 = container.Resolve<ITransient>();
                transientWatch.Stop();

                combinedWatch.Start();
                var result3 = container.Resolve<ICombined>();
                combinedWatch.Stop();

                complexWatch.Start();
                var complexResult = container.Resolve<IComplex>();
                complexWatch.Stop();

                if (container.SupportsPropertyInjection)
                {
                    propertyWatch.Start();
                    var propertyInjectionResult = container.Resolve<IComplexPropertyObject>();
                    propertyWatch.Stop();
                }

                if (container.SupportsConditional)
                {
                    conditionsWatch.Start();
                    var result4 = container.Resolve<ImportConditionObject>();
                    var result5 = container.Resolve<ImportConditionObject2>();
                    conditionsWatch.Stop();
                }

                if (container.SupportGeneric)
                {
                    genericWatch.Start();
                    var genericResult = container.Resolve<ImportGeneric<int>>();
                    genericWatch.Stop();
                }

                if (container.SupportsMultiple)
                {
                    multipleWatch.Start();
                    var importMultiple = container.Resolve<ImportMultiple>();
                    multipleWatch.Stop();
                }
            }

            outputResult.SingletonTime = singletonWatch.ElapsedMilliseconds;
            outputResult.TransientTime = transientWatch.ElapsedMilliseconds;
            outputResult.CombinedTime = combinedWatch.ElapsedMilliseconds;
            outputResult.ComplexTime = complexWatch.ElapsedMilliseconds;

            if (container.SupportsPropertyInjection)
            {
                outputResult.PropertyInjectionTime = propertyWatch.ElapsedMilliseconds;
            }

            if (container.SupportGeneric)
            {
                outputResult.GenericTime = genericWatch.ElapsedMilliseconds;
            }

            if (container.SupportsMultiple)
            {
                outputResult.MultipleImport = multipleWatch.ElapsedMilliseconds;
            }

            if (container.SupportsConditional)
            {
                outputResult.ConditionalTime = conditionsWatch.ElapsedMilliseconds;
            }
        }

        private static long MeasureProxy(IContainerAdapter container)
        {
            var watch = Stopwatch.StartNew();

            for (int i = 0; i < LoopCount; i++)
            {
                var result = container.Resolve<ICalculator>();

                // Call method because part of the time spent with a proxy is how long does it take to execute a proxied method
                result.Add(5, 10);
            }

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
            var interface1 = container.Resolve<ISingleton>();

            if (interface1 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ISingleton)));
            }

            var interface2 = container.Resolve<ITransient>();

            if (interface2 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ITransient)));
            }

            var combined = container.Resolve<ICombined>();

            if (combined == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ICombined)));
            }

            var complex = container.Resolve<IComplex>();

            if (complex == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(IComplex)));
            }

            if (container.SupportsPropertyInjection)
            {
                var propertyInjectionObject = container.Resolve<IComplexPropertyObject>();

                if (propertyInjectionObject == null)
                {
                    throw new Exception(
                        string.Format("Container {0} could not create type {1}",
                        container.PackageName,
                        typeof(IComplexPropertyObject)));
                }

                propertyInjectionObject.Verify(container.PackageName);
            }

            if (container.SupportGeneric)
            {
                var generic = container.Resolve<ImportGeneric<int>>();

                if (generic == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportGeneric<int>)));
                }
            }

            if (container.SupportsMultiple)
            {
                var importMultiple = container.Resolve<ImportMultiple>();

                if (importMultiple == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportMultiple)));
                }
            }

            if (container.SupportsConditional)
            {
                var importObject = container.Resolve<ImportConditionObject>();

                if (importObject == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportConditionObject)));
                }

                var importObject2 = container.Resolve<ImportConditionObject2>();

                if (importObject2 == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportConditionObject2)));
                }
            }

            if (container.SupportsInterception)
            {
                var calculator = container.Resolve<ICalculator>();
                calculator.Add(1, 2);
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