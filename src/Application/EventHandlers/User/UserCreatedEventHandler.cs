using Domain.Events.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.EventHandlers.User;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain Event: {notification.GetType().Name}");
        
        return Task.CompletedTask;
    }
}