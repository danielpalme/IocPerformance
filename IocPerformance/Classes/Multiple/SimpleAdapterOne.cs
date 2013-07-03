using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocPerformance.Classes.Complex;

namespace IocPerformance.Classes.Multiple
{
	[Export(typeof(ISimpleAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class SimpleAdapterOne : ISimpleAdapter
	{
	}
}
