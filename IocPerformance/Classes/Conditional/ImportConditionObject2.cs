using System;

namespace IocPerformance.Classes.Conditions
{
    public class ImportConditionObject2
    {
        private static int counter;

        public ImportConditionObject2(IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException("exportConditionInterface");
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject2))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject2 got: " + exportConditionInterface.GetType().FullName, 
                    "exportConditionInterface");
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
