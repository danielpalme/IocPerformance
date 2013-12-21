using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Adapters
{
    public sealed class AutofacContainerAdapter : ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName
        {
            get { return "Autofac"; }
        }

        public override string Url
        {
            get { return "http://code.google.com/p/autofac"; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override bool SupportGeneric
        {
            get { return true; }
        }

        public override bool SupportsMultiple
        {
            get { return true; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

	    public override bool SupportsChildContainer
	    {
		    get { return true; }
	    }

	    public override IChildContainerAdapter CreateChildContainerAdapter()
	    {
		    return new AutofacChildContainerAdapter(container.BeginLifetimeScope());
	    }

	    public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
			   this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

            RegisterDummies(autofacContainerBuilder);
            RegisterStandard(autofacContainerBuilder);
            RegisterComplexObject(autofacContainerBuilder);
            RegisterPropertyInjection(autofacContainerBuilder);
            RegisterOpenGeneric(autofacContainerBuilder);
            RegisterMultiple(autofacContainerBuilder);
            RegisterInterceptor(autofacContainerBuilder);

            this.container = autofacContainerBuilder.Build();
        }

        private static void RegisterDummies(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new DummyOne()).As<IDummyOne>();
            autofacContainerBuilder.Register(c => new DummyTwo()).As<IDummyTwo>();
            autofacContainerBuilder.Register(c => new DummyThree()).As<IDummyThree>();
            autofacContainerBuilder.Register(c => new DummyFour()).As<IDummyFour>();
            autofacContainerBuilder.Register(c => new DummyFive()).As<IDummyFive>();
            autofacContainerBuilder.Register(c => new DummySix()).As<IDummySix>();
            autofacContainerBuilder.Register(c => new DummySeven()).As<IDummySeven>();
            autofacContainerBuilder.Register(c => new DummyEight()).As<IDummyEight>();
            autofacContainerBuilder.Register(c => new DummyNine()).As<IDummyNine>();
            autofacContainerBuilder.Register(c => new DummyTen()).As<IDummyTen>();
        }

        private static void RegisterStandard(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Singleton())
                                          .As<ISingleton>()
                                          .SingleInstance();

            autofacContainerBuilder.Register(c => new Transient())
                                          .As<ITransient>();

            autofacContainerBuilder.Register(c => new Combined(c.Resolve<ISingleton>(), c.Resolve<ITransient>()))
                                          .As<ICombined>();
        }

        private static void RegisterComplexObject(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new FirstService()).As<IFirstService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SecondService()).As<ISecondService>().SingleInstance();
            autofacContainerBuilder.Register(c => new ThirdService()).As<IThirdService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SubObjectOne(c.Resolve<IFirstService>())).As<ISubObjectOne>();
            autofacContainerBuilder.Register(c => new SubObjectTwo(c.Resolve<ISecondService>())).As<ISubObjectTwo>();
            autofacContainerBuilder.Register(c => new SubObjectThree(c.Resolve<IThirdService>())).As<ISubObjectThree>();
            autofacContainerBuilder.Register(c => new Complex(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex>();
        }

        private static void RegisterPropertyInjection(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new ServiceA()).As<IServiceA>().SingleInstance();
            autofacContainerBuilder.Register(c => new ServiceB()).As<IServiceB>().SingleInstance();
            autofacContainerBuilder.Register(c => new ServiceC()).As<IServiceC>().SingleInstance();

            autofacContainerBuilder.Register(c => new SubObjectA { ServiceA = c.Resolve<IServiceA>() }).As<ISubObjectA>();
            autofacContainerBuilder.Register(c => new SubObjectB { ServiceB = c.Resolve<IServiceB>() }).As<ISubObjectB>();
            autofacContainerBuilder.Register(c => new SubObjectC { ServiceC = c.Resolve<IServiceC>() }).As<ISubObjectC>();

            autofacContainerBuilder.Register(c => new ComplexPropertyObject
            {
                ServiceA = c.Resolve<IServiceA>(),
                ServiceB = c.Resolve<IServiceB>(),
                ServiceC = c.Resolve<IServiceC>(),
                SubObjectA = c.Resolve<ISubObjectA>(),
                SubObjectB = c.Resolve<ISubObjectB>(),
                SubObjectC = c.Resolve<ISubObjectC>()
            }).As<IComplexPropertyObject>();
        }

        private static void RegisterOpenGeneric(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterGeneric(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
            autofacContainerBuilder.RegisterGeneric(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new SimpleAdapterOne()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterTwo()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterThree()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterFour()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterFive()).As<ISimpleAdapter>();

            autofacContainerBuilder.Register(c => new ImportMultiple(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple>();
        }

        private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Calculator())
                                          .As<ICalculator>()
                                          .EnableInterfaceInterceptors();
        }
    }

	public class AutofacChildContainerAdapter : IChildContainerAdapter
	{
		private ILifetimeScope lifetimeScope;

		public AutofacChildContainerAdapter(ILifetimeScope lifetimeScope)
		{
			this.lifetimeScope = lifetimeScope;
		}

		public void Dispose()
		{
			lifetimeScope.Dispose();
		}

		public void Prepare()
		{
			var autofacContainerBuilder = new ContainerBuilder();

			autofacContainerBuilder.Register(c => new ScopedTransient()).As<ITransient>();
			autofacContainerBuilder.Register(c => new ScopedCombined(c.Resolve<ITransient>(), c.Resolve<ISingleton>()))
				.As<ICombined>();

			autofacContainerBuilder.Update(lifetimeScope.ComponentRegistry);
		}

		public object Resolve(Type resolveType)
		{
			return lifetimeScope.Resolve(resolveType);
		}
	}
}