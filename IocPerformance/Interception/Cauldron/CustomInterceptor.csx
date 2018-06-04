using System;
using System.Text;
using Cauldron.Interception.Cecilator;
using Cauldron.Interception.Fody;
using Cauldron.Interception.Fody.HelperTypes;
using System.Linq;
using Cauldron.Interception.Cecilator.Coders;
using System.Diagnostics;

/*
    This is only required during build 
*/

public static class CustomInterceptor
{
    [Display("Ioc Performance Method interceptor")]
    public static void Implement(Builder builder)
    {
        var attribute = builder.GetType("IocPerformance.Interception.Cauldron.CauldronLoggerAttribute");
        var writeLineMethod = attribute.GetMethod("WriteLine", 2, true).Import();
        var attributedMethods = builder.FindMethodsByAttribute(attribute);

        foreach (var attributedMethod in attributedMethods)
        {
            builder.Log(LogTypes.Info, $"Implementing interceptor for method {attributedMethod.Method.Name}");
            attributedMethod.Method.NewCoder()
                .Context(x => x.Call(writeLineMethod, attributedMethod.Method.Name, x.GetParametersArray()).End)
                .End
                .Insert(InsertionPosition.Beginning);

            // We dont need the attribute on the method anymore... So lets get rid of it.
            attributedMethod.Attribute.Remove();
        }
    }
}
