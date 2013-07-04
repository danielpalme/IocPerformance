using System;
using Dynamo.Ioc;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : ContainerAdapterBase
    {
        private IocContainer container;

        public override string PackageName
        {
            get { return "Dynamo.Ioc"; }
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }

        public override void Prepare()
        {
            this.container = new IocContainer(defaultCompileMode: CompileMode.Dynamic);

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();

            this.container.Compile();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne, DummyOne>();
            this.container.Register<IDummyTwo, DummyTwo>();
            this.container.Register<IDummyThree, DummyThree>();
            this.container.Register<IDummyFour, DummyFour>();
            this.container.Register<IDummyFive, DummyFive>();
            this.container.Register<IDummySix, DummySix>();
            this.container.Register<IDummySeven, DummySeven>();
            this.container.Register<IDummyEight, DummyEight>();
            this.container.Register<IDummyNine, DummyNine>();
            this.container.Register<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.Register<ISingleton, Singleton>().WithContainerLifetime();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
        }

        private void RegisterComplex()
        {
            this.container.Register<IFirstService, FirstService>().WithContainerLifetime();
            this.container.Register<ISecondService, SecondService>().WithContainerLifetime();
            this.container.Register<IThirdService, ThirdService>().WithContainerLifetime();
            this.container.Register<ISubObjectOne, SubObjectOne>();
            this.container.Register<ISubObjectTwo, SubObjectTwo>();
            this.container.Register<ISubObjectThree, SubObjectThree>();
            this.container.Register<IComplex, Complex>();
        }
    }
}