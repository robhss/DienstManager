using Domain.Common;

namespace Domain.Events.User;

public class UserUpdatedEvent : BaseEvent
{
    public Entities.User User;
    
    public UserUpdatedEvent(Entities.User user)
    {
        User = user;
    }
}