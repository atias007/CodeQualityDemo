namespace TaskClass3;

internal class Mission2 : BaseMission
{
    public Mission2() : base(ConsoleColor.Blue)
    {
    }

    public async Task Start()
    {
        Write("Start Mission 2");
        await Task.Delay(5000);
        Write("Step 1 Completed");
        await Task.Delay(5000);
        Write("Step 2 Completed");
        await Task.Delay(7000);
        Write("Step 3 Completed");
        await Task.Delay(6000);
        Write("Step 4 Completed");
        Write("Mission 2 Completed");
    }
}