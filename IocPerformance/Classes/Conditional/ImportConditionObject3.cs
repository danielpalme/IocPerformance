using System;

namespace IocPerformance.Classes.Conditions
{
    public class ImportConditionObject3
    {
        private static int counter;

        public ImportConditionObject3(IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException("exportConditionInterface");
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject3))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject3 got: " + exportConditionInterface.GetType().FullName,
                    "exportConditionInterface");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }
}
