using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISubObjectThree
	{
		
	}


	[Export(typeof(ISubObjectThree)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class SubObjectThree : ISubObjectThree
	{
		[ImportingConstructor]
		public SubObjectThree(IThirdService thirdService)
		{
			if (thirdService == null)
			{
				throw new ArgumentNullException("thirdService");
			}
		}
	}
}
