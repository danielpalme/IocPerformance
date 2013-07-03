using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISubObjectOne
	{
		
	}
	[Export(typeof(ISubObjectOne)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class SubObjectOne : ISubObjectOne
	{
		[ImportingConstructor]
		public SubObjectOne(IFirstService firstService)
		{
			if (firstService == null)
			{
				throw new ArgumentNullException("firstService");
			}
		}
	}
}
