using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(ImportGeneric<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportGeneric<>))]
    public class ImportGeneric<T>
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportGeneric(IGenericInterface<T> importGenericInterface)
        {
            if (importGenericInterface == null)
            {
                throw new ArgumentNullException(nameof(importGenericInterface));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
