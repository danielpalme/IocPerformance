using System;
using System.Collections.Generic;
using System.Diagnostics;
using IocPerformance.Adapters;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
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

            var containers = new List<Tuple<string, IContainerAdapter>>
            {
                Tuple.Create<string, IContainerAdapter>("No", new NoContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("AutoFac", new AutofacContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Caliburn.Micro", new CaliburnMicroContainer()), 
                Tuple.Create<string, IContainerAdapter>("Catel", new CatelContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Dynamo", new DynamoContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("fFastInjector", new FFastInjectorContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Funq", new FunqContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Griffin", new GriffinContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("HaveBox", new HaveBoxContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Hiro", new HiroContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("LightCore", new LightCoreContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("LightInject", new LightInjectContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("LinFu", new LinFuContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Mef", new MefContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("MicroSliver", new MicroSliverContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Mugen", new MugenContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("Munq", new MunqContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("Ninject", new NinjectContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Petite", new PetiteContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("SimpleInjector", new SimpleInjectorContainerAdapter()), 
                //Tuple.Create<string, IContainerAdapter>("Speedioc", new SpeediocContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("Spring.NET", new SpringContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("StructureMap", new StructureMapContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("StyleMVVM", new StyleMVVMContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("TinyIOC", new TinyIOCContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("Unity", new UnityContainerAdapter()), 
                Tuple.Create<string, IContainerAdapter>("Windsor", new WindsorContainerAdapter())
            };

            foreach (var container in containers)
            {
                output.Result(MeasurePerformance(container.Item1, container.Item2));
            }

            output.Finish();
        }

        private static Result MeasurePerformance(string name, IContainerAdapter container)
        {
            ClearInstanceProperties();

            CollectMemory();

            container.Prepare();

            WarmUp(container);

            var result = new Result();
            result.Name = name;
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
                throw new Exception("Singleton instance count must be one");
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

            for (int i = 0; i < LoopCount; i++)
            {
                singletonWatch.Start();
                var result1 = (ISingleton)container.Resolve(typeof(ISingleton));
                singletonWatch.Stop();

                transientWatch.Start();
                var result2 = (ITransient)container.Resolve(typeof(ITransient));
                transientWatch.Stop();

                combinedWatch.Start();
                var result3 = (ICombined)container.Resolve(typeof(ICombined));
                combinedWatch.Stop();

                complexWatch.Start();
                var complexResult = (IComplex)container.Resolve(typeof(IComplex));
                complexWatch.Stop();

                if (container.SupportsConditional)
                {
                    conditionsWatch.Start();
                    var result4 = (ImportConditionObject)container.Resolve(typeof(ImportConditionObject));
                    var result5 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));
                    conditionsWatch.Stop();
                }

                if (container.SupportGeneric)
                {
                    genericWatch.Start();
                    var genericResult = (ImportGeneric<int>)container.Resolve(typeof(ImportGeneric<int>));
                    genericWatch.Stop();
                }

                if (container.SupportsMultiple)
                {
                    multipleWatch.Start();
                    var importMultiple = (ImportMultiple)container.Resolve(typeof(ImportMultiple));
                    multipleWatch.Stop();
                }
            }

            outputResult.SingletonTime = singletonWatch.ElapsedMilliseconds;
            outputResult.TransientTime = transientWatch.ElapsedMilliseconds;
            outputResult.CombinedTime = combinedWatch.ElapsedMilliseconds;
            outputResult.ComplexTime = complexWatch.ElapsedMilliseconds;

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
                var result = (ICalculator)container.ResolveProxy(typeof(ICalculator));

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
            var interface1 = (ISingleton)container.Resolve(typeof(ISingleton));

            if (interface1 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ISingleton)));
            }

            var interface2 = (ITransient)container.Resolve(typeof(ITransient));

            if (interface2 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ITransient)));
            }

            var combined = (ICombined)container.Resolve(typeof(ICombined));

            if (combined == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ICombined)));
            }

            var complex = (IComplex)container.Resolve(typeof(IComplex));

            if (complex == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(IComplex)));
            }

            if (container.SupportGeneric)
            {
                var generic = (ImportGeneric<int>)container.Resolve(typeof(ImportGeneric<int>));

                if (generic == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportGeneric<int>)));
                }
            }

            if (container.SupportsMultiple)
            {
                var importMultiple = (ImportMultiple)container.Resolve(typeof(ImportMultiple));

                if (importMultiple == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportMultiple)));
                }
            }

            if (container.SupportsConditional)
            {
                var importObject = (ImportConditionObject)container.Resolve(typeof(ImportConditionObject));

                if (importObject == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportConditionObject)));
                }

                var importObject2 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));

                if (importObject2 == null)
                {
                    throw new Exception(string.Format("Container {0} could not create type {1}", container.PackageName, typeof(ImportConditionObject2)));
                }
            }

            if (container.SupportsInterception)
            {
                var calculator = (ICalculator)container.ResolveProxy(typeof(ICalculator));
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