using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Multiple
{
    [Export(typeof(ISimpleAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SimpleAdapterFour : ISimpleAdapter
    {
    }
}
