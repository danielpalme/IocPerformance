using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Output
{
	public class CsvOutput : IOutput
	{
		private readonly List<Result> results = new List<Result>();

		public void Start()
		{
		}

		public void Result(Result result)
		{
			results.Add(result);
		}

		public void Finish()
		{
			if (!Directory.Exists("output"))
			{
				Directory.CreateDirectory("output");
			}

			using (var fileStream = new FileStream("output\\csv_output.csv", FileMode.Create))
			{
				using (var writer = new StreamWriter(fileStream))
				{
					writer.WriteLine("Container,Singleton,Transient,Combined,Complex,Generics,Conditional,Interception");

					foreach (Result result in results)
					{
						long genericTime = 0;
						long conditionalTime = 0;
						long interceptorTime = 0;

						if (result.GenericTime.HasValue)
						{
							genericTime = result.GenericTime.Value;
						}

						if (result.ConditionalTime.HasValue)
						{
							conditionalTime = result.ConditionalTime.Value;
						}

						if (result.InterceptionTime.HasValue)
						{
							interceptorTime = result.InterceptionTime.Value;
						}

						// write container name and resolve times
						writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", 
							result.Name, result.SingletonTime, result.TransientTime, result.CombinedTime, result.ComplexTime,
								genericTime,conditionalTime,interceptorTime);

					}
				}
			}
		}
	}
}
