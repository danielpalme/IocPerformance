using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyFive
    {
    }

    [Cauldron.Activator.Component(typeof(IDummyFive))]
    [Export(typeof(IDummyFive)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyFive))]
    public class DummyFive : IDummyFive
    {
    }
}
