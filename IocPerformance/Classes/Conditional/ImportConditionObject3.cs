using System;
using System.ComponentModel.Composition;
using SmartDi;

namespace IocPerformance.Classes.Conditions
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]

    public class ImportConditionObject3
    {
        private static int counter;

        public ImportConditionObject3([ResolveNamed("ExportConditionalObject3")]  IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException(nameof(exportConditionInterface));
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject3))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject3 got: " + exportConditionInterface.GetType().FullName,
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
