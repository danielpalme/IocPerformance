using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(IGenericInterface<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IGenericInterface<>))]
    public class GenericExport<T> : IGenericInterface<T>
    {
        public T Value { get; set; }
    }
}
