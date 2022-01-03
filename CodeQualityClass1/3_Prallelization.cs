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
                Thread.Sleep(3);
            }
        }

        [Benchmark]
        public void ParallelForeachTest()
        {
            var items = Enumerable.Range(0, 100).ToList();

            Parallel.ForEach(items, (item) =>
            {
                //Simulating long running operation
                Thread.Sleep(3);
            });
        }

        #region Result

        /*
         
            |              Method |       Mean |    Error |   StdDev |
            |-------------------- |-----------:|---------:|---------:|
            |         ForeachTest | 1,565.7 ms |  5.63 ms |  4.70 ms |
            | ParallelForeachTest |   106.2 ms | 14.40 ms | 42.45 ms |
         */

        #endregion
    }
}
