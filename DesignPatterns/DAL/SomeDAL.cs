using DesignPatterns.Model;
using System;

namespace DesignPatterns.DAL
{
    public class SomeDAL
    {
        public static Person GetPerson()
        {
            return new Person
            {
                BirthDate = new DateTime(1979, 3, 7),
                FirstName = "Tsahi",
                LastName = "Atias",
                Id = 123
            };
        }
    }
}