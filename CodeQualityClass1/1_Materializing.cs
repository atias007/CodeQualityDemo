using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQualityClass1
{
    public class Materializing
    {
        [Benchmark]
        public void NotMaterializedQueryTest()
        {
            var elements = Enumerable.Range(0, 50000000);

            var filteredElements = elements.Where(element => element % 100000 == 0);

            foreach (var element in filteredElements)
            {
                //some logic
            }

            foreach (var element in filteredElements)
            {
                //another logic
            }

            foreach (var element in filteredElements)
            {
                //another logic
            }
        }

        [Benchmark]
        public void MaterializedQueryTest()
        {
            var elements = Enumerable.Range(0, 50000000);           

            var filteredElements = elements.Where(element => element % 100000 == 0).ToList();

            foreach (var element in filteredElements)
            {
                //some logic
            }

            foreach (var element in filteredElements)
            {
                //another logic
            }

            foreach (var element in filteredElements)
            {
                //another logic
            }
        }
    }
}
