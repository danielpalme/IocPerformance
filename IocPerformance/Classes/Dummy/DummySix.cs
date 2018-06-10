using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummySix
    {
    }

    [Cauldron.Activator.Component(typeof(IDummySix))]
    [Export(typeof(IDummySix)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummySix))]
    public class DummySix : IDummySix
    {
    }
}
