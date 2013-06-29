using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISubObjectTwo
	{
		
	}

	public class SubObjectTwo : ISubObjectTwo
	{
		public SubObjectTwo(ISecondService secondService)
		{
			if (secondService == null)
			{
				throw new ArgumentNullException("secondService");
			}
		}
	}
}
