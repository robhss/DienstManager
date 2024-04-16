using System.Runtime.CompilerServices;
using Domain.Common;
using MediatR;

namespace Domain.Events.User;

public class UserCreatedEvent : BaseEvent
{
    public Entities.User User;
    
    public UserCreatedEvent(Entities.User user)
    {
        User = user;
    }
}