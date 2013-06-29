using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocPerformance.Interception;

namespace IocPerformance.Classes.Standard
{
	public interface ICalculator
	{
		int Add(int first, int second);
	}

	[UnityInterceptionLogger]
	public class Calculator : ICalculator
	{
		public static int Instances { get; set; }

		public Calculator()
		{
			Instances++;
		}

		public virtual int Add(int first, int second)
		{
			return first + second;
		}
	}
}
