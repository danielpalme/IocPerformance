using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace IocPerformance.Classes.Multiple
{
    [Export(typeof(ImportMultiple)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ImportMultiple
    {
        [ImportingConstructor]
        public ImportMultiple([ImportMany]IEnumerable<ISimpleAdapter> adapters)
        {
            if (adapters == null)
            {
                throw new ArgumentNullException("adapters");
            }

            int adapterCount = adapters.Count();

            if (adapterCount != 5)
            {
                throw new ArgumentException("there should be 5 adapters and there where: " + adapterCount, "adapters");
            }

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
