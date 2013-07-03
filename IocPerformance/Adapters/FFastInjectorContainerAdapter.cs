using System;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using fFastInjector;

namespace IocPerformance.Adapters
{
    public sealed class FFastInjectorContainerAdapter : ContainerAdapterBase
    {
		 public override string PackageName
        {
            get { return "fFastInjector"; }
        }

        public override void Prepare()
        {
	        RegisterDummies();

	        RegisterStandard();

	        RegisterComplex();
        }

	    private void RegisterDummies()
	    {
		    Injector.SetResolver<IDummyOne, DummyOne>();
		    Injector.SetResolver<IDummyTwo, DummyTwo>();
		    Injector.SetResolver<IDummyThree, DummyThree>();
		    Injector.SetResolver<IDummyFour, DummyFour>();
		    Injector.SetResolver<IDummyFive, DummyFive>();
		    Injector.SetResolver<IDummySix, DummySix>();
		    Injector.SetResolver<IDummySeven, DummySeven>();
		    Injector.SetResolver<IDummyEight, DummyEight>();
		    Injector.SetResolver<IDummyNine, DummyNine>();
		    Injector.SetResolver<IDummyTen, DummyTen>();
	    }

	    private void RegisterComplex()
	    {
		    var firstService = new FirstService();
		    var secondService = new SecondService();
		    var thirdService = new ThirdService();

		    Injector.SetResolver<IFirstService>(() => firstService);
		    Injector.SetResolver<ISecondService>(() => secondService);
		    Injector.SetResolver<IThirdService>(() => thirdService);
		    Injector.SetResolver<ISubObjectOne, SubObjectOne>();
		    Injector.SetResolver<ISubObjectTwo, SubObjectTwo>();
		    Injector.SetResolver<ISubObjectThree, SubObjectThree>();
			 
		    Injector.SetResolver<IComplex, Complex>();
	    }

	    private static void RegisterStandard()
	    {
		    var singleton = new Singleton();

		    Injector.SetResolver<ISingleton>(() => singleton);
		    Injector.SetResolver<ITransient, Transient>();
		    Injector.SetResolver<ICombined, Combined>();
	    }

	    public override object Resolve(Type type)
        {
            return Injector.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
        }
    }
}