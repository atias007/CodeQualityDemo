using System;

namespace YieldReturn
{
    internal class Conventional
    {
        public static List<int> GetDoubledNumbers(List<int> list)
        {
            var result = new List<int>();
            foreach (var i in list)
            {
                Console.Write("*");
                result.Add(i * 2);
            }
            return result;
        }

        public static List<int> GetDoubledNumbersIfMoreThanThreshhold(List<int> list, int threshhold)
        {
            var result = new List<int>();
            foreach (var i in list)
            {
                if (i >= threshhold)
                {
                    break;
                }

                Console.Write("*");
                result.Add(i * 2);
            }

            Console.WriteLine(" *End Method*");

            return result;
        }
    }
}