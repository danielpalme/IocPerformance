using System;
using System.Collections.Generic;
using System.Diagnostics;
using IocPerformance.Adapters;

namespace IocPerformance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Name        \tSingleton\tTransient\tCombined\t#.ctor Singleton\t#.ctor Transient\t#.ctor Combined");

            var containers = new List<Tuple<string, IContainerAdapter>>
            {
                Tuple.Create<string, IContainerAdapter>("No", new NoContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("AutoFac", new AutofacContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Caliburn.Micro", new CatelContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Catel", new CatelContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Dynamo", new DynamoContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("Funq", new FunqContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Griffin", new GriffinContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Hiro", new HiroContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("LightCore", new LightCoreContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("LightInject", new LightInjectContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("LinFu", new LinFuContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Mef", new MefContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Mugen", new MugenContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Munq", new MunqContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Ninject", new NinjectContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Petite", new PetiteContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("SimpleInjector", new SimpleInjectorContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Speedioc", new SpeediocContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Spring.NET", new SpringContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("StructureMap", new StructureMapContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("TinyIOC", new TinyIOCContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Unity", new UnityContainerAdapter()),
				Tuple.Create<string, IContainerAdapter>("Windsor", new WindsorContainerAdapter())
            };

            foreach (var container in containers)
            {
                MeasurePerformance(container.Item1, container.Item2);
            }

            Console.WriteLine("Done.");

            Console.ReadKey();
        }

        private static void MeasurePerformance(string name, IContainerAdapter container)
        {
            CollectMemory();

            container.Prepare();

            WarmUp(container);

            long singletonTime = MeasureSingleton(container);
            long transientTime = MeasureTransient(container);
            long combinedTime = MeasureCombined(container);

            Console.WriteLine(string.Format(
                "{0}\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t\t{5}\t\t\t\t{6}",
                name + "             ".Substring(name.Length - 1),
                singletonTime,
                transientTime,
                combinedTime,
                Singleton.Instances,
                Transient.Instances,
                Combined.Instances));

            Singleton.Instances = 0;
            Transient.Instances = 0;
            Combined.Instances = 0;

            container.Dispose();
        }

        private const int LoopCount = 1000000;

        private static long MeasureSingleton(IContainerAdapter container)
        {
            var watch = Stopwatch.StartNew();

            for (int i = 0; i < LoopCount; i++)
            {
                container.Resolve<ISingleton>();
            }

            return watch.ElapsedMilliseconds;
        }

        private static long MeasureTransient(IContainerAdapter container)
        {
            var watch = Stopwatch.StartNew();

            for (int i = 0; i < LoopCount; i++)
            {
                container.Resolve<ITransient>();
            }

            return watch.ElapsedMilliseconds;
        }

        private static long MeasureCombined(IContainerAdapter container)
        {
            var watch = Stopwatch.StartNew();

            for (int i = 0; i < LoopCount; i++)
            {
                container.Resolve<ICombined>();
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
            var interface2 = container.Resolve<ITransient>();
            var combined = container.Resolve<ISingleton>();
        }
    }
}

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}