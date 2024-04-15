using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;

public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger logger)
    {
        _logger = logger;
    }
    
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Request: {typeof(TRequest).Name} {request}");
        
        return Task.CompletedTask;
    }
}