using System;

namespace IocPerformance.Classes.Conditions
{
    public class ImportConditionObject
    {
        public ImportConditionObject(IExportConditionInterface exportConditionInterface)
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

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
