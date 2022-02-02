using DesignPatterns.DAL;
using System;

namespace DesignPatterns.BL
{
    internal class SomeBL
    {
        public static void DoSomething()
        {
            var person = SomeDAL.GetPerson();
            //person.EntityCalculate = new PersonCalculator();
            Console.WriteLine($"Person Age: {person.Age}");
        }
    }
}