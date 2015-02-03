﻿using System;
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
        /// <summary>
        /// Creates the specified benchmarks.
        /// </summary>
        /// <param name="benchmarks">The benchmarks.</param>
        /// <param name="benchmarkResults">The benchmark results.</param>
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            int counter = 0;

            foreach (var benchmark in benchmarks)
            {
                var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);

                CreateBenchmarkChart(
                    benchmark.Name,
                    string.Format("output\\{0:00}-{1}.png", ++counter, benchmark.Name),
                    resultsOfBenchmark
                        .Where(r => r.SingleThreadedResult.Time.HasValue)
                        .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                        .OrderByDescending(r => r.SingleThreadedResult.Time.Value)
                        .Concat(resultsOfBenchmark.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))))
                        .Select(r => r));
            }

            CreateOverviewChart(benchmarks, benchmarkResults, "Registration", 0, long.MaxValue);
            CreateOverviewChart(benchmarks, benchmarkResults, "Basic", 0, 6000);
            CreateOverviewChart(benchmarks, benchmarkResults, "Basic", 6000, long.MaxValue);
            CreateOverviewChart(benchmarks, benchmarkResults, "Basic", 0, long.MaxValue);
            CreateOverviewChart(benchmarks, benchmarkResults, "Advanced", 0, 25000);
            CreateOverviewChart(benchmarks, benchmarkResults, "Advanced", 25000, long.MaxValue);
            CreateOverviewChart(benchmarks, benchmarkResults, "Advanced", 0, long.MaxValue);

            // Blog images
            if (!Directory.Exists("output\\blog"))
            {
                Directory.CreateDirectory("output\\blog");
            }

            File.Copy("output\\Overview_Basic_Fast.png", "output\\blog\\5225c515-2f25-498f-84fe-6c6e931d2042.png", true);
            File.Copy("output\\Overview_Advanced_Fast.png", "output\\blog\\e0401485-20c6-462e-b5d4-c9cf854e6bee.png", true);
        }

        private static void CreateOverviewChart(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults, string type, long minTime, long maxTime)
        {
            var filteredBenchmarkResults = benchmarkResults.Where(b => b.Benchmark.GetType().FullName.Contains(type)).ToArray();
            var filteredBenchmarks = benchmarks.Where(b => b.GetType().FullName.Contains(type)).ToArray();

            Chart chart = new Chart()
            {
                Size = new Size(800, 600),
                Palette = ChartColorPalette.Pastel,
                BorderlineColor = Color.Black,
                BorderlineWidth = 1,
                BorderColor = Color.Black,
                BorderDashStyle = ChartDashStyle.Solid,
            };

            if (minTime == 0 && maxTime == long.MaxValue)
            {
                chart.Titles.Add("Overview '" + type + "' (all)");
                type += "_All";
            }
            else if (minTime == 0)
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
                Alignment = StringAlignment.Center,
                BorderWidth = 1,
                BorderColor = Color.Black
            });

            foreach (var benchmark in filteredBenchmarks)
            {
                chart.Series.Add(benchmark.Name);
                chart.Series[benchmark.Name].ChartType = SeriesChartType.StackedBar;
            }

            var containers = filteredBenchmarkResults
                .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                .Select(r => r.Container)
                .Distinct()
                .Select(c => new
                    {
                        Container = c,
                        TotalTime = filteredBenchmarkResults.Where(b => b.Container == c).Sum(b => b.SingleThreadedResult.Time)
                    })
                .Where(r => r.TotalTime.HasValue && r.TotalTime.Value <= maxTime && r.TotalTime.Value > minTime)
                .OrderByDescending(r => r.TotalTime.Value)
                .Select(r => r.Container)
                .Concat(filteredBenchmarkResults.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))).Select(r => r.Container).Distinct());

            foreach (var container in containers)
            {
                foreach (var benchmark in filteredBenchmarks)
                {
                    var time = filteredBenchmarkResults.First(r => r.Benchmark == benchmark && r.Container == container).SingleThreadedResult.Time;

                    chart.Series[benchmark.Name].Points.AddXY(container.Name, time.GetValueOrDefault());
                }
            }

            chart.SaveImage("output\\Overview_" + type + ".png", ChartImageFormat.Png);
        }

        private static void CreateBenchmarkChart(string name, string filename, IEnumerable<BenchmarkResult> results)
        {
            const bool useLogarithmicChart = false;

            if (!results.Any())
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

            chart.Series.Add("Single thread");
            chart.Series["Single thread"].ChartType = SeriesChartType.Bar;

            chart.Series.Add("Multiple threads");
            chart.Series["Multiple threads"].ChartType = SeriesChartType.Bar;

            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.IsLogarithmic = useLogarithmicChart;

            chart.Legends.Add(new Legend("Default")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                BorderWidth = 1,
                BorderColor = Color.Black
            });

            foreach (var result in results)
            {
                var stTime = Math.Max(result.SingleThreadedResult.Time.GetValueOrDefault(1), 1);
                var mtTime = Math.Max(result.MultiThreadedResult.Time.GetValueOrDefault(1), 1);
                chart.Series["Single thread"].Points.AddXY(result.Container.Name, stTime);
                chart.Series["Multiple threads"].Points.AddXY(result.Container.Name, mtTime);
            }

            chart.SaveImage(filename, ChartImageFormat.Png);
        }
    }
}
