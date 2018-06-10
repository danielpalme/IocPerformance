using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyOne
    {
    }

    [Cauldron.Activator.Component(typeof(IDummyOne))]
    [Export(typeof(IDummyOne)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyOne))]
    public class DummyOne : IDummyOne
    {
    }
}
