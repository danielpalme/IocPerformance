using System;

namespace IocPerformance.Adapters
{
	public interface IContainerAdapter : IDisposable
	{
		void Prepare();

		object Resolve(Type type);

		object ResolveProxy(Type type);

		string Version { get; }

		string PackageName { get; }

		bool SupportsConditional { get; }

		bool SupportGeneric { get; }

		bool SupportsMultiple { get; }

		bool SupportsInterception { get; }
	}
}