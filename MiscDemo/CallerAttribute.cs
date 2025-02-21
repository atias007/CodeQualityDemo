﻿using System.Runtime.CompilerServices;

namespace MiscDemo
{
    internal class CallerAttribute
    {
        public static void Run()
        {
            TraceMessage("Hello World!");

            var myFirstValue1 = "Some Text";
            Validate(myFirstValue1);

            var mySecondValue = "Some Text 2";
            Validate(mySecondValue);
        }

        public static void TraceMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("message: " + message);
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }

        public static void Validate(string message,
            [CallerArgumentExpression(nameof(message))] string argumentName = "")
        {
            Console.WriteLine("message: " + message);
            Console.WriteLine("argumentName: " + argumentName);
        }
    }
}