using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Griffin.Container;
using Griffin.Container.Interception;

namespace IocPerformance.Interception
{
    public class GriffinLoggingDecorator : CastleDecorator
    {
        public override void PreScan(IEnumerable<Type> concretes)
        {
        }

        protected override IInterceptor CreateInterceptor(DecoratorContext context)
        {
            return new GriffinInterceptionLogger();
        }
    }
}
