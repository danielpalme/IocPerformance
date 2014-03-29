using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.Child
{
    public class ScopedTransient : ITransient1
    {
        public void DoSomething()
        {
            Console.WriteLine("ScopedTransient");
        }
    }
}
