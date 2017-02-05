using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Conditions
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExportConditionalObject : IExportConditionInterface
    {
    }
}
