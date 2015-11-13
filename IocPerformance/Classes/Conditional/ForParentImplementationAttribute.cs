using System;
using System.Linq;
using DryIocAttributes;

namespace IocPerformance.Classes.Conditions
{
    public abstract class ForParentImplementationAttribute : ExportConditionAttribute
    {
        public override bool Evaluate(RequestInfo request)
        {
            return request.Enumerate().Any(r => r.ImplementationType == _parentImplementationType);
        }

        protected ForParentImplementationAttribute(Type parentImplementationType)
        {
            _parentImplementationType = parentImplementationType;
        }

        private readonly Type _parentImplementationType;
    }

    public class ForImportCondition1ParentAttribute : ForParentImplementationAttribute
    {
        public ForImportCondition1ParentAttribute() : base(typeof(ImportConditionObject1)) { }
    }

    public class ForImportCondition2ParentAttribute : ForParentImplementationAttribute
    {
        public ForImportCondition2ParentAttribute() : base(typeof(ImportConditionObject2)) { }
    }

    public class ForImportCondition3ParentAttribute : ForParentImplementationAttribute
    {
        public ForImportCondition3ParentAttribute() : base(typeof(ImportConditionObject3)) { }
    }
}