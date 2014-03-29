using System;

namespace IocPerformance.Classes.Conditions
{
    public class ImportConditionObject3
    {
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

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
