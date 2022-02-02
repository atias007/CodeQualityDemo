using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Demo2
    {
        public async Task Start1()
        {
            // Do some sync code lines

            await DoSomething1();
            await DoSomething2();
            await DoSomething3();

            // Do some sync code lines
        }

        public async Task Start2()
        {
            // Do some sync code lines

            var t1 = DoSomething1();
            var t2 = DoSomething2();
            var t3 = DoSomething3();

            await t1;
            await t2;
            await t3;

            // Do some sync code lines
        }

        public void Start3()
        {
            // Do some sync code lines

            DoSomething1().Wait();
            DoSomething2().Wait();
            DoSomething3().Wait();

            // Do some sync code lines
        }

        internal async Task DoSomething1()
        {
            Console.WriteLine("[x] Start DoSomething1...");
            await Task.Delay(2000);
            Console.WriteLine("    End DoSomething1");
        }

        internal async Task DoSomething2()
        {
            Console.WriteLine("[x] Start DoSomething2...");
            await Task.Delay(3000);
            Console.WriteLine("    End DoSomething2");
        }

        internal async Task DoSomething3()
        {
            Console.WriteLine("[x] Start DoSomething3...");
            await Task.Delay(4000);
            Console.WriteLine("    End DoSomething3");
        }
    }
}