using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyNine
    {
    }

    [Export(typeof(IDummyNine)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyNine : IDummyNine
    {
    }
}
