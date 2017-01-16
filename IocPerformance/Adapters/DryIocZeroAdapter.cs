using System;
using DryIocZero;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public sealed class DryIocZeroAdapter : ContainerAdapterBase
    {
        public static readonly Type[] Roots =
        {
            typeof(IComplex1),
            typeof(IComplex2),
            typeof(IComplex3),
            typeof(IDummyOne),
            typeof(ImportMultiple1),
            typeof(ImportMultiple2),
            typeof(ImportMultiple3),
            typeof(IComplexPropertyObject1),
            typeof(IComplexPropertyObject2),
            typeof(IComplexPropertyObject3),
            typeof(ICombined1),
            typeof(ICombined2),
            typeof(ICombined3),
            typeof(ISingleton1),
            typeof(ISingleton2),
            typeof(ISingleton3),
            typeof(ITransient1),
            typeof(ITransient2),
            typeof(ITransient3),
            typeof(ImportConditionObject1),
            typeof(ImportConditionObject2),
            typeof(ImportConditionObject3)
        };

        private Container container;

        public override string PackageName => "DryIocZero";

        public override string Url => "https://bitbucket.org/dadhi/dryioc";

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => false;

        public override bool SupportsMultiple => true;

        public override bool SupportsInterception => false;

        public override bool SupportsPropertyInjection => true;

        public override object Resolve(Type type)
        {
            return container.Resolve(type, false);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (container != null)
            {
                container.Dispose();
            }
        }

        public override void Prepare()
        {
            PrepareBasic();
        }

        public override void PrepareBasic()
        {
            container = new Container();
        }
    }
}