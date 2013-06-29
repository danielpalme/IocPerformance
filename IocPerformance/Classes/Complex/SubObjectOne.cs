using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISubObjectOne
	{
		
	}

	public class SubObjectOne : ISubObjectOne
	{
		public SubObjectOne(IFirstService firstService)
		{
			if (firstService == null)
			{
				throw new ArgumentNullException("firstService");
			}
		}
	}
}
