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
	public interface ISubObjectB
	{
		void Verify(string containerName);
	}

	[LinFuAttr.Implements(typeof(ISubObjectB))]
	[MEFAttr.ExportAttribute(typeof(ISubObjectB))]
	[MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
	public class SubObjectB : ISubObjectB
	{
		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public IServiceB ServiceB { get; set; }

		public void Verify(string containerName)
		{
			if (ServiceB == null)
			{
				throw new Exception("ServiceB was null for SubObjectC for container " + containerName);
			}
		}
	}
}
