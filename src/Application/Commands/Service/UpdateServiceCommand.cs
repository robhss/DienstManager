using Application.Common.Interfaces;
using Domain.Events.Service;
using MediatR;

namespace Application.Commands.Service;

public record UpdateServiceCommand : IRequest
{
    public Guid ServiceId { get; init; }
    public DateTime? Date { get; init; }
    public string? Topic { get; init; }
}

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateServiceCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Services.FindAsync(new object?[] { request.ServiceId }, cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.AddDomainEvent(new ServiceUpdatedEvent(entity));
            if (request.Date != null) entity.Date = request.Date;
            if (request.Topic != null) entity.Topic = request.Topic;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}