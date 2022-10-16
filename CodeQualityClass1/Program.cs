using BenchmarkDotNet.Running;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeQualityClass1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //new Materializing().NotMaterializedQueryTest();

            //BenchmarkRunner.Run<Materializing>();
            //BenchmarkRunner.Run<LinearSearch>();
            // BenchmarkRunner.Run<Parallelization>();
            //BenchmarkRunner.Run<TextBuilder>();
            // BenchmarkRunner.Run<StructClass>();
            // BenchmarkRunner.Run<Capacity>();
            BenchmarkRunner.Run<SealedClass>();
            //TaskDemo();
        }

        private static void TaskDemo()
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