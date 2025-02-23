using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Travel.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest>(ILogger<TRequest> logger) : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger = logger;

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            await Task.Run(() => LogRequest(request), cancellationToken);
        }

        public void LogRequest(TRequest request)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Travel Request: {Name} {@Request}", requestName, request);
        }
    }
}