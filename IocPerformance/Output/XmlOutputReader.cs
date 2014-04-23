using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Adapters;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public static class XmlOutputReader
    {
        public static IEnumerable<BenchmarkResult> GetExistingBenchmarkResults(
            IEnumerable<BenchmarkBase> currentBenchmarks,
            IEnumerable<IContainerAdapter> currentContainers)
        {
            if (!File.Exists("output\\result.xml"))
            {
                yield break;
            }

            XDocument doc = XDocument.Load("output\\result.xml");

            foreach (var container in currentContainers)
            {
                var containerElement = doc.Root
                    .Elements("Container")
                    .FirstOrDefault(c => c.Attribute("name").Value.Equals(container.Name) 
                        && c.Attribute("version").Value.Equals(container.Version));

                if (containerElement == null)
                {
                    continue;
                }

                foreach (var benchmark in currentBenchmarks)
                {
                    var benchmarkElement = containerElement.Elements()
                        .FirstOrDefault(e => e.Attribute("type") != null && e.Attribute("type").Value.Equals(benchmark.GetType().FullName));

                    if (benchmarkElement == null)
                    {
                        continue;
                    }

                    var result = new BenchmarkResult(benchmark, container);

                    result.Time = string.IsNullOrEmpty(benchmarkElement.Value) ? (long?)null : long.Parse(benchmarkElement.Value);

                    yield return result;
                }
            }
        }
    }
}
