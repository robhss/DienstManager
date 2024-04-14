using MediatR;

namespace Domain.Events.User;

public class UserDeletedEvent : INotification
{
    public Entities.User User;
    
    public UserDeletedEvent(Entities.User user)
    {
        User = user;
    }
}