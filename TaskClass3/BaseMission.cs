namespace TaskClass3;

internal abstract class BaseMission
{
    private readonly ConsoleColor _color;
    private static readonly object _locker = new object();

    protected BaseMission(ConsoleColor color)
    {
        _color = color;
    }

    protected void Write(string message)
    {
        lock (_locker)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}