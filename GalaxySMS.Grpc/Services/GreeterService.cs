using System.Reflection;
using GalaxySMS.Grpc;
using Grpc.Core;

namespace GalaxySMS.Grpc.Services
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
            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name}, from {Assembly.GetExecutingAssembly().GetName()}"
            });
        }
    }
}