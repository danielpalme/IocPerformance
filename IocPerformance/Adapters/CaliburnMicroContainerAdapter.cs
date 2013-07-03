using System;
using System.Collections.Generic;
using Caliburn.Micro;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
	public sealed class CaliburnMicroContainer : ContainerAdapterBase
	{
		private SimpleContainer container;

		public override string PackageName
		{
			get { return "Caliburn.Micro.Container"; }
		}

		public override bool SupportsMultiple
		{
			get
			{
				return true;
			}
		}

		public override void Prepare()
		{
			this.container = new SimpleContainer();

			RegisterDummies();

			RegisterStandard();

			RegisterComplex();

			RegisterMultiple();
		}

		private void RegisterDummies()
		{
			container.RegisterHandler(typeof(IDummyOne), null, ioc => new DummyOne());
			container.RegisterHandler(typeof(IDummyTwo), null, ioc => new DummyTwo());
			container.RegisterHandler(typeof(IDummyThree), null, ioc => new DummyThree());
			container.RegisterHandler(typeof(IDummyFour), null, ioc => new DummyFour());
			container.RegisterHandler(typeof(IDummyFive), null, ioc => new DummyFive());
			container.RegisterHandler(typeof(IDummySix), null, ioc => new DummySix());
			container.RegisterHandler(typeof(IDummySeven), null, ioc => new DummySeven());
			container.RegisterHandler(typeof(IDummyEight), null, ioc => new DummyEight());
			container.RegisterHandler(typeof(IDummyNine), null, ioc => new DummyNine());
			container.RegisterHandler(typeof(IDummyTen), null, ioc => new DummyTen());
		}

		private void RegisterStandard()
		{
			this.container.RegisterSingleton(typeof(ISingleton), null, typeof(Singleton));
			this.container.RegisterHandler(typeof(ITransient), null, (ioc) => new Transient());
			this.container.RegisterHandler(typeof(ICombined),
			                               null,
			                               (ioc) => new Combined(
				                                        (ISingleton)ioc.GetInstance(typeof(ISingleton), null),
				                                        (ITransient)ioc.GetInstance(typeof(ITransient), null)));
		}

		private void RegisterComplex()
		{
			container.RegisterSingleton(typeof(IFirstService), null, typeof(FirstService));
			container.RegisterSingleton(typeof(ISecondService), null, typeof(SecondService));
			container.RegisterSingleton(typeof(IThirdService), null, typeof(ThirdService));

			container.RegisterHandler(typeof(ISubObjectOne),
			                          null,
			                          (ioc) =>
			                          new SubObjectOne((IFirstService)ioc.GetInstance(typeof(IFirstService), null)));
			container.RegisterHandler(typeof(ISubObjectTwo),
			                          null,
			                          (ioc) =>
			                          new SubObjectTwo((ISecondService)ioc.GetInstance(typeof(ISecondService), null)));
			container.RegisterHandler(typeof(ISubObjectThree),
			                          null,
			                          (ioc) =>
			                          new SubObjectThree((IThirdService)ioc.GetInstance(typeof(IThirdService), null)));

			container.RegisterHandler(typeof(IComplex),
			                          null,
			                          (ioc) => new Complex(
				                                   (IFirstService)ioc.GetInstance(typeof(IFirstService), null),
				                                   (ISecondService)ioc.GetInstance(typeof(ISecondService), null),
				                                   (IThirdService)ioc.GetInstance(typeof(IThirdService), null),
				                                   (ISubObjectOne)ioc.GetInstance(typeof(ISubObjectOne), null),
				                                   (ISubObjectTwo)ioc.GetInstance(typeof(ISubObjectTwo), null),
				                                   (ISubObjectThree)ioc.GetInstance(typeof(ISubObjectThree), null)
				                                   ));
		}

		private void RegisterMultiple()
		{
			container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterOne());
			container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterTwo());
			container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterThree());
			container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterFour());
			container.RegisterHandler(typeof(ISimpleAdapter), null, ioc => new SimpleAdapterFive());

			container.RegisterHandler(typeof(ImportMultiple), null,
				ioc => new ImportMultiple(
					(IEnumerable<ISimpleAdapter>)ioc.GetInstance(typeof(IEnumerable<ISimpleAdapter>), null)));
		}


		public override object Resolve(Type type)
		{
			return this.container.GetInstance(type, null);
		}

		public override void Dispose()
		{
			// Allow the container and everything it references to be disposed.
			this.container = null;
		}
	}
}