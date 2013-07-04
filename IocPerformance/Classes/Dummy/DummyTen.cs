using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyTen
    {
    }

    [Export(typeof(IDummyTen)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyTen : IDummyTen
    {
    }
}
