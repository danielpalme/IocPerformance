﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes.Dummy
{
	public interface IDummyFour
	{
		
	}


	[Export(typeof(IDummyFour)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class DummyFour : IDummyFour
	{
	}
}
