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
                    writer.WriteLine("");
                    writer.WriteLine("Source code of my performance comparison of the most popular .NET IoC containers:  ");
                    writer.WriteLine("[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)");
                    writer.WriteLine("");
                    writer.WriteLine("Author: Daniel Palme  ");
                    writer.WriteLine("Blog: [www.palmmedia.de](http://www.palmmedia.de)  ");
                    writer.WriteLine("Twitter: [@danielpalme](http://twitter.com/danielpalme)  ");
                    writer.WriteLine("");
                    writer.WriteLine("Results");
                    writer.WriteLine("-------");
                    writer.WriteLine("<table>");

                    writer.WriteLine("<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Interception</th></tr>");

                    foreach (var result in this.results)
                    {
                        writer.WriteLine(
                            "<tr><th>{0}{1}{2}</th><t{3}>{4}</t{3}><t{5}>{6}</t{5}><t{7}>{8}</t{7}><t{9}>{10}</t{9}></tr>",
                            result.Name,
                            result.Version == null ? string.Empty : " ",
                            result.Version,
                            result.SingletonTime == results.Skip(1).Min(r => r.SingletonTime) ? "h" : "d",
                            result.SingletonTime,
                            result.TransientTime == results.Skip(1).Min(r => r.TransientTime) ? "h" : "d",
                            result.TransientTime,
                            result.CombinedTime == results.Skip(1).Min(r => r.CombinedTime) ? "h" : "d",
                            result.CombinedTime,
                            result.InterceptionTime == results.Skip(1).Min(r => r.InterceptionTime) ? "h" : "d",
                            result.InterceptionTime);
                    }

                    writer.WriteLine("</table>");
                }
            }
        }
    }
}
