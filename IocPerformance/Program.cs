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
		private const int LoopCount = 1000000;

		// I put it at 10000 because some containers take a while
		private const int ChildContainerLoopCount = 10000;

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

				if (result != null)
				{
					result.Url = container.Url;
				}

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
			result.Url = container.Url;
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

			if (container.SupportsChildContainer)
			{
				if (ScopedCombined.Instances != ChildContainerLoopCount + 1 &&
					 ScopedCombined.Instances != ChildContainerLoopCount + 2)
				{
					throw new Exception(string.Format("ScopedCombined count must be {0} or {1} was {2}", ChildContainerLoopCount + 1, ChildContainerLoopCount + 2));
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
			ScopedCombined.Instances = 0;
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
			var childContainerWatch = new Stopwatch();

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

				if (container.SupportsPropertyInjection)
				{
					propertyWatch.Start();
					var propertyInjectionResult = (IComplexPropertyObject)container.Resolve(typeof(IComplexPropertyObject));
					propertyWatch.Stop();
				}

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

				if (container.SupportsChildContainer && i < ChildContainerLoopCount)
				{
					// Note I'm writing the test this way specifically because it matches the Per Request bootstrapper for Nance
					// It's also a very common pattern used in MVC applications where a scope is created per request
					childContainerWatch.Start();

					using (var childContainer = container.CreateChildContainerAdapter())
					{
						childContainer.Prepare();

						var scopedCombined = childContainer.Resolve(typeof(ICombined));
					}

					childContainerWatch.Stop();
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

			if (container.SupportsChildContainer)
			{
				outputResult.ChildContainerTime = childContainerWatch.ElapsedMilliseconds * (LoopCount / ChildContainerLoopCount);
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

			if (container.SupportsPropertyInjection)
			{
				var propertyInjectionObject = (ComplexPropertyObject)container.Resolve(typeof(IComplexPropertyObject));
				var propertyInjectionObject2 = (ComplexPropertyObject)container.Resolve(typeof(IComplexPropertyObject));

				if (propertyInjectionObject == null || propertyInjectionObject2 == null)
				{
					throw new Exception(
						 string.Format(
						 "Container {0} could not create type {1}",
						 container.PackageName,
						 typeof(IComplexPropertyObject)));
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
						 typeof(IComplexPropertyObject)));
				}

				propertyInjectionObject.Verify(container.PackageName);
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

			if (container.SupportsChildContainer)
			{
				using (var childContainer = container.CreateChildContainerAdapter())
				{
					childContainer.Prepare();

					ICombined scopedCombined = (ICombined)childContainer.Resolve(typeof(ICombined));

					if (scopedCombined == null)
					{
						throw new Exception(string.Format("Child Container {0} could not create type {1}", container.PackageName, typeof(ICombined)));
					}

					if (!(scopedCombined is ScopedCombined))
					{
						throw new Exception(string.Format("Child Container {0} resolved type incorrectly should have been {1} but was {2}", 
							container.PackageName, typeof(ICombined), scopedCombined.GetType()));
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