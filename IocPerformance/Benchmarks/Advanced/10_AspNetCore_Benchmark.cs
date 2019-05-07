using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.AspNet;
using Microsoft.Extensions.DependencyInjection;

namespace IocPerformance.Benchmarks.Advanced
{
    public class AspNetCore_10_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        /// <summary>If false returned no methods are invoked.</summary>
        /// <param name="container">The container.</param>
        /// <returns><c>true</c> if supported otherwise <c>false</c></returns>
        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportAspNetCore;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var factory = (IServiceScopeFactory)container.Resolve(typeof(IServiceScopeFactory));

            using (var scope = factory.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService(typeof(TestController1));
            }

            factory = (IServiceScopeFactory)container.Resolve(typeof(IServiceScopeFactory));

            using (var scope = factory.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService(typeof(TestController2));
            }

            factory = (IServiceScopeFactory)container.Resolve(typeof(IServiceScopeFactory));

            using (var scope = factory.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService(typeof(TestController3));
            }
        }

        /// <summary>
        /// Ensures that container behaved validly. Called once after looping <see cref="M:IocPerformance.Benchmarks.IBenchmark.MethodToBenchmark(IocPerformance.Adapters.IContainerAdapter)" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <exception cref="T:System.Exception">Any exception indicates verification failure</exception>
        public override void Verify(IContainerAdapter container)
        {
            if (!container.SupportAspNetCore)
            {
                return;
            }

            if (TestController1.Instances != this.LoopCount ||
                TestController1.DisposeCount != this.LoopCount)
            {
                throw new Exception(string.Format("TestController1 count must be {0}", this.LoopCount));
            }

            if (TestController2.Instances != this.LoopCount ||
                TestController2.DisposeCount != this.LoopCount)
            {
                throw new Exception(string.Format("TestController2 count must be {0}", this.LoopCount));
            }

            if (TestController3.Instances != this.LoopCount ||
                TestController3.DisposeCount != this.LoopCount)
            {
                throw new Exception(string.Format("TestController3 count must be {0}", this.LoopCount));
            }

            if (RepositoryTransient1.Instances != this.LoopCount * 3 ||
                RepositoryTransient2.Instances != this.LoopCount * 3 ||
                RepositoryTransient3.Instances != this.LoopCount * 3 ||
                RepositoryTransient4.Instances != this.LoopCount * 3 ||
                RepositoryTransient5.Instances != this.LoopCount * 3)
            {
                throw new Exception(string.Format("RepositoryTransient count must be {0}", this.LoopCount));
            }

            if (ScopedService1.Instances != this.LoopCount * 3 ||
                ScopedService2.Instances != this.LoopCount * 3 ||
                ScopedService3.Instances != this.LoopCount * 3 ||
                ScopedService4.Instances != this.LoopCount * 3 ||
                ScopedService5.Instances != this.LoopCount * 3)
            {
                throw new Exception(string.Format("ScopedService count must be {0}", this.LoopCount));
            }
        }
    }
}
