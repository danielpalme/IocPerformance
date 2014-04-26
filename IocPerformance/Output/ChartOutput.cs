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
                    string.Format("output\\{0:00}-{1}.png", ++counter, benchmark.Name),
                    resultsOfBenchmark
                        .Where(r => r.Time.HasValue)
                        .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                        .OrderByDescending(r => r.Time.Value)
                        .Concat(resultsOfBenchmark.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))))
                        .Select(r => new Tuple<string, double>(r.Container.Name, r.Time.Value)));
            }

            // Blog images
            File.Copy("output\\01-Singleton.png", "output\\41fb475d-167c-43e0-83bf-42a051d5ec72.png", true);
            File.Copy("output\\02-Transient.png", "output\\fb72e35e-db43-443a-89c2-f977799241b8.png", true);
            File.Copy("output\\03-Combined.png", "output\\b837914c-8bec-4f15-b8d1-493affd7ebb8.png", true);

            CreateOverviewChart(benchmarks, benchmarkResults, "Basic");
            CreateOverviewChart(benchmarks, benchmarkResults, "Advanced");
        }

        private static void CreateOverviewChart(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults, string type)
        {
            Chart chart = new Chart()
            {
                Size = new Size(800, 600),
                Palette = ChartColorPalette.Pastel,
            };

            chart.ChartAreas.Add("Default");
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.IsLogarithmic = true;
            chart.Legends.Add(new Legend("Default")
            { 
                Docking = Docking.Bottom,
                Alignment = System.Drawing.StringAlignment.Center,
                BorderWidth = 1,
                BorderColor = Color.Black
            });

            foreach (var benchmark in benchmarks.Where(b => b.GetType().FullName.Contains(type)))
            {
                chart.Series.Add(benchmark.Name);
                chart.Series[benchmark.Name].ChartType = SeriesChartType.StackedBar;
            }

            var containers = benchmarkResults
                .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                .Select(r => r.Container)
                .Distinct()
                .OrderByDescending(c => c.Name)
                .Concat(benchmarkResults.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))).Select(r => r.Container).Distinct());

            foreach (var container in containers)
            {
                foreach (var benchmark in benchmarks.Where(b => b.GetType().FullName.Contains(type)))
                {
                    var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);
                    var time = resultsOfBenchmark.First(r => r.Container == container).Time;

                    chart.Series[benchmark.Name].Points.AddXY(container.Name, time.GetValueOrDefault());
                }
            }

            chart.SaveImage("output\\Overview_" + type + ".png", ChartImageFormat.Png);
        }

        private static void CreateChart(string filename, IEnumerable<Tuple<string, double>> values)
        {
            if (!values.Any())
            {
                return;
            }

            Chart chart = new Chart()
            {
                Size = new Size(800, 600),
                Palette = ChartColorPalette.Pastel,
            };

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
