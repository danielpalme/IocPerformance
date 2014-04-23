using System.Collections.Generic;
using System.IO;
using System.Linq;
using IocPerformance.Adapters;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class HtmlOutput : IOutput
    {
        public void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            using (var fileStream = new FileStream("output\\result.txt", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write("<tr>");

                    foreach (var benchmark in benchmarks)
                    {
                        writer.Write("<th>{0}</th>", benchmark.Name);
                    }

                    writer.WriteLine("</tr>");

                    foreach (var container in benchmarkResults.Select(r => r.Container).Distinct())
                    {
                        writer.Write("<tr>");
                        writer.Write("<th>{0}</th>", GetName(container));

                        foreach (var benchmark in benchmarks)
                        {
                            var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);
                            var time = resultsOfBenchmark.First(r => r.Container == container).Time;

                            string emphasis = time.HasValue
                                && resultsOfBenchmark
                                    .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                                    .Min(r => r.Time) == time ? "h" : "d";

                            writer.Write(
                                "<t{0}>{1}</t{0}>",
                                emphasis,
                                time);
                        }

                        writer.WriteLine("</tr>");
                    }
                }
            }
        }

        private static string GetName(IContainerAdapter container)
        {
            string name = string.Format(
                "{0}{1}{2}",
                container.Name,
                string.IsNullOrEmpty(container.Version) ? string.Empty : " ",
                container.Version);

            if (!string.IsNullOrEmpty(container.Url))
            {
                name = string.Format("<a href=\"{0}\">{1}</a>", container.Url, name);
            }

            return name;
        }
    }
}
