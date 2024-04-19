using Domain.Common;

namespace Domain.Events.Service;

public class ServiceDeletedEvent : BaseEvent
{
    public Entities.Service Service;

    public ServiceDeletedEvent(Entities.Service service)
    {
        Service = service;
    }
}