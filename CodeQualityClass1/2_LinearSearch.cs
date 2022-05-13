using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace CodeQualityClass1
{
    public class LinearSearch
    {
        private HashSet<int> _userIds;
        private IEnumerable<int> _userIds2;
        private Dictionary<int, int> _dict;

        public LinearSearch()
        {
            _userIds2 = Enumerable.Range(0, 10000000);
            _userIds = Enumerable.Range(0, 10000000).ToHashSet();
            _dict = Enumerable.Range(0, 10000000).ToDictionary(k => k);
        }

        [Benchmark]
        public void LinearSearchTestA()
        {
            int userIdToFind = 9193513;

            var userExists = _userIds2.Any(u => u == userIdToFind);
        }

        [Benchmark]
        public void LinearSearchTestC()
        {
            int userIdToFind = 9193513;

            var userExists = _userIds2.Contains(userIdToFind);
        }

        [Benchmark]
        public void LinearSearchDictionary()
        {
            int userIdToFind = 9193513;

            var userExists = _dict[userIdToFind];
        }

        [Benchmark]
        public void HashSetTest()
        {
            int userIdToFind = 9193513;

            var userExists = _userIds.Contains(userIdToFind);
        }

        #region Result

        /*

        |                 Method |              Mean |             Error |            StdDev |            Median |
        |----------------------- |------------------:|------------------:|------------------:|------------------:|
        |      LinearSearchTestA | 64,150,070.417 ns | 1,222,124.7194 ns | 3,198,087.3811 ns | 63,455,283.333 ns |
        |      LinearSearchTestC | 46,158,034.545 ns |   800,636.2818 ns | 1,068,826.4394 ns | 45,903,781.818 ns |
        | LinearSearchDictionary |          6.820 ns |         0.1655 ns |         0.4303 ns |          6.678 ns |
        |            HashSetTest |          5.837 ns |         0.1922 ns |         0.5261 ns |          5.692 ns |

         */

        #endregion Result
    }
}