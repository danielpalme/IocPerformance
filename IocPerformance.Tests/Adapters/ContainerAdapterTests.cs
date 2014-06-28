using System;
using System.Collections.Generic;

using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

using TestStack.BDDfy;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

using Xunit;
using Xunit.Extensions;

namespace IocPerformance.Tests.Adapters
{
    public class ContainerAdapterTests
    {
        public static IEnumerable<object[]> ContainerAdapters
        {
            get
            {
                yield return new object[] { new AutofacContainerAdapter() };
                yield return new object[] { new CaliburnMicroContainer() };
                yield return new object[] { new CatelContainerAdapter() };
            }
        }

        public class SingletonTests : ContainerAdapterTests, IDisposable
        {
            private object _retSingleton1;

            private object _retSingleton2;

            private IContainerAdapter _sut;

            public void Dispose()
            {
                _sut.Dispose();
            }

            [Theory]
            [PropertyData("ContainerAdapters")]
            public void ResolvesTwoInstancesOfSingleton1(IContainerAdapter containerAdapter)
            {
                this.Given(x => x.ContainerAdapterIs(containerAdapter))
                    .When(x => x.ResolvesTwoInstancesOf(typeof(ISingleton1)))
                    .Then(x => x.ResolvedInstancesAreSame())
                    .BDDfy();
            }

            [Theory]
            [PropertyData("ContainerAdapters")]
            public void ResolvesTwoInstancesOfSingleton2(IContainerAdapter containerAdapter)
            {
                this.Given(x => x.ContainerAdapterIs(containerAdapter))
                    .When(x => x.ResolvesTwoInstancesOf(typeof(ISingleton2)))
                    .Then(x => x.ResolvedInstancesAreSame())
                    .BDDfy();
            }

            private void ContainerAdapterIs(IContainerAdapter containerAdapter)
            {
                _sut = containerAdapter;
                _sut.Prepare();
            }

            private void ResolvedInstancesAreSame()
            {
                Assert.Equal(_retSingleton1, _retSingleton2);
            }

            private void ResolvesTwoInstancesOf(Type typeToResolve)
            {
                _retSingleton1 = _sut.Resolve(typeToResolve);
                _retSingleton2 = _sut.Resolve(typeToResolve);
            }
        }
    }
}