using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace IocPerformance.Classes.Conditions
{
	public class ImportConditionObject
	{
		public static int Instances { get; set; }

		public ImportConditionObject(IExportConditionInterface exportConditionInterface)
		{
			if (exportConditionInterface == null)
			{
				throw new ArgumentNullException("exportConditionInterface");
			}

			if (exportConditionInterface.GetType() != typeof(ExportConditionalObject))
			{
				throw new ArgumentException(
								"Should have imported ExportConditionalObject got: " + 
									exportConditionInterface.GetType().FullName, "exportConditionInterface");
			}

			Instances++;
		}
	}
}
