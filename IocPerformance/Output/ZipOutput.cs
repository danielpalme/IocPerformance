using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class ZipOutput : IOutput
    {
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output\\blog"))
            {
                Directory.CreateDirectory("output\\blog");
            }

            File.Delete("output\\blog\\Results.zip");

            using (ZipArchive archive = ZipFile.Open("output\\blog\\Results.zip", ZipArchiveMode.Create))
            {
                foreach (var file in new DirectoryInfo("output").EnumerateFiles())
                {
                    archive.CreateEntryFromFile(file.FullName, file.Name);
                }
            }

            File.Copy("output\\blog\\Results.zip", "output\\blog\\74215f6b-4885-46bb-8595-49d56381004e.zip", true);
        }
    }
}
