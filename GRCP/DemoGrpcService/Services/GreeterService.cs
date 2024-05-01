using DemoGrpcService;
using Grpc.Core;

namespace DemoGrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = $"Hello {request.FirstName} {request.LastName}" });
        }

        public override Task<AddReply> Add(AddRequest request, ServerCallContext context)
        {
            var result = new AddReply { Result = request.A + request.B };
            return Task.FromResult(result);
        }
    }
}