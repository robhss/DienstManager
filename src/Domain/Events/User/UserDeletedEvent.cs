using Domain.Common;
using MediatR;

namespace Domain.Events.User;

public class UserDeletedEvent : BaseEvent
{
    public Entities.User User;
    
    public UserDeletedEvent(Entities.User user)
    {
        User = user;
    }
}