using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Multiple
{
	[Export(typeof(ISimpleAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class SimpleAdapterThree : ISimpleAdapter
	{
	}
}
