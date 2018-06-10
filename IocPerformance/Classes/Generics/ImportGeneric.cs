using IocPerformance.Classes.Generics;
using System;
using System.ComponentModel.Composition;

[module: Cauldron.Activator.GenericComponent(typeof(CauldronImportGeneric<int>), typeof(ImportGeneric<int>))]
[module: Cauldron.Activator.GenericComponent(typeof(CauldronImportGeneric<float>), typeof(ImportGeneric<float>))]
[module: Cauldron.Activator.GenericComponent(typeof(CauldronImportGeneric<object>), typeof(ImportGeneric<object>))]

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(ImportGeneric<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportGeneric<>))]
    public class ImportGeneric<T>
    {
        protected static int counter;

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

        protected ImportGeneric()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }


    #region Cauldron 
    /*
        Cauldron is a weaver, means cauldron changes the IL code of the assembly during build.
     */

    public class CauldronImportGeneric<T> : ImportGeneric<T>
    {
        [Cauldron.Activator.Inject]
        private IGenericInterface<T> importGenericInterface;

        public CauldronImportGeneric() : base()
        {
            if (importGenericInterface == null)
            {
                throw new ArgumentNullException(nameof(importGenericInterface));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    #endregion
}
