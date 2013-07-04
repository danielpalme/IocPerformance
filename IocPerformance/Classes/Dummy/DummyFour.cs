using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyFour
    {
    }

    [Export(typeof(IDummyFour)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyFour : IDummyFour
    {
    }
}
