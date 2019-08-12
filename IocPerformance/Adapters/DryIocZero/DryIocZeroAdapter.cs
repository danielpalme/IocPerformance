using System;
using DryIocZero;

namespace IocPerformance.Adapters
{
    public sealed class DryIocZeroAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName => "DryIocZero";

        public override string Url => "https://bitbucket.org/dadhi/dryioc";

        public override bool SupportsConditional => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override object Resolve(Type type) => container.Resolve(type, false);

        public override void Dispose() => container?.Dispose();

        public override void Prepare() => PrepareBasic();

        public override void PrepareBasic()
        {
            container = new Container();
        }
    }
}