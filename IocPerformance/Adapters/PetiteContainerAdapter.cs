using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using Petite;

namespace IocPerformance.Adapters
{
    public sealed class PetiteContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string Name
        {
            get { return "Petite"; }
        }

        public override string PackageName
        {
            get { return "Petite.Container"; }
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
            this.container = new Petite.Container();

            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.Register<IDummyOne>(c => new DummyOne());
            this.container.Register<IDummyTwo>(c => new DummyTwo());
            this.container.Register<IDummyThree>(c => new DummyThree());
            this.container.Register<IDummyFour>(c => new DummyFour());
            this.container.Register<IDummyFive>(c => new DummyFive());
            this.container.Register<IDummySix>(c => new DummySix());
            this.container.Register<IDummySeven>(c => new DummySeven());
            this.container.Register<IDummyEight>(c => new DummyEight());
            this.container.Register<IDummyNine>(c => new DummyNine());
            this.container.Register<IDummyTen>(c => new DummyTen());
        }

        private void RegisterStandard()
        {
            this.container.RegisterSingleton<ISingleton>(c => new Singleton());
            this.container.Register<ITransient>(c => new Transient());
            this.container.Register<ICombined>(c => new Combined(
                c.Resolve<ISingleton>(),
                c.Resolve<ITransient>()));
        }

        private void RegisterComplex()
        {
            this.container.RegisterSingleton<IFirstService>(c => new FirstService());
            this.container.RegisterSingleton<ISecondService>(c => new SecondService());
            this.container.RegisterSingleton<IThirdService>(c => new ThirdService());
            this.container.Register<ISubObjectOne>(c => new SubObjectOne(c.Resolve<IFirstService>()));
            this.container.Register<ISubObjectTwo>(c => new SubObjectTwo(c.Resolve<ISecondService>()));
            this.container.Register<ISubObjectThree>(c => new SubObjectThree(c.Resolve<IThirdService>()));
            this.container.Register<IComplex>(c => new Complex(
                c.Resolve<IFirstService>(),
                c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(),
                c.Resolve<ISubObjectOne>(),
                c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>()));
        }
    }
}