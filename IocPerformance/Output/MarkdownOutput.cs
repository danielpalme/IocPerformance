using System.Collections.Generic;
using System.IO;
using System.Linq;
using IocPerformance.Adapters;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class MarkdownOutput : IOutput
    {
        public void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            using (var fileStream = new FileStream("../../../README.md", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("Ioc Performance");
                    writer.WriteLine("===============");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Source code of my performance comparison of the most popular .NET IoC containers:  ");
                    writer.WriteLine("[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Author: Daniel Palme  ");
                    writer.WriteLine("Blog: [www.palmmedia.de](http://www.palmmedia.de)  ");
                    writer.WriteLine("Twitter: [@danielpalme](http://twitter.com/danielpalme)  ");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Results");
                    writer.WriteLine("-------");

                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Basic Features");
                    writer.WriteLine(string.Empty);

                    this.WriteBenchmarks(writer, benchmarks.Where(b => b.GetType().FullName.Contains("Basic")), benchmarkResults);

                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Advanced Features");
                    writer.WriteLine(string.Empty);

                    this.WriteBenchmarks(writer, benchmarks.Where(b => b.GetType().FullName.Contains("Advanced")), benchmarkResults);

                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Charts");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)");
                    writer.WriteLine("![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)");
                }
            }
        }

        private void WriteBenchmarks(StreamWriter writer, IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            writer.Write("|**Container**|");
            foreach (var benchmark in benchmarks)
            {
                writer.Write("**{0}**|", benchmark.Name);
            }

            writer.WriteLine();

            writer.Write("|:------------|");
            foreach (var benchmark in benchmarks)
            {
                writer.Write("{0}:|", new string('-', benchmark.Name.Length + 3));
            }

            writer.WriteLine();

            foreach (var container in benchmarkResults.Select(r => r.Container).Distinct())
            {
                writer.Write("|**{0}**|", this.GetName(container));

                foreach (var benchmark in benchmarks)
                {
                    var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);
                    var time = resultsOfBenchmark.First(r => r.Container == container).Time;

                    string emphasis = time.HasValue
                        && resultsOfBenchmark
                            .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                            .Min(r => r.Time) == time ? "**" : string.Empty;

                    writer.Write(
                        "{0}{1}{0}|",
                        emphasis,
                        time);
                }

                writer.WriteLine();
            }
        }

        private string GetName(IContainerAdapter container)
        {
            string name = string.Format(
                "{0}{1}{2}",
                container.Name,
                string.IsNullOrEmpty(container.Version) ? string.Empty : " ",
                container.Version);

            if (!string.IsNullOrEmpty(container.Url))
            {
                name = string.Format("[{0}]({1})", name, container.Url);
            }

            return name;
        }
    }
}
