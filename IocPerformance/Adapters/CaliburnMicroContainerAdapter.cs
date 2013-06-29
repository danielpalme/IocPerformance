using System;
using Caliburn.Micro;
using IocPerformance.Classes.Complex;
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

		public override void Prepare()
		{
			this.container = new SimpleContainer();

			this.container.RegisterSingleton(typeof(ISingleton), null, typeof(Singleton));
			this.container.RegisterHandler(typeof(ITransient), null, (ioc) => new Transient());
			this.container.RegisterHandler(typeof(ICombined), null, (ioc) => new Combined(
				 (ISingleton)ioc.GetInstance(typeof(ISingleton), null),
				 (ITransient)ioc.GetInstance(typeof(ITransient), null)));

			container.RegisterSingleton(typeof(IFirstService), null, typeof(FirstService));
			container.RegisterSingleton(typeof(ISecondService), null, typeof(SecondService));
			container.RegisterSingleton(typeof(IThirdService), null, typeof(ThirdService));

			container.RegisterHandler(typeof(ISubObjectOne), null, (ioc) =>
				new SubObjectOne((IFirstService)ioc.GetInstance(typeof(IFirstService), null)));
			container.RegisterHandler(typeof(ISubObjectTwo), null, (ioc) =>
				new SubObjectTwo((ISecondService)ioc.GetInstance(typeof(ISecondService), null)));
			container.RegisterHandler(typeof(ISubObjectThree), null, (ioc) =>
				new SubObjectThree((IThirdService)ioc.GetInstance(typeof(IThirdService), null)));

			container.RegisterHandler(typeof(IComplex), null, 
				(ioc) => new Complex(
								(IFirstService)ioc.GetInstance(typeof(IFirstService), null), 
								(ISecondService)ioc.GetInstance(typeof(ISecondService), null),
								(IThirdService)ioc.GetInstance(typeof(IThirdService), null),
								(ISubObjectOne)ioc.GetInstance(typeof(ISubObjectOne), null),
								(ISubObjectTwo)ioc.GetInstance(typeof(ISubObjectTwo), null),
								(ISubObjectThree)ioc.GetInstance(typeof(ISubObjectThree), null)
								));
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