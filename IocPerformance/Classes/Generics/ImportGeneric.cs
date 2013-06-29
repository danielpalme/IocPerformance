using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using StyleMVVM.DependencyInjection;

namespace IocPerformance.Classes.Generics
{
	[Export(typeof(ImportGeneric<>))]
	public class ImportGeneric<T>
	{
		public static int Instances { get; set; }

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
