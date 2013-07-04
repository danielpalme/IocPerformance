using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyThree
    {
    }

    [Export(typeof(IDummyThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyThree : IDummyThree
    {
    }
}
