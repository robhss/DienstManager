using Application.Common.Interfaces;
using Domain.Events.Service;
using MediatR;

namespace Application.Commands.Service;

public record CreateServiceCommand : IRequest
{
    public DateTime Date { get; init; }
    public String Topic { get; init; }
}

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateServiceCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Service
        {
            //Id = default,
            //CreatedOn = default,
            //LastModified = default,
            Date = request.Date,
            Topic = request.Topic,
            //Participants = null
        };
        
        entity.AddDomainEvent(new ServiceCreatedEvent(entity));
        
        _dbContext.Services.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}