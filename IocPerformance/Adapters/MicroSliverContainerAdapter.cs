using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using MicroSliver;

namespace IocPerformance.Adapters
{
    public sealed class MicroSliverContainerAdapter : ContainerAdapterBase
    {
        private IoC container;

        public override string PackageName
        {
            get { return "MicroSliver"; }
        }

        public override void Prepare()
        {
	        this.container = new IoC();

	        RegisterDummies();

	        RegisterStandard();

	        RegisterComplex();
        }

	    private void RegisterComplex()
	    {
		    container.Map<IFirstService,FirstService>().ToSingletonScope();
			 container.Map<ISecondService,SecondService>().ToSingletonScope();
			 container.Map<IThirdService,ThirdService>().ToSingletonScope();
			 container.Map<ISubObjectOne,SubObjectOne>();
			 container.Map<ISubObjectTwo,SubObjectTwo>();
			 container.Map<ISubObjectThree,SubObjectThree>();
		    container.Map<IComplex, Complex>();
	    }

	    private void RegisterDummies()
	    {
		    container.Map<IDummyOne, DummyOne>();
		    container.Map<IDummyTwo, DummyTwo>();
		    container.Map<IDummyThree, DummyThree>();
		    container.Map<IDummyFour, DummyFour>();
		    container.Map<IDummyFive, DummyFive>();
		    container.Map<IDummySix, DummySix>();
		    container.Map<IDummySeven, DummySeven>();
		    container.Map<IDummyEight, DummyEight>();
		    container.Map<IDummyNine, DummyNine>();
		    container.Map<IDummyTen, DummyTen>();
	    }

	    private void RegisterStandard()
	    {
		    this.container.Map<ISingleton, Singleton>().ToSingletonScope();
		    this.container.Map<ITransient, Transient>();
		    this.container.Map<ICombined, Combined>();
	    }

	    public override object Resolve(Type type)
        {
            return this.container.GetByType(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}