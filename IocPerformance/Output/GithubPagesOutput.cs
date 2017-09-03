using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class GithubPagesOutput : IOutput
    {
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            string baseDirectory = "../../../docs";
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            string imageDirectory = Path.Combine(baseDirectory, "img");
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            new ChartOutput().Create(benchmarks, benchmarkResults, imageDirectory);
            new JsonOutput().Create(benchmarks, benchmarkResults, baseDirectory);

            using (var fileStream = new FileStream(Path.Combine(baseDirectory, "index.html"), FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write("<!DOCTYPE html>");
                    writer.Write("<html lang=\"en\">");
                    writer.Write("<head>");
                    writer.Write("<meta charset=\"utf -8\" />");                    writer.Write("<title>Ioc Performance - Results</title>");                    writer.Write("<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css\" integrity=\"sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M\" crossorigin=\"anonymous\" />");
                    writer.Write("<style>");
                    writer.Write(".blue { background-color: #e7f6ff; }");
                    writer.Write("</style>");
                    writer.Write("</head>");
                    writer.Write("<body>");
                    writer.Write("<div class=\"container-fluid\">");
                    writer.Write("<h1>Ioc Performance - Results</h1>");
                    writer.Write("<h2>Overview</h2>");
                    writer.Write("<div class=\"table-responsive\">");
                    writer.Write("<table class=\"table table-condensed table-striped\">");

                    writer.Write("<tr>");
                    writer.Write("<th></th>");

                    foreach (var category in Enum.GetValues(typeof(BenchmarkCategory)).Cast<BenchmarkCategory>())
                    {
                        writer.Write(
                            "<th class=\"text-center {0}\" colspan=\"{1}\">{2}</th>",
                            category == BenchmarkCategory.Advanced ? string.Empty : "blue",
                            benchmarks.Count(b => b.Category == category),
                            category);
                    }

                    writer.Write("</tr>");

                    writer.Write("<tr>");
                    writer.Write("<th>Container</th>");

                    foreach (var benchmark in benchmarks)
                    {
                        writer.Write(
                            "<th class=\"text-right {1}\">{0}</th>",
                            benchmark.Name,
                            benchmark.Category == BenchmarkCategory.Advanced ? string.Empty : "blue");
                    }

                    writer.WriteLine("</tr>");

                    foreach (var container in benchmarkResults.Select(r => r.ContainerInfo).Distinct())
                    {
                        writer.Write("<tr>");
                        writer.Write("<th>{0}</th>", GetName(container));

                        foreach (var benchmark in benchmarks)
                        {
                            var resultsOfBenchmark = benchmarkResults.Where(r => r.BenchmarkInfo.Name == benchmark.Name);
                            var containerResult = resultsOfBenchmark.First(r => r.ContainerInfo.Name == container.Name);

                            string emphasisTime = containerResult.SingleThreadedResult.Time.HasValue
                                && resultsOfBenchmark
                                    .Where(r => r.ContainerInfo.Name != "No")
                                    .Min(r => r.SingleThreadedResult.Time) == containerResult.SingleThreadedResult.Time ? " style=\"font-weight:bold;\"" : string.Empty;

                            string emphasisMultithreadedTime = containerResult.MultiThreadedResult.Time.HasValue
                                && resultsOfBenchmark
                                    .Where(r => r.ContainerInfo.Name != "No")
                                    .Min(r => r.MultiThreadedResult.Time) == containerResult.MultiThreadedResult.Time ? " style=\"font-weight:bold;\"" : string.Empty;

                            writer.Write(
                                "<td class=\"{0}\" style=\"text-align:right;\"><span title=\"Single thread\"{1}>{2}</span><br /><span title=\"Multiple threads\"{3}>{4}</span></td>",
                                benchmark.Category == BenchmarkCategory.Advanced ? string.Empty : "blue",
                                emphasisTime,
                                containerResult.SingleThreadedResult,
                                emphasisMultithreadedTime,
                                containerResult.MultiThreadedResult);
                        }

                        writer.WriteLine("</tr>");
                    }

                    writer.Write("</table>");
                    writer.Write("</div>");

                    writer.Write("<h2>Charts</h2>");

                    int counter = 0;

                    foreach (var benchmark in benchmarks)
                    {
                        writer.Write("<h3>{0}</h3>", benchmark.Name);
                        writer.Write(
                            "<img src=\"img/{0:00}-{1}.png\" class=\"img-fluid\" alt=\"{2}\" />",
                            ++counter,
                            benchmark.Name,
                            benchmark.Name);

                        writer.Write("<br /><br />");
                    }

                    writer.Write("</div>");
                    writer.Write("</body>");
                    writer.Write("</html>");
                }
            }
        }

        private static string GetName(ContainerAdapterInfo container)
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
