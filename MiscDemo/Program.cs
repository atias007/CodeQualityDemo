using MiscDemo;
using System.Reflection.Emit;

var demo1 = new ProducerConsumer();
await demo1.Run();
Console.WriteLine("--- DONE ---");

return;

CallerAttribute.Run();
Console.WriteLine("--- DONE ---");

//LocalFunctions(10, 12, 43, 24, 55);
//RawString1();
//RawString2();
//RawString3();
return;

static void RawString1()
{
    string desc = "my name is john doe.\n"
                  + "I am a software engineer.\n"
                  + "I love c#";
    Console.WriteLine(desc);
}

static void RawString2()
{
    string desc = $"""
                    my name is john "doe." {Math.Pow(2, 2)}
                      I am a software engineer.

                    I love c#
                  """;
    Console.WriteLine(desc);
}

static void RawString3()
{
    string desc = """
                  {
                    "Title": "My Name",
                    "Description": "my name is john doe.",
                    "Items": [
                      "item1",
                      "item2"
                    ]
                  }
                  """;
    Console.WriteLine(desc);
}

static void LocalFunctions(params int[] nums)
{
    var i = 4;
    int Mean() { return nums.Sum() / nums.Count() + i; }
    double Average() { return nums.Average(); }

    Console.WriteLine($"The mean is-{Mean()} and the average is-{Average()}");
}

static void ListPatterns()
{
    int[] nums = { 1, 2, 3 };

    Console.WriteLine(nums is [1, 2, 3]); // returns true
    Console.WriteLine(nums is [1, ..]); //.. gets the rest elements and returns true
    Console.WriteLine(nums is [0 or 1, .., 3]); // the first element is 0 or 1 and ".." returns the rest

    //--------------------- //

    var maths_score = 10;
    var english_score = 20;
    var level = (maths_score, english_score) switch
    {
        ( >= 50, >= 50) => "Level1",
        ( < 50, < 50) => "Level2",
        _ => "Level3"
    };
    Console.WriteLine(level);

    //--------------------- //

    object o = "Hello, world!";
    if (o is string s)
    {
        Console.WriteLine(s.ToUpper());  // Output: HELLO, WORLD!
    }

    //--------------------- //

    switch (o)
    {
        case int i:
            Console.WriteLine($"Integer: {i}");
            break;

        case string ss:
            Console.WriteLine($"String: {ss}");
            break;

        default:
            Console.WriteLine("Unknown type");
            break;
    }

    //--------------------- //

    object p = new Point(3, 4);
    if (p is Point(var x, var y))
    {
        Console.WriteLine($"Point at ({x}, {y})");
    }

    //--------------------- //

    var e = new Employee { Department = "Sales", Salary = 40000 };
    if (e is { Department: "Sales", Salary: var sal })
    {
        Console.WriteLine($"Salesperson's Salary: {sal}");
    }

    (int dx, int dy) vector = new(1, 4);
    var result = vector switch
    {
        (1, 0) => "East",
        (0, 1) => "North",
        (-1, 0) => "West",
        (0, -1) => "South",
        _ => "Unknown"
    };

    Console.WriteLine(result);
}