using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Multiple
{
    [Export(typeof(ImportMultiple1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple1))]
    public class ImportMultiple1
    {
        protected static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple1(
            [ImportMany]
            [System.Composition.ImportMany]
            IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            int adapterCount = 0;
            foreach (var adapter in adapters)
            {
                if (adapter == null)
                {
                    throw new ArgumentException("adapters item should be not null");
                }

                ++adapterCount;
            }

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, nameof(adapters));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ImportMultiple1()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(ImportMultiple2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple2))]
    public class ImportMultiple2
    {
        protected static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple2(
            [ImportMany]
            [System.Composition.ImportMany]
            IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            int adapterCount = 0;
            foreach (var adapter in adapters)
            {
                if (adapter == null)
                {
                    throw new ArgumentException("adapters item should be not null");
                }

                ++adapterCount;
            }

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, nameof(adapters));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ImportMultiple2()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(ImportMultiple3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple3))]
    public class ImportMultiple3
    {
        protected static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple3(
            [ImportMany]
            [System.Composition.ImportMany]
            IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            int adapterCount = 0;
            foreach (var adapter in adapters)
            {
                if (adapter == null)
                {
                    throw new ArgumentException("adapters item should be not null");
                }

                ++adapterCount;
            }

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, nameof(adapters));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ImportMultiple3()
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

    [Cauldron.Activator.Component(typeof(ImportMultiple1))]
    public class CauldronImportMultiple1 : ImportMultiple1
    {
        [Cauldron.Activator.Inject]
        private IEnumerable<ISimpleAdapter> adapters;

        public CauldronImportMultiple1()
        {
            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            int adapterCount = 0;
            foreach (var adapter in adapters)
            {
                if (adapter == null)
                {
                    throw new ArgumentException("adapters item should be not null");
                }

                ++adapterCount;
            }

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, nameof(adapters));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    [Cauldron.Activator.Component(typeof(ImportMultiple2))]
    public class CauldronImportMultiple2 : ImportMultiple2
    {
        [Cauldron.Activator.Inject]
        private IEnumerable<ISimpleAdapter> adapters;

        public CauldronImportMultiple2()
        {
            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            int adapterCount = 0;
            foreach (var adapter in adapters)
            {
                if (adapter == null)
                {
                    throw new ArgumentException("adapters item should be not null");
                }

                ++adapterCount;
            }

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, nameof(adapters));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    [Cauldron.Activator.Component(typeof(ImportMultiple3))]
    public class CauldronImportMultiple3 : ImportMultiple3
    {
        [Cauldron.Activator.Inject]
        private IEnumerable<ISimpleAdapter> adapters;

        public CauldronImportMultiple3()
        {
            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            int adapterCount = 0;
            foreach (var adapter in adapters)
            {
                if (adapter == null)
                {
                    throw new ArgumentException("adapters item should be not null");
                }

                ++adapterCount;
            }

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, nameof(adapters));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    #endregion
}
