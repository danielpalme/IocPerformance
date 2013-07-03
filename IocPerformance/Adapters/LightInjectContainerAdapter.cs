using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class LightInjectContainerAdapter : ContainerAdapterBase
    {
        private IServiceContainer container;

        public override string PackageName
        {
            get { return "LightInject"; }
        }

        public override void Prepare()
        {
	        this.container = new ServiceContainer();

	        RegisterDummies();

	        RegisterStandard();

	        RegisterComplex();
        }

	    private void RegisterComplex()
	    {
		    container.Register<IFirstService>(c => new FirstService(), new PerContainerLifetime());
			 container.Register<ISecondService>(c => new SecondService(),new PerContainerLifetime());
			 container.Register<IThirdService>(c => new ThirdService(),new PerContainerLifetime());
			 container.Register<ISubObjectOne>(c => new SubObjectOne(c.GetInstance<IFirstService>()),new PerRequestLifeTime());
			 container.Register<ISubObjectTwo>(c => new SubObjectTwo(c.GetInstance<ISecondService>()),new PerRequestLifeTime());
			 container.Register<ISubObjectThree>(c => new SubObjectThree(c.GetInstance<IThirdService>()), new PerRequestLifeTime());

			 container.Register<IComplex>(c => new Complex(c.GetInstance<IFirstService>(),
																		  c.GetInstance<ISecondService>(),
																		  c.GetInstance<IThirdService>(),
																		  c.GetInstance<ISubObjectOne>(),
																		  c.GetInstance<ISubObjectTwo>(),
																		  c.GetInstance<ISubObjectThree>()), new PerRequestLifeTime());
	    }

	    private void RegisterDummies()
	    {
			 container.Register<IDummyOne>(c => new DummyOne(), new PerRequestLifeTime());
			 container.Register<IDummyTwo>(c => new DummyTwo(),new PerRequestLifeTime());
			 container.Register<IDummyThree>(c => new DummyThree(),new PerRequestLifeTime());
			 container.Register<IDummyFour>(c => new DummyFour(),new PerRequestLifeTime());
			 container.Register<IDummyFive>(c => new DummyFive(),new PerRequestLifeTime());
			 container.Register<IDummySix>(c => new DummySix(),new PerRequestLifeTime());
			 container.Register<IDummySeven>(c => new DummySeven(),new PerRequestLifeTime());
			 container.Register<IDummyEight>(c => new DummyEight(),new PerRequestLifeTime());
			 container.Register<IDummyNine>(c => new DummyNine(),new PerRequestLifeTime());
			 container.Register<IDummyTen>(c => new DummyTen(),new PerRequestLifeTime());
	    }

	    private void RegisterStandard()
	    {
		    container.Register<ISingleton>(c => new Singleton(), new PerContainerLifetime());
		    container.Register<ITransient>(c => new Transient(), new PerRequestLifeTime());
		    container.Register<ICombined>(c => new Combined(c.GetInstance<ISingleton>(), c.GetInstance<ITransient>()),
		                                  new PerRequestLifeTime());
	    }

	    public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}