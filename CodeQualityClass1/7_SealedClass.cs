using BenchmarkDotNet.Attributes;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQualityClass1
{
    public class Person
    {
        public virtual void Eat()
        {
        }
    }

    public class Programmer : Person
    {
        public override void Eat()
        {
        }
    }

    public sealed class ProgrammerSealed : Person
    {
        public override void Eat()
        {
        }
    }

    [MemoryDiagnoser]
    public class SealedClass
    {
        private readonly Programmer _programmer = new();
        private readonly ProgrammerSealed _programmerSealed = new();

        [Benchmark]
        public void MethodCall()
        {
            _programmer.Eat();
        }

        [Benchmark]
        public void MethodCallSealed()
        {
            _programmerSealed.Eat();
        }
    }
}

////| Method            | Mean | Error | StdDev      | Median     | Allocated  |
////| ----------------- | ----------  :| ---------- :| ----------:| ----------:| ----------:|
////| MethodCall        | 0.4654 ns    | 0.0222 ns   | 0.0208 ns  | 0.4640 ns  | - |
////| MethodCallSealed  | 0.1675 ns    | 0.0278 ns   | 0.0783 ns  | 0.1458 ns  | - |