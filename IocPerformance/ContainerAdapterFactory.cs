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
                 .Where(t => t != typeof(NoContainerAdapter)
                     && t != typeof(SpeediocContainerAdapter) // Causes exceptions at runtime
                     && t != typeof(StilettoContainerAdapter) // Uses Fody which makes build process unstable
                     && t != typeof(HiroContainerAdapter)) // Causes exceptions at runtime
                 //.Where(t => t == typeof(SimpleInjectorContainerAdapter)
                 //   || t == typeof(LightInjectContainerAdapter)
                 //   || t == typeof(WindsorContainerAdapter)
                 //   )
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
