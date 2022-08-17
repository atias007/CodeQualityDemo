using System.Collections.Generic;

namespace YieldReturn
{
    /// <summary>
    /// *** note that yield could not be part of try/catch
    /// </summary>
    internal class YieldContextual
    {
        public static IEnumerable<int> GetDoubledNumbers(List<int> list)
        {
            foreach (var i in list)
            {
                Console.Write("*"); // Code to prove that this run only during its turn in the iteration (loop) after this method is called

                yield return i * 2;
            }
        }

        public static IEnumerable<int> GetDoubledNumbersIfMoreThanThreshhold(List<int> list, int threshhold)
        {
            foreach (var i in list)
            {
                if (i >= threshhold)
                {
                    Console.Write("*Break*");
                    break;
                }

                yield return i * 2;
            }

            Console.Write(" *End Method*");
        }
    }
}