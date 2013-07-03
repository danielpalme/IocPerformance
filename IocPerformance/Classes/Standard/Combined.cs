using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Standard
{

	public interface ICombined
	{
		void DoSomething();
	}

	[Export(typeof(ICombined)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class Combined : ICombined
	{
		public static int Instances { get; set; }

		[ImportingConstructor]
		public Combined(ISingleton first, ITransient second)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}

			if (second == null)
			{
				throw new ArgumentNullException("second");
			}

			Instances++;
		}

		public void DoSomething()
		{
			Console.WriteLine("Combined");
		}
	}


}
