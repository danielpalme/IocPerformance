using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
	public interface IServiceB
	{
		
	}

	[MEFAttr.ExportAttribute(typeof(IServiceB))]
	[MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
	public class ServiceB : IServiceB
	{
	}
}
