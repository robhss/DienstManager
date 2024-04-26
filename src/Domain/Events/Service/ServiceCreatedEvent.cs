using Domain.Common;

namespace Domain.Events.Service;

public class ServiceCreatedEvent : BaseEvent
{
    public Entities.Service Service;

    public ServiceCreatedEvent(Entities.Service service)
    {
        Service = service;
    }
}