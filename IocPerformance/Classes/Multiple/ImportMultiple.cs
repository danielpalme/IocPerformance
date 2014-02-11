using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Multiple
{
    [Export(typeof(ImportMultiple)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportMultiple))]
    public class ImportMultiple
    {
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportMultiple(
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

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
