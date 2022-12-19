using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodeQualityClass1
{
    public class CompileLinqExpressions
    {
        private struct Person
        {
            public string Title { get; set; }
            public int Age { get; set; }
        }

        private static readonly List<Person> _people = new List<Person>();

        static CompileLinqExpressions()
        {
            for (int i = 0; i < 1000000; i++)
            {
                var person = new Person { Age = i, Title = $"Person Number {i}" };
                _people.Add(person);
            }
        }

        [Benchmark]
        public void WithoutCompile()
        {
            _people.Where(person => person.Age == 23 && person.Title.StartsWith("23_")).Single();
        }

        private static readonly Expression<Func<Person, bool>>
            _ageExpression = e => e.Age == 23 &&
            e.Title.StartsWith("23_");

        private static readonly Func<Person, bool> _ageExpressionCompiled = _ageExpression.Compile();

        [Benchmark(Baseline = true)]
        public void WithCompile()
        {
            _people.Where(_ageExpressionCompiled).Single();
        }
    }
}