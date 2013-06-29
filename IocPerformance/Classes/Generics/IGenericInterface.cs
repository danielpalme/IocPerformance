using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Generics
{
	public interface IGenericInterface<T>
	{
		T Value { get; set; }
	}
}
