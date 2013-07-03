using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface ISecondService
	{
		
	}

	[Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
	public class SecondService : ISecondService
	{
	}
}
