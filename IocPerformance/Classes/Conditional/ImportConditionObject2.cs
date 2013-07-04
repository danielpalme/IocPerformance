using System;

namespace IocPerformance.Classes.Conditions
{
    public class ImportConditionObject2
    {
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

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
