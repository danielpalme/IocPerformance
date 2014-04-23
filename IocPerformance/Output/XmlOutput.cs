using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class XmlOutput : IOutput
    {
        public void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
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
                    var time = resultsOfBenchmark.First(r => r.Container == container).Time;
                    containerElement.Add(new XElement("Benchmark", new XAttribute("type", benchmark.GetType().FullName), time));
                }

                doc.Root.Add(containerElement);
            }

            doc.Save("output\\result.xml");
        }
    }
}
