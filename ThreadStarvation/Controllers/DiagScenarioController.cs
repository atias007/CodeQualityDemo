using Microsoft.AspNetCore.Mvc;

namespace ThreadStarvation.Controllers;

[ApiController]
[Route("[controller]")]
public class DiagScenarioController(ILogger<DiagScenarioController> logger) : ControllerBase
{
    [HttpGet("taskwait")]
    public async Task<IActionResult> TaskWait()
    {
        logger.LogInformation("TaskWait called {TimeStamp:HHmmssfff}", DateTimeOffset.UtcNow);
        await Task.Delay(500);
        return Ok("TaskWait:Success");
    }

    [HttpGet("tasksleepwait")]
    public IActionResult TaskSleepWait()
    {
        logger.LogInformation("TaskWait called");
        Thread.Sleep(500);
        return Ok("TaskSleepWait:Success");
    }
}