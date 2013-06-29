using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Standard
{

	public interface ITransient
	{
		void DoSomething();
	}

	[Export(typeof(ITransient)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class Transient : ITransient
	{
		public static int Instances { get; set; }

		public Transient()
		{
			Instances++;
		}

		public void DoSomething()
		{
			Console.WriteLine("World");
		}
	}
}
