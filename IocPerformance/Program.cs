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
                Tuple.Create<string, IContainerAdapter>("Griffin", new GriffinContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("LightInject", new LightInjectContainerAdapter()),
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