using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Standard
{
	public interface ISingleton
	{
		void DoSomething();
	}

	[Export(typeof(ISingleton)), PartCreationPolicy(CreationPolicy.Shared)]
	public class Singleton : ISingleton
	{
		public static int Instances { get; set; }

		public Singleton()
		{
			Instances++;
		}

		public void DoSomething()
		{
			Console.WriteLine("Hello");
		}
	}
}
