using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyFive
    {
    }

    [Export(typeof(IDummyFive)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyFive : IDummyFive
    {
    }
}
