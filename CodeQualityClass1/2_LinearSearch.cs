using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace CodeQualityClass1
{
    public class LinearSearch
    {
        HashSet<int> _userIds;
        IEnumerable<int> _userIds2;

        public LinearSearch()
        {
            _userIds2 = Enumerable.Range(0, 10000000);
            _userIds = Enumerable.Range(0, 10000000).ToHashSet();
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
        public void HashSetTest()
        {

            int userIdToFind = 9193513;

            var userExists = _userIds.Contains(userIdToFind);
        }
    }
}
