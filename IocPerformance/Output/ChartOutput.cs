using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using IocPerformance.Adapters;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class ChartOutput : IOutput
    {
        public void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            int counter = 0;

            foreach (var benchmark in benchmarks)
            {
                var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);

                CreateChart(
                    benchmark.Name,
                    string.Format("output\\{0:00}-{1}.png", ++counter, benchmark.Name),
                    resultsOfBenchmark
                        .Where(r => r.Time.HasValue)
                        .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                        .OrderByDescending(r => r.Time.Value)
                        .Concat(resultsOfBenchmark.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))))
                        .Select(r => new Tuple<string, double>(r.Container.Name, r.Time.Value)));
            }

            CreateOverviewChart(benchmarks, benchmarkResults, "Basic", 0, 6000);
            CreateOverviewChart(benchmarks, benchmarkResults, "Basic", 6000, long.MaxValue);
            CreateOverviewChart(benchmarks, benchmarkResults, "Advanced", 0, 25000);
            CreateOverviewChart(benchmarks, benchmarkResults, "Advanced", 25000, long.MaxValue);

            // Blog images
            File.Copy("output\\Overview_Basic_Fast.png", "output\\5225c515-2f25-498f-84fe-6c6e931d2042.png", true);
            File.Copy("output\\Overview_Advanced_Fast.png", "output\\e0401485-20c6-462e-b5d4-c9cf854e6bee.png", true);
        }

        private static void CreateOverviewChart(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults, string type, long minTime, long maxTime)
        {
            benchmarkResults = benchmarkResults.Where(b => b.Benchmark.GetType().FullName.Contains(type)).ToArray();
            benchmarks = benchmarks.Where(b => b.GetType().FullName.Contains(type)).ToArray();

            Chart chart = new Chart()
            {
                Size = new Size(800, 600),
                Palette = ChartColorPalette.Pastel,
                BorderlineColor = Color.Black,
                BorderlineWidth = 1,
                BorderColor = Color.Black,
                BorderDashStyle = ChartDashStyle.Solid,
            };

            if (minTime == 0)
            {
                chart.Titles.Add("Overview '" + type + "' (Maximum total time: " + maxTime + "ms)");
                type += "_Fast";
            }
            else
            {
                chart.Titles.Add("Overview '" + type + "' (Minimum total time: " + minTime + "ms)");
                type += "_Slow";
            }

            chart.ChartAreas.Add("Default");
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.Legends.Add(new Legend("Default")
            {
                Docking = Docking.Bottom,
                Alignment = System.Drawing.StringAlignment.Center,
                BorderWidth = 1,
                BorderColor = Color.Black
            });

            foreach (var benchmark in benchmarks)
            {
                chart.Series.Add(benchmark.Name);
                chart.Series[benchmark.Name].ChartType = SeriesChartType.StackedBar;
            }

            var containers = benchmarkResults
                .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                .Select(r => r.Container)
                .Distinct()
                .Select(c => new
                    {
                        Container = c,
                        TotalTime = benchmarkResults.Where(b => b.Container == c).Sum(b => b.Time)
                    })
                .Where(r => r.TotalTime.HasValue && r.TotalTime.Value <= maxTime && r.TotalTime.Value > minTime)
                .OrderByDescending(r => r.TotalTime.Value)
                .Select(r => r.Container)
                .Concat(benchmarkResults.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))).Select(r => r.Container).Distinct());

            foreach (var container in containers)
            {
                foreach (var benchmark in benchmarks)
                {
                    var time = benchmarkResults.First(r => r.Benchmark == benchmark && r.Container == container).Time;

                    chart.Series[benchmark.Name].Points.AddXY(container.Name, time.GetValueOrDefault());
                }
            }

            chart.SaveImage("output\\Overview_" + type + ".png", ChartImageFormat.Png);
        }

        private static void CreateChart(string name, string filename, IEnumerable<Tuple<string, double>> values)
        {
            if (!values.Any())
            {
                return;
            }

            Chart chart = new Chart()
            {
                Size = new Size(800, 600),
                Palette = ChartColorPalette.Pastel,
                BorderlineColor = Color.Black,
                BorderlineWidth = 1,
                BorderColor = Color.Black,
                BorderDashStyle = ChartDashStyle.Solid,
            };

            chart.Titles.Add(name);
            chart.ChartAreas.Add("Default");

            chart.Series.Add("Series1");
            chart.Series["Series1"].ChartType = SeriesChartType.Bar;
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.IsLogarithmic = true;

            foreach (var value in values)
            {
                chart.Series["Series1"].Points.AddXY(value.Item1, value.Item2);
            }

            chart.SaveImage(filename, ChartImageFormat.Png);
        }
    }
}
