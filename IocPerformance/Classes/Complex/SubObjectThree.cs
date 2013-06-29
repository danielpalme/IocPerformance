using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISubObjectThree
	{
		
	}

	public class SubObjectThree : ISubObjectThree
	{
		public SubObjectThree(IThirdService thirdService)
		{
			if (thirdService == null)
			{
				throw new ArgumentNullException("thirdService");
			}
		}
	}
}
