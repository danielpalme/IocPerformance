using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface IFirstService
	{
		
	}


	[Export(typeof(IFirstService)), PartCreationPolicy(CreationPolicy.Shared)]
	public class FirstService : IFirstService
	{

	}
}
