using BenchmarkDotNet.Attributes;
using System.Linq;
using System.Text;

namespace CodeQualityClass1
{
    public class TextBuilder
    {
        [Benchmark]
        public void StringTest()
        {
            var items = Enumerable.Range(0, 100000).ToList();
            string result = string.Empty;
            foreach (var item in items)
            {
                result += item.ToString() + "\r\n";
            }
        }

        [Benchmark]
        public void StringBuilderTest()
        {
            var items = Enumerable.Range(0, 100000).ToList();
            StringBuilder sb = new();
            foreach (var item in items)
            {
                sb.AppendLine(item.ToString());
            }

            var result = sb.ToString();
        }
        
        #region result
        /*

            |            Method |          Mean |         Error |        StdDev |        Median |
            |------------------ |--------------:|--------------:|--------------:|--------------:|
            |        StringTest | 22,662.479 ms | 2,201.3497 ms | 6,490.7293 ms | 20,680.556 ms |
            | StringBuilderTest |      8.459 ms |     0.2172 ms |     0.6372 ms |      8.324 ms |

        */
        #endregion
    }
}
