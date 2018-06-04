using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyEight
    {
    }

    [Cauldron.Activator.Component(typeof(IDummyEight))]
    [Export(typeof(IDummyEight)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyEight))]
    public class DummyEight : IDummyEight
    {
    }
}
