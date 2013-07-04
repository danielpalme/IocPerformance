using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyEight
    {
    }

    [Export(typeof(IDummyEight)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyEight : IDummyEight
    {
    }
}
