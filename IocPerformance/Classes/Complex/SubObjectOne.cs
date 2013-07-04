using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectOne
    {
    }

    [Export(typeof(ISubObjectOne)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubObjectOne : ISubObjectOne
    {
        [ImportingConstructor]
        public SubObjectOne(IFirstService firstService)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException("firstService");
            }
        }
    }
}
