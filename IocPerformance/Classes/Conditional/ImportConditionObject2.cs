using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Conditions
{
	public class ImportConditionObject2
	{
		public static int Instances { get; set; }

		public ImportConditionObject2(IExportConditionInterface exportConditionInterface)
		{
			if (exportConditionInterface == null)
			{
				throw new ArgumentNullException("exportConditionInterface");
			}

			if (exportConditionInterface.GetType() != typeof(ExportConditionalObject2))
			{
				throw new ArgumentException(
								"Should have imported ExportConditionalObject2 got: " +
									exportConditionInterface.GetType().FullName, "exportConditionInterface");
			}

			Instances++;
		}
	}
}
