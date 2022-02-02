using System;

namespace DesignPatterns.Model
{
    public class Person
    {
        public IEntityCalculate<Person> EntityCalculate { get; set; } = new DefaultEntityCalculate<Person>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Id { get; set; }

        public int Age
        {
            get
            {
                return (int)EntityCalculate.Calculate(this, nameof(Age));
            }
        }
    }
}