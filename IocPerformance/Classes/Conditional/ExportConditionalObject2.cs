using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Conditions
{
    [ForImportCondition2Parent, PartCreationPolicy(CreationPolicy.NonShared)]

    public class ExportConditionalObject2 : IExportConditionInterface
    {
    }
}
