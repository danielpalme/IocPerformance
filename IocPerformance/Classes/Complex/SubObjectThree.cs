using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectThree
    {
    }

    [Export(typeof(ISubObjectThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubObjectThree : ISubObjectThree
    {
        [ImportingConstructor]
        public SubObjectThree(IThirdService thirdService)
        {
            if (thirdService == null)
            {
                throw new ArgumentNullException("thirdService");
            }
        }
    }
}
