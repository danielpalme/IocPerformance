using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Conditions
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ImportConditionObject1
    {
        private static int counter;

        public ImportConditionObject1(IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException(nameof(exportConditionInterface));
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject got: " + exportConditionInterface.GetType().FullName,
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
