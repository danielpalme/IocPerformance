using System.Collections.Generic;
using System.IO;
using System.Linq;
using IocPerformance.Adapters;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    /// <summary>
    /// Returns csv_Rate.csv, each value is a rate of comparing with the base value in NoContainerAdapter. 
    /// It makes the measurements to be independent of the hardware installed.
    /// </summary>
    public class CsvRateOutput : IOutput
    {
        public void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            using (var fileStream = new FileStream("output\\csv_Rate.csv", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write("Container,Version");

                    foreach (var benchmark in benchmarks)
                    {
                        writer.Write(",{0}", benchmark.Name);
                    }

                    writer.WriteLine();

                    foreach (var container in benchmarkResults.Select(r => r.Container).Distinct())
                    {
                        writer.Write("{0},{1}", container.Name, container.Version);

                        foreach (var benchmark in benchmarks)
                        {
                            var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);
                            var time = resultsOfBenchmark.First(r => r.Container == container).Time;
                            var basetime = resultsOfBenchmark.First(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))).Time;

                            writer.Write(
                                ",{0}",
                                CalcRate(time, basetime));
                        }

                        writer.WriteLine();
                    }
                }
            }
        }

        private static string CalcRate(long? val, long? baseValue)
        {
            if (!val.HasValue || !baseValue.HasValue)
            {
                return "-";
            }

            if (baseValue.Value == 0)
            {
                return "NaN";
            }

            double rate = (double)val.Value / baseValue.Value;
            return rate.ToString("0.000");
        }
    }
}
