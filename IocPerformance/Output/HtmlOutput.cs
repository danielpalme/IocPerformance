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
            if (!Directory.Exists("output\\blog"))
            {
                Directory.CreateDirectory("output\\blog");
            }

            using (var fileStream = new FileStream("output\\blog\\result.txt", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write("<tr><th>Container</th>");

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
                            var containerResult = resultsOfBenchmark.First(r => r.Container == container);

                            string emphasisTime = containerResult.SingleThreadedResult.Time.HasValue
                                && resultsOfBenchmark
                                    .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                                    .Min(r => r.SingleThreadedResult.Time) == containerResult.SingleThreadedResult.Time ? " style=\"font-weight:bold;\"" : string.Empty;

                            string emphasisMultithreadedTime = containerResult.MultiThreadedResult.Time.HasValue
                                && resultsOfBenchmark
                                    .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                                    .Min(r => r.MultiThreadedResult.Time) == containerResult.MultiThreadedResult.Time ? " style=\"font-weight:bold;\"" : string.Empty;

                            writer.Write(
                                "<td style=\"text-align:right;\"><span title=\"Single thread\"{0}>{1}</span><br /><span title=\"Multiple threads\"{2}>{3}</span></td>",
                                emphasisTime,
                                containerResult.SingleThreadedResult,
                                emphasisMultithreadedTime,
                                containerResult.MultiThreadedResult);
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
