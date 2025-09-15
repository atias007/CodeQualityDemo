using EasyValidation;
using System.Linq;

var user = new User
{
    Name = string.Empty, // "John Doe",
    Email = "john@example.com",
    Age = 25
};

var result = user.Validate();

if (result.IsValid())
{
    Console.WriteLine("User is valid!");
}
else
{
    Console.WriteLine("User is invalid");
    foreach (var item in result.Results)
    {
        Console.WriteLine($" - {item.PropertyName}");
        foreach (var p in item.Results)
        {
            Console.WriteLine(p.ChainName);
            Console.WriteLine($"   - {string.Join(", ", p.Errors.Select(e => e.FormattedMessage))}");
        }
    }
}