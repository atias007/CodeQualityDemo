using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace CodeQualityClass1
{
    public class LinearSearch
    {
        HashSet<int> _userIds;
        IEnumerable<int> _userIds2;
        Dictionary<int, int> _dict;

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

        |            Method |              Mean |             Error |            StdDev |            Median |
        |------------------ |------------------:|------------------:|------------------:|------------------:|
        | LinearSearchTestA | 82,569,229.155 ns | 2,892,761.6939 ns |  8,438,321.640 ns | 79,967,785.714 ns |
        | LinearSearchTestC | 71,095,910.431 ns | 3,738,270.7031 ns | 10,904,711.106 ns | 67,941,494.444 ns |
        |       HashSetTest |          8.216 ns |         0.5803 ns |          1.702 ns |          7.865 ns |

        */

        #endregion
    }
}
