using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Multiple
{
    [Export(typeof(ISimpleAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ISimpleAdapter))]
    public class SimpleAdapterThree : ISimpleAdapter
    {
    }
}
