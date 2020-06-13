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
            IEnumerable<IBenchmark> currentBenchmarks,
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

                    XElement singleThreadedResultElement = benchmarkElement.Element("SingleThreadedResult");
                    result.SingleThreadedResult = new Measurement()
                    {
                        Time = string.IsNullOrEmpty(singleThreadedResultElement.Attribute("time").Value) ? (long?)null : long.Parse(singleThreadedResultElement.Attribute("time").Value),
                        Error = singleThreadedResultElement.Attribute("error").Value,
                        ExtraPolated = bool.Parse(singleThreadedResultElement.Attribute("extrapolated").Value)
                    };

                    XElement multiThreadedResultElement = benchmarkElement.Element("MultiThreadedResult");
                    result.MultiThreadedResult = new Measurement()
                    {
                        Time = string.IsNullOrEmpty(multiThreadedResultElement.Attribute("time").Value) ? (long?)null : long.Parse(multiThreadedResultElement.Attribute("time").Value),
                        Error = multiThreadedResultElement.Attribute("error").Value,
                        ExtraPolated = bool.Parse(multiThreadedResultElement.Attribute("extrapolated").Value)
                    };

                    yield return result;
                }
            }
        }

        public static void AddHistoricBenchmarkResults(IEnumerable<BenchmarkResult> benchmarkResults)
        {
            Directory.CreateDirectory("output");

            foreach (var file in Directory.GetFiles("output", "result_*.xml").OrderBy(f => f).Concat(Directory.GetFiles("output", "result.xml")))
            {
                XDocument doc = XDocument.Load(file);
                var containerElements = doc.Root.Elements("Container").ToArray();

                foreach (var containerElement in containerElements)
                {
                    string containerName = containerElement.Attribute("name").Value;

                    var benchmarkResultsOfContainer = benchmarkResults
                        .Where(b => b.ContainerInfo.Name == containerName)
                        .ToArray();

                    if (benchmarkResultsOfContainer.Length == 0)
                    {
                        continue;
                    }

                    var benchmarkElements = containerElement.Elements("Benchmark").ToArray();

                    foreach (var benchmarkElement in benchmarkElements)
                    {
                        string benchmarkTypeName = benchmarkElement.Attribute("type").Value;

                        var benchmarkResult = benchmarkResultsOfContainer
                            .FirstOrDefault(b => b.BenchmarkInfo.FullName == benchmarkTypeName);

                        if (benchmarkResult == null)
                        {
                            continue;
                        }

                        string version = containerElement.Attribute("version").Value;

                        if (benchmarkResult.History.Any(h => h.Version == version))
                        {
                            continue;
                        }

                        HistoricMeasurement historicMeasurement = new HistoricMeasurement();
                        historicMeasurement.Version = version;

                        XElement singleThreadedResultElement = benchmarkElement.Element("SingleThreadedResult");
                        historicMeasurement.SingleThreadedResult = new Measurement()
                        {
                            Time = string.IsNullOrEmpty(singleThreadedResultElement.Attribute("time").Value) ? (long?)null : long.Parse(singleThreadedResultElement.Attribute("time").Value),
                            Error = singleThreadedResultElement.Attribute("error").Value,
                            ExtraPolated = bool.Parse(singleThreadedResultElement.Attribute("extrapolated").Value)
                        };

                        XElement multiThreadedResultElement = benchmarkElement.Element("MultiThreadedResult");
                        historicMeasurement.MultiThreadedResult = new Measurement()
                        {
                            Time = string.IsNullOrEmpty(multiThreadedResultElement.Attribute("time").Value) ? (long?)null : long.Parse(multiThreadedResultElement.Attribute("time").Value),
                            Error = multiThreadedResultElement.Attribute("error").Value,
                            ExtraPolated = bool.Parse(multiThreadedResultElement.Attribute("extrapolated").Value)
                        };

                        benchmarkResult.History.Add(historicMeasurement);
                    }
                }
            }

            foreach (var benchmarkResult in benchmarkResults)
            {
                if (benchmarkResult.History.Any(h => h.Version == benchmarkResult.ContainerInfo.Version))
                {
                    continue;
                }

                HistoricMeasurement historicMeasurement = new HistoricMeasurement();
                historicMeasurement.Version = benchmarkResult.ContainerInfo.Version;
                historicMeasurement.SingleThreadedResult = benchmarkResult.SingleThreadedResult;
                historicMeasurement.MultiThreadedResult = benchmarkResult.MultiThreadedResult;

                benchmarkResult.History.Add(historicMeasurement);
            }
        }
    }
}
