using Application.Common.Interfaces;
using Domain.Events.Service;
using MediatR;

namespace Application.Commands.Service;

public record DeleteServiceCommand : IRequest
{
    public Guid ServiceId { get; init; }
}

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteServiceCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Services.FindAsync(new object?[] { request.ServiceId } , cancellationToken);

        if (entity != null)
        {
            entity.AddDomainEvent(new ServiceDeletedEvent(entity));
            _dbContext.Services.Remove(entity);
        }
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}