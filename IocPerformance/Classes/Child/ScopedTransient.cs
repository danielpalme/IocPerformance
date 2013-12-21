using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.Child
{
	public class ScopedTransient : ITransient
	{
		public void DoSomething()
		{
			Console.WriteLine("ScopedTransient");
		}
	}
}
