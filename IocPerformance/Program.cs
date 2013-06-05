using System;
using System.Collections.Generic;
using System.Diagnostics;
using IocPerformance.Adapters;
using IocPerformance.Output;

namespace IocPerformance
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			IOutput output = new MultiOutput(new IOutput[] { new HtmlOutput(), new MarkdownOutput(), new ChartOutput(), new ConsoleOutput() });
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
                Tuple.Create<string, IContainerAdapter>("Speedioc", new SpeediocContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("Spring.NET", new SpringContainerAdapter()),
                Tuple.Create<string, IContainerAdapter>("StructureMap", new StructureMapContainerAdapter()),
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
			CollectMemory();

			container.Prepare();

			WarmUp(container);

			var timings = MeasurePerformance(container);
			
			var result = new Result();
			result.Name = name;
			result.Version = container.Version;
			result.SingletonTime = timings.Item1;
			result.TransientTime = timings.Item2;
			result.CombinedTime = timings.Item3;

			if (container.SupportsInterception)
			{
				result.InterceptionTime = MeasureProxy(container);
			}

			result.SingletonInstances = Singleton.Instances;
			result.TransientInstances = Transient.Instances;
			result.CombinedInstances = Combined.Instances;
			result.InterceptionInstances = Calculator.Instances;

			Singleton.Instances = 0;
			Transient.Instances = 0;
			Combined.Instances = 0;
			Calculator.Instances = 0;

			container.Dispose();

			return result;
		}

		private const int LoopCount = 1000000;

		private static Tuple<long, long, long> MeasurePerformance(IContainerAdapter container)
		{
			var singletonWatch = new Stopwatch();
			var transientWatch = new Stopwatch();
			var combinedWatch = new Stopwatch();

			for (int i = 0; i < LoopCount; i++)
			{
				singletonWatch.Start();
				container.Resolve<ISingleton>();
				singletonWatch.Stop();

				transientWatch.Start();
				container.Resolve<ITransient>();
				transientWatch.Stop();

				combinedWatch.Start();
				container.Resolve<ICombined>();
				combinedWatch.Stop();
			}

			return new Tuple<long, long, long>(singletonWatch.ElapsedMilliseconds, transientWatch.ElapsedMilliseconds, combinedWatch.ElapsedMilliseconds);
		}

		private static long MeasureProxy(IContainerAdapter container)
		{
			var watch = Stopwatch.StartNew();

			for (int i = 0; i < LoopCount; i++)
			{
				container.ResolveProxy<ICalculator>();
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
			var combined = container.Resolve<ICombined>();

			if (container.SupportsInterception)
			{
				var calculator = container.ResolveProxy<ICalculator>();
				calculator.Add(1, 2);
			}
		}
	}
}

namespace System.Runtime.CompilerServices
{
	public class ExtensionAttribute : Attribute { }
}