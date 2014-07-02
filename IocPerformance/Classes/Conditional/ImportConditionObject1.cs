using System;

namespace IocPerformance.Classes.Conditions
{
    public class ImportConditionObject1
    {
        private static int counter;

        public ImportConditionObject1(IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException("exportConditionInterface");
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject got: " + exportConditionInterface.GetType().FullName, 
                    "exportConditionInterface");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }
}
