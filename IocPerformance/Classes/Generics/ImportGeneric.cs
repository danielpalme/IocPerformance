using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace IocPerformance.Classes.Generics
{
	[Export(typeof(ImportGeneric<>)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class ImportGeneric<T>
	{
		public static int Instances { get; set; }

		[ImportingConstructor]
		public ImportGeneric(IGenericInterface<T> importGenericInterface)
		{
			if (importGenericInterface == null)
			{
				throw new ArgumentNullException("importGenericInterface");
			}

			Instances++;
		}
	}
}
