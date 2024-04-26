using Application.Common.Interfaces;
using Domain.Events.User;
using MediatR;

namespace Application.Commands.User;

public record DeleteUserCommand : IRequest
{
    public Guid UserId { get; init; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.FindAsync(new object?[] { request.UserId } , cancellationToken);

        if (entity != null)
        {
            entity.AddDomainEvent(new UserDeletedEvent(entity));
            _dbContext.Users.Remove(entity);
        }
        
        await _dbContext.SaveChangesAsync(cancellationToken);

    }
}