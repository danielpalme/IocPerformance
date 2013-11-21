namespace IocPerformance.Classes.Generics
{
    [IfInjector.ImplementedBy(typeof(GenericExport<>))]
    public interface IGenericInterface<T>
    {
        T Value { get; set; }
    }
}
