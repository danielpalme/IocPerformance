using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Multiple
{
	public class ImportMultiple
	{
		public static int Instances { get; set; }

		public ImportMultiple(ReadOnlyCollection<ISimpleAdapter> adapters)
		{
			if (adapters == null)
			{
				throw  new ArgumentNullException("adapters");
			}
			
			int adapterCount = adapters.Count();

			if (adapterCount != 5)
			{
				throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, "adapters");
			}

			Instances++;
		}
	}
}
