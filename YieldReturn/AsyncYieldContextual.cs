using System.Collections.Generic;

namespace YieldReturn
{
    /// <summary>
    /// *** note that yield could not be part of try/catch
    /// </summary>
    internal class AsyncYieldContextual
    {
        public static async IAsyncEnumerable<int> GetDoubledNumbersAsync(List<int> list)
        {
            foreach (var i in list)
            {
                Console.Write("*"); // Code to prove that this run only during its turn in the iteration (loop) after this method is called

                await Task.Delay(1000);

                yield return i * 2;
            }
        }

        //public static async Task<IEnumerable<int>> GetDoubledNumbersAsync(List<int> list)
        //{
        //    foreach (var i in list)
        //    {
        //        Console.Write("*"); // Code to prove that this run only during its turn in the iteration (loop) after this method is called

        //        await Task.Delay(1000);

        //        yield return i * 2;
        //    }
        //}
    }
}