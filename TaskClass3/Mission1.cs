namespace TaskClass3;

internal class Mission1 : BaseMission
{
    public Mission1() : base(ConsoleColor.Green)
    {
    }

    public async Task Start(AutoResetEvent are)
    {
        Write("Start Mission 1");
        await Task.Delay(1000);
        Write("Step 1 Completed");
        await Task.Delay(1000);
        Write("Step 2 Completed");
        await Task.Delay(2000);
        Write("----- Wait to Mission2: Step 3 -----");

        are.WaitOne();
        Write("Step 3 Completed");
        await Task.Delay(2000);
        Write("Step 4 Completed");
        await Task.Delay(2000);
        Write("Step 5 Completed");
        Write("Mission 1 Completed");
    }
}