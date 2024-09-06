using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Polling.Controllers
{
    // https://medium.com/@kova98
    // https://medium.com/@kova98/long-polling-in-net-08caa91000cd
    // https://gist.github.com/marekstachura/2941d7dbd80f82c92af9
    // https://medium.com/@kova98/server-sent-events-in-net-7f700b21cdb7
    // https://github.com/kova98/BackendCommunicationPatterns.NET/blob/master/PublishSubscribe/MessageBroker/MessageBroker.Producer/Program.cs

    [ApiController]
    [Route("[controller]")]
    public class PollingController : ControllerBase
    {
        [HttpPost("invoke")]
        public ActionResult<Guid> StartProcess([FromBody] StartProcessRequest request)
        {
            return Ok(LongProcessUtil.StartLongProcess(request.Seconds));
        }

        [HttpGet("polling")]
        public ActionResult<bool> Polling([FromQuery] Guid id)
        {
            return Ok(LongProcessUtil.IsLongProcessFinished(id));
        }

        [HttpGet("long-polling")]
        public async Task<IActionResult> LongPolling([FromQuery] Guid id, CancellationToken token)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(token);
            cts.CancelAfter(TimeSpan.FromSeconds(10));

            while (!cts.IsCancellationRequested)
            {
                if (LongProcessUtil.IsLongProcessFinished(id))
                {
                    return Ok();
                }

                await Task.Delay(100, token);
            }

            return NoContent();
        }

        [HttpGet("server-send-event")]
        public async Task ServerSendEvents(CancellationToken token)
        {
            HttpContext.Response.Headers.Append("Content-Type", "text/event-stream");

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(token);
            var count = -1;

            while (!cts.IsCancellationRequested)
            {
                var running = LongProcessUtil.Count;
                if (running != count)
                {
                    count = running;
                    await HttpContext.Response.WriteAsync("event: message\n", cancellationToken: token);
                    await HttpContext.Response.WriteAsync("data: ", cancellationToken: token);
                    var item = new SseData { Total = LongProcessUtil.Count, Message = $"there are {LongProcessUtil.Count} running items" };
                    await JsonSerializer.SerializeAsync(HttpContext.Response.Body, item, cancellationToken: token);
                    await HttpContext.Response.WriteAsync($"\nid: {DateTime.Now.Ticks}", cancellationToken: token);
                    await HttpContext.Response.WriteAsync($"\n\n", cancellationToken: token);
                    await HttpContext.Response.Body.FlushAsync(token);
                }
                await Task.Delay(100, token);
            }
        }

        [HttpPost("long-process")]
        public async Task LongProcess(CancellationToken token)
        {
            await Console.Out.WriteLineAsync("start");
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(30), token);
            }
            catch (TaskCanceledException)
            {
                await Console.Out.WriteLineAsync("Cancel");
                return;
            }

            await Console.Out.WriteLineAsync("end");
        }
    }
}