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
	public interface IComplexPropertyObject
	{
		void Verify(string containerName);
	}

	[LinFuAttr.Implements(typeof(IComplexPropertyObject))]
	[MEFAttr.ExportAttribute(typeof(IComplexPropertyObject))]
	[MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
	public class ComplexPropertyObject : IComplexPropertyObject
	{

		public void Verify(string containerName)
		{
			if (ServiceA == null)
			{
				throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
			}

			if (ServiceB == null)
			{
				throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
			}

			if (ServiceC == null)
			{
				throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
			}

			if (SubObjectA == null)
			{
				throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
			}

			SubObjectA.Verify(containerName);

			if (SubObjectB == null)
			{
				throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
			}

			SubObjectB.Verify(containerName);

			if (SubObjectC == null)
			{
				throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
			}

			SubObjectC.Verify(containerName);
		}

		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public IServiceA ServiceA { get; set; }

		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public IServiceB ServiceB { get; set; }

		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public IServiceC ServiceC { get; set; }

		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public ISubObjectA SubObjectA { get; set; }

		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public ISubObjectB SubObjectB { get; set; }

		[MEFAttr.Import]
		[LinFuAttr.Inject]
		[MugenAttr.Inject]
		[NinjectAttr.Inject]
		[UnityAttr.Dependency]
		public ISubObjectC SubObjectC { get; set; }
	}
}
