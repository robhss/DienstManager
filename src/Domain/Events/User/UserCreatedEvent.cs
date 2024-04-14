using System.Runtime.CompilerServices;
using MediatR;

namespace Domain.Events.User;

public class UserCreatedEvent : INotification
{
    public Entities.User User;
    
    public UserCreatedEvent(Entities.User user)
    {
        User = user;
    }
}