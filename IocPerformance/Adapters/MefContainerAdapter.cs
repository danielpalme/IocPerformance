using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class MefContainerAdapter : ContainerAdapterBase
	{
		private CompositionContainer container;

		public override string PackageName
		{
			get { return "Mef"; }
		}

		public override bool SupportsMultiple
		{
			get
			{
				return true;
			}
		}

		public override bool SupportGeneric
		{
			get
			{
				return true;
			}
		}

		public override string Version
		{
			get { return typeof(CompositionContainer).Assembly.GetName().Version.ToString(); }
		}

		public override void Prepare()
		{
			var dummyCatalog = new TypeCatalog(typeof(DummyOne),
			                                   typeof(DummyTwo),
			                                   typeof(DummyThree),
			                                   typeof(DummyFour),
			                                   typeof(DummyFive),
			                                   typeof(DummySix),
			                                   typeof(DummySeven),
			                                   typeof(DummyEight),
			                                   typeof(DummyNine),
			                                   typeof(DummyTen));

			var standardCatalog = new TypeCatalog(typeof(Singleton), typeof(Transient), typeof(Combined));

			var complexCatalog = new TypeCatalog(typeof(FirstService),
			                              typeof(SecondService),
			                              typeof(ThirdService),
			                              typeof(SubObjectOne),
			                              typeof(SubObjectTwo),
			                              typeof(SubObjectThree), 
													typeof(Complex));

			var multipleCatalog = new TypeCatalog(typeof(SimpleAdapterOne),
			                                      typeof(SimpleAdapterTwo),
			                                      typeof(SimpleAdapterThree),
															  typeof(SimpleAdapterFour),
															  typeof(SimpleAdapterFive),
															  typeof(ImportMultiple));

			var openGenericCatalog = new TypeCatalog(typeof(ImportGeneric<>), typeof(GenericExport<>));

			container = new CompositionContainer(
				new AggregateCatalog(dummyCatalog, standardCatalog, complexCatalog, multipleCatalog, openGenericCatalog));
		}

		public override object Resolve(Type type)
		{
			return this.container.GetExports(type, null, null).First().Value;
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}
