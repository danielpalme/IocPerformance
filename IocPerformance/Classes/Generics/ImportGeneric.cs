using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(ImportGeneric<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ImportGeneric<T>
    {
        [ImportingConstructor]
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
