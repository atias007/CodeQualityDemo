using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace CodeQualityClass1
{
    public class PointClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct PointStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    public class StructClass
    {
        [Benchmark]
        public void ListOfObjectsTest()
        {
            const int length = 1000000;

            var items = new List<PointClass>(length);

            for (int i = 0; i < length; i++)
            {
                items.Add(new PointClass() { X = i, Y = i });
            }
        }

        [Benchmark]
        public void ListOfStructsTest()
        {
            const int length = 1000000;

            var items = new List<PointStruct>(length);

            for (int i = 0; i < length; i++)
            {
                items.Add(new PointStruct() { X = i, Y = i });
            }
        }


        #region Result
        
        //          |            Method |      Mean |     Error |    StdDev |
        //          |------------------ |----------:|----------:|----------:|
        //          | ListOfObjectsTest | 64.683 ms | 1.2765 ms | 1.9873 ms |
        //          | ListOfStructsTest |  3.961 ms | 0.0787 ms | 0.1945 ms | 
        
        #endregion
    }
}
