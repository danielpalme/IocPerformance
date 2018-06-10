using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Multiple
{
    [Cauldron.Activator.Component(typeof(ISimpleAdapter))]
    [Export(typeof(ISimpleAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ISimpleAdapter))]
    public class SimpleAdapterTwo : ISimpleAdapter
    {
    }
}
