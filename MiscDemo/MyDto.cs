using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscDemo
{
    public record MyRecord(int Id, string Title);

    public class MyDto
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
    }

    public class MyUtil
    {
        public static MyRecord GetDto()
        {
            var x = new MyRecord(1, "my title");

            var y = x with { Title = "new title" };

            return x;
        }
    }
}