using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyFour
    {
    }

    [Export(typeof(IDummyFour)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyFour))]
    public class DummyFour : IDummyFour
    {
    }
}
