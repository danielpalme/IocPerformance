using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IocPerformance.Output
{
    public class MarkdownOutput : IOutput
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
                    writer.WriteLine("<table>");

                    writer.WriteLine("<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Complex</th></tr>");

                    foreach (var result in this.results)
                    {
                        writer.WriteLine(
                            "<tr><th>{0}{1}{2}</th><t{3}>{4}</t{3}><t{5}>{6}</t{5}><t{7}>{8}</t{7}><t{9}>{10}</t{9}></tr>",
                            result.Name,
                            string.IsNullOrEmpty(result.Version) ? string.Empty : " ",
                            result.Version,
                            result.SingletonTime == this.results.Skip(1).Min(r => r.SingletonTime) ? "h" : "d",
                            result.SingletonTime,
                            result.TransientTime == this.results.Skip(1).Min(r => r.TransientTime) ? "h" : "d",
                            result.TransientTime,
                            result.CombinedTime == this.results.Skip(1).Min(r => r.CombinedTime) ? "h" : "d",
                            result.CombinedTime,
                            result.ComplexTime == this.results.Skip(1).Min(r => r.ComplexTime) ? "h" : "d",
                            result.ComplexTime);
                    }

                    writer.WriteLine("</table>");
                    writer.WriteLine("Advanced Features");
                    writer.WriteLine("<table>");
						  writer.WriteLine("<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>");

                    foreach (var result in this.results)
                    {
                        writer.WriteLine(
                            "<tr><th>{0}{1}{2}</th><t{3}>{4}</t{3}><t{5}>{6}</t{5}><t{7}>{8}</t{7}><t{9}>{10}</t{9}></tr>",
                            result.Name,
                            result.Version == null ? string.Empty : " ",
									 result.Version,
									 result.PropertyInjectionTime == this.results.Skip(1).Min(r => r.PropertyInjectionTime) ? "h" : "d",
									 result.PropertyInjectionTime,
                            result.GenericTime == this.results.Skip(1).Min(r => r.GenericTime) ? "h" : "d",
                            result.GenericTime,
                            result.MultipleImport == this.results.Skip(1).Min(r => r.MultipleImport) ? "h" : "d",
                            result.MultipleImport,
                            result.ConditionalTime == this.results.Skip(1).Min(r => r.ConditionalTime) ? "h" : "d",
                            result.ConditionalTime,
                            result.InterceptionTime == this.results.Skip(1).Min(r => r.InterceptionTime) ? "h" : "d",
                            result.InterceptionTime);
                    }

                    writer.WriteLine("</table>");
                }
            }
        }
    }
}
