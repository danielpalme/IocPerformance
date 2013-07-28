using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace IocPerformance.Output
{
    public class ChartOutput : IOutput
    {
        private readonly List<Result> results = new List<Result>();

        public void Start()
        {
        }

        public void Result(Result result)
        {
            this.results.Add(result);
        }

        public void Finish()
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            this.CreateChart(
                "output\\01-Singleton.png",
                this.results.AsEnumerable()
                .Skip(1)
                .OrderByDescending(r => r.SingletonTime)
                .Concat(this.results.Take(1))
                .Select(r => new Tuple<string, double>(r.Name, r.SingletonTime)));
            this.CreateChart(
                "output\\02-Transient.png",
                this.results.AsEnumerable()
                .Skip(1)
                .OrderByDescending(r => r.TransientTime)
                .Concat(this.results.Take(1))
                .Select(r => new Tuple<string, double>(r.Name, r.TransientTime)));
            this.CreateChart(
                "output\\03-Combined.png",
                this.results.AsEnumerable()
                .Skip(1)
                .OrderByDescending(r => r.CombinedTime)
                .Concat(this.results.Take(1))
                .Select(r => new Tuple<string, double>(r.Name, r.CombinedTime)));
            this.CreateChart(
                "output\\04-Complex.png",
                this.results.AsEnumerable()
                .Skip(1)
                .OrderByDescending(r => r.ComplexTime)
                .Concat(this.results.Take(1))
                .Select(r => new Tuple<string, double>(r.Name, r.ComplexTime)));
				this.CreateChart(
					 "output\\05-Property.png",
					 this.results.AsEnumerable()
					 .Skip(1)
					 .Where(r => r.PropertyInjectionTime.HasValue)
					 .OrderByDescending(r => r.PropertyInjectionTime.Value)
					 .Select(r => new Tuple<string, double>(r.Name, r.PropertyInjectionTime.Value)));
            this.CreateChart(
                "output\\06-Generic.png",
                this.results.AsEnumerable()
                .Skip(1)
                .Where(r => r.GenericTime.HasValue)
                .OrderByDescending(r => r.GenericTime.Value)
                .Select(r => new Tuple<string, double>(r.Name, r.GenericTime.Value)));
            this.CreateChart(
                "output\\07-IEnumerable.png",
                this.results.AsEnumerable()
                .Skip(1)
                .Where(r => r.MultipleImport.HasValue)
                .OrderByDescending(r => r.MultipleImport.Value)
                .Select(r => new Tuple<string, double>(r.Name, r.MultipleImport.Value)));
            this.CreateChart(
                "output\\08-Conditional.png",
                this.results.AsEnumerable()
                .Skip(1)
                .Where(r => r.ConditionalTime.HasValue)
                .OrderByDescending(r => r.ConditionalTime.Value)
                .Select(r => new Tuple<string, double>(r.Name, r.ConditionalTime.Value)));
            this.CreateChart(
                "output\\09-Interception.png",
                this.results.AsEnumerable()
                .Skip(1)
                .Where(r => r.InterceptionTime.HasValue)
                .OrderByDescending(r => r.InterceptionTime.Value)
                .Select(r => new Tuple<string, double>(r.Name, r.InterceptionTime.Value)));

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
