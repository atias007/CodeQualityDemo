using BenchmarkDotNet.Attributes;
using System.Linq;

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

        #region Result

        /*

        |                   Method |       Mean |    Error |   StdDev |     Median |
        |------------------------- |-----------:|---------:|---------:|-----------:|
        | NotMaterializedQueryTest | 1,147.2 ms | 27.19 ms | 74.44 ms | 1,122.5 ms |
        |    MaterializedQueryTest |   359.8 ms |  7.79 ms | 22.85 ms |   354.2 ms |

         */

        #endregion Result
    }
}