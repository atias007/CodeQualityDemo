using BenchmarkDotNet.Running;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeQualityClass1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var summary = BenchmarkRunner.Run<Materializing>();
            //var summary = BenchmarkRunner.Run<LinearSearch>();
            //var summary = BenchmarkRunner.Run<Parallelization>();

            //TaskDemo();
        }

        static void TaskDemo()
        {
            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine("Hi i'm task1");
                    Thread.Sleep(100);
                }
            });

            var t2 = Task.Run(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine("Hi i'm task2");
                    Thread.Sleep(100);
                }
            });

            Task.WaitAll(t1, t2);
        }
    }
}
