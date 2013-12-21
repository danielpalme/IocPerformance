using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Adapters
{
	public interface IChildContainerAdapter : IDisposable
	{
		void Prepare();

		object Resolve(Type resolveType);
	}
}
