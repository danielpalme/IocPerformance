using System;
using System.Diagnostics;
using System.Linq;

namespace IocPerformance.Interception.Cauldron
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CauldronLoggerAttribute : Attribute
    {
        public static void WriteLine(string methodName, object[] parameters)
        {
            var args = string.Join(", ", parameters.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine(string.Format("Cauldron: {0}({1})", methodName, args));
        }
    }
}