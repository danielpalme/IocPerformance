using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Generics
{
	[Export(typeof(IGenericInterface<>)),PartCreationPolicy(CreationPolicy.NonShared)]
	public class GenericExport<T> : IGenericInterface<T>
	{
		public T Value { get; set; }
	}
}
