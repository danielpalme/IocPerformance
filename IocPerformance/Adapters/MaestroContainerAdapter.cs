using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using Maestro;
using Maestro.Configuration;
using System;
using Maestro.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace IocPerformance.Adapters
{
   public class MaestroContainerAdapter : ContainerAdapterBase
   {
      private IContainer _container;

      public override string PackageName => "Maestro";

      public override string Url => "https://github.com/JonasSamuelsson/Maestro";

      public override bool SupportAspNetCore => true;

      public override bool SupportsInterception => true;

      public override bool SupportsPropertyInjection => true;

      public override bool SupportGeneric => true;

      public override bool SupportsMultiple => true;

      public override void Prepare()
      {
         _container = new Container(builder =>
         {
            RegisterBasic(builder);
            RegisterPropertyInjection(builder);
            RegisterGeneric(builder);
            RegisterMultiple(builder);
            RegisterInterceptor(builder);

            var services = new ServiceCollection();
            RegisterAspNetCoreClasses(services);
            builder.Populate(services);
         });
      }

      public override void PrepareBasic()
      {
         _container = new Container(RegisterBasic);
      }

      public override void Dispose()
      {
         // Allow the container and everything it references to be garbage collected.
         if (_container == null)
         {
            return;
         }

         _container.Dispose();
         _container = null;
      }

      public override object Resolve(Type type) => _container.GetService(type);

      private static void RegisterBasic(IContainerBuilder builder)
      {
         RegisterDummies(builder);
         RegisterStandard(builder);
         RegisterComplex(builder);
      }

      private static void RegisterDummies(IContainerBuilder builder)
      {
         builder.Add<IDummyOne>().Type<DummyOne>();
         builder.Add<IDummyTwo>().Type<DummyTwo>();
         builder.Add<IDummyThree>().Type<DummyThree>();
         builder.Add<IDummyFour>().Type<DummyFour>();
         builder.Add<IDummyFive>().Type<DummyFive>();
         builder.Add<IDummySix>().Type<DummySix>();
         builder.Add<IDummySeven>().Type<DummySeven>();
         builder.Add<IDummyEight>().Type<DummyEight>();
         builder.Add<IDummyNine>().Type<DummyNine>();
         builder.Add<IDummyTen>().Type<DummyTen>();
      }

      private static void RegisterStandard(IContainerBuilder builder)
      {
         builder.Add<ISingleton1>().Type<Singleton1>().Singleton();
         builder.Add<ISingleton2>().Type<Singleton2>().Singleton();
         builder.Add<ISingleton3>().Type<Singleton3>().Singleton();
         builder.Add<ITransient1>().Type<Transient1>();
         builder.Add<ITransient2>().Type<Transient2>();
         builder.Add<ITransient3>().Type<Transient3>();
         builder.Add<ICombined1>().Type<Combined1>();
         builder.Add<ICombined2>().Type<Combined2>();
         builder.Add<ICombined3>().Type<Combined3>();
      }

      private static void RegisterComplex(IContainerBuilder builder)
      {
         builder.Add<IFirstService>().Type<FirstService>().Singleton();
         builder.Add<ISecondService>().Type<SecondService>().Singleton();
         builder.Add<IThirdService>().Type<ThirdService>().Singleton();
         builder.Add<ISubObjectOne>().Type<SubObjectOne>();
         builder.Add<ISubObjectTwo>().Type<SubObjectTwo>();
         builder.Add<ISubObjectThree>().Type<SubObjectThree>();
         builder.Add<IComplex1>().Type<Complex1>();
         builder.Add<IComplex2>().Type<Complex2>();
         builder.Add<IComplex3>().Type<Complex3>();
      }

      private static void RegisterPropertyInjection(IContainerBuilder builder)
      {
         builder.Add<IServiceA>().Type<ServiceA>().Singleton();
         builder.Add<IServiceB>().Type<ServiceB>().Singleton();
         builder.Add<IServiceC>().Type<ServiceC>().Singleton();

         builder.Add<ISubObjectA>().Type<SubObjectA>().SetProperty(x => x.ServiceA);
         builder.Add<ISubObjectB>().Type<SubObjectB>().SetProperty(x => x.ServiceB);
         builder.Add<ISubObjectC>().Type<SubObjectC>().SetProperty(x => x.ServiceC);

         builder.Add<IComplexPropertyObject1>().Type<ComplexPropertyObject1>()
             .SetProperty(x => x.ServiceA)
             .SetProperty(x => x.ServiceB)
             .SetProperty(x => x.ServiceC)
             .SetProperty(x => x.SubObjectA)
             .SetProperty(x => x.SubObjectB)
             .SetProperty(x => x.SubObjectC);

         builder.Add<IComplexPropertyObject2>().Type<ComplexPropertyObject2>()
             .SetProperty(x => x.ServiceA)
             .SetProperty(x => x.ServiceB)
             .SetProperty(x => x.ServiceC)
             .SetProperty(x => x.SubObjectA)
             .SetProperty(x => x.SubObjectB)
             .SetProperty(x => x.SubObjectC);

         builder.Add<IComplexPropertyObject3>().Type<ComplexPropertyObject3>()
             .SetProperty(x => x.ServiceA)
             .SetProperty(x => x.ServiceB)
             .SetProperty(x => x.ServiceC)
             .SetProperty(x => x.SubObjectA)
             .SetProperty(x => x.SubObjectB)
             .SetProperty(x => x.SubObjectC);
      }

      private static void RegisterGeneric(IContainerBuilder builder)
      {
         builder.Add(typeof(IGenericInterface<>)).Type(typeof(GenericExport<>));
         builder.Add(typeof(ImportGeneric<>)).Self();
      }

      private static void RegisterMultiple(IContainerBuilder builder)
      {
         builder.Add<ISimpleAdapter>().Type<SimpleAdapterOne>();
         builder.Add<ISimpleAdapter>().Type<SimpleAdapterTwo>();
         builder.Add<ISimpleAdapter>().Type<SimpleAdapterThree>();
         builder.Add<ISimpleAdapter>().Type<SimpleAdapterFour>();
         builder.Add<ISimpleAdapter>().Type<SimpleAdapterFive>();
         builder.Add<ImportMultiple1>().Self();
         builder.Add<ImportMultiple2>().Self();
         builder.Add<ImportMultiple3>().Self();
      }

      private static void RegisterInterceptor(IContainerBuilder builder)
      {
         builder.Add<ICalculator1>().Type<Calculator1>()
             .Proxy((x, pg) => pg.CreateInterfaceProxyWithTarget<ICalculator1>(x, new MaestroInterceptionLogger()));
         builder.Add<ICalculator2>().Type<Calculator2>()
             .Proxy((x, pg) => pg.CreateInterfaceProxyWithTarget<ICalculator2>(x, new MaestroInterceptionLogger()));
         builder.Add<ICalculator3>().Type<Calculator3>()
             .Proxy((x, pg) => pg.CreateInterfaceProxyWithTarget<ICalculator3>(x, new MaestroInterceptionLogger()));
      }
   }
}