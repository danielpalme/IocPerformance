using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using MugenInjection;

namespace IocPerformance.Adapters
{
    public sealed class MugenContainerAdapter : ContainerAdapterBase
    {
        private MugenInjector container;

        public override string PackageName
        {
            get { return "MugenInjection"; }
        }

        public override void Prepare()
        {
	        this.container = new MugenInjector();

	        RegisterDummies();

	        RegisterStandard();

	        RegisterComplex();
        }

	    private void RegisterComplex()
	    {
		    container.Bind<IFirstService>().To<FirstService>().InTransientScope();
		    container.Bind<ISecondService>().To<SecondService>().InTransientScope();
		    container.Bind<IThirdService>().To<ThirdService>().InTransientScope();
		    container.Bind<ISubObjectOne>().To<SubObjectOne>().InTransientScope();
		    container.Bind<ISubObjectTwo>().To<SubObjectTwo>().InTransientScope();
		    container.Bind<ISubObjectThree>().To<SubObjectThree>().InTransientScope();
		    container.Bind<IComplex>().To<Complex>().InTransientScope();
	    }

	    private void RegisterDummies()
	    {
			 container.Bind<IDummyOne>().To<DummyOne>().InTransientScope();
			 container.Bind<IDummyTwo>().To<DummyTwo>().InTransientScope();
			 container.Bind<IDummyThree>().To<DummyThree>().InTransientScope();
			 container.Bind<IDummyFour>().To<DummyFour>().InTransientScope();
			 container.Bind<IDummyFive>().To<DummyFive>().InTransientScope();
			 container.Bind<IDummySix>().To<DummySix>().InTransientScope();
			 container.Bind<IDummySeven>().To<DummySeven>().InTransientScope();
			 container.Bind<IDummyEight>().To<DummyEight>().InTransientScope();
			 container.Bind<IDummyNine>().To<DummyNine>().InTransientScope();
			 container.Bind<IDummyTen>().To<DummyTen>().InTransientScope();
	    }

	    private void RegisterStandard()
	    {
		    this.container.Bind<ISingleton>().To<Singleton>().InSingletonScope();
		    this.container.Bind<ITransient>().To<Transient>().InTransientScope();
		    this.container.Bind<ICombined>().To<Combined>().InTransientScope();
	    }

	    public override object Resolve(Type type)
        {
            return this.container.Get(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}