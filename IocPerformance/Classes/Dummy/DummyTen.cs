using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyTen
    {
    }

    [Export(typeof(IDummyTen)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyTen))]
    public class DummyTen : IDummyTen
    {
    }
}
