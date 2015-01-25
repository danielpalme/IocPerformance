using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyNine
    {
    }

    [Export(typeof(IDummyNine)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyNine))]
    public class DummyNine : IDummyNine
    {
    }
}
