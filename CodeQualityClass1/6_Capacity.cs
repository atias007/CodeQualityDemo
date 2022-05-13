using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace CodeQualityClass1
{
    public class Capacity
    {
        [Benchmark]
        public void NonFixedCapacityTest()
        {
            var items = new List<decimal>();
            for (int i = 0; i < 1000000; i++)
            {
                items.Add(i);
            }
        }

        [Benchmark]
        public void FixedCapacityTest()
        {
            const int capacity = 1000000;
            var items = new List<decimal>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                items.Add(i);
            }
        }

        #region Result

        /*
            |               Method |      Mean |     Error |    StdDev |    Median |
            |--------------------- |----------:|----------:|----------:|----------:|
            | NonFixedCapacityTest | 15.106 ms | 0.2806 ms | 0.5731 ms | 14.875 ms |
            |    FixedCapacityTest |  7.376 ms | 0.1471 ms | 0.3349 ms |  7.413 ms |
         */

        #endregion Result
    }
}