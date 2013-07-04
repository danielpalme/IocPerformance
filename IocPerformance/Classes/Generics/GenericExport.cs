using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(IGenericInterface<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class GenericExport<T> : IGenericInterface<T>
    {
        public T Value { get; set; }
    }
}
