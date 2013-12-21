using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.Child
{
	public class ScopedCombined : ICombined
	{
		public ScopedCombined(ITransient transient, ISingleton singleton)
		{
			if (transient == null)
			{
				throw new ArgumentNullException("transient");
			}

			if (singleton == null)
			{
				throw new ArgumentNullException("singleton");
			}

			if (!(transient is ScopedTransient))
			{
				throw new ArgumentException("transient should be of type ScopedTransient");
			}

			Instances++;
		}

		public static int Instances { get; set; }

		public void DoSomething()
		{
			Console.WriteLine("Combined");
		}
	}
}
