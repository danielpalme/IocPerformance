using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(ImportGeneric<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportGeneric<>))]
    public class ImportGeneric<T>
    {
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportGeneric(IGenericInterface<T> importGenericInterface)
        {
            if (importGenericInterface == null)
            {
                throw new ArgumentNullException("importGenericInterface");
            }

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
