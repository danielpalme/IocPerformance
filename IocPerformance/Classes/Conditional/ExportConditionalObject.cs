using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Conditions
{
    [ForImportCondition1Parent, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExportConditionalObject : IExportConditionInterface
    {
    }
}
