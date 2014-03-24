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

                    writer.WriteLine("|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|");
                    writer.WriteLine("|:------------|------------:|------------:|-----------:|----------:|");

                    foreach (var result in this.results)
                    {
                        writer.WriteLine(
                            "|**{0}**|{1}{2}{1}|{3}{4}{3}|{5}{6}{5}|{7}{8}{7}|",
                            GetName(result),
                            result.SingletonTime == this.results.Skip(1).Min(r => r.SingletonTime) ? "**" : string.Empty,
                            result.SingletonTime,
                            result.TransientTime == this.results.Skip(1).Min(r => r.TransientTime) ? "**" : string.Empty,
                            result.TransientTime,
                            result.CombinedTime == this.results.Skip(1).Min(r => r.CombinedTime) ? "**" : string.Empty,
                            result.CombinedTime,
                            result.ComplexTime == this.results.Skip(1).Min(r => r.ComplexTime) ? "**" : string.Empty,
                            result.ComplexTime);
                    }

                    writer.WriteLine(string.Empty);
                    writer.WriteLine("Advanced Features");
                    writer.WriteLine(string.Empty);
                    writer.WriteLine("|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception**|");
                    writer.WriteLine("|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|");

                    foreach (var result in this.results)
                    {
                        writer.WriteLine(
                            "|**{0}**|{1}{2}{1}|{3}{4}{3}|{5}{6}{5}|{7}{8}{7}|{9}{10}{9}|{11}{12}{11}|",
                            GetName(result),
                            result.PropertyInjectionTime == this.results.Skip(1).Min(r => r.PropertyInjectionTime) ? "**" : string.Empty,
                            result.PropertyInjectionTime,
                            result.GenericTime == this.results.Skip(1).Min(r => r.GenericTime) ? "**" : string.Empty,
                            result.GenericTime,
                            result.MultipleImport == this.results.Skip(1).Min(r => r.MultipleImport) ? "**" : string.Empty,
                            result.MultipleImport,
                            result.ConditionalTime == this.results.Skip(1).Min(r => r.ConditionalTime) ? "**" : string.Empty,
                            result.ConditionalTime,
                            result.ChildContainerTime == this.results.Skip(1).Min(r => r.ChildContainerTime) ? "**" : string.Empty,
                            result.ChildContainerTime,
                            result.InterceptionTime == this.results.Skip(1).Min(r => r.InterceptionTime) ? "**" : string.Empty,
                            result.InterceptionTime);
                    }
                }
            }
        }

        private static string GetName(Result result)
        {
            string name = string.Format(
                "{0}{1}{2}",
                result.Name,
                string.IsNullOrEmpty(result.Version) ? string.Empty : " ",
                result.Version);

            if (!string.IsNullOrEmpty(result.Url))
            {
                name = string.Format("[{0}]({1})", name, result.Url);
            }

            return name;
        }
    }
}
