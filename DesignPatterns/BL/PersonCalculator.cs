using DesignPatterns.Model;
using System;

namespace DesignPatterns.BL
{
    public class PersonCalculator : IEntityCalculate<Person>
    {
        public object Calculate(Person entity, string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Person.Age):
                    var today = DateTime.Today;
                    var age = today.Year - entity.BirthDate.Year;
                    if (entity.BirthDate.Date > today.AddYears(-age)) age--;
                    return age;

                default:
                    return default;
            }
        }
    }
}