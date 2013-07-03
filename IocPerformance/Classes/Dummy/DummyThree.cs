using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Dummy
{
	public interface IDummyThree
	{
		
	}

	[Export(typeof(IDummyThree)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class DummyThree : IDummyThree
	{
	}
}
