using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyThree
    {
    }

    [Cauldron.Activator.Component(typeof(IDummyThree))]
    [Export(typeof(IDummyThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyThree))]
    public class DummyThree : IDummyThree
    {
    }
}
