using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class MarkdownOutput : IOutput
    {
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            using (var fileStream = new FileStream("../../../README.md", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("# Ioc Performance");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("[![Build Status](https://dev.azure.com/danielpalme/IocPerformance/_apis/build/status/danielpalme.IocPerformance?branchName=master)](https://dev.azure.com/danielpalme/IocPerformance/_build/latest?definitionId=6&branchName=master)");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Source code of my performance comparison of the most popular .NET IoC containers:  ");
                    writer.WriteLine("[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](https://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Author: Daniel Palme  ");
                    writer.WriteLine("Blog: [www.palmmedia.de](https://www.palmmedia.de)  ");
                    writer.WriteLine("Twitter: [@danielpalme](https://twitter.com/danielpalme)  ");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("## Results");

                    writer.WriteLine("### Explantions");
                    writer.WriteLine("**First value**: Time of single-threaded execution in [ms]  ");
                    writer.WriteLine("**Second value**: Time of multi-threaded execution in [ms]  ");

                    if (benchmarkResults.Any(b => b.SingleThreadedResult.ExtraPolated || b.MultiThreadedResult.ExtraPolated))
                    {
                        writer.WriteLine("**_*_**: Benchmark was stopped after 1 minute and result is extrapolated.  ");
                    }

                    if (benchmarkResults.Any(b => b.SingleThreadedResult.Error == "OoM" || b.MultiThreadedResult.Error == "OoM"))
                    {
                        writer.WriteLine("**OoM**: Benchmark was stopped after an *OutOfMemoryException* was thrown.  ");
                    }

                    if (benchmarkResults.Any(b => b.SingleThreadedResult.Error == "OoM" || b.MultiThreadedResult.Error == "OoM"))
                    {
                        writer.WriteLine("**Error**: Benchmark was stopped after an *Exception* was thrown.  ");
                    }

                    writer.WriteLine("### Basic Features");
                    this.WriteBenchmarks(writer, benchmarks.Where(b => b.GetType().FullName.Contains("Basic")), benchmarkResults);

                    writer.WriteLine("### Advanced Features");
                    this.WriteBenchmarks(writer, benchmarks.Where(b => b.GetType().FullName.Contains("Advanced")), benchmarkResults);

                    writer.WriteLine("### Prepare");
                    this.WriteBenchmarks(writer, benchmarks.Where(b => b.GetType().FullName.Contains("Prepare")), benchmarkResults);

                    writer.WriteLine("### Charts");
                    writer.WriteLine("![Basic features](https://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)");
                    writer.WriteLine("![Advanced features](https://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)");
                    writer.WriteLine("![Prepare](https://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)");

                    writer.WriteLine("### Machine");
                    writer.WriteLine("The benchmark was executed on the following machine:  ");
                    using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                        win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                            win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
                    {
                        foreach (ManagementObject obj in win32Proc.Get())
                        {
                            writer.WriteLine("**CPU**: " + obj["Name"] + "  ");
                        }
                    }

                    writer.WriteLine("**Memory**: " + ((double)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (1024 * 1024 * 1024)).ToString("f2") + "GB");
                }
            }
        }

        private void WriteBenchmarks(StreamWriter writer, IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
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

            foreach (var container in benchmarkResults.Select(r => r.ContainerInfo).Distinct())
            {
                writer.Write("|**{0}**|", this.GetName(container));

                foreach (var benchmark in benchmarks)
                {
                    var resultsOfBenchmark = benchmarkResults.Where(r => r.BenchmarkInfo.Name == benchmark.Name);
                    var containerResult = resultsOfBenchmark.First(r => r.ContainerInfo.Name == container.Name);

                    string emphasisTime = containerResult.SingleThreadedResult.Time.HasValue
                        && resultsOfBenchmark
                            .Where(r => r.ContainerInfo.Name != "No")
                            .Min(r => r.SingleThreadedResult.Time) == containerResult.SingleThreadedResult.Time ? "**" : string.Empty;

                    string emphasisMultithreadedTime = containerResult.MultiThreadedResult.Time.HasValue
                        && resultsOfBenchmark
                            .Where(r => r.ContainerInfo.Name != "No")
                            .Min(r => r.MultiThreadedResult.Time) == containerResult.MultiThreadedResult.Time ? "**" : string.Empty;

                    writer.Write(
                        "{0}{1}{0}<br/>{2}{3}{2}|",
                        emphasisTime,
                        containerResult.SingleThreadedResult,
                        emphasisMultithreadedTime,
                        containerResult.MultiThreadedResult);
                }

                writer.WriteLine();
            }
        }

        private string GetName(ContainerAdapterInfo container)
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
