using System;

namespace AsyncAwait
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var demo = new Demo1();

            // demo.Start1();
            // demo.Start2();
            // demo.Start3();
            // demo.Start4();
            // demo.Start5();

            var bf = new BreakfastAsync();
            //bf.Start().Wait();
            bf.StartConcurrently().Wait();

            Console.WriteLine("------------> UI Thread - Wait for input:");
            Console.ReadLine();
        }
    }
}