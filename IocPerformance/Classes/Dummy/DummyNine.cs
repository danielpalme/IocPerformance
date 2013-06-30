using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Dummy
{
	public interface IDummyNine
	{
		
	}

	[Export(typeof(IDummyNine)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class DummyNine : IDummyNine
	{
	}
}
