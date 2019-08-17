using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class GithubPagesOutput : IOutput
    {
        private const int MaximumNumberOfHistoryEntrys = 25;

        private const double ChartWidth = 50;

        private const double ChartHeight = 20;

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
                    writer.Write("<meta charset=\"utf -8\" />");
                    writer.Write("<title>Ioc Performance - Results</title>");
                    writer.Write("<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css\" integrity=\"sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T\" crossorigin=\"anonymous\">");
                    writer.Write("<style>");
                    writer.Write(".blue { background-color: #e7f6ff; }");
                    writer.Write(".legendbox { border: 1px solid #c1c1c1; width: 20px; height: 20px; display: inline-block; position: relative; top: 3px; }");
                    writer.Write(".imagecontainer:before { content: ' '; display: block; }");
                    writer.Write("</style>");
                    writer.Write("</head>");
                    writer.Write("<body>");
                    writer.Write("<div class=\"container-fluid\">");
                    writer.Write("<h1>Ioc Performance - Results</h1>");
                    writer.Write("<h2>Overview</h2>");
                    writer.Write("<p>Chart legend: <span class=\"legendbox\" style =\"background-color: #c00;\">&nbsp;</span> Single thread <span class=\"legendbox ml-4\" style=\"background-color: #1c2298;\">&nbsp;</span> Multiple threads</p>");
                    writer.Write("<div class=\"table-responsive\">");
                    writer.Write("<table class=\"table table-sm table-striped\">");

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
                                "<td class=\"{0}\" style=\"text-align:right;\"><span title=\"Single thread\"{1}>{2}</span><br /><span title=\"Multiple threads\"{3}>{4}</span>{5}</td>",
                                benchmark.Category == BenchmarkCategory.Advanced ? string.Empty : "blue",
                                emphasisTime,
                                containerResult.SingleThreadedResult,
                                emphasisMultithreadedTime,
                                containerResult.MultiThreadedResult,
                                CreateSvgHistoryChart(containerResult));
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

        private static string CreateSvgHistoryChart(BenchmarkResult containerResult)
        {
            var history = containerResult.History.ToList();
            history.RemoveRange(0, Math.Max(0, history.Count - MaximumNumberOfHistoryEntrys));

            if (history.Count < 2)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendFormat(
                "<div class=\"imagecontainer\" title=\"Container: {0}\r\nBenchmark: {1}\r\n\r\nVersions:\r\n{2}\">",
                containerResult.ContainerInfo.Name,
                containerResult.BenchmarkInfo.Name,
                string.Join("\r\n", history.Select(h => h.ToString())));
            sb.AppendFormat("<svg width=\"{0}\" height=\"{1}\" fill=\"#fff\" viewBox=\"0 0 {0} {1}\">", ChartWidth, ChartHeight);
            sb.AppendFormat("<rect width=\"{0}\" height=\"{1}\" fill=\"#fff\" stroke=\"#c1c1c1\"/>", ChartWidth, ChartHeight);
            sb.AppendLine("<g>");

            string path = string.Empty;
            var successfulHistoriesMultiThreaded = history.Select(h => h.MultiThreadedResult).Where(h => h.Time.HasValue).ToArray();
            var successfulHistoriesSingleThreaded = history.Select(h => h.SingleThreadedResult).Where(h => h.Time.HasValue).ToArray();

            if (successfulHistoriesMultiThreaded.Length == 0 && successfulHistoriesSingleThreaded.Length == 0)
            {
                return string.Empty;
            }

            long maximum = successfulHistoriesMultiThreaded.Concat(successfulHistoriesSingleThreaded).Max(h => h.Time.Value);

            if (successfulHistoriesMultiThreaded.Length > 0)
            {
                for (int i = 0; i < history.Count; i++)
                {
                    if (history[i].MultiThreadedResult.Time.HasValue)
                    {
                        long value = history[i].MultiThreadedResult.Time.Value;

                        path += path.Length == 0 ? "M" : "L";
                        path += Math.Round(ChartWidth * i / (history.Count - 1), 1).ToString(CultureInfo.InvariantCulture);
                        path += ",";
                        path += Math.Round(ChartHeight - (ChartHeight * value / (maximum == 0 ? 1 : maximum)), 1).ToString(CultureInfo.InvariantCulture);

                    }
                }

                sb.AppendFormat("<path d=\"{0}\" stroke=\"#1c2298\" fill=\"transparent\"></path>", path);
            }

            // Single threaded result
            path = string.Empty;

            if (successfulHistoriesSingleThreaded.Length > 0)
            {
                for (int i = 0; i < history.Count; i++)
                {
                    if (history[i].SingleThreadedResult.Time.HasValue)
                    {
                        long value = history[i].SingleThreadedResult.Time.Value;

                        path += path.Length == 0 ? "M" : "L";
                        path += Math.Round(ChartWidth * i / (history.Count - 1), 1).ToString(CultureInfo.InvariantCulture);
                        path += ",";
                        path += Math.Round(ChartHeight - (ChartHeight * value / (maximum == 0 ? 1 : maximum)), 1).ToString(CultureInfo.InvariantCulture);

                    }
                }

                sb.AppendFormat("<path d=\"{0}\" stroke=\"#c00\" fill=\"transparent\"></path>", path);
            }

            sb.AppendLine("</g>");
            sb.AppendLine("</svg>");
            sb.AppendLine("</div>");

            return sb.ToString();
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
