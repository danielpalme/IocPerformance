using System;
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
