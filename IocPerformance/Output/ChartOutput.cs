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

                this.CreateChart(
                    string.Format("output\\{0:00}-{1}.png", ++counter, benchmark.Name),
                    resultsOfBenchmark
                        .Where(r => r.Time.HasValue)
                        .Where(r => !r.Container.GetType().Equals(typeof(NoContainerAdapter)))
                        .Skip(1)
                        .OrderByDescending(r => r.Time.Value)
                        .Concat(resultsOfBenchmark.Where(r => r.Container.GetType().Equals(typeof(NoContainerAdapter))))
                        .Select(r => new Tuple<string, double>(r.Container.Name, r.Time.Value)));
            }

            // Blog images
            File.Copy("output\\01-Singleton.png", "output\\41fb475d-167c-43e0-83bf-42a051d5ec72.png", true);
            File.Copy("output\\02-Transient.png", "output\\fb72e35e-db43-443a-89c2-f977799241b8.png", true);
            File.Copy("output\\03-Combined.png", "output\\b837914c-8bec-4f15-b8d1-493affd7ebb8.png", true);
        }

        private void CreateChart(string filename, IEnumerable<Tuple<string, double>> values)
        {
            if (!values.Any())
            {
                return;
            }

            Chart singletonChart = new Chart()
            {
                Size = new Size(800, 600),
                Palette = ChartColorPalette.Pastel,
            };

            singletonChart.ChartAreas.Add("Series1");

            singletonChart.Series.Add("Series1");
            singletonChart.Series["Series1"].ChartType = SeriesChartType.Bar;
            singletonChart.ChartAreas[0].AxisX.Interval = 1;
            singletonChart.ChartAreas[0].AxisY.IsLogarithmic = true;

            foreach (var value in values)
            {
                singletonChart.Series["Series1"].Points.AddXY(value.Item1, value.Item2);
            }

            singletonChart.SaveImage(filename, ChartImageFormat.Png);
        }
    }
}
