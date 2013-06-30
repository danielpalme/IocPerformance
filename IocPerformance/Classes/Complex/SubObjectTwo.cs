using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISubObjectTwo
	{
		
	}

	[Export(typeof(ISubObjectTwo)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class SubObjectTwo : ISubObjectTwo
	{
		[ImportingConstructor]
		public SubObjectTwo(ISecondService secondService)
		{
			if (secondService == null)
			{
				throw new ArgumentNullException("secondService");
			}
		}
	}
}
