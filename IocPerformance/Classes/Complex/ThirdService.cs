using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Complex
{
	public interface IThirdService
	{
		
	}

	[Export(typeof(IThirdService)),PartCreationPolicy(CreationPolicy.Shared)]
	public class ThirdService : IThirdService
	{
	}
}
