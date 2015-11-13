using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Conditions
{
    [ForImportCondition3Parent, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExportConditionalObject3 : IExportConditionInterface
    {
    }
}
