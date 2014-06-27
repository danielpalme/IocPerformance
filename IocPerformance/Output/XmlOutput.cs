using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class XmlOutput : IOutput
    {
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            var doc = new XDocument(new XElement("Containers"));

            foreach (var container in benchmarkResults.Select(r => r.Container).Distinct())
            {
                XElement containerElement = new XElement(
                    "Container",
                    new XAttribute("name", container.Name),
                    new XAttribute("version", container.Version));

                foreach (var benchmark in benchmarks)
                {
                    var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);
                    var containerResult = resultsOfBenchmark.First(r => r.Container == container);

                    containerElement.Add(new XElement(
                        "Benchmark",
                        new XAttribute("type", benchmark.GetType().FullName),
                        new XElement(
                            "SingleThreadedResult",
                            new XAttribute("time", containerResult.SingleThreadedResult.Time.HasValue ? containerResult.SingleThreadedResult.Time.ToString() : string.Empty),
                            new XAttribute("error", containerResult.SingleThreadedResult.Error ?? string.Empty),
                            new XAttribute("extrapolated", containerResult.SingleThreadedResult.ExtraPolated)),
                        new XElement(
                            "MultiThreadedResult",
                            new XAttribute("time", containerResult.MultiThreadedResult.Time.HasValue ? containerResult.MultiThreadedResult.Time.ToString() : string.Empty),
                            new XAttribute("error", containerResult.MultiThreadedResult.Error ?? string.Empty),
                            new XAttribute("extrapolated", containerResult.MultiThreadedResult.ExtraPolated))));
                }

                doc.Root.Add(containerElement);
            }

            doc.Save("output\\result.xml");
        }
    }
}
