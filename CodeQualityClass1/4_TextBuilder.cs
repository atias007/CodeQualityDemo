using BenchmarkDotNet.Attributes;
using System.Linq;
using System.Text;

namespace CodeQualityClass1
{
    [MemoryDiagnoser]
    public class TextBuilder
    {
        [Benchmark]
        public void StringConcatTest()
        {
            var items = Enumerable.Range(0, 10000).ToList();
            string result = string.Empty;
            foreach (var item in items)
            {
                result += item.ToString() + "\r\n";
            }
        }

        [Benchmark]
        public void StringFormatTest()
        {
            var items = Enumerable.Range(0, 10000).ToList();
            string result = string.Empty;
            foreach (var item in items)
            {
                result = $"{result}\r\n{item}";
            }
        }

        [Benchmark]
        public void StringBuilderTest()
        {
            var items = Enumerable.Range(0, 10000).ToList();
            StringBuilder sb = new();
            foreach (var item in items)
            {
                sb.AppendLine(item.ToString());
            }

            var result = sb.ToString();
        }

        #region result

        /*

            |            Method |        Mean |       Error |       StdDev |      Median |       Gen 0 |      Gen 1 |      Gen 2 |  Allocated |
            |------------------ |------------:|------------:|-------------:|------------:|------------:|-----------:|-----------:|-----------:|
            |  StringConcatTest | 57,725.1 us | 3,669.54 us | 10,819.71 us | 52,589.7 us | 181600.0000 | 87600.0000 | 86700.0000 | 565,906 KB |
            |  StringFormatTest | 76,301.6 us | 3,895.77 us | 11,177.71 us | 72,964.6 us | 181625.0000 | 87125.0000 | 86750.0000 | 566,144 KB |
            | StringBuilderTest |    443.7 us |    12.38 us |     34.91 us |    432.9 us |    148.4375 |    73.2422 |    36.6211 |     593 KB |

        */

        #endregion result
    }
}