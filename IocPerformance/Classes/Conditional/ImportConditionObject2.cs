using System;
using System.ComponentModel.Composition;
using ZenIoc;

namespace IocPerformance.Classes.Conditions
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]

    public class ImportConditionObject2
    {
        private static int counter;

        public ImportConditionObject2([ResolveNamed("ExportConditionalObject2")]  IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException(nameof(exportConditionInterface));
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject2))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject2 got: " + exportConditionInterface.GetType().FullName,
nameof(exportConditionInterface));
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
