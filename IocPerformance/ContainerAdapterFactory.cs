using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Adapters;

namespace IocPerformance
{
    internal static class ContainerAdapterFactory
    {
        public static IEnumerable<IContainerAdapter> CreateAdapters()
        {
            yield return new NoContainerAdapter();

            var containers = typeof(ContainerAdapterFactory).Assembly.GetTypes()
                 .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IContainerAdapter)))
                 .Where(t => !t.Equals(typeof(NoContainerAdapter)) && !t.Equals(typeof(SpeediocContainerAdapter)))
                 .Select(t => Activator.CreateInstance(t))
                 .Cast<IContainerAdapter>()
                 .OrderBy(c => c.Name);

            foreach (var container in containers)
            {
                yield return container;
            }
        }
    }
}
