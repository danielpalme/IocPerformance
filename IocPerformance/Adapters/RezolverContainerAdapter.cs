using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Rezolver;
using Rezolver.Targets;

namespace IocPerformance.Adapters
{
    public sealed class RezolverContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName => "Rezolver";

        public override string Url => "http://rezolver.co.uk";

        public override bool SupportGeneric => true;

        public override bool SupportsBasic => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportAspNetCore => true;

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            var targets = new TargetContainer();
            RegisterBasic(targets);
            RegisterPropertyInjection(targets);
            RegisterOpenGeneric(targets);
            RegisterMultiple(targets);
            targets.Populate(CreateServiceCollection());

            this.container = new Container(targets);
        }

        public override void PrepareBasic()
        {
            var targets = new TargetContainer();
            RegisterBasic(targets);
            this.container = new Container(targets);
        }

        private static void RegisterBasic(ITargetContainer targets)
        {
            RegisterDummies(targets);
            RegisterStandard(targets);
            RegisterComplexObject(targets);
        }

        private static void RegisterDummies(ITargetContainer targets)
        {
            targets.RegisterType<DummyOne, IDummyOne>();
            targets.RegisterType<DummyTwo, IDummyTwo>();
            targets.RegisterType<DummyThree, IDummyThree>();
            targets.RegisterType<DummyFour, IDummyFour>();
            targets.RegisterType<DummyFive, IDummyFive>();
            targets.RegisterType<DummySix, IDummySix>();
            targets.RegisterType<DummySeven, IDummySeven>();
            targets.RegisterType<DummyEight, IDummyEight>();
            targets.RegisterType<DummyNine, IDummyNine>();
            targets.RegisterType<DummyTen, IDummyTen>();
        }

        private static void RegisterStandard(ITargetContainer targets)
        {
            // two options for singletons in Rezolver - a singleton target wrapping
            // another, and a straight constant object.  I think for the purposes of the
            // test we should be wrapping a constructor target.
            targets.RegisterSingleton<Singleton1, ISingleton1>();
            targets.RegisterSingleton<Singleton2, ISingleton2>();
            targets.RegisterSingleton<Singleton3, ISingleton3>();
            targets.RegisterType<Transient1, ITransient1>();
            targets.RegisterType<Transient2, ITransient2>();
            targets.RegisterType<Transient3, ITransient3>();
            targets.RegisterType<Combined1, ICombined1>();
            targets.RegisterType<Combined2, ICombined2>();
            targets.RegisterType<Combined3, ICombined3>();
        }

        private static void RegisterComplexObject(ITargetContainer targets)
        {
            targets.RegisterSingleton<FirstService, IFirstService>();
            targets.RegisterSingleton<SecondService, ISecondService>();
            targets.RegisterSingleton<ThirdService, IThirdService>();
            targets.RegisterType<SubObjectOne, ISubObjectOne>();
            targets.RegisterType<SubObjectTwo, ISubObjectTwo>();
            targets.RegisterType<SubObjectThree, ISubObjectThree>();
            targets.RegisterType<Complex1, IComplex1>();
            targets.RegisterType<Complex2, IComplex2>();
            targets.RegisterType<Complex3, IComplex3>();
        }

        private static void RegisterPropertyInjection(ITargetContainer targets)
        {
            // this method is temporary till I add auto property injection - thinking I might do it as
            // an extension target that can be added to any other target (except another target)
            targets.RegisterSingleton<ServiceA, IServiceA>();
            targets.RegisterSingleton<ServiceB, IServiceB>();
            targets.RegisterSingleton<ServiceC, IServiceC>();

            targets.RegisterType<SubObjectA, ISubObjectA>(DefaultMemberBindingBehaviour.Instance);
            targets.RegisterType<SubObjectB, ISubObjectB>(DefaultMemberBindingBehaviour.Instance);
            targets.RegisterType<SubObjectC, ISubObjectC>(DefaultMemberBindingBehaviour.Instance);

            targets.RegisterType<ComplexPropertyObject1, IComplexPropertyObject1>(DefaultMemberBindingBehaviour.Instance);
            targets.RegisterType<ComplexPropertyObject2, IComplexPropertyObject2>(DefaultMemberBindingBehaviour.Instance);
            targets.RegisterType<ComplexPropertyObject3, IComplexPropertyObject3>(DefaultMemberBindingBehaviour.Instance);
        }

        private static void RegisterOpenGeneric(ITargetContainer targets)
        {
            targets.RegisterType(typeof(GenericExport<>), typeof(IGenericInterface<>));
            targets.RegisterType(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ITargetContainer targets)
        {
            targets.RegisterMultiple(
                new[]
                {
                    Target.ForType<SimpleAdapterOne>(),
                    Target.ForType<SimpleAdapterTwo>(),
                    Target.ForType<SimpleAdapterThree>(),
                    Target.ForType<SimpleAdapterFour>(),
                    Target.ForType<SimpleAdapterFive>()
                },
            typeof(ISimpleAdapter));
            targets.RegisterType<ImportMultiple1>();
            targets.RegisterType<ImportMultiple2>();
            targets.RegisterType<ImportMultiple3>();
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new RezolverChildContainerAdapter(this.container);
        }

        public class RezolverChildContainerAdapter : IChildContainerAdapter
        {
            private readonly IContainer parent;
            private IContainer child;
            private IContainerScope childScope;

            public RezolverChildContainerAdapter(IContainer parent)
            {
                this.parent = parent;
            }

            public void Dispose()
            {
                this.childScope.Dispose();
            }

            public void Prepare()
            {
                var targets = new TargetContainer();

                targets.RegisterType<ScopedTransient, ITransient1>();
                targets.RegisterType<ScopedCombined1, ICombined1>();
                targets.RegisterType<ScopedCombined2, ICombined2>();
                targets.RegisterType<ScopedCombined3, ICombined3>();
                this.child = new OverridingContainer(this.parent, targets);
                this.childScope = this.child.CreateScope();
            }

            public object Resolve(Type resolveType)
            {
                return this.childScope.Resolve(resolveType);
            }
        }
    }
}