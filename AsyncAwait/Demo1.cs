using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Demo1
    {
        public void Start1()
        {
            DoSomething1();
            DoSomething2();
            DoSomething3();
        }

        public void Start2()
        {
            Parallel.Invoke(DoSomething1, DoSomething2, DoSomething3);
        }

        public void Start3()
        {
            Task.Run(DoSomething1)
                .ContinueWith(t => DoSomething2())
                .ContinueWith(t => DoSomething3());
        }

        public void Start4()
        {
            Task.Run(DoSomething1)
                .ContinueWith(t => DoSomethingWrong())
                .ContinueWith(t => DoSomething2())
                .ContinueWith(t => DoSomething3());
        }

        internal void DoSomething1()
        {
            Console.WriteLine("[x] Start DoSomething1...");
            Thread.Sleep(2000);
            Console.WriteLine("    End DoSomething1");
        }

        internal void DoSomething2()
        {
            Console.WriteLine("[x] Start DoSomething2...");
            Thread.Sleep(3000);
            Console.WriteLine("    End DoSomething2");
        }

        internal void DoSomething3()
        {
            Console.WriteLine("[x] Start DoSomething3...");
            Thread.Sleep(4000);
            Console.WriteLine("    End DoSomething3");
        }

        internal void DoSomethingWrong()
        {
            throw new NotImplementedException();
        }
    }
}