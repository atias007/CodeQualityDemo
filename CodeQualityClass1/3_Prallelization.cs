using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeQualityClass1
{
    public class Parallelization
    {
        [Benchmark]
        public void ForeachTest()
        {
            var items = Enumerable.Range(0, 100).ToList();

            foreach (var item in items)
            {
                //Simulating long running operation
                Thread.Sleep(1);
            }
        }

        [Benchmark]
        public void ParallelForeachTest()
        {
            var items = Enumerable.Range(0, 100).ToList();

            Parallel.ForEach(items, (item) =>
            {
                //Simulating long running operation
                Thread.Sleep(1);
            });
        }
    }
}
