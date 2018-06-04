using Cauldron.Activator;
using System;

namespace IocPerformance.Adapters
{
    public sealed class CauldronContainerAdapter : ContainerAdapterBase
    {
        public override string Name => "Cauldron.Activator";
        public override string PackageName => "Capgemini.Cauldron.Activator";
        public override bool SupportGeneric => true;
        public override bool SupportsBasic => true;
        public override bool SupportsCombined => true;
        public override bool SupportsInterception => true;
        public override bool SupportsMultiple => true;
        public override bool SupportsPropertyInjection => true;
        public override bool SupportsTransient => true            ;
        public override string Url => "https://github.com/Capgemini/Cauldron";

        public override void Dispose() => Factory.Destroy();

        public override void PrepareBasic()
        {
        }

        public override object Resolve(Type type) => Factory.Create(type);
    }
}