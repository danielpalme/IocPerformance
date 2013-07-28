using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
	public interface IServiceA
	{
		
	}

	[MEFAttr.ExportAttribute(typeof(IServiceA))]
	[MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
	public class ServiceA : IServiceA
	{
	}
}
