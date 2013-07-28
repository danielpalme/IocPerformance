using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityAttr = Microsoft.Practices.Unity;
using MugenAttr = MugenInjection.Attributes;
using LinFuAttr = LinFu.IoC.Configuration;
using NinjectAttr = Ninject;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
	public interface ISubObjectC
	{
		void Verify(string containerName);
	}
	
	[LinFuAttr.Implements(typeof(ISubObjectA))]
	[MEFAttr.ExportAttribute(typeof(ISubObjectC))]
	[MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
	public class SubObjectC : ISubObjectC
	{
		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public IServiceC ServiceC { get; set; }

		public void Verify(string containerName)
		{
			if (ServiceC == null)
			{
				throw new Exception("ServiceC was null for SubObjectC for container " + containerName);
			}
		}
	}
}
