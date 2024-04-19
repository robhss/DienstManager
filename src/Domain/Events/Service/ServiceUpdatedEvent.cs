using Domain.Common;

namespace Domain.Events.Service;

public class ServiceUpdatedEvent : BaseEvent
{
    public Entities.Service Service;

    public ServiceUpdatedEvent(Entities.Service service)
    {
        Service = service;
    }
}