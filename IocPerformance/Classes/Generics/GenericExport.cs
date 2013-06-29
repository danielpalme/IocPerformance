using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyleMVVM.DependencyInjection;

namespace IocPerformance.Classes.Generics
{
	[Export(typeof(IGenericInterface<>))]
	public class GenericExport<T> : IGenericInterface<T>
	{
		public T Value { get; set; }
	}
}
