// See https://aka.ms/new-console-template for more information

// See https://medium.com/geekculture/understanding-the-power-of-yield-return-c3886668375d for more details of yield return

using YieldReturn;

var numbers = new List<int>
{
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};

#region Step1

// var conventionalList = Conventional.GetDoubledNumbers(numbers);
// var yieldList = YieldContextual.GetDoubledNumbers(numbers);
// PrintNumbers("Print conventional list:", conventionalList);
// PrintNumbers("Print yield list:", yieldList);

#endregion Step1

#region Step2

// var conventionalList = Conventional.GetDoubledNumbersIfMoreThanThreshhold(numbers, 5);
// var yieldList = YieldContextual.GetDoubledNumbersIfMoreThanThreshhold(numbers, 5);
// PrintNumbers("Print conventional list:", conventionalList);
// PrintNumbers("Print yield list:", yieldList);

#endregion Step2

#region Step3

var conventionalList = Conventional.GetDoubledNumbers(numbers);
var yieldList = AsyncYieldContextual.GetDoubledNumbersAsync(numbers);
PrintNumbers("Print conventional list:", conventionalList);
await PrintNumbersAsync("Print yield list:", yieldList);

#endregion Step3

Console.ReadLine();

void PrintNumbers(string title, IEnumerable<int> list)
{
    Console.WriteLine();
    Console.Write(title);
    foreach (var i in list)
    {
        Console.Write($"{i}, ");
    }
}

async Task PrintNumbersAsync(string title, IAsyncEnumerable<int> list)
{
    Console.WriteLine();
    Console.Write(title);

    await foreach (var i in list)
    {
        Console.Write(i + ", ");
    }
}