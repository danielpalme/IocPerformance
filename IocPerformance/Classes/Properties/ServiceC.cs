using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
	public interface IServiceC
	{
		
	}

	[MEFAttr.ExportAttribute(typeof(IServiceC))]
	[MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
	public class ServiceC : IServiceC
	{
	}
}
