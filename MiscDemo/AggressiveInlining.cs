using System.Runtime.CompilerServices;

namespace MiscDemo
{
    internal class AggressiveInlining
    {
        public static void Check()
        {
            var myVar = "true";

            if (IsTrue(myVar))
            {
                Console.WriteLine("It's true!");
            }
            else
            {
                Console.WriteLine("It's false!");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTrue(string value)
        {
            if (bool.TryParse(value, out bool boolValue))
            {
                return boolValue;
            }

            return false;
        }
    }
}