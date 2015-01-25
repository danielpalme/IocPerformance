using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyThree
    {
    }

    [Export(typeof(IDummyThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyThree))]
    public class DummyThree : IDummyThree
    {
    }
}
