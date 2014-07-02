using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Multiple
{
    [Export(typeof(ImportMultiple1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple1))]
    public class ImportMultiple1
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple1(
            [ImportMany]
            [System.Composition.ImportMany]
            IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException("adapters");
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
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, "adapters");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }

    [Export(typeof(ImportMultiple2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple2))]
    public class ImportMultiple2
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple2(
            [ImportMany]
            [System.Composition.ImportMany]
            IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException("adapters");
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
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, "adapters");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }


    [Export(typeof(ImportMultiple3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple3))]
    public class ImportMultiple3
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple3(
            [ImportMany]
            [System.Composition.ImportMany]
            IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException("adapters");
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
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, "adapters");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }
}
