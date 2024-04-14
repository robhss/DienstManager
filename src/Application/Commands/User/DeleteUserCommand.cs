using Domain.Common.Interfaces;
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
        var user = await _dbContext.Users.FindAsync(new object?[] { request.UserId } , cancellationToken);

        if (user != null)
        {
            _dbContext.Users.Remove(user);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

    }
}